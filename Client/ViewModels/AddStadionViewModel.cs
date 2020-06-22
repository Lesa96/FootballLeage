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
    public class AddStadionViewModel : BindableBase
    {
        public MyICommand addCommand { get; set; }
        private Stadion stadion;
        public static ObservableCollection<Klub_Selektovan> klubovi { get; set; }
        public string Kapacitet { get; set; }

        public Stadion Stadion_prop
        {
            get { return stadion; }
            set
            {
                SetProperty(ref stadion, value);
                OnPropertyChanged("Stadion_prop");
            }
        }

        public AddStadionViewModel()
        {
            addCommand = new MyICommand(OnAdd);
            dodajKlubove();

            Stadion_prop = new Stadion() { id_stadiona = 0, naziv_stadiona = "", grad= "" , kapacitet = -1 };            
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
                    //id logic
                    int nextID = 0;
                    Stadion proveraID = null;
                    do
                    {
                        proveraID = db.Stadions.Where(x => x.id_stadiona == nextID + 1).FirstOrDefault();
                        nextID++;
                    }
                    while (proveraID != null);

                    Stadion novi_stadion = new Stadion() { id_stadiona = nextID, naziv_stadiona = Stadion_prop.naziv_stadiona , grad = Stadion_prop.grad, kapacitet = Stadion_prop.kapacitet };                    

                    db.Stadions.Add(novi_stadion);
                    db.SaveChanges();
                    foreach (Klub klub in klub_zaDodavanje)
                    {
                        Poseduje poseduje = new Poseduje() { Klub = klub, Stadion = novi_stadion };
                        db.Posedujes.Add(poseduje);
                        db.SaveChanges();
                    }
                    MessageBox.Show("Uspesno ste dodali stadion", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    LogReport(novi_stadion);
                }
           }
        }

        private bool validate()
        {
            if (Stadion_prop.naziv_stadiona == "" || Stadion_prop.naziv_stadiona == null || Stadion_prop.grad == "" || Stadion_prop.grad == null || Kapacitet == "" || Kapacitet== null)
            {
                MessageBox.Show("Potrebno je popuniti sva polja", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            bool isNan = int.TryParse(Kapacitet, out int x);
            if (!isNan)
            {
                MessageBox.Show("Kapacitet stadiona (Broj sedista) mora biti BROJ", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            Stadion_prop.kapacitet = int.Parse(Kapacitet);
            return true;
        }

        public void LogReport(Stadion logObjekat)
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../LogReport.txt", true);
            outPutText = string.Format("KREIRANJE {0} \t STADION:    ID: {1}, Naziv: {2} , Grad: {3}\n"
                 , DateTime.Now.ToShortDateString(), logObjekat.id_stadiona, logObjekat.naziv_stadiona, logObjekat.grad);

            file.WriteLine(outPutText);
            file.Close();
        }
    }
}
