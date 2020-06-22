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
    public class ShowSudijaViewModel : BindableBase
    {
        public static ObservableCollection<Sudija> sudije { get; set; }
        private Sudija selektovani_sudija;
        private bool canDelete;
        private Visibility visibility;

        public MyICommand DeleteCommand { get; set; }
        public MyICommand IspisCommand { get; set; }

        public ShowSudijaViewModel()
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

            DeleteCommand = new MyICommand(onDelete);
            IspisCommand = new MyICommand(Stampaj);
            sudije = new ObservableCollection<Sudija>();

            using (var db = new BazaZaLiguEntities())
            {
                foreach (Sudija sud in db.Sudijas.ToList())
                {
                    Sudija pomSudija = sud;
                    Liga pomLiga = new Liga();
                    if (sud.Liga != null)
                        pomLiga.naziv_lige = sud.Liga.naziv_lige;

                    pomSudija.Liga = pomLiga;
                    sudije.Add(pomSudija);
                }
                
            }
            OnPropertyChanged("sudije");
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

        public Sudija Selektovani_sudija
        {
            get { return selektovani_sudija; }
            set
            {
                SetProperty(ref selektovani_sudija, value);
                OnPropertyChanged("Selektovani_sudija");

                if (selektovani_sudija != null)
                    CanDelete = true;
                else
                    CanDelete = false;
            }
        }

        public void onDelete()
        {
            using (var db = new BazaZaLiguEntities())
            {
                //ako je jedini sudija u ligi, ne smemo ga obrisati
                List<Sudija> proveraSudijaZbogLige = db.Sudijas.Where(x => x.liga_id_lige == Selektovani_sudija.liga_id_lige).ToList();

                if(proveraSudijaZbogLige.Count <= 1 && Selektovani_sudija.liga_id_lige != null)
                {
                    MessageBox.Show("Izabrani sudija je jedini u ligi " + Selektovani_sudija.Liga.naziv_lige + "ne moze se obrisati.", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                Sudija sudijaZaBrisanje = db.Sudijas.Find(Selektovani_sudija.id_sudije);
                if(sudijaZaBrisanje != null)
                {
                    try
                    {
                        db.Sudijas.Remove(sudijaZaBrisanje);
                        db.SaveChanges();
                        MessageBox.Show("Uspesno ste obrisali sudiju", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        LogReport(sudijaZaBrisanje);
                        sudije.Remove(Selektovani_sudija);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Greska prilikom brisanja, nemoguce je obrisati sudiju zbog zavisnosti sa drugim entitetima", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    
                }
            }
        }

        public void Stampaj()
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../RezultatStampanja.txt");
            file.WriteLine("\t\t\t Sudije: ");
            file.WriteLine("");

            foreach (Sudija item in sudije)
            {
                outPutText = string.Format("ID: {0}, Ime: {1},Prezime: {2},Drzava: {3}"
                    , item.id_sudije, item.ime_sudije, item.prezime_sudije,item.nacionalnost_sudije);
                if(item.Liga != null)
                { 
                    outPutText += ", Liga: "+ item.Liga.naziv_lige;

                }
                file.WriteLine(outPutText);
            }
            file.Close();

            MessageBox.Show("Datoteka je sacuvana u RezultatStampanja.txt", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        public void LogReport(Sudija logObjekat)
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../LogReport.txt", true);
            outPutText = string.Format("BRISANJE {0} \t SUDIJA:    ID: {1}, Ime: {2} , Prezime: {3} , Drzava: {4}\n"
                 , DateTime.Now.ToShortDateString(), logObjekat.id_sudije, logObjekat.ime_sudije, logObjekat.prezime_sudije, logObjekat.nacionalnost_sudije);

            file.WriteLine(outPutText);
            file.Close();
        }
    }
}
