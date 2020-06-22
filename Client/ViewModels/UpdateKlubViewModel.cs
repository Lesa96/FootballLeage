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
    public class UpdateKlubViewModel : BindableBase
    {
        public static ObservableCollection<string> Naziv_lige { get; set; }
        public static ObservableCollection<String> naziv_Trenera { get; set; }
        public static ObservableCollection<Klub_Selektovan> klubUpdate { get; set; }
        private Klub_Selektovan selektovana_klub;
        private bool canUpdate;
        public MyICommand UpdateCommand { get; set; }
        public string Vrednost { get; set; }

        public UpdateKlubViewModel()
        {
            
            
            UpdateCommand = new MyICommand(onUpdate);
            ucitajKlubove();
            ucitajTrenereILige();
                       
        }

        private void ucitajTrenereILige()
        {
            Naziv_lige = new ObservableCollection<string>();
            Naziv_Trenera = new ObservableCollection<string>();

            using (var db = new BazaZaLiguEntities())
            {
                foreach (Liga item in db.Ligas)
                {
                    //sve lige
                    Naziv_lige.Add(item.naziv_lige);
                }
                Naziv_lige.Add("");     //za davanje otkaza iz lige

                foreach (Trener item in db.Treners)
                {
                    Vodi zauzetiTrener = db.Vodis.Where(x => x.trener_id_trenera == item.id_trenera).FirstOrDefault();
                    //svi slobodni treneri
                    if (zauzetiTrener == null)
                    {
                        Naziv_Trenera.Add(item.ime_trenera);
                    }
                }


                Naziv_Trenera.Add("");

            }

            OnPropertyChanged("Naziv_lige");
            OnPropertyChanged("Naziv_Trenera");
        }

        private void ucitajKlubove()
        {
            KlubUpdate = new ObservableCollection<Klub_Selektovan>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Klub item in db.Klubs)
                {
                    Klub_Selektovan klubS = new Klub_Selektovan() { K = item };
                    KlubUpdate.Add(klubS);

                    if (item.Liga != null)
                    {
                        klubS.Naziv_lige = item.Liga.naziv_lige;
                    }
                    //trener
                    Vodi vod = db.Vodis.Where(x => x.klub_naziv == item.naziv).FirstOrDefault();
                    if (vod != null)
                    {
                        Trener trener = db.Treners.Find(vod.trener_id_trenera);
                        klubS.Trener = trener.ime_trenera;
                    }
                    //broj navijaca
                    klubS.Broj_Navijaca = 0;
                    if (item.Navijacs != null)
                    {
                        klubS.Broj_Navijaca = item.Navijacs.Count;
                    }
                }
            }
            OnPropertyChanged("KlubUpdate");
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

        public Klub_Selektovan Selektovana_klub
        {
            get { return selektovana_klub; }
            set
            {
                SetProperty(ref selektovana_klub, value);
                OnPropertyChanged("Selektovana_klub");
                
                if (selektovana_klub != null)
                {
                    Vrednost = Selektovana_klub.K.vrednost.ToString();
                    OnPropertyChanged("Vrednost");
                    CanUpdate = true;
                }
                    
                else
                    CanUpdate = false;

            }
        }

        public ObservableCollection<String> Naziv_Trenera
        {
            get { return naziv_Trenera; }
            set
            {
                naziv_Trenera = value;
                OnPropertyChanged("Naziv_Trenera");
            }
        }
        public  ObservableCollection<Klub_Selektovan> KlubUpdate
        {
            get { return klubUpdate; }
            set
            {
                klubUpdate = value;
                OnPropertyChanged("KlubUpdate");
            }
        }

        public void onUpdate()
        {
            if(validate())
            {
                using (var db = new BazaZaLiguEntities())
                {
                    Klub klub_update = db.Klubs.Where(x => x.naziv.Equals(Selektovana_klub.K.naziv)).FirstOrDefault();

                    if (klub_update != null)
                    {
                        klub_update.grad = Selektovana_klub.K.grad;
                        if (klub_update.Liga != null) //igrao je u nekoj ligi pre toga, brisi ga iz stare lige
                        {
                            Liga liga = db.Ligas.Find(klub_update.Liga.id_lige);
                            liga.Klubs.Remove(klub_update);
                            db.SaveChanges();
                        }
                        Liga nova_liga = db.Ligas.Where(x => x.naziv_lige == Selektovana_klub.Naziv_lige).FirstOrDefault();
                        klub_update.Liga = nova_liga; //ako je odabrao prazno stavice null

                        if(klub_update.Vodis.Count > 0) // imao je trenera, brisi starog
                        {
                            Vodi stariTrener = db.Vodis.Where(x => x.klub_naziv == klub_update.naziv).FirstOrDefault();
                            List<Igrac> igraciKluba = stariTrener.Igracs.ToList();
                            foreach (Igrac item in igraciKluba)
                            {
                                Igrac igrac = db.Igracs.Find(item.id_igraca);
                                igrac.Vodi = null;
                                igrac.vodi_id_trenera = null;
                                igrac.vodi_naziv = null;
                                db.Entry(igrac).State = System.Data.Entity.EntityState.Modified;
                            }
                            db.Vodis.Remove(stariTrener);
                            db.SaveChanges();
                        }
                        if(Selektovana_klub.Trener != "" && Selektovana_klub.Trener != null) //odabrao je novog
                        {
                            Vodi noviVodi = new Vodi() { klub_naziv = klub_update.naziv };
                            Trener noviTrener = db.Treners.Where(x => x.ime_trenera == Selektovana_klub.Trener).FirstOrDefault();
                            noviVodi.trener_id_trenera = noviTrener.id_trenera;
                            db.Vodis.Add(noviVodi);
                            db.SaveChanges();
                            foreach (Igrac igrac in db.Igracs)
                            {
                                if(igrac.naziv_kluba == klub_update.naziv)
                                {
                                    igrac.Vodi = noviVodi;
                                    db.Entry(igrac).State = System.Data.Entity.EntityState.Modified;
                                }                               
                            }
                        }
                        
                        db.Entry(klub_update).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Uspesno ste promenili klub", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                    ucitajKlubove();
                    ucitajTrenereILige();
                    Vrednost = "";
                    OnPropertyChanged("Vrednost");
                }
            }
        }

        public bool validate()
        {
            if (Selektovana_klub.K.grad == "" || Vrednost == "")
            {
                MessageBox.Show("Potrebno je popuniti sva polja !", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            bool isNan = int.TryParse(Vrednost, out int x);
            if (!isNan)
            {
                MessageBox.Show("Vrednost kluba mora biti BROJ", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            Selektovana_klub.K.vrednost = int.Parse(Vrednost);
            return true;
        }
    }
}
