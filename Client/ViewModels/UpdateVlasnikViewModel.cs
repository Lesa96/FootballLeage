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
    public class UpdateVlasnikViewModel : BindableBase
    {
        public static ObservableCollection<Vlasnik_Selektovan> vlasnici { get; set; }
        public static ObservableCollection<Klub_Selektovan> klubovi { get; set; }
        private Vlasnik_Selektovan vlasnik_selektovan;
        private bool canUpdate;
        public MyICommand UpdateCommand { get; set; }
        public ObservableCollection<string> Drzave { get; set; }

        public UpdateVlasnikViewModel()
        {
            UpdateCommand = new MyICommand(OnUpdate);
            ucitajDrzave();
            ucitajVlasnike();
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

        private void ucitajVlasnike()
        {
            Vlasnici = new ObservableCollection<Vlasnik_Selektovan>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Vlasnik item in db.Vlasniks)
                {
                    Vlasnik_Selektovan vlas = new Vlasnik_Selektovan() { V = item, IsSelected = false };
                    vlas.Nazivi_klubova = new ObservableCollection<string>();
                    foreach (Klub klub in item.Klubs)
                    {
                        vlas.Nazivi_klubova.Add(klub.naziv);
                    }
                    Vlasnici.Add(vlas);
                }
            }
            OnPropertyChanged("Vlasnici");
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

        public ObservableCollection<Klub_Selektovan> Klubovi
        {
            get { return klubovi; }
            set
            {
                klubovi = value;
                OnPropertyChanged("Klubovi");
            }
        }
        public ObservableCollection<Vlasnik_Selektovan> Vlasnici
        {
            get { return vlasnici; }
            set
            {
                vlasnici = value;
                OnPropertyChanged("Vlasnici");
            }
        }

        public Vlasnik_Selektovan Selektovani_vlasnik
        {
            get { return vlasnik_selektovan; }
            set
            {
                SetProperty(ref vlasnik_selektovan, value);
                OnPropertyChanged("Selektovani_vlasnik");
                if (vlasnik_selektovan != null)      //kad ga promeni, selektovan predje na null, tad ne treba namestati checkbox
                    namestiCheckBoxove();

                if (vlasnik_selektovan != null)
                    CanUpdate = true;
                else
                    CanUpdate = false;
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

                    if (Selektovani_vlasnik.Nazivi_klubova.Contains(klub.K.naziv))
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
            if (validate())
                using (var db = new BazaZaLiguEntities())
                {
                    Vlasnik novi_vlasnik = db.Vlasniks.Find(Selektovani_vlasnik.V.id_vlasnika);
                    novi_vlasnik.ime_vlasnika = Selektovani_vlasnik.V.ime_vlasnika;
                    novi_vlasnik.prezime_vlasnika = Selektovani_vlasnik.V.prezime_vlasnika;
                    novi_vlasnik.drzava = Selektovani_vlasnik.V.drzava;

                    novi_vlasnik.Klubs.Clear();
                    db.Entry(novi_vlasnik).State = System.Data.Entity.EntityState.Modified;
                    foreach (Klub_Selektovan klub in Klubovi)
                    {
                        if (klub.IsSelected)
                        {
                            Klub noviKlub = db.Klubs.Find(klub.K.naziv);
                            novi_vlasnik.Klubs.Add(noviKlub);
                        }
                    }
                    db.Entry(novi_vlasnik).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ucitajVlasnike();
                    ucitajKlubove();
                    MessageBox.Show("Uspesno ste promenili vlasnika", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }

        }

        private bool validate()
        {
            if (Selektovani_vlasnik.V.ime_vlasnika == "" || Selektovani_vlasnik.V.prezime_vlasnika == "" || Selektovani_vlasnik.V.drzava == "")
            {
                MessageBox.Show("Potrebno je popuniti sva polja", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
    }
}
