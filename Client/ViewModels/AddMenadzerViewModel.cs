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
    public class AddMenadzerViewModel : BindableBase
    {
        public MyICommand addCommand { get; set; }
        private Menadzer menadzer;
        public static ObservableCollection<Igrac_Selektovan> igraci { get; set; }
        public ObservableCollection<string> Drzave { get; set; }

        public Menadzer Menadzer_prop
        {
            get { return menadzer; }
            set
            {
                SetProperty(ref menadzer, value);
                OnPropertyChanged("Menadzer_prop");
            }
        }

        public AddMenadzerViewModel()
        {
            ucitajDrzave();
            addCommand = new MyICommand(OnAdd);
            dodajIgrace();

            Menadzer_prop = new Menadzer() { id_menagera = 0, ime_menagera = "", prezime_menagera = "" };
        }

        private void dodajIgrace()
        {
            igraci = new ObservableCollection<Igrac_Selektovan>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Igrac item in db.Igracs)
                {
                    //svi igraci
                    Igrac_Selektovan igrac = new Igrac_Selektovan() { igrac = item, IsSelected = false };
                    igrac.Ime_Prezime = item.ime_igraca + " " + item.prezime_igraca;
                    igraci.Add(igrac);

                }
            }
            OnPropertyChanged("igraci");
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

        private void OnAdd()
        {
            if (validate())
            {
                using (var db = new BazaZaLiguEntities())
                {
                    // dodaj selektovane stadione
                    List<Igrac> igraci_zaDodavanje = new List<Igrac>();
                    foreach (Igrac_Selektovan igrac in igraci)
                    {
                        if (igrac.IsSelected)
                        {
                            Igrac igracProvera = db.Igracs.Find(igrac.igrac.id_igraca);
                            igraci_zaDodavanje.Add(igracProvera);
                        }
                    }

                    if (igraci_zaDodavanje.Count <= 0) // nije odabrao nijednog igraca
                    {
                        MessageBox.Show("Potrebno je odabrati barem jednog igraca !", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    //id logic
                    int nextID = 0;
                    Menadzer proveraID = null;
                    do
                    {
                        proveraID = db.Menadzers.Where(x => x.id_menagera == nextID + 1).FirstOrDefault();
                        nextID++;
                    }
                    while (proveraID != null);

                    Menadzer novi_Menadzer = new Menadzer() { id_menagera = nextID, ime_menagera = Menadzer_prop.ime_menagera, prezime_menagera = Menadzer_prop.prezime_menagera, drzava = Menadzer_prop.drzava };
                    novi_Menadzer.Igracs = igraci_zaDodavanje;

                    db.Menadzers.Add(novi_Menadzer);
                    db.SaveChanges();
                    MessageBox.Show("Uspesno ste dodali Menadzera", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    LogReport(novi_Menadzer);

                }
            }
        }

        private bool validate()
        {
            if (Menadzer_prop.ime_menagera == "" || Menadzer_prop.ime_menagera == null || Menadzer_prop.prezime_menagera == "" || Menadzer_prop.prezime_menagera == null || Menadzer_prop.drzava == null || Menadzer_prop.drzava == "")
            {
                MessageBox.Show("Potrebno je popuniti sva polja", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        public void LogReport(Menadzer logObjekat)
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../LogReport.txt", true);
            outPutText = string.Format("KREIRANJE {0} \t MENADZER:    ID: {1} , Ime: {2} , Prezime: {3} , Drzava: {4}\n"
                 , DateTime.Now.ToShortDateString(), logObjekat.id_menagera, logObjekat.ime_menagera, logObjekat.prezime_menagera , logObjekat.drzava);

            file.WriteLine(outPutText);
            file.Close();
        }
    }
}
