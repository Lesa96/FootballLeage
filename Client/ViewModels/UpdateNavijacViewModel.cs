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
    public class UpdateNavijacViewModel : BindableBase
    {
        public static ObservableCollection<Navijac_Selektovan> navijaci { get; set; }
        public static ObservableCollection<Klub_Selektovan> klubovi { get; set; }
        private Navijac_Selektovan navijac_selektovan;
        private bool canUpdate;
        public MyICommand UpdateCommand { get; set; }
        public ObservableCollection<string> Drzave { get; set; }

        public UpdateNavijacViewModel()
        {            
            UpdateCommand = new MyICommand(OnUpdate);
            ucitajDrzave();
            ucitajNavijace();
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

        private void ucitajNavijace()
        {
            Navijaci = new ObservableCollection<Navijac_Selektovan>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Navijac item in db.Navijacs)
                {
                    Navijac_Selektovan nav = new Navijac_Selektovan() { N = item, IsSelected = false };
                    nav.Nazivi_klubova = new ObservableCollection<string>();
                    foreach (Klub klub in item.Klubs)
                    {
                        nav.Nazivi_klubova.Add(klub.naziv);
                    }
                    Navijaci.Add(nav);
                }
            }
            OnPropertyChanged("Navijaci");
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
        public ObservableCollection<Navijac_Selektovan> Navijaci
        {
            get { return navijaci; }
            set
            {
                navijaci = value;
                OnPropertyChanged("Navijaci");
            }
        }

        public Navijac_Selektovan Selektovani_navijac
        {
            get { return navijac_selektovan; }
            set
            {
                SetProperty(ref navijac_selektovan, value);
                OnPropertyChanged("Selektovani_navijac");
                if(navijac_selektovan != null)      //kad ga promeni, selektovan predje na null, tad ne treba namestati checkbox
                    namestiCheckBoxove();

                if (navijac_selektovan != null)
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

                    if (Selektovani_navijac.Nazivi_klubova.Contains(klub.K.naziv))
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
                    Navijac novi_navijac = db.Navijacs.Find(Selektovani_navijac.N.id_navijaca);
                    novi_navijac.ime_navijaca = Selektovani_navijac.N.ime_navijaca;
                    novi_navijac.prezime_navijaca = Selektovani_navijac.N.prezime_navijaca;
                    novi_navijac.drzava = Selektovani_navijac.N.drzava;

                    novi_navijac.Klubs.Clear();
                    db.Entry(novi_navijac).State = System.Data.Entity.EntityState.Modified;
                    foreach (Klub_Selektovan klub in Klubovi)
                    {
                        if(klub.IsSelected)
                        {
                            Klub noviKlub = db.Klubs.Find(klub.K.naziv);
                            novi_navijac.Klubs.Add(noviKlub);
                        }
                    }
                    db.Entry(novi_navijac).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ucitajNavijace();
                    ucitajKlubove();
                    MessageBox.Show("Uspesno ste promenili navijaca", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
               
        }

        private bool validate()
        {
            if(Selektovani_navijac.N.ime_navijaca == "" || Selektovani_navijac.N.prezime_navijaca == "" || Selektovani_navijac.N.drzava == "")
            {
                MessageBox.Show("Potrebno je popuniti sva polja", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
    }
}
