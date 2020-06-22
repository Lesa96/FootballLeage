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
    public class UpdateIgracViewModel : BindableBase
    {
        
        public static ObservableCollection<Igrac_Selektovan> igraci { get; set; }
        public static ObservableCollection<string> Naziv_Klubova { get; set; }
        private Igrac_Selektovan selektovani_igrac;
        private bool canUpdate;
        public MyICommand UpdateCommand { get; set; }
        public string Utakmice { get; set; }
        public string Golovi { get; set; }
        public string Godine { get; set; }

        public UpdateIgracViewModel()
        {
            igraci = new ObservableCollection<Igrac_Selektovan>();
            Naziv_Klubova = new ObservableCollection<string>();
            UpdateCommand = new MyICommand(OnUpdate);

            ucitajKlubove();

            using (var db = new BazaZaLiguEntities())
            {
                foreach (Klub item in db.Klubs)
                {
                    //svi klubovi
                    Naziv_Klubova.Add(item.naziv);
                }
                Naziv_Klubova.Add("");     //za davanje otkaza iz kluba
            }
            OnPropertyChanged("Naziv_Klubova");
            
        }

        private void ucitajKlubove()
        {
            igraci = new ObservableCollection<Igrac_Selektovan>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Igrac item in db.Igracs)
                {
                    Igrac_Selektovan ig = new Igrac_Selektovan();
                    ig.igrac = item;
                    ig.Prethodni_klub = item.naziv_kluba;
                    igraci.Add(ig);
                }
            }
            OnPropertyChanged("igraci");
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

        public Igrac_Selektovan Selektovani_igrac
        {
            get { return selektovani_igrac; }
            set
            {
                SetProperty(ref selektovani_igrac, value);
                Utakmice = selektovani_igrac.igrac.odigranih_utakmica.ToString();
                Golovi = selektovani_igrac.igrac.postignutih_golova.ToString();
                Godine = selektovani_igrac.igrac.godine_igraca.ToString();
                OnPropertyChanged("Selektovani_igrac");
                OnPropertyChanged("Utakmice");
                OnPropertyChanged("Golovi");
                OnPropertyChanged("Godine");
                if (selektovani_igrac != null)
                    CanUpdate = true;
                else
                    CanUpdate = false;
            }
        }

        public void OnUpdate()
        {
            if (validate())
            {
                using (var db = new BazaZaLiguEntities())
                {
                    double prosek_golova = 0;
                    Igrac igrac_update = db.Igracs.Find(Selektovani_igrac.igrac.id_igraca);

                    if (igrac_update != null)
                    {
                        igrac_update.ime_igraca = Selektovani_igrac.igrac.ime_igraca;
                        igrac_update.prezime_igraca = Selektovani_igrac.igrac.prezime_igraca;
                        igrac_update.odigranih_utakmica = Selektovani_igrac.igrac.odigranih_utakmica;
                        igrac_update.postignutih_golova = Selektovani_igrac.igrac.postignutih_golova;
                        igrac_update.godine_igraca = Selektovani_igrac.igrac.godine_igraca;

                        if (igrac_update.odigranih_utakmica != 0 || igrac_update.postignutih_golova != 0)
                        {
                            prosek_golova = (double)db.Database.SqlQuery<double>($"SELECT [dbo].[Prosek]({igrac_update.postignutih_golova},{igrac_update.odigranih_utakmica})").FirstOrDefault();
                            prosek_golova = Math.Round(prosek_golova, 2);
                        }
                        igrac_update.prosek_golova = prosek_golova;

                        if(Selektovani_igrac.Prethodni_klub == Selektovani_igrac.igrac.naziv_kluba || (Selektovani_igrac.Prethodni_klub == null && (Selektovani_igrac.igrac.naziv_kluba == "" || Selektovani_igrac.igrac.naziv_kluba == null))) // nije promenio
                        {
                            db.Entry(igrac_update).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();

                            MessageBox.Show("Uspesno ste promenili igraca", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            return;
                        }
                        else if(Selektovani_igrac.igrac.naziv_kluba == "" || Selektovani_igrac.igrac.naziv_kluba == null) //dao je otkaz u klubu
                        {
                            Klub stariKlub = db.Klubs.Where(x=> x.naziv == selektovani_igrac.igrac.vodi_naziv).FirstOrDefault();
                            if(stariKlub != null)
                            {
                                Vodi stari_trener = db.Vodis.Where(x => x.klub_naziv == stariKlub.naziv).FirstOrDefault();
                                stari_trener.Igracs.Remove(Selektovani_igrac.igrac);
                                stariKlub.Igracs.Remove(Selektovani_igrac.igrac);
                            }
                            igrac_update.naziv_kluba = null;
                            db.Entry(igrac_update).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                          
                            igrac_update.Vodi = null;
                        }
                        else    //odabrao je drugi klub
                        {
                            igrac_update.naziv_kluba = Selektovani_igrac.igrac.naziv_kluba;
                            Klub novi_klub_igraca = db.Klubs.Find(igrac_update.naziv_kluba);
                            igrac_update.Klub = novi_klub_igraca;

                            Vodi stari_trener = db.Vodis.Where(x => x.klub_naziv == Selektovani_igrac.igrac.vodi_naziv).FirstOrDefault();
                            if(stari_trener != null)
                            {
                                stari_trener.Igracs.Remove(Selektovani_igrac.igrac);
                                db.SaveChanges();
                            }
                                                                                  
                            Vodi trener_Novog_Kluba = db.Vodis.Where(x => x.klub_naziv == novi_klub_igraca.naziv).FirstOrDefault();                            
                            igrac_update.Vodi = trener_Novog_Kluba;

                            //generise sledeci ID:
                            int nextID = 0;
                            transferistorija proveraIDa = null;
                            do
                            {
                                proveraIDa = db.transferistorijas.Where(x => x.id == nextID + 1).FirstOrDefault();
                                nextID++;
                            }
                            while (proveraIDa != null);
                            transferistorija transfer = new transferistorija() { id = nextID, Igrac = igrac_update, klub = igrac_update.naziv_kluba };
                            transfer.datum = DateTime.Now.ToShortDateString();
                            db.transferistorijas.Add(transfer);
                            db.SaveChanges();

                        }


                        db.Entry(igrac_update).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        MessageBox.Show("Uspesno ste promenili igraca", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                }

                ucitajKlubove();
            }
        }

        public bool validate()
        {
            if (Selektovani_igrac.igrac.ime_igraca == "" || Selektovani_igrac.igrac.prezime_igraca == "" || Golovi == "" || Utakmice == "" || Godine == "")
            {
                MessageBox.Show("Potrebno je popuniti sva polja !", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            bool isNan = int.TryParse(Golovi, out int x);
            if (!isNan)
            {
                MessageBox.Show("Broj datih golova mora biti BROJ", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            isNan = int.TryParse(Utakmice, out int y);
            if (!isNan)
            {
                MessageBox.Show("Broj odigranih utakmica mora biti BROJ", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            isNan = int.TryParse(Godine, out int z);
            if (!isNan)
            {
                MessageBox.Show("Godine moraju biti BROJ", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            Selektovani_igrac.igrac.postignutih_golova = int.Parse(Golovi);
            Selektovani_igrac.igrac.odigranih_utakmica = int.Parse(Utakmice);
            Selektovani_igrac.igrac.godine_igraca = int.Parse(Godine);
            return true;


        }
    }
}
