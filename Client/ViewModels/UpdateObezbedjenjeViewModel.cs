using Client.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace Client.ViewModels
{
    public class UpdateObezbedjenjeViewModel : BindableBase
    {
        public static ObservableCollection<Radnik_Selektovan> radnici { get; set; }
        public static ObservableCollection<Poseduje_Selektovan> poseduju { get; set; }
        private Radnik_Selektovan radnik_selektovan;
        private bool canUpdate;
        public MyICommand UpdateCommand { get; set; }
        public ObservableCollection<string> Drzave { get; set; }

        public UpdateObezbedjenjeViewModel()
        {
            UpdateCommand = new MyICommand(OnUpdate);
            ucitajRadnike();
            ucitajPoseduje();
            ucitajDrzave();
        }



        private void ucitajRadnike()
        {
            Radnici = new ObservableCollection<Radnik_Selektovan>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Obezbedjenje item in db.Obezbedjenjes)
                {
                    Radnik_Selektovan rad = new Radnik_Selektovan() { Radnik = item , IsSelected = false};
                    rad.Klub_Stadion_Nazivi = new ObservableCollection<string>();
                    foreach (Poseduje poseduje in item.Posedujes)
                    {
                        Stadion stadion = db.Stadions.Find(poseduje.stadion_id_stadiona);
                        rad.Klub_Stadion_Nazivi.Add(stadion.naziv_stadiona + " (" + poseduje.klub_naziv + ")");

                    }
                    radnici.Add(rad);
                }
            }
            OnPropertyChanged("Radnici");
        }

        private void ucitajPoseduje() //svi stadioni i njihovi vlasnici
        {
            Poseduju = new ObservableCollection<Poseduje_Selektovan>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Poseduje posed in db.Posedujes)
                {
                    Poseduje_Selektovan pos = new Poseduje_Selektovan() { P = posed, IsSelected = false };
                    Stadion stadion = db.Stadions.Find(posed.stadion_id_stadiona);
                    pos.Klub_Stadion_Nazivi = stadion.naziv_stadiona + " (" + posed.klub_naziv + ")";
                    Poseduju.Add(pos);
                }
                OnPropertyChanged("Poseduju");
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

        public bool CanUpdate
        {
            get { return canUpdate; }
            set
            {
                canUpdate = value;
                OnPropertyChanged("CanUpdate");
            }
        }

        public ObservableCollection<Poseduje_Selektovan> Poseduju
        {
            get { return poseduju; }
            set
            {
                poseduju = value;
                OnPropertyChanged("Poseduju");
            }
        }
        public ObservableCollection<Radnik_Selektovan> Radnici
        {
            get { return radnici; }
            set
            {
                radnici = value;
                OnPropertyChanged("Radnici");
            }
        }

        public Radnik_Selektovan Selektovani_radnik
        {
            get { return radnik_selektovan; }
            set
            {
                SetProperty(ref radnik_selektovan, value);
                OnPropertyChanged("Selektovani_radnik");
                if (radnik_selektovan != null)      //kad ga promeni, selektovan predje na null, tad ne treba namestati checkbox
                    namestiCheckBoxove();

                if (radnik_selektovan != null)
                    CanUpdate = true;
                else
                    CanUpdate = false;
            }
        }

        private void namestiCheckBoxove()
        {
            ObservableCollection<Poseduje_Selektovan> noviPoseduje = new ObservableCollection<Poseduje_Selektovan>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Poseduje_Selektovan poseduje in Poseduju)
                {
                    Poseduje_Selektovan novPosedujeSelektovan = new Poseduje_Selektovan() {
                        P = db.Posedujes.Where(x => 
                            x.klub_naziv == poseduje.P.klub_naziv && x.stadion_id_stadiona == poseduje.P.stadion_id_stadiona).FirstOrDefault()
                    };
                    novPosedujeSelektovan.Klub_Stadion_Nazivi = poseduje.Klub_Stadion_Nazivi;



                    if (Selektovani_radnik.Klub_Stadion_Nazivi.Contains(poseduje.Klub_Stadion_Nazivi))
                    {
                        novPosedujeSelektovan.IsSelected = true;
                    }
                    else
                        novPosedujeSelektovan.IsSelected = false;
                    noviPoseduje.Add(novPosedujeSelektovan);

                }
                Poseduju = new ObservableCollection<Poseduje_Selektovan>();
                Poseduju = noviPoseduje;
                OnPropertyChanged("Poseduju");
            }
        }

        private void OnUpdate()
        {
            if (validate())
                using (var db = new BazaZaLiguEntities())
                {
                    Obezbedjenje novi_radnik = db.Obezbedjenjes.Find(Selektovani_radnik.Radnik.id_radnika);
                    novi_radnik.ime_radnika = Selektovani_radnik.Radnik.ime_radnika;
                    novi_radnik.prezime_radnika = Selektovani_radnik.Radnik.prezime_radnika;
                    novi_radnik.drzava = Selektovani_radnik.Radnik.drzava;

                    novi_radnik.Posedujes.Clear();
                    db.Entry(novi_radnik).State = System.Data.Entity.EntityState.Modified;
                    foreach (Poseduje_Selektovan poseduje in Poseduju)
                    {
                        if (poseduje.IsSelected)
                        {
                            Poseduje noviStadionKlub = db.Posedujes.Where(x =>
                            x.klub_naziv == poseduje.P.klub_naziv && x.stadion_id_stadiona == poseduje.P.stadion_id_stadiona).FirstOrDefault();

                            novi_radnik.Posedujes.Add(noviStadionKlub);
                        }
                    }
                    db.Entry(novi_radnik).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ucitajRadnike();
                    ucitajPoseduje();
                    MessageBox.Show("Uspesno ste promenili radnika", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
        }

        private bool validate()
        {
            if (Selektovani_radnik.Radnik.ime_radnika == "" || Selektovani_radnik.Radnik.prezime_radnika == "" || Selektovani_radnik.Radnik.drzava == "")
            {
                MessageBox.Show("Potrebno je popuniti sva polja", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
    }
}
