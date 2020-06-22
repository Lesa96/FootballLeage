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
    public class ShowNavijacViewModel : BindableBase
    {
        public static ObservableCollection<Navijac_Selektovan> navijaci { get; set; }
        private Navijac_Selektovan selektovani_navijac;
        private bool canDelete;
        private Visibility visibility;

        public MyICommand DeleteCommand { get; set; }
        public MyICommand IspisCommand { get; set; }

        public ShowNavijacViewModel()
        {
            string role = (string)Application.Current.Properties["Role"];
            if (role != "Admin")
            {
                Visibility = Visibility.Hidden;
            }
            else
            {
                Visibility = Visibility.Visible;
            }

            navijaci = new ObservableCollection<Navijac_Selektovan>();
            DeleteCommand = new MyICommand(OnDelete);
            IspisCommand = new MyICommand(Stampaj);

            using (var db = new BazaZaLiguEntities())
            {
                foreach (Navijac item in db.Navijacs)
                {
                    Navijac_Selektovan nav = new Navijac_Selektovan() { N = item };
                    nav.Nazivi_klubova =new ObservableCollection<string>();
                    foreach (Klub klub in item.Klubs)
                    {
                        nav.Nazivi_klubova.Add( klub.naziv);
                    }
                    navijaci.Add(nav);
                }
            }
            OnPropertyChanged("navijaci");
        }

        public Visibility Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;

                OnPropertyChanged("Visibility");
            }
        }

        public bool CanDelete
        {
            get { return canDelete; }
            set
            {
                canDelete = value;
                OnPropertyChanged("CanDelete");
            }
        }

        public Navijac_Selektovan Selektovani_navijac
        {
            get { return selektovani_navijac; }
            set
            {
                SetProperty(ref selektovani_navijac, value);
                OnPropertyChanged("Selektovani_navijac");

                if (selektovani_navijac != null)
                    CanDelete = true;
                else
                    CanDelete = false;
            }
        }

        private void OnDelete()
        {
            using (var db = new BazaZaLiguEntities())
            {
                Navijac navijac_zaBrisanje = db.Navijacs.Find(Selektovani_navijac.N.id_navijaca);
                if (navijac_zaBrisanje != null)
                {
                    
                    List<Klub> klubovi = navijac_zaBrisanje.Klubs.ToList();
                    foreach (Klub klub in klubovi)
                    {
                        Klub kl = db.Klubs.Find(klub.naziv);
                        kl.Navijacs.Remove(navijac_zaBrisanje);
                        db.SaveChanges();
                    }

                    
                    db.Entry(navijac_zaBrisanje).State = System.Data.Entity.EntityState.Deleted;                   
                    db.SaveChanges();
                    navijaci.Remove(Selektovani_navijac);
                    OnPropertyChanged("navijaci");
                    MessageBox.Show("Uspesno ste obrisali igraca", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    LogReport(navijac_zaBrisanje);
                }
            }
        }

        public void Stampaj()
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../RezultatStampanja.txt");
            file.WriteLine("\t\t\t Navijaci: ");
            file.WriteLine("");
            foreach (Navijac_Selektovan item in navijaci)
            {
                outPutText = string.Format("ID: {0}, Ime: {1},Prezime: {2}, Drzava: {3} Klubovi za koje navija:  "
                    , item.N.id_navijaca, item.N.ime_navijaca, item.N.prezime_navijaca,item.N.drzava);
                foreach (string naziv in item.Nazivi_klubova)
                {
                    outPutText += naziv + " ; ";

                }
                file.WriteLine(outPutText);
            }
            file.Close();

            MessageBox.Show("Datoteka je sacuvana u RezultatStampanja.txt", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        public void LogReport(Navijac logObjekat)
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../LogReport.txt", true);
            outPutText = string.Format("BRISANJE {0} \t NAVIJAC:    ID: {1}, Ime: {2} , Prezime: {3} , Drzava: {4}\n"
                 , DateTime.Now.ToShortDateString(), logObjekat.id_navijaca, logObjekat.ime_navijaca, logObjekat.prezime_navijaca, logObjekat.drzava);

            file.WriteLine(outPutText);
            file.Close();
        }
    }
}
