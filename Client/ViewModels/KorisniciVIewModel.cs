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
    public class KorisniciVIewModel : BindableBase
    {
        public static ObservableCollection<LogUser> korisnici { get; set; }
        private LogUser selektovani_korisnik;
        private bool canDelete;

        public MyICommand DeleteCommand { get; set; }

        public KorisniciVIewModel()
        {
            korisnici = new ObservableCollection<LogUser>();
            DeleteCommand = new MyICommand(OnDelete);


            using (var db = new BazaZaLiguEntities())
            {
                foreach (LogUser item in db.LogUsers.Where(x => x.role_usera != "Admin"))
                {
                    
                    korisnici.Add(item);
                }
            }
            OnPropertyChanged("korisnici");
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

        public LogUser Selektovani_korisnik
        {
            get { return selektovani_korisnik; }
            set
            {
                SetProperty(ref selektovani_korisnik, value);
                OnPropertyChanged("Selektovani_korisnik");

                if (selektovani_korisnik != null)
                    CanDelete = true;
                else
                    CanDelete = false;
            }
        }

        private void OnDelete()
        {
            using (var db = new BazaZaLiguEntities())
            {
                LogUser korisnik_zaBrisanje = db.LogUsers.Find(Selektovani_korisnik.id_usera);
                if (korisnik_zaBrisanje != null)
                {
                  
                    db.Entry(korisnik_zaBrisanje).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    korisnici.Remove(Selektovani_korisnik);
                    OnPropertyChanged("korisnici");
                    MessageBox.Show("Uspesno ste obrisali korisnika", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    LogReport(korisnik_zaBrisanje);

                }
            }
        }

        public void LogReport(LogUser logObjekat)
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../LogReport.txt", true);
            outPutText = string.Format("BRISANJE {0} \t KORISNIK:    ID: {1},Korisnicko ime: {2} \n"
                 , DateTime.Now.ToShortDateString(), logObjekat.id_usera, logObjekat.username_usera);

            file.WriteLine(outPutText);
            file.Close();
        }
    }
}
