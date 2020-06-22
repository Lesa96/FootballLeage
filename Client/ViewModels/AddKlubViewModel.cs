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
    public class AddKlubViewModel : BindableBase
    {
        public ObservableCollection<Liga> lige { get; set; }
        public ObservableCollection<string> Naziv_lige { get; set; }
        public static ObservableCollection<Stadion_Selektovan> stadioni { get; set; }
        public string Vrednost { get; set; }


        public MyICommand addCommand { get; set; }
        private string selektovanaLiga;
        private Klub klub;

        public Klub Klub_prop
        {
            get { return klub; }
            set
            {
                SetProperty(ref klub, value);
                OnPropertyChanged("Klub_prop");
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

        public AddKlubViewModel()
        {
            dodajStadione();
            

            addCommand = new MyICommand(OnDodajKlub);
            lige = new ObservableCollection<Liga>();
            //vlasnici = new ObservableCollection<Vlasnik_Selektovan>();
            Naziv_lige = new ObservableCollection<string>();
            //dodajVlasnike();

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

            Klub_prop = new Klub() { naziv = "", grad = "" };
        }
        public void dodajStadione()
        {
            stadioni = new ObservableCollection<Stadion_Selektovan>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Stadion stad in db.Stadions)
                {
                    Stadion_Selektovan s = new Stadion_Selektovan() { S = stad, IsSelected = false, Naziv_stadiona = stad.naziv_stadiona };
                    stadioni.Add(s);
                }
            }
            
            OnPropertyChanged("stadioni");
        }

        

        public void OnDodajKlub()
        {
            if (validate())
            {
                List<Stadion> stadioni_zaDodavanje = new List<Stadion>() ;
                using (var db = new BazaZaLiguEntities())   // dodaj selektovane stadione
                {
                    foreach(Stadion_Selektovan stadion in stadioni) 
                    {
                        if (stadion.IsSelected)
                        {
                            Stadion stadionProvera = db.Stadions.Find(stadion.S.id_stadiona);

                            stadioni_zaDodavanje.Add(stadionProvera);
                        }
                    }
                }

                using (var db = new BazaZaLiguEntities())
                {
                   
                    Klub novi_klub = new Klub() { naziv = Klub_prop.naziv, grad = Klub_prop.grad , vrednost = Klub_prop.vrednost };
                    foreach (Stadion item in stadioni_zaDodavanje)
                    {
                        Stadion stadion_dodaj = db.Stadions.Find(item.id_stadiona);
                        Poseduje p1 = new Poseduje() { Klub = novi_klub, Stadion = stadion_dodaj, klub_naziv = novi_klub.naziv, stadion_id_stadiona = item.id_stadiona };
                        db.Posedujes.Add(p1);
                    }

                    if(SelektovanaLiga != "" && SelektovanaLiga != null && SelektovanaLiga != "None")
                    {
                        Liga liga_dodaj = db.Ligas.Where(x => x.naziv_lige == SelektovanaLiga).FirstOrDefault();
                        novi_klub.liga_id_lige = liga_dodaj.id_lige;
                        novi_klub.Liga = liga_dodaj;
                        //liga_dodaj.broj_klubova++;
                        
                    }

                    db.Klubs.Add(novi_klub);
                    

                    db.SaveChanges();
                    MessageBox.Show("Klub je uspesno dodat","Uspesno" , MessageBoxButton.OK,MessageBoxImage.Asterisk);
                    LogReport(novi_klub);
                }
            }
        }

        public bool validate()
        {
            if(Klub_prop.naziv == "" || Klub_prop.grad =="" || Vrednost == "")
            {
                MessageBox.Show("Potrebno je popuniti sva polja","Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else
            {
                

                using (var db = new BazaZaLiguEntities())
                {
                    var klubZaProveru = db.Klubs.Find(Klub_prop.naziv);
                    if (klubZaProveru != null)
                    {
                        MessageBox.Show("Naziv (ID) kluba vec postoji", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return false;
                    }
                }
            }
            bool isNan = int.TryParse(Vrednost, out int x);
            if (!isNan)
            {
                MessageBox.Show("Vrednost kluba mora biti BROJ", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            Klub_prop.vrednost = int.Parse(Vrednost);
            return true;
        }

        public void LogReport(Klub logObjekat)
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../LogReport.txt", true);
            outPutText = string.Format("KREIRANJE {0} \t KLUB:    Naziv: {1} , Grad: {2} \n"
                 , DateTime.Now.ToShortDateString(), logObjekat.naziv, logObjekat.grad);

            file.WriteLine(outPutText);
            file.Close();
        }


    }
}

