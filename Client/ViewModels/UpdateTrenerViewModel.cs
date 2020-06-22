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
    public class UpdateTrenerViewModel : BindableBase
    {
        public static ObservableCollection<Trener_Selektovan> treneri { get; set; }
        private Trener_Selektovan selektovani_trener;
        public static ObservableCollection<string> Naziv_Klubova { get; set; }
        private bool canUpdate;
        public MyICommand UpdateCommand { get; set; }
        public ObservableCollection<string> Drzave { get; set; }

        public UpdateTrenerViewModel()
        {                        
            UpdateCommand = new MyICommand(OnUpdate);
            ucitajKlubove();
            ucitajTrenera();
            ucitajDrzave();
        }

        private void ucitajTrenera()
        {
            treneri = new ObservableCollection<Trener_Selektovan>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Trener item in db.Treners)
                {
                    Trener_Selektovan trener = new Trener_Selektovan() { T = item };
                    Vodi klubTrenera = db.Vodis.Where(x => x.trener_id_trenera == item.id_trenera).FirstOrDefault();
                    if (klubTrenera != null)
                    {
                        trener.Naziv_Kluba = klubTrenera.klub_naziv;
                    }
                    treneri.Add(trener);
                }
            }
            OnPropertyChanged("treneri");
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

        private void ucitajKlubove()
        {
            Naziv_Klubova = new ObservableCollection<string>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Klub item in db.Klubs)
                {
                    //svi slobodni klubovi
                    Vodi vodi = db.Vodis.Where(x => x.klub_naziv == item.naziv).FirstOrDefault();
                    if(vodi == null)
                    {
                        Naziv_Klubova.Add(item.naziv);
                    }                   
                }
                Naziv_Klubova.Add("");     //za davanje otkaza iz kluba
            }
            OnPropertyChanged("Naziv_Klubova");
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

        public Trener_Selektovan Selektovani_trener
        {
            get { return selektovani_trener; }
            set
            {
                SetProperty(ref selektovani_trener, value);
                OnPropertyChanged("Selektovani_trener");

                if (selektovani_trener != null)
                    CanUpdate = true;
                else
                    CanUpdate = false;
            }
        }

        public void OnUpdate()
        {
            if(validate())
            {
                using (var db = new BazaZaLiguEntities())
                {
                    Trener trener_update = db.Treners.Find(Selektovani_trener.T.id_trenera);

                    if (trener_update != null)
                    {
                        trener_update.ime_trenera = Selektovani_trener.T.ime_trenera;
                        trener_update.prezime_trenera = Selektovani_trener.T.prezime_trenera;
                        trener_update.drzava = Selektovani_trener.T.drzava;

                        if (trener_update.Vodis.Count > 0) //sudio je negde 
                        {
                            Vodi stariKlub = db.Vodis.Where(x => x.trener_id_trenera == trener_update.id_trenera).FirstOrDefault();
                            foreach (Igrac igrac in db.Igracs)
                            {
                                if (igrac.naziv_kluba == stariKlub.klub_naziv)
                                {
                                    igrac.Vodi = null;
                                    db.Entry(igrac).State = System.Data.Entity.EntityState.Modified;
                                }

                            }
                            db.Vodis.Remove(stariKlub);
                            db.SaveChanges();
                        }
                        if(Selektovani_trener.Naziv_Kluba != "" && Selektovani_trener.Naziv_Kluba != null) //odabrao je nekog
                        {
                            Vodi noviVodi = new Vodi() { trener_id_trenera = trener_update.id_trenera };
                            Klub noviKlub = db.Klubs.Where(x => x.naziv == Selektovani_trener.Naziv_Kluba).FirstOrDefault();
                            noviVodi.klub_naziv = noviKlub.naziv;
                            db.Vodis.Add(noviVodi);
                            db.SaveChanges();
                            foreach (Igrac igrac in db.Igracs)
                            {
                                if (igrac.naziv_kluba == noviKlub.naziv)
                                {
                                    igrac.Vodi = noviVodi;
                                    db.Entry(igrac).State = System.Data.Entity.EntityState.Modified;
                                }

                            }
                        }

                        db.Entry(trener_update).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        ucitajTrenera();
                        ucitajKlubove();
                        Selektovani_trener = null;
                        OnPropertyChanged("Selektovani_trener");
                        MessageBox.Show("Uspesno ste promenili trenera", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        //Ne refreshuje lepo combobox
                    }
                }
            }
        }

        public bool validate()
        {
            if (Selektovani_trener.T.ime_trenera == "" || Selektovani_trener.T.prezime_trenera == "" || Selektovani_trener.T.drzava == "")
            {
                MessageBox.Show("Potrebno je popuniti sva polja !", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
    }
}
