using Client.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace Client.ViewModels
{
    public class AddObezbedjenjeViewModel : BindableBase
    {
        public MyICommand addCommand { get; set; }
        private Obezbedjenje radnik;
        public static ObservableCollection<Poseduje_Selektovan> stadioni_klubovi { get; set; }
        public ObservableCollection<string> Drzave { get; set; }

        public Obezbedjenje Radnik_prop
        {
            get { return radnik; }
            set
            {
                SetProperty(ref radnik, value);
                OnPropertyChanged("Radnik_prop");
            }
        }

        public AddObezbedjenjeViewModel()
        {
            addCommand = new MyICommand(OnAdd);
            dodajStadioneSaKlubovima();
            ucitajDrzave();
            Radnik_prop = new Obezbedjenje() { id_radnika = 0, ime_radnika = "", prezime_radnika = "" };
        }

        private void ucitajDrzave()
        {
            Drzave = new ObservableCollection<string>();
            XmlDocument doc = new XmlDocument();
            doc.Load(@"../../../Drzave.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string nazivDrzave = node.InnerText;
                Drzave.Add(nazivDrzave);

            }
        }

        private void dodajStadioneSaKlubovima()
        {
            stadioni_klubovi = new ObservableCollection<Poseduje_Selektovan>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Poseduje item in db.Posedujes)
                {
                    //Stadioni i svoji klubovi
                    Poseduje_Selektovan poseduje = new Poseduje_Selektovan() { P = item, IsSelected = false };
                    Stadion stadion = db.Stadions.Find(poseduje.P.stadion_id_stadiona);
                    poseduje.Klub_Stadion_Nazivi = stadion.naziv_stadiona + " ("+ poseduje.P.klub_naziv +")";
                    stadioni_klubovi.Add(poseduje);
                       
                }
            }
            OnPropertyChanged("stadioni_klubovi");
        }

        private void OnAdd()
        {
            if(validate())
            {
                using (var db = new BazaZaLiguEntities())
                {
                    // dodaj selektovane stadione sa klubovima
                    List<Poseduje> poseduje_zaDodavanje = new List<Poseduje>();
                    foreach (Poseduje_Selektovan poseduje in stadioni_klubovi)
                    {
                        if (poseduje.IsSelected)
                        {
                            Poseduje posedujeProvera = db.Posedujes.Where(x=> x.klub_naziv == poseduje.P.klub_naziv && x.stadion_id_stadiona == poseduje.P.stadion_id_stadiona).FirstOrDefault();
                            poseduje_zaDodavanje.Add(posedujeProvera);
                        }
                    }

                    if (poseduje_zaDodavanje.Count <= 0) // nije odabrao nijedan stadion 
                    {
                        MessageBox.Show("Potrebno je odabrati barem 1 stadion !", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    //id logic
                    int nextID = 0;
                    Obezbedjenje proveraID = null;
                    do
                    {
                        proveraID = db.Obezbedjenjes.Where(x => x.id_radnika == nextID + 1).FirstOrDefault();
                        nextID++;
                    }
                    while (proveraID != null);

                    Obezbedjenje novi_radnik = new Obezbedjenje() { id_radnika = nextID, ime_radnika = Radnik_prop.ime_radnika, prezime_radnika = Radnik_prop.prezime_radnika , drzava = Radnik_prop.drzava };
                    novi_radnik.Posedujes = poseduje_zaDodavanje;

                    db.Obezbedjenjes.Add(novi_radnik);
                    db.SaveChanges();
                    MessageBox.Show("Uspesno ste dodali radnika", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    LogReport(novi_radnik);
                }
            }
        }

        private bool validate()
        {
            if (Radnik_prop.ime_radnika == "" || Radnik_prop.ime_radnika == null || Radnik_prop.prezime_radnika == "" || Radnik_prop.prezime_radnika == null || Radnik_prop.drzava == null || Radnik_prop.drzava == "")
            {
                MessageBox.Show("Potrebno je popuniti sva polja", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        public void LogReport(Obezbedjenje logObjekat)
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../LogReport.txt", true);
            outPutText = string.Format("KREIRANJE {0} \t RADNIK:    ID: {1}, Ime: {2} , Prezime: {3} , Drzava: {4}\n"
                 , DateTime.Now.ToShortDateString(), logObjekat.id_radnika, logObjekat.ime_radnika, logObjekat.prezime_radnika, logObjekat.drzava);

            file.WriteLine(outPutText);
            file.Close();
        }
    }
}
