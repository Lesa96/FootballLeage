using Client.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    public class ShowIgracViewModel : BindableBase
    {       
        public static ObservableCollection<Igrac_Selektovan> igraci { get; set; }
        private Igrac_Selektovan selektovani_igrac;
        private bool canDelete;
        private Visibility visibility;

        public MyICommand DeleteCommand { get; set; }
        public MyICommand IspisCommand { get; set; }

        public ShowIgracViewModel()
        {
            string role = (string)Application.Current.Properties["Role"];
            if (role != "Admin")
            {
                Visibility = Visibility.Hidden;
            }
            else
            {
                Visibility = Visibility.Visible;
            }

            igraci = new ObservableCollection<Igrac_Selektovan>();
            DeleteCommand = new MyICommand(OnDelete);
            IspisCommand = new MyICommand(Stampaj);

            using (var db = new BazaZaLiguEntities())
            {
                foreach (Igrac item in db.Igracs)
                {
                    Igrac_Selektovan igrac = new Igrac_Selektovan() { igrac = item };
                    igrac.Transferi = new ObservableCollection<string>();
                    foreach (transferistorija transf in db.transferistorijas.Where(x=> x.igrac_id_igraca == item.id_igraca))
                    {
                        igrac.Transferi.Add(transf.klub + "  " + transf.datum);
                    }
                    igraci.Add(igrac);
                }
            }
            OnPropertyChanged("igraci");
        }

        //public void IspisiProsekGOlova()
        //{
        //    using (var db = new BazaZaLiguEntities())
        //    {
        //        //Igrac igrac = db.Igracs.Find(Selektovani_igrac.id_igraca);
        //       // igrac.prosek_golova= db.Database.SqlQuery<float>($"SELECT [dbo].[Prosek]({(float)igrac.postignutih_golova},{(float)igrac.odigranih_utakmica})").FirstOrDefault();
        //        //db.Entry(igrac).State = System.Data.Entity.EntityState.Modified;
        //       // db.SaveChanges();
        //        MessageBox.Show("Prosek golova po utakmici je " + Selektovani_igrac.prosek_golova, "Prosek" , MessageBoxButton.OK , MessageBoxImage.Asterisk);
        //    }
        //    Stampaj();
            
        //}

        public Visibility Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;

                OnPropertyChanged("Visibility");
            }
        }

        public bool CanDelete
        {
            get { return canDelete; }
            set
            {
                canDelete = value;
                OnPropertyChanged("CanDelete");
            }
        }

        public Igrac_Selektovan Selektovani_igrac
        {
            get { return selektovani_igrac; }
            set
            {
                SetProperty(ref selektovani_igrac, value);
                OnPropertyChanged("Selektovani_igrac");

                if (selektovani_igrac != null)
                    CanDelete = true;
                else
                    CanDelete = false;
            }
        }

        public void OnDelete()
        {
            using (var db = new BazaZaLiguEntities())
            {
                Igrac igrac_zaBrisanje = db.Igracs.Find(Selektovani_igrac.igrac.id_igraca);
                if(igrac_zaBrisanje != null)
                {
                    //treba veza ka menadzeru da se ispita
                    foreach (Menadzer item in igrac_zaBrisanje.Menadzers)
                    {
                        Menadzer menadzer = db.Menadzers.Find(item.id_menagera);
                        if(menadzer.Igracs.Count <=1)
                        {
                            MessageBox.Show("Igrac je jedini klijent menadzeru "+menadzer.ime_menagera + " " + menadzer.prezime_menagera +"\n Potrebno je obrisati prvo Menadzera igraca", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                    }
                    //treba veza ka menadzeru da se ispita
                    List<transferistorija> transferistorijas = igrac_zaBrisanje.transferistorijas.ToList();
                    foreach (transferistorija item in transferistorijas)
                    {
                        transferistorija transf = db.transferistorijas.Find(item.id);
                        db.transferistorijas.Remove(transf);
                    }
                    db.Entry(igrac_zaBrisanje).State = System.Data.Entity.EntityState.Deleted;
                    igraci.Remove(Selektovani_igrac);
                    db.SaveChanges();
                    MessageBox.Show("Uspesno ste obrisali igraca", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    LogReport(igrac_zaBrisanje);
                }
            }
        }

        public void Stampaj()
        {           
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../RezultatStampanja.txt");
            file.WriteLine("\t\t\t Igraci: ");
            file.WriteLine("");
            foreach (Igrac_Selektovan item in igraci.OrderBy(x => x.igrac.prosek_golova))
            {
                outPutText = string.Format("ID: {0}, Ime: {1},Prezime: {2},Klub: {3}, Utakmica: {4}, Golova: {5}, Prosek golova: {6} , Godina: {7} , Transferi: \n"
                    ,item.igrac.id_igraca, item.igrac.ime_igraca, item.igrac.prezime_igraca, item.igrac.naziv_kluba, item.igrac.odigranih_utakmica, item.igrac.postignutih_golova, item.igrac.prosek_golova,item.igrac.godine_igraca);
                foreach (string transf in item.Transferi)
                {
                    outPutText += transf + "; ";
                }
                file.WriteLine(outPutText);
            }
            file.Close();
                
            MessageBox.Show("Datoteka je sacuvana u RezultatStampanja.txt", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        public void LogReport(Igrac logObjekat)
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../LogReport.txt", true);
            outPutText = string.Format("BRISANJE {0} \t IGRAC:    ID: {1} , Ime: {2}  , Prezime: {3}\n"
                 , DateTime.Now.ToShortDateString(), logObjekat.id_igraca, logObjekat.ime_igraca, logObjekat.prezime_igraca);

            file.WriteLine(outPutText);
            file.Close();
        }
    }
}
