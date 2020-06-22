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
    public class UpdateMenadzerViewModel : BindableBase
    {
        public static ObservableCollection<Menadzer_Selektovan> menadzeri { get; set; }
        public static ObservableCollection<Igrac_Selektovan> igraci { get; set; }
        private Menadzer_Selektovan menadzer_selektovan;
        private bool canUpdate;
        public MyICommand UpdateCommand { get; set; }
        public ObservableCollection<string> Drzave { get; set; }

        public UpdateMenadzerViewModel()
        {
            UpdateCommand = new MyICommand(OnUpdate);
            ucitajDrzave();
            ucitajMenadzere();
            ucitajIgrace();
        }

        private void ucitajIgrace()
        {
            Igraci = new ObservableCollection<Igrac_Selektovan>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Igrac igrac in db.Igracs)
                {
                    Igrac_Selektovan ig = new Igrac_Selektovan() { igrac = igrac, IsSelected = false };
                    ig.Ime_Prezime = igrac.ime_igraca + " " + igrac.prezime_igraca;
                    Igraci.Add(ig);
                }
                OnPropertyChanged("Igraci");
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

        private void ucitajMenadzere()
        {
            Menadzeri = new ObservableCollection<Menadzer_Selektovan>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Menadzer item in db.Menadzers)
                {
                    Menadzer_Selektovan men = new Menadzer_Selektovan() { M = item, IsSelected = false };
                    men.Nazivi_igraca = new ObservableCollection<string>();
                    foreach (Igrac igrac in item.Igracs)
                    {
                        men.Nazivi_igraca.Add(igrac.ime_igraca + " " + igrac.prezime_igraca);
                    }
                    Menadzeri.Add(men);
                }
            }
            OnPropertyChanged("Menadzeri");
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

        public ObservableCollection<Igrac_Selektovan> Igraci
        {
            get { return igraci; }
            set
            {
                igraci = value;
                OnPropertyChanged("Igraci");
            }
        }
        public ObservableCollection<Menadzer_Selektovan> Menadzeri
        {
            get { return menadzeri; }
            set
            {
                menadzeri = value;
                OnPropertyChanged("Menadzeri");
            }
        }

        public Menadzer_Selektovan Selektovani_menadzer
        {
            get { return menadzer_selektovan; }
            set
            {
                SetProperty(ref menadzer_selektovan, value);
                OnPropertyChanged("Selektovani_menadzer");
                if (menadzer_selektovan != null)      //kad ga promeni, selektovan predje na null, tad ne treba namestati checkbox
                    namestiCheckBoxove();

                if (menadzer_selektovan != null)
                    CanUpdate = true;
                else
                    CanUpdate = false;
            }
        }

        private void namestiCheckBoxove()
        {
            ObservableCollection<Igrac_Selektovan> noviIgraci = new ObservableCollection<Igrac_Selektovan>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Igrac_Selektovan igrac in Igraci)
                {
                    Igrac_Selektovan novIgracSelektovan = new Igrac_Selektovan() { igrac = db.Igracs.Find(igrac.igrac.id_igraca) };
                    novIgracSelektovan.Ime_Prezime = igrac.Ime_Prezime;

                    if (Selektovani_menadzer.Nazivi_igraca.Contains(igrac.igrac.ime_igraca + " " + igrac.igrac.prezime_igraca))
                    {
                        novIgracSelektovan.IsSelected = true;
                    }
                    else
                        novIgracSelektovan.IsSelected = false;
                    noviIgraci.Add(novIgracSelektovan);

                }
                Igraci = new ObservableCollection<Igrac_Selektovan>();
                Igraci = noviIgraci;
                OnPropertyChanged("Igraci");
            }
        }

        private void OnUpdate()
        {
            if (validate())
                using (var db = new BazaZaLiguEntities())
                {
                    Menadzer novi_menadzer = db.Menadzers.Find(Selektovani_menadzer.M.id_menagera);
                    novi_menadzer.ime_menagera = Selektovani_menadzer.M.ime_menagera;
                    novi_menadzer.prezime_menagera = Selektovani_menadzer.M.prezime_menagera;
                    novi_menadzer.drzava = Selektovani_menadzer.M.drzava;

                    novi_menadzer.Igracs.Clear();
                    db.Entry(novi_menadzer).State = System.Data.Entity.EntityState.Modified;
                    foreach (Igrac_Selektovan igrac in Igraci)
                    {
                        if (igrac.IsSelected)
                        {
                            Igrac noviIgrac = db.Igracs.Find(igrac.igrac.id_igraca);
                            novi_menadzer.Igracs.Add(noviIgrac);
                        }
                    }
                    db.Entry(novi_menadzer).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ucitajMenadzere();
                    ucitajIgrace();
                    MessageBox.Show("Uspesno ste promenili menadzera", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }

        }

        private bool validate()
        {
            if (Selektovani_menadzer.M.ime_menagera == "" || Selektovani_menadzer.M.prezime_menagera == "" || Selektovani_menadzer.M.drzava == "")
            {
                MessageBox.Show("Potrebno je popuniti sva polja", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
    }
}
