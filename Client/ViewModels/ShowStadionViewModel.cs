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
    public class ShowStadionViewModel : BindableBase
    {
        public static ObservableCollection<Stadion_Selektovan> stadioni { get; set; }
        private Stadion_Selektovan selektovani_stadion;
        private bool canDelete;
        private Visibility visibility;

        public MyICommand DeleteCommand { get; set; }
        public MyICommand IspisCommand { get; set; }

        public ShowStadionViewModel()
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

            stadioni = new ObservableCollection<Stadion_Selektovan>();
            DeleteCommand = new MyICommand(OnDelete);
            IspisCommand = new MyICommand(Stampaj);

            using (var db = new BazaZaLiguEntities())
            {
                foreach (Stadion item in db.Stadions)
                {
                    Stadion_Selektovan stad = new Stadion_Selektovan() { S = item };
                    stad.Nazivi_klubova = new ObservableCollection<string>();
                    foreach (Poseduje poseduje in item.Posedujes)
                    {
                        stad.Nazivi_klubova.Add(poseduje.klub_naziv);
                    }
                    stadioni.Add(stad);
                }
            }
            OnPropertyChanged("stadioni");
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

        public Stadion_Selektovan Selektovani_stadion
        {
            get { return selektovani_stadion; }
            set
            {
                SetProperty(ref selektovani_stadion, value);
                OnPropertyChanged("Selektovani_stadion");

                if (selektovani_stadion != null)
                    CanDelete = true;
                else
                    CanDelete = false;
            }
        }

        private void OnDelete()
        {
            using (var db = new BazaZaLiguEntities())
            {
                Stadion stadion_zaBrisanje = db.Stadions.Find(Selektovani_stadion.S.id_stadiona);
                if (!izvrsiProvere(stadion_zaBrisanje))
                {
                    //nije ispunio uslove brisanje, ne brisi
                    return;
                }

                //brisi iz klubova
                List<Poseduje> posedujeLista = stadion_zaBrisanje.Posedujes.ToList();
                foreach (Poseduje pos in posedujeLista)
                {
                    Poseduje poseduje = db.Posedujes.Where(x => x.klub_naziv == pos.klub_naziv && x.stadion_id_stadiona == pos.stadion_id_stadiona).FirstOrDefault();
                    List<Obezbedjenje> radnici = poseduje.Obezbedjenjes.ToList();
                    foreach (Obezbedjenje item in radnici)
                    {
                        Obezbedjenje radnik = db.Obezbedjenjes.Find(item.id_radnika);
                        radnik.Posedujes.Remove(poseduje);
                        db.Entry(radnik).State = System.Data.Entity.EntityState.Modified;
                    }
                    db.Posedujes.Remove(poseduje);
                    db.SaveChanges();
                }

                db.Entry(stadion_zaBrisanje).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                stadioni.Remove(Selektovani_stadion);
                OnPropertyChanged("stadioni");
                MessageBox.Show("Uspesno ste obrisali stadion", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                LogReport(stadion_zaBrisanje);

            }

        }
        private bool izvrsiProvere(Stadion stadionZaProveru)
        {
            if (stadionZaProveru == null)
                return false;

            using (var db = new BazaZaLiguEntities())
            {
                //provera za radnike na stadionu, poseduje
                List<Poseduje> provera_poseduje = db.Posedujes.Where(x => x.stadion_id_stadiona == stadionZaProveru.id_stadiona).ToList();
                int brojKlubova = provera_poseduje.Count;

                foreach (Poseduje item in provera_poseduje)
                {
                    foreach (Obezbedjenje obez in item.Obezbedjenjes) //radnici , obezbedjenje
                    {
                        Obezbedjenje obezbedjenje = db.Obezbedjenjes.Find(obez.id_radnika);
                        if (obezbedjenje.Posedujes.Count < brojKlubova + 1) //radnik mora da radi na jos nekom stadionu koji ne pripada tom klubu
                        {
                            MessageBox.Show("Od stadiona zavise Radnici , prvo njih obrisati", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return false;
                        }

                    }

                }
            }
            return true;
        }

        public void Stampaj()
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../RezultatStampanja.txt");
            file.WriteLine("\t\t\t Stadioni: ");
            file.WriteLine("");
            foreach (Stadion_Selektovan item in stadioni)
            {
                outPutText = string.Format("ID: {0}, Naziv: {1}, Grad: {2}, Kapacitet: {3}, Klubovi:  "
                    , item.S.id_stadiona, item.S.naziv_stadiona,item.S.grad , item.S.kapacitet);
                foreach (string naziv in item.Nazivi_klubova)
                {
                    outPutText += naziv + " ; ";

                }
                file.WriteLine(outPutText);
            }
            file.Close();

            MessageBox.Show("Datoteka je sacuvana u RezultatStampanja.txt", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        public void LogReport(Stadion logObjekat)
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../LogReport.txt", true);
            outPutText = string.Format("BRISANJE {0} \t STADION:    ID: {1}, Naziv: {2} , Grad: {3}\n"
                 , DateTime.Now.ToShortDateString(), logObjekat.id_stadiona, logObjekat.naziv_stadiona, logObjekat.grad);

            file.WriteLine(outPutText);
            file.Close();
        }
    }
}
