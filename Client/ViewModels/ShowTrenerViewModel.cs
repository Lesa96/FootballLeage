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
    public class ShowTrenerViewModel : BindableBase
    {
        public static ObservableCollection<Trener_Selektovan> treneri { get; set; }
        private Trener_Selektovan selektovani_trener;
        private bool canDelete;
        private Visibility visibility;

        public MyICommand DeleteCommand { get; set; }
        public MyICommand IspisCommand { get; set; }

        public ShowTrenerViewModel()
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

            treneri = new ObservableCollection<Trener_Selektovan>();
            DeleteCommand = new MyICommand(OnDelete);
            IspisCommand = new MyICommand(Stampaj);

            using (var db = new BazaZaLiguEntities())
            {
                foreach (Trener item in db.Treners)
                {
                    Trener_Selektovan trener = new Trener_Selektovan() { T = item };
                    Vodi klubTrenera = db.Vodis.Where(x => x.trener_id_trenera == item.id_trenera).FirstOrDefault();
                    if(klubTrenera != null)
                    {
                        trener.Naziv_Kluba = klubTrenera.klub_naziv;
                    }
                    treneri.Add(trener);
                }
            }
            OnPropertyChanged("treneri");
        }

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

        public Trener_Selektovan Selektovani_trener
        {
            get { return selektovani_trener; }
            set
            {
                SetProperty(ref selektovani_trener, value);
                OnPropertyChanged("Selektovani_trener");

                if (selektovani_trener != null)
                    CanDelete = true;
                else
                    CanDelete = false;
            }
        }

        public void OnDelete()
        {
            using (var db = new BazaZaLiguEntities())
            {
                //brisi iz vodi
                Vodi provera_vodi = db.Vodis.Where(x => x.trener_id_trenera == Selektovani_trener.T.id_trenera).FirstOrDefault();
                if (provera_vodi != null)
                {
                    foreach (Igrac igrac in db.Igracs)
                    {
                        if (igrac.naziv_kluba == provera_vodi.klub_naziv)
                        {
                            igrac.Vodi = null;
                            db.Entry(igrac).State = System.Data.Entity.EntityState.Modified;
                        }

                    }
                    db.Entry(provera_vodi).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
               
                Trener trener_brisanje = db.Treners.Find(Selektovani_trener.T.id_trenera);
                if(trener_brisanje != null)
                {
                    db.Entry(trener_brisanje).State = System.Data.Entity.EntityState.Deleted;
                    treneri.Remove(Selektovani_trener);
                }

                db.SaveChanges();
                MessageBox.Show("Uspesno ste obrisali Trenera", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                LogReport(trener_brisanje);
            }
        }

        public void Stampaj()
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../RezultatStampanja.txt");
            file.WriteLine("\t\t\t Treneri: ");
            file.WriteLine("");
            foreach (Trener_Selektovan item in treneri)
            {
                outPutText = string.Format("ID: {0}, Ime: {1},Prezime: {2}, Drzava: {3},Klub: {4}"
                    , item.T.id_trenera, item.T.ime_trenera, item.T.prezime_trenera,item.T.drzava,item.Naziv_Kluba);
                
                file.WriteLine(outPutText);
            }
            file.Close();

            MessageBox.Show("Datoteka je sacuvana u RezultatStampanja.txt", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        public void LogReport(Trener logObjekat)
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../LogReport.txt", true);
            outPutText = string.Format("BRISANJE {0} \t TRENER:    ID: {1}, Ime: {2} , Prezime: {3} , Drzava: {4} \n"
                 , DateTime.Now.ToShortDateString(), logObjekat.id_trenera, logObjekat.ime_trenera, logObjekat.prezime_trenera, logObjekat.drzava);

            file.WriteLine(outPutText);
            file.Close();
        }
    }
}
