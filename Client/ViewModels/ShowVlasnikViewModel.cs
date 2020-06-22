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
    public class ShowVlasnikViewModel : BindableBase
    {
        public static ObservableCollection<Vlasnik_Selektovan> vlasnici { get; set; }
        private Vlasnik_Selektovan selektovani_vlasnik;
        private bool canDelete;
        private Visibility visibility;

        public MyICommand DeleteCommand { get; set; }
        public MyICommand IspisCommand { get; set; }

        public ShowVlasnikViewModel()
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

            vlasnici = new ObservableCollection<Vlasnik_Selektovan>();
            DeleteCommand = new MyICommand(OnDelete);
            IspisCommand = new MyICommand(Stampaj);

            using (var db = new BazaZaLiguEntities())
            {
                foreach (Vlasnik item in db.Vlasniks)
                {
                    Vlasnik_Selektovan vlas = new Vlasnik_Selektovan() { V = item };
                    vlas.Nazivi_klubova = new ObservableCollection<string>();
                    foreach (Klub klub in item.Klubs)
                    {
                        vlas.Nazivi_klubova.Add(klub.naziv);
                    }
                    vlasnici.Add(vlas);
                }
            }
            OnPropertyChanged("vlasnici");
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

        public Vlasnik_Selektovan Selektovani_vlasnik
        {
            get { return selektovani_vlasnik; }
            set
            {
                SetProperty(ref selektovani_vlasnik, value);
                OnPropertyChanged("Selektovani_vlasnik");

                if (selektovani_vlasnik != null)
                    CanDelete = true;
                else
                    CanDelete = false;
            }
        }

        private void OnDelete()
        {
            using (var db = new BazaZaLiguEntities())
            {
                Vlasnik vlasnik_zaBrisanje = db.Vlasniks.Find(Selektovani_vlasnik.V.id_vlasnika);
                if (vlasnik_zaBrisanje != null)
                {

                    List<Klub> klubovi = vlasnik_zaBrisanje.Klubs.ToList();
                    foreach (Klub klub in klubovi)
                    {
                        Klub kl = db.Klubs.Find(klub.naziv);
                        kl.Vlasniks.Remove(vlasnik_zaBrisanje);
                        db.SaveChanges();
                    }


                    db.Entry(vlasnik_zaBrisanje).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    vlasnici.Remove(Selektovani_vlasnik);
                    OnPropertyChanged("vlasnici");
                    MessageBox.Show("Uspesno ste obrisali vlasnika", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    LogReport(vlasnik_zaBrisanje);
                    
                }
            }
        }

        public void Stampaj()
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../RezultatStampanja.txt");
            file.WriteLine("\t\t\t Vlasnici: ");
            file.WriteLine("");
            foreach (Vlasnik_Selektovan item in vlasnici)
            {
                outPutText = string.Format("ID: {0}, Ime: {1},Prezime: {2}, Drzava: {3}, Klubovi ciji je vlasnik:  "
                    , item.V.id_vlasnika, item.V.ime_vlasnika, item.V.prezime_vlasnika,item.V.drzava);
                foreach (string naziv in item.Nazivi_klubova)
                {
                    outPutText += naziv + " ; ";

                }
                file.WriteLine(outPutText);
            }
            file.Close();

            MessageBox.Show("Datoteka je sacuvana u RezultatStampanja.txt", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        public void LogReport(Vlasnik logObjekat)
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../LogReport.txt", true);
            outPutText = string.Format("BRISANJE {0} \t VLASNIK:    ID: {1} , Ime: {2} , Prezime: {3} , Drzava: {4}\n"
                 , DateTime.Now.ToShortDateString(), logObjekat.id_vlasnika, logObjekat.ime_vlasnika, logObjekat.prezime_vlasnika, logObjekat.drzava);

            file.WriteLine(outPutText);
            file.Close();
        }
    }
}
