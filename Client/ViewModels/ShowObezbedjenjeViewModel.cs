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
    public class ShowObezbedjenjeViewModel : BindableBase
    {
        public static ObservableCollection<Radnik_Selektovan> radnici { get; set; }
        private Radnik_Selektovan selektovani_radnik;
        private bool canDelete;
        private Visibility visibility;

        public MyICommand DeleteCommand { get; set; }
        public MyICommand IspisCommand { get; set; }

        public ShowObezbedjenjeViewModel()
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

            radnici = new ObservableCollection<Radnik_Selektovan>();
            DeleteCommand = new MyICommand(OnDelete);
            IspisCommand = new MyICommand(Stampaj);

            using (var db = new BazaZaLiguEntities())
            {
                foreach (Obezbedjenje item in db.Obezbedjenjes)
                {
                    Radnik_Selektovan rad = new Radnik_Selektovan() { Radnik = item };
                    rad.Klub_Stadion_Nazivi = new ObservableCollection<string>();
                    foreach (Poseduje poseduje in item.Posedujes)
                    {
                        Stadion stadion = db.Stadions.Find(poseduje.stadion_id_stadiona);
                        rad.Klub_Stadion_Nazivi.Add( stadion.naziv_stadiona + " (" + poseduje.klub_naziv + ")" );
                        
                    }
                    radnici.Add(rad);
                }
            }
            OnPropertyChanged("radnici");
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

        public Radnik_Selektovan Selektovani_radnik
        {
            get { return selektovani_radnik; }
            set
            {
                SetProperty(ref selektovani_radnik, value);
                OnPropertyChanged("Selektovani_radnik");

                if (selektovani_radnik != null)
                    CanDelete = true;
                else
                    CanDelete = false;
            }
        }

        private void OnDelete()
        {
            using (var db = new BazaZaLiguEntities())
            {
                Obezbedjenje radnik_zaBrisanje = db.Obezbedjenjes.Find(Selektovani_radnik.Radnik.id_radnika);
                if (radnik_zaBrisanje != null)
                {

                    List<Poseduje> poseduje = radnik_zaBrisanje.Posedujes.ToList();
                    foreach (Poseduje item in poseduje)
                    {
                        Poseduje pos = db.Posedujes.Where(x => x.klub_naziv == item.klub_naziv && x.stadion_id_stadiona == item.stadion_id_stadiona).FirstOrDefault();
                        pos.Obezbedjenjes.Remove(radnik_zaBrisanje);
                        db.SaveChanges();
                    }


                    db.Entry(radnik_zaBrisanje).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    radnici.Remove(Selektovani_radnik);
                    OnPropertyChanged("radnici");
                    MessageBox.Show("Uspesno ste obrisali radnika", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    LogReport(radnik_zaBrisanje);
                }
            }
        }

        public void Stampaj()
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../RezultatStampanja.txt");
            file.WriteLine("\t\t\t Radnici: ");
            file.WriteLine("");
            foreach (Radnik_Selektovan item in radnici)
            {
                outPutText = string.Format("ID: {0}, Ime: {1},Prezime: {2}, Drzava: {3}, Stadioni:  "
                    , item.Radnik.id_radnika, item.Radnik.ime_radnika, item.Radnik.prezime_radnika,item.Radnik.drzava);
                foreach (string naziv in item.Klub_Stadion_Nazivi)
                {
                    outPutText += naziv + " ; ";

                }
                file.WriteLine(outPutText);
            }
            file.Close();

            MessageBox.Show("Datoteka je sacuvana u RezultatStampanja.txt", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        public void LogReport(Obezbedjenje logObjekat)
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../LogReport.txt", true);
            outPutText = string.Format("BRISANJE {0} \t RADNIK:    ID: {1}, Ime: {2} , Prezime: {3} , Drzava: {4}\n"
                 , DateTime.Now.ToShortDateString(), logObjekat.id_radnika, logObjekat.ime_radnika, logObjekat.prezime_radnika, logObjekat.drzava);

            file.WriteLine(outPutText);
            file.Close();
        }
    }
}
