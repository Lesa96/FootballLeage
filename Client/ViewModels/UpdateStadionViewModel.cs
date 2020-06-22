using Client.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    public class UpdateStadionViewModel : BindableBase
    {
        public static ObservableCollection<Stadion_Selektovan> stadioni { get; set; }
        public static ObservableCollection<Klub_Selektovan> klubovi { get; set; }
        private Stadion_Selektovan selektovani_stadion;
        private bool canUpdate;
        public MyICommand UpdateCommand { get; set; }
        public string Kapacitet { get; set; }

        public UpdateStadionViewModel()
        {
            UpdateCommand = new MyICommand(OnUpdate);

            ucitajStadione();
            ucitajKlubove();
        }        

        private void ucitajKlubove()
        {
            Klubovi = new ObservableCollection<Klub_Selektovan>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Klub klub in db.Klubs)
                {
                    Klub_Selektovan kl = new Klub_Selektovan() { K = klub, IsSelected = false };
                    Klubovi.Add(kl);
                }
                OnPropertyChanged("Klubovi");
            }
        }
        private void ucitajStadione()
        {
            Stadioni = new ObservableCollection<Stadion_Selektovan>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Stadion item in db.Stadions)
                {
                    Stadion_Selektovan stad = new Stadion_Selektovan() { S = item, IsSelected = false };
                    stad.Nazivi_klubova = new ObservableCollection<string>();
                    foreach (Poseduje poseduje in item.Posedujes)
                    {
                        stad.Nazivi_klubova.Add(poseduje.klub_naziv);
                    }
                    Stadioni.Add(stad);
                }
            }
            OnPropertyChanged("Stadioni");
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

        public Stadion_Selektovan Selektovani_stadion
        {
            get { return selektovani_stadion; }
            set
            {
                SetProperty(ref selektovani_stadion, value);
                
                OnPropertyChanged("Selektovani_stadion");
                
                if (selektovani_stadion != null)      //kad ga promeni, selektovan predje na null, tad ne treba namestati checkbox
                {
                    Kapacitet = selektovani_stadion.S.kapacitet.ToString();
                    OnPropertyChanged("Kapacitet");
                    namestiCheckBoxove();
                }

                if (selektovani_stadion != null)
                    CanUpdate = true;
                else
                    CanUpdate = false;
            }
        }

        public ObservableCollection<Klub_Selektovan> Klubovi
        {
            get { return klubovi; }
            set
            {
                klubovi = value;
                OnPropertyChanged("Klubovi");
            }
        }
        public ObservableCollection<Stadion_Selektovan> Stadioni
        {
            get { return stadioni; }
            set
            {
                stadioni = value;
                OnPropertyChanged("Stadioni");
            }
        }

        private void namestiCheckBoxove()
        {
            ObservableCollection<Klub_Selektovan> noviKlubovi = new ObservableCollection<Klub_Selektovan>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Klub_Selektovan klub in Klubovi)
                {
                    Klub_Selektovan novKlubSelektovan = new Klub_Selektovan() { K = db.Klubs.Find(klub.K.naziv) };

                    if (Selektovani_stadion.Nazivi_klubova.Contains(klub.K.naziv))
                    {
                        novKlubSelektovan.IsSelected = true;
                    }
                    else
                        novKlubSelektovan.IsSelected = false;
                    noviKlubovi.Add(novKlubSelektovan);

                }
                Klubovi = new ObservableCollection<Klub_Selektovan>();
                Klubovi = noviKlubovi;
                OnPropertyChanged("Klubovi");
            }
        }

        private void OnUpdate()
        {
            if(validate())
                using (var db = new BazaZaLiguEntities())
                {
                    Stadion novi_stadion = db.Stadions.Find(Selektovani_stadion.S.id_stadiona);
                    novi_stadion.naziv_stadiona = Selektovani_stadion.S.naziv_stadiona;
                    novi_stadion.grad = Selektovani_stadion.S.grad;
                    novi_stadion.kapacitet = Selektovani_stadion.S.kapacitet;

                    
                    List<Poseduje> provera_poseduje = db.Posedujes.Where(x => x.stadion_id_stadiona == novi_stadion.id_stadiona).ToList();
                    List<string> stariKlubovi = new List<string>();  //bili su ranije selektovani
                    foreach (var item in provera_poseduje)
                    {
                        stariKlubovi.Add(item.Klub.naziv);
                    }

                    
                    //novi_stadion.Posedujes.Clear();
                    //
                    foreach (Klub_Selektovan klub in Klubovi)
                    {
                        if (klub.IsSelected)
                        {
                            if (!stariKlubovi.Contains(klub.K.naziv)) //Nije bio selektovan, sad jeste
                            {
                                Klub kl = db.Klubs.Find(klub.K.naziv);
                                Poseduje poseduje = new Poseduje() { Klub = kl, Stadion = novi_stadion };
                                db.Posedujes.Add(poseduje);
                                db.SaveChanges();
                            }
                          
                        }
                        else if(stariKlubovi.Contains( klub.K.naziv)) //bio je selektovan, sad nije
                        {
                            // radnici dobiju otkaz, brisi ako samo tu rade
                            Poseduje item = provera_poseduje.Where(x => x.klub_naziv == klub.K.naziv && x.stadion_id_stadiona == novi_stadion.id_stadiona).FirstOrDefault();
                            List<Obezbedjenje> radnici = item.Obezbedjenjes.ToList();
                            foreach (Obezbedjenje obez in radnici) //radnici , obezbedjenje
                            {
                                Obezbedjenje obezbedjenje = db.Obezbedjenjes.Find(obez.id_radnika);
                                if (obezbedjenje.Posedujes.Count < 2) //brisi radnike koji rade samo tu
                                {
                                    db.Obezbedjenjes.Remove(obezbedjenje);
                                    db.SaveChanges();
                                }

                            }
                            db.Posedujes.Remove(item);  //brisi vezu izmedju stadiona i kluba
                            db.SaveChanges();
                            
                        }
                    }
                    db.Entry(novi_stadion).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ucitajStadione();
                    ucitajKlubove();
                    Kapacitet = "";
                    OnPropertyChanged("Kapacitet");
                    MessageBox.Show("Uspesno ste promenili stadion", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
        }

        private bool validate()
        {
            if (Selektovani_stadion.S.naziv_stadiona == "" || Selektovani_stadion.S.naziv_stadiona == null || Selektovani_stadion.S.grad == "" || Selektovani_stadion.S.grad == null || Kapacitet == "" || Kapacitet == null)
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
            Selektovani_stadion.S.kapacitet = int.Parse(Kapacitet);
            
            return true;
        }
    }
}
