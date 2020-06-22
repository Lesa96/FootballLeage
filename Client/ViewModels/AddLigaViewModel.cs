using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using Client.Model;

namespace Client.ViewModels
{
    public class AddLigaViewModel : BindableBase
    {
        public ObservableCollection<Sudija_Selektovan> sudije { get; set; }
        public static ObservableCollection<Sponzor_Selektovan> sponzori { get; set; }
        public MyICommand addCommand { get; set; }
        public ObservableCollection<string> Drzave { get; set; }
        private Liga liga;

        public Liga Liga_prop
        {
            get { return liga; }
            set
            {
                SetProperty(ref liga, value);
                OnPropertyChanged("Liga_prop");
            }
        }

      


        public AddLigaViewModel()
        {
            Drzave = new ObservableCollection<string>();
            addCommand = new MyICommand(OnDodajLigu);
            sudije = new ObservableCollection<Sudija_Selektovan>();
            sponzori = new ObservableCollection<Sponzor_Selektovan>();
            Liga_prop = new Liga() {naziv_lige = "", drzava_lige = "" , id_lige = 0  , broj_klubova = 0};
            ucitajSlobodneSudije();
            ucitajSponzore();
            ucitajDrzave();
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

        public void ucitajSlobodneSudije()
        {           
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Sudija sud in db.Sudijas.Where(x=> x.liga_id_lige == null).ToList())
                {
                    Sudija_Selektovan s = new Sudija_Selektovan() { S = sud, IsSelected = false, Naziv_sudije = sud.ime_sudije + " " + sud.prezime_sudije };
                    sudije.Add(s);
                }
            }                            
            OnPropertyChanged("sudije");
        }

        public void ucitajSponzore()
        {                                 
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Sponzor sponzor in db.Sponzors)
                {
                    Sponzor_Selektovan s1 = new Sponzor_Selektovan() { S = sponzor, Naziv_sponzora = sponzor.naziv, SelectedItem = false };
                    sponzori.Add(s1);
                }

                OnPropertyChanged("sponzori");
            }
        }

        public void OnDodajLigu()
        {
            if (validate())
            {
                //ShowLigaViewModel.dodajLigu(Liga_prop);
                using (var db = new BazaZaLiguEntities())
                {
                    Liga l1 = new Liga() { naziv_lige = Liga_prop.naziv_lige, drzava_lige = Liga_prop.drzava_lige  , broj_klubova = 0};
                    //generise sledeci ID:
                    List<Liga> lige = db.Ligas.ToList();
                    //id logic
                    int nextID = 0;
                    Liga proveraID = null;
                    do
                    {
                        proveraID = db.Ligas.Where(x => x.id_lige == nextID + 1).FirstOrDefault();
                        nextID++;
                    }
                    while (proveraID != null);
                    l1.id_lige = nextID;

                    foreach (Sudija sud in Liga_prop.Sudijas) //dodavanje sudija u ligu
                    {                        
                        Sudija sudijaUpdate = db.Sudijas.Find(sud.id_sudije);    
                        l1.Sudijas.Add(sudijaUpdate);
                    }

                    foreach (Sponzor_Selektovan sponzor in sponzori) // dodavanje sponzora
                    {
                        if (sponzor.SelectedItem)
                        {
                            Sponzor selektovanSponzor = db.Sponzors.Find(sponzor.S.id_sponzora);                           
                            l1.Sponzors.Add(selektovanSponzor); //ovo funkcionise                            
                        }
                    }
                    
                    db.Ligas.Add(l1);
                    db.SaveChanges();
                    LogReport(l1);


                }
                MessageBox.Show("Liga je uspesno dodata", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                

                //vrati na prazno :
                Liga_prop.drzava_lige = "";
                Liga_prop.naziv_lige = "";
                Liga_prop.id_lige = 0;
                foreach (Sudija_Selektovan item in sudije) //smisli nesto za ovo
                {
                    item.IsSelected = false;
                    
                }
                OnPropertyChanged("Liga_prop");
                OnPropertyChanged("sudije");
                
                
            }
        }

        public bool validate()
        {
            
            bool val = true;
            using (var db = new BazaZaLiguEntities())
            {

                //var ligaZaProveru = db.Ligas.Find(Liga_prop.id_lige);
                var ligaZaProveruNaziv = db.Ligas.Where(x=> x.naziv_lige == Liga_prop.naziv_lige).FirstOrDefault();

                if (ligaZaProveruNaziv != null)
                {
                    MessageBox.Show("Postoji liga sa tim nazivom", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                    val = false;
                }
                else if (Liga_prop.naziv_lige == "")
                {
                    MessageBox.Show("Naziv lige mora biti popunjen", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                    val = false;
                }
                else if (Liga_prop.drzava_lige == "" || Liga_prop.drzava_lige == null)
                {
                    MessageBox.Show("Drzava lige mora biti popunjen", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                    val = false;
                }
                else
                {

                    

                    int selektovane_sudije = 0;
                    foreach (Sudija_Selektovan item in sudije)
                    {
                        if (item.IsSelected)
                        {
                            var sudijaProvera = db.Sudijas.Find(item.S.id_sudije);
                            if (sudijaProvera.liga_id_lige == null) // ovo treba menjati jer u bazi nema
                            {
                                selektovane_sudije++;
                                Liga_prop.Sudijas.Add(item.S);
                            }
                            else
                            {
                                MessageBox.Show("Sudija vec sudi u jednoj ligi", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                               return false;
                            }

                            

                        }
                    }
                    foreach (Sponzor_Selektovan item in sponzori)
                    {
                        //var sponzorProvera = db.Sponzors.Find(item.S.id_sponzora);
                        Liga_prop.Sponzors.Add(item.S);
                    }

                    if (selektovane_sudije <= 0)
                    {
                        MessageBox.Show("Potrebno je odabrati bar jednog sudiju", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                        val = false;
                    }
                }


            }

            return val;
        }

        public void LogReport(Liga logObjekat)
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../LogReport.txt", true);
            outPutText = string.Format("KREIRANJE {0} \t LIGA:    ID: {1}  ,Naziv: {2} , Drzava: {3}\n"
                 , DateTime.Now.ToShortDateString(), logObjekat.id_lige, logObjekat.naziv_lige, logObjekat.drzava_lige);

            file.WriteLine(outPutText);
            file.Close();
        }
    }
}
