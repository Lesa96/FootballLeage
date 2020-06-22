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
    public class AddVlasnikViewModel : BindableBase
    {
        public MyICommand addCommand { get; set; }
        private Vlasnik vlasnik;
        public static ObservableCollection<Klub_Selektovan> klubovi { get; set; }
        public ObservableCollection<string> Drzave { get; set; }

        public Vlasnik Vlasnik_prop
        {
            get { return vlasnik; }
            set
            {
                SetProperty(ref vlasnik, value);
                OnPropertyChanged("Vlasnik_prop");
            }
        }

        public AddVlasnikViewModel()
        {
            addCommand = new MyICommand(OnAdd);
            dodajKlubove();
            ucitajDrzave();
            Vlasnik_prop = new Vlasnik() { id_vlasnika = 0, ime_vlasnika = "", prezime_vlasnika = "" };
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

        private void dodajKlubove()
        {
            klubovi = new ObservableCollection<Klub_Selektovan>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Klub item in db.Klubs)
                {
                    //svi klubovi
                    Klub_Selektovan klub = new Klub_Selektovan() { K = item, IsSelected = false };
                    klubovi.Add(klub);

                }
            }
            OnPropertyChanged("klubovi");
        }



        private void OnAdd()
        {
            if (validate())
            {
                using (var db = new BazaZaLiguEntities())
                {
                    // dodaj selektovane stadione
                    List<Klub> klub_zaDodavanje = new List<Klub>();
                    foreach (Klub_Selektovan klub in klubovi)
                    {
                        if (klub.IsSelected)
                        {
                            Klub klubProvera = db.Klubs.Find(klub.K.naziv);
                            klub_zaDodavanje.Add(klubProvera);
                        }
                    }

                    if (klub_zaDodavanje.Count <= 0) // nije odabrao nijedan klub
                    {
                        MessageBox.Show("Potrebno je odabrati barem 1 klub !", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    //id logic
                    int nextID = 0;
                    Vlasnik proveraID = null;
                    do
                    {
                        proveraID = db.Vlasniks.Where(x => x.id_vlasnika == nextID + 1).FirstOrDefault();
                        nextID++;
                    }
                    while (proveraID != null);

                    Vlasnik novi_Vlasnik = new Vlasnik() { id_vlasnika = nextID, ime_vlasnika = Vlasnik_prop.ime_vlasnika, prezime_vlasnika = Vlasnik_prop.prezime_vlasnika, drzava = Vlasnik_prop.drzava };
                    novi_Vlasnik.Klubs = klub_zaDodavanje;

                    db.Vlasniks.Add(novi_Vlasnik);
                    db.SaveChanges();
                    MessageBox.Show("Uspesno ste dodali vlasnika", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    LogReport(novi_Vlasnik);

                }
            }
        }

        private bool validate()
        {
            if (Vlasnik_prop.ime_vlasnika == "" || Vlasnik_prop.ime_vlasnika == null || Vlasnik_prop.prezime_vlasnika == "" || Vlasnik_prop.prezime_vlasnika == null || Vlasnik_prop.drzava == null || Vlasnik_prop.drzava == "")
            {
                MessageBox.Show("Potrebno je popuniti sva polja", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        public void LogReport(Vlasnik logObjekat)
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../LogReport.txt", true);
            outPutText = string.Format("KREIRANJE {0} \t VLASNIK:    ID: {1} , Ime: {2} , Prezime: {3} , Drzava: {4}\n"
                 , DateTime.Now.ToShortDateString(), logObjekat.id_vlasnika, logObjekat.ime_vlasnika, logObjekat.prezime_vlasnika, logObjekat.drzava);

            file.WriteLine(outPutText);
            file.Close();
        }
    }
}
