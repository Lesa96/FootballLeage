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
    public class AddTrenerViewModel : BindableBase
    {
        public MyICommand addCommand { get; set; }
        private Trener trener;
        public ObservableCollection<string> Naziv_kluba { get; set; }
        public ObservableCollection<Klub> klubovi { get; set; }
        public ObservableCollection<Vodi> klubKojiVodi { get; set; }
        private string selektovaniKlub;
        public ObservableCollection<string> Drzave { get; set; }

        public Trener Trener_prop
        {
            get { return trener; }
            set
            {
                SetProperty(ref trener, value);
                OnPropertyChanged("Trener_prop");
            }
        }

        public string SelektovaniKlub
        {
            get { return selektovaniKlub; }
            set
            {
                selektovaniKlub = value;
                OnPropertyChanged("SelektovaniKlub");
            }
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

        public AddTrenerViewModel()
        {
            ucitajDrzave();
            addCommand = new MyICommand(OnAdd);            
            klubKojiVodi = new ObservableCollection<Vodi>();
            klubovi = new ObservableCollection<Klub>();

            ucitajSlobodneKlubove();            
            OnPropertyChanged("klubovi");
            Trener_prop = new Trener() { id_trenera = 0, ime_trenera = "", prezime_trenera = "" };
        }

        public void OnAdd()
        {
            if(validate())
            {
                using (var db = new BazaZaLiguEntities())
                {
                    //id logic
                    int nextID = 0;
                    Trener proveraID = null;
                    do
                    {
                        proveraID = db.Treners.Where(x => x.id_trenera == nextID + 1).FirstOrDefault();
                        nextID++;
                    }
                    while (proveraID != null);

                    Klub novi_klub = db.Klubs.Find(SelektovaniKlub);                   
                    Trener novi_trener = new Trener() { id_trenera = nextID, ime_trenera = Trener_prop.ime_trenera, prezime_trenera = Trener_prop.prezime_trenera , drzava = Trener_prop.drzava };
                    db.Treners.Add(novi_trener);

                    if (SelektovaniKlub != "" && SelektovaniKlub != null && SelektovaniKlub != "None")
                    {
                        Vodi novi_vodi = new Vodi() { trener_id_trenera = novi_trener.id_trenera, klub_naziv = novi_klub.naziv, Klub = novi_klub, Trener = novi_trener };
                        db.Vodis.Add(novi_vodi);
                        foreach (Igrac igrac in db.Igracs)
                        {
                            if(igrac.naziv_kluba == novi_klub.naziv)
                            {
                                igrac.Vodi = novi_vodi;
                                db.Entry(igrac).State = System.Data.Entity.EntityState.Modified;
                            }
                        }
                    }

                    db.SaveChanges();
                    MessageBox.Show("Uspesno dodan trener", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    Trener_prop.ime_trenera = Trener_prop.prezime_trenera = SelektovaniKlub  =  "";     //works fine
                    OnPropertyChanged("Trener_prop");
                    ucitajSlobodneKlubove();
                    LogReport(novi_trener);


                }
            }
        }

        public bool validate()
        {
            using (var db = new BazaZaLiguEntities())
            {
                
                if (Trener_prop.ime_trenera == "" || Trener_prop.prezime_trenera == "" || Trener_prop.drzava == "" || Trener_prop.drzava == null)
                {
                    MessageBox.Show("Potrebno je popuniti sva polja", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                else
                {                   
                    var vodiZaProveru = db.Vodis.Where(x => x.klub_naziv == SelektovaniKlub).FirstOrDefault();
                    if(vodiZaProveru != null)
                    {
                        MessageBox.Show("Izabrani klub vec trenira neki trener", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return false;
                    }
                }
            }

            return true;
        }

        private void ucitajSlobodneKlubove()
        {
            Naziv_kluba = new ObservableCollection<string>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Klub item in db.Klubs)
                {
                    var vodiZaProveru = db.Vodis.Where(x => x.klub_naziv == item.naziv).FirstOrDefault();
                    //svi slobodni klubovi
                    if (vodiZaProveru == null)
                    {
                        klubovi.Add(item);
                        Naziv_kluba.Add(item.naziv);
                    }
                }
            }
            OnPropertyChanged("Naziv_kluba");
        }

        public void LogReport(Trener logObjekat)
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../LogReport.txt", true);
            outPutText = string.Format("KREIRANJE {0} \t TRENER:    ID: {1}, Ime: {2} , Prezime: {3} , Drzava: {4} \n"
                 , DateTime.Now.ToShortDateString(), logObjekat.id_trenera, logObjekat.ime_trenera, logObjekat.prezime_trenera, logObjekat.drzava);

            file.WriteLine(outPutText);
            file.Close();
        }
    }
}
