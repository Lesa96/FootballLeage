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
    public class AddSudijaViewModel : BindableBase
    {
        public ObservableCollection<Liga> lige { get; set; }
        public ObservableCollection<string> Naziv_lige { get; set; }
        public ObservableCollection<string> Drzave { get; set; }
        public MyICommand addCommand { get; set; }
        private string selektovanaLiga;
        private Sudija sudija;

        public Sudija Sudija_prop
        {
            get { return sudija; }
            set
            {
                SetProperty(ref sudija, value);
                OnPropertyChanged("Sudija_prop");
            }
        }




        public string SelektovanaLiga
        {
            get { return selektovanaLiga; }
            set
            {
                selektovanaLiga = value;
                OnPropertyChanged("SelektovanaLiga");
            }
        }

        public AddSudijaViewModel()
        {
            Drzave = new ObservableCollection<string>();
            addCommand = new MyICommand(OnDodajSudija);
            lige = new ObservableCollection<Liga>();
            Naziv_lige = new ObservableCollection<string>();

            using (var db = new BazaZaLiguEntities())
            {
                foreach (Liga item in db.Ligas)
                {
                    //sve lige
                    lige.Add(item);
                    Naziv_lige.Add(item.naziv_lige);
                }
            }
            OnPropertyChanged("Naziv_lige");
            ucitajDrzave();

           Sudija_prop = new Sudija() { ime_sudije = "", prezime_sudije = "", nacionalnost_sudije = "" };
        }

        private void ucitajDrzave()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"../../../Drzave.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string nazivDrzave = node.InnerText;
                Drzave.Add(nazivDrzave);

            }
        }

        public void OnDodajSudija()
        {
            if(validate())
            {
                Sudija sudijaDodaj = new Sudija() { ime_sudije = Sudija_prop.ime_sudije, prezime_sudije = Sudija_prop.prezime_sudije, nacionalnost_sudije = Sudija_prop.nacionalnost_sudije };
                using (var db = new BazaZaLiguEntities())
                {
                    //generise sledeci ID:
                    int nextID = 0;
                    Sudija proveraID = null;
                    do
                    {
                        proveraID = db.Sudijas.Where(x => x.id_sudije == nextID + 1).FirstOrDefault();
                        nextID++;
                    }
                    while (proveraID != null);
                    sudijaDodaj.id_sudije = nextID;

                    if (SelektovanaLiga != "" && SelektovanaLiga != null && SelektovanaLiga != "None")
                    {
                        foreach (Liga item in lige)
                        {

                            if (item.naziv_lige == SelektovanaLiga)
                            {
                                sudijaDodaj.liga_id_lige = item.id_lige;
                                Liga liga_dodaj = db.Ligas.Find(item.id_lige);
                                sudijaDodaj.Liga = liga_dodaj;                                
                                break;
                            }
                        }
                        
                    }
                    db.Sudijas.Add(sudijaDodaj);
                    db.SaveChanges();
                    OnPropertyChanged("Sudija_prop");
                    MessageBox.Show("Sudija je uspesno dodat", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    LogReport(sudijaDodaj);
                }
            }
        }

        public bool validate()
        {
            if(Sudija_prop.ime_sudije == "" || Sudija_prop.prezime_sudije =="" || Sudija_prop.nacionalnost_sudije == "" || Sudija_prop.nacionalnost_sudije == null)
            {
                MessageBox.Show("Potrebno je popuniti sva polja", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        public void LogReport(Sudija logObjekat)
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../LogReport.txt", true);
            outPutText = string.Format("KREIRANJE {0} \t SUDIJA:    ID: {1}, Ime: {2} , Prezime: {3} , Drzava: {4}\n"
                 , DateTime.Now.ToShortDateString(), logObjekat.id_sudije, logObjekat.ime_sudije, logObjekat.prezime_sudije,logObjekat.nacionalnost_sudije);

            file.WriteLine(outPutText);
            file.Close();
        }
    }
}
