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
    public class ShowLigaViewModel : BindableBase
    {
        public static ObservableCollection<Liga_Selektovan> lige { get; set; }
        private Liga_Selektovan selektovana_liga;
        private bool canDelete;
        private Visibility visibility;

        public MyICommand DeleteCommand { get;  set; }
        public MyICommand PrikaziCommand { get; set; }
        public MyICommand IspisCommand { get; set; }

        public ShowLigaViewModel()
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
            PrikaziCommand = new MyICommand(OnPrikazi);
            IspisCommand = new MyICommand(Stampaj);
            lige = new ObservableCollection<Liga_Selektovan>();

            using (var db = new BazaZaLiguEntities())
            {
                foreach (Liga item in db.Ligas)
                {
                    double prosek = prosekVrednosti(item);
                    Liga_Selektovan liga = new Liga_Selektovan() { L = item, Prosecna_Vrednost_Klubova = prosek };
                    lige.Add(liga);
                }
            }
            OnPropertyChanged("lige");
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

        public Liga_Selektovan Selektovana_liga
        {
            get { return selektovana_liga; }
            set
            {
                SetProperty(ref selektovana_liga, value);
                OnPropertyChanged("Selektovana_liga");

                if (selektovana_liga != null)
                    CanDelete = true;
                else
                    CanDelete = false;
            }
        }


     

        public void onDelete()
        {
            using (var db = new BazaZaLiguEntities())
            {
                List<Sudija> provera_sudije = db.Sudijas.Where(x => x.liga_id_lige == Selektovana_liga.L.id_lige).ToList(); //vrati sve sudije koje sude u ligi
                foreach (Sudija item in provera_sudije)
                {
                    db.Sudijas.Find(item.id_sudije).liga_id_lige = null; //FK
                    db.SaveChanges();
                }
                List<Klub> provera_klkubova = db.Klubs.Where(x => x.liga_id_lige == Selektovana_liga.L.id_lige).ToList(); //klubovi
                foreach (Klub item in provera_klkubova)
                {
                    Klub klub = db.Klubs.Find(item.naziv);
                    klub.liga_id_lige = null; //FK
                    klub.Liga = null;
                    db.Entry(klub).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                var liga_Sponzor = db.Ligas.Find(Selektovana_liga.L.id_lige);
                List<Sponzor> sponzori = liga_Sponzor.Sponzors.ToList();
                foreach (Sponzor item in sponzori)
                {                    
                    Sponzor s = db.Sponzors.Find(item.id_sponzora);

                    if(s != null)
                    {
                        Liga l = s.Ligas.Where(x => x.id_lige == liga_Sponzor.id_lige).FirstOrDefault();
                        s.Ligas.Remove(l);
                    }
                    db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                }
                

                Liga ligaZaBrisanje = db.Ligas.Find(Selektovana_liga.L.id_lige);
                if (ligaZaBrisanje != null)
                {
                    db.Entry(ligaZaBrisanje).State = System.Data.Entity.EntityState.Deleted; //brise iz baze
                }

                var liga_brisi = lige.Where(x => x.L.id_lige == ligaZaBrisanje.id_lige).First();
                if (liga_brisi != null)
                {
                    lige.Remove(liga_brisi);
                }

                OnPropertyChanged("lige");
                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Liga je obrisana", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    LogReport(ligaZaBrisanje);
                }
                catch (Exception)
                {

                    MessageBox.Show("Od lige zavise drugi entiteti, prvo njih obrisati", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                
            }

        }

        public void OnPrikazi()
        {
            using (var db = new BazaZaLiguEntities())
            {
               // List<string> treneriProc = db.SumProcedura();
                System.Data.Entity.Core.Objects.ObjectResult<string> tr = db.SumProcedura();


            }
        }

        public void Stampaj()
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../RezultatStampanja.txt");
            file.WriteLine("\t\t\t Lige: ");
            file.WriteLine("");
            foreach (Liga_Selektovan item in lige.OrderBy(x=> x.Prosecna_Vrednost_Klubova))
            {
                outPutText = string.Format("ID: {0}, Naziv: {1},Drzava: {2}, Ukupno klubova: {3} , Prosecna vrednost klubova:  {4}\n"
                    , item.L.id_lige, item.L.naziv_lige, item.L.drzava_lige, item.L.broj_klubova,item.Prosecna_Vrednost_Klubova);

                file.WriteLine(outPutText);
            }
            file.Close();

            MessageBox.Show("Datoteka je sacuvana u RezultatStampanja.txt", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        public void LogReport(Liga logObjekat)
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../LogReport.txt", true);
            outPutText = string.Format("BRISANJE {0} \t LIGA:    ID: {1}  ,Naziv: {2} , Drzava: {3}\n"
                 , DateTime.Now.ToShortDateString(), logObjekat.id_lige, logObjekat.naziv_lige, logObjekat.drzava_lige);

            file.WriteLine(outPutText);
            file.Close();
        }

        public double prosekVrednosti(Liga liga)
        {
            using (var db = new BazaZaLiguEntities())
            {
                double vrednost = 0;
                double brojKlubova = 0;
                foreach (Klub klub in liga.Klubs)
                {
                    vrednost += (double)klub.vrednost;
                    brojKlubova++;
                }
                if (brojKlubova > 0)
                {
                    vrednost = (double)db.Database.SqlQuery<double>($"SELECT [dbo].[Prosek]({vrednost},{brojKlubova})").FirstOrDefault();
                    vrednost = Math.Round(vrednost, 2);
                }

                return vrednost;
            }
        }


    }
}
