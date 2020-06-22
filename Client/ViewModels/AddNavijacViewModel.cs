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
    public class AddNavijacViewModel : BindableBase
    {
        public MyICommand addCommand { get; set; }
        private Navijac navijac;       
        public static ObservableCollection<Klub_Selektovan> klubovi { get; set; }
        public ObservableCollection<string> Drzave { get; set; }

        public Navijac Navijac_prop
        {
            get { return navijac; }
            set
            {
                SetProperty(ref navijac, value);
                OnPropertyChanged("Navijac_prop");
            }
        }        

        public AddNavijacViewModel()
        {
            ucitajDrzave();
            addCommand = new MyICommand(OnAdd);
            dodajKlubove();
           
            Navijac_prop = new Navijac() { id_navijaca = 0, ime_navijaca = "", prezime_navijaca = "" };
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
            if(validate())
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

                    if(klub_zaDodavanje.Count <= 0) // nije odabrao nijedan klub
                    {
                        MessageBox.Show("Potrebno je odabrati barem 1 klub !", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    //id logic
                    int nextID = 0;
                    Navijac proveraID = null;
                    do
                    {
                        proveraID = db.Navijacs.Where(x => x.id_navijaca == nextID + 1).FirstOrDefault();
                        nextID++;
                    }
                    while (proveraID != null);

                    Navijac novi_Navijac = new Navijac() { id_navijaca = nextID,ime_navijaca = Navijac_prop.ime_navijaca, prezime_navijaca = Navijac_prop.prezime_navijaca, drzava = Navijac_prop.drzava };
                    novi_Navijac.Klubs = klub_zaDodavanje;

                    db.Navijacs.Add(novi_Navijac);
                    db.SaveChanges();
                    MessageBox.Show("Uspesno ste dodali navijaca", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    LogReport(novi_Navijac);

                }
            }
        }

        private bool validate()
        {
            if(Navijac_prop.ime_navijaca == "" || Navijac_prop.ime_navijaca == null || Navijac_prop.prezime_navijaca == "" || Navijac_prop.prezime_navijaca == null || Navijac_prop.drzava == null || Navijac_prop.drzava == "")
            {
                MessageBox.Show("Potrebno je popuniti sva polja", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        public void LogReport(Navijac logObjekat)
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../LogReport.txt", true);
            outPutText = string.Format("KREIRANJE {0} \t NAVIJAC:    ID: {1}, Ime: {2} , Prezime: {3} , Drzava: {4}\n"
                 , DateTime.Now.ToShortDateString(), logObjekat.id_navijaca, logObjekat.ime_navijaca, logObjekat.prezime_navijaca, logObjekat.drzava);

            file.WriteLine(outPutText);
            file.Close();
        }
    }
}
