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
    public class ShowMenadzerViewModel : BindableBase
    {
        public static ObservableCollection<Menadzer_Selektovan> menadzeri { get; set; }
        private Menadzer_Selektovan selektovani_menadzer;
        private bool canDelete;
        private Visibility visibility;
        public MyICommand IspisCommand { get; set; }

        public MyICommand DeleteCommand { get; set; }

        public ShowMenadzerViewModel()
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

            menadzeri = new ObservableCollection<Menadzer_Selektovan>();
            DeleteCommand = new MyICommand(OnDelete);
            IspisCommand = new MyICommand(Stampaj);

            using (var db = new BazaZaLiguEntities())
            {
                foreach (Menadzer item in db.Menadzers)
                {
                    Menadzer_Selektovan men = new Menadzer_Selektovan() { M = item };
                    men.Nazivi_igraca = new ObservableCollection<string>();
                    foreach (Igrac igrac in item.Igracs)
                    {
                        men.Nazivi_igraca.Add(igrac.ime_igraca + " "+ igrac.prezime_igraca);
                    }
                    menadzeri.Add(men);
                }
            }
            OnPropertyChanged("menadzeri");
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

        public Menadzer_Selektovan Selektovani_menadzer
        {
            get { return selektovani_menadzer; }
            set
            {
                SetProperty(ref selektovani_menadzer, value);
                OnPropertyChanged("Selektovani_menadzer");

                if (selektovani_menadzer != null)
                    CanDelete = true;
                else
                    CanDelete = false;
            }
        }

        private void OnDelete()
        {
            using (var db = new BazaZaLiguEntities())
            {
                Menadzer menadzer_zaBrisanje = db.Menadzers.Find(Selektovani_menadzer.M.id_menagera);
                if (menadzer_zaBrisanje != null)
                {

                    List<Igrac> igraci = menadzer_zaBrisanje.Igracs.ToList();
                    foreach (Igrac igrac in igraci)
                    {
                        Igrac ig = db.Igracs.Find(igrac.id_igraca);
                        ig.Menadzers.Remove(menadzer_zaBrisanje);
                        db.SaveChanges();
                    }


                    db.Entry(menadzer_zaBrisanje).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    menadzeri.Remove(Selektovani_menadzer);
                    OnPropertyChanged("menadzeri");
                    MessageBox.Show("Uspesno ste obrisali menadzera", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    LogReport(menadzer_zaBrisanje);
                }
            }
        }

        public void Stampaj()
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../RezultatStampanja.txt");
            file.WriteLine("\t\t\t Menadzeri: ");
            file.WriteLine("");
            foreach (Menadzer_Selektovan item in menadzeri)
            {
                outPutText = string.Format("ID: {0}, Ime: {1},Prezime: {2}, Drzava: {3}, Igraci:  "
                    , item.M.id_menagera, item.M.ime_menagera, item.M.prezime_menagera,item.M.drzava);
                foreach (string naziv in item.Nazivi_igraca)
                {
                    outPutText += naziv + " ; ";

                }
                file.WriteLine(outPutText);
            }
            file.Close();

            MessageBox.Show("Datoteka je sacuvana u RezultatStampanja.txt", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        public void LogReport(Menadzer logObjekat)
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../LogReport.txt", true);
            outPutText = string.Format("BRISANJE {0} \t MENADZER:    ID: {1} , Ime: {2} , Prezime: {3} , Drzava: {4}\n"
                 , DateTime.Now.ToShortDateString(), logObjekat.id_menagera, logObjekat.ime_menagera, logObjekat.prezime_menagera, logObjekat.drzava);

            file.WriteLine(outPutText);
            file.Close();
        }
    }
}
