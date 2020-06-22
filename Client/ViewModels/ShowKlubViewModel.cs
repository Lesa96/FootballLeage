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
    public class ShowKlubViewModel : BindableBase
    {
        public static ObservableCollection<Klub_Selektovan> klubovi { get; set; }
       
        private Klub_Selektovan selektovana_klub;
        private bool canDelete;
        private Visibility visibility;

        public MyICommand DeleteCommand { get; set; }
        public MyICommand IspisCommand { get; set; }

        public ShowKlubViewModel()
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
            klubovi = new ObservableCollection<Klub_Selektovan>();

            using (var db = new BazaZaLiguEntities())
            {
                foreach (Klub item in db.Klubs)
                {
                    double starost = prosekStarosti(item);
                    Klub_Selektovan klubS = new Klub_Selektovan() { K = item , Prosecna_Starost = (float)starost};
                    if(item.Liga != null)
                    {
                        klubS.Naziv_lige = item.Liga.naziv_lige;
                    }
                    else
                    {
                        klubS.Naziv_lige = "";
                    }
                    //trener
                    Vodi vod = db.Vodis.Where(x => x.klub_naziv == item.naziv).FirstOrDefault();
                    if(vod != null)
                    {
                        Trener trener = db.Treners.Find(vod.trener_id_trenera);
                        klubS.Trener = trener.ime_trenera + " " + trener.prezime_trenera;
                    }
                    else
                    {
                        klubS.Trener = "";
                    }
                    //broj navijaca
                    klubS.Broj_Navijaca = 0;
                    if(item.Navijacs != null)
                    {
                        klubS.Broj_Navijaca = item.Navijacs.Count;
                    }
                    
                    
                    klubovi.Add(klubS);
                }
            }
            OnPropertyChanged("klubovi");
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

        public Klub_Selektovan Selektovana_klub
        {
            get { return selektovana_klub; }
            set
            {
                SetProperty(ref selektovana_klub, value);
                OnPropertyChanged("Selektovana_klub");

                if (selektovana_klub != null)
                    CanDelete = true;
                else
                    CanDelete = false;
            }
        }

        public void onDelete()
        {
            using (var db = new BazaZaLiguEntities())
            {
                Klub klubZaBrisanje = db.Klubs.Find(Selektovana_klub.K.naziv);
                Klub logReportKlub = klubZaBrisanje;

                if (!izvrsiProvere(klubZaBrisanje))
                {
                    //nije ispunio uslove brisanje, ne brisi
                    return;
                }

                //brisi poseduje:
                List<Poseduje> provera_poseduje = db.Posedujes.Where(x => x.klub_naziv == Selektovana_klub.K.naziv).ToList();
                foreach (Poseduje item in provera_poseduje)
                {
                    item.Obezbedjenjes.Clear();
                    db.Posedujes.Remove(item);
                    db.SaveChanges();
                }                

                //brisi trenere koji vodi klub
                Vodi provera_vodi = db.Vodis.Where(x => x.klub_naziv == Selektovana_klub.K.naziv).FirstOrDefault();
                if (provera_vodi != null)
                {
                    provera_vodi.Igracs.Clear();
                    db.Entry(provera_vodi).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }               

                //brisi kod igraca:
                List<Igrac> provera_igraca = db.Igracs.Where(x => x.naziv_kluba == Selektovana_klub.K.naziv).ToList(); //vrati sve igrace koji igraju za klub
                foreach (Igrac item in provera_igraca)
                {
                    Igrac igrac = db.Igracs.Find(item.id_igraca); //FK
                    igrac.Klub = null;
                    igrac.naziv_kluba = null;
                    igrac.Vodi = null;
                    igrac.vodi_id_trenera = null;
                    igrac.vodi_naziv = null;

                    db.Entry(igrac).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                }

                db.Entry(klubZaBrisanje).State = System.Data.Entity.EntityState.Deleted; //brise iz baze
                db.SaveChanges();

                var klub_brisi = klubovi.Where(x => x.K.naziv == klubZaBrisanje.naziv).First(); 
                if (klub_brisi != null)
                {
                    klubovi.Remove(klub_brisi); //brisemo iz liste
                }

                OnPropertyChanged("klubovi");
                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Uspesno ste obrisali klub", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    LogReport(logReportKlub);
                }
                catch (Exception)
                {

                    MessageBox.Show("Od kluba zavise drugi entiteti, prvo njih obrisati", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

        }

        private bool izvrsiProvere(Klub klubZaProveru)
        {
            using (var db = new BazaZaLiguEntities())
            {
                //provera za radnike na stadionu, poseduje
                List<Poseduje> provera_poseduje = db.Posedujes.Where(x => x.klub_naziv == klubZaProveru.naziv).ToList();
                int brojStadiona = provera_poseduje.Count;

                foreach (Poseduje item in provera_poseduje)
                {
                    foreach (Obezbedjenje obez in item.Obezbedjenjes) //radnici , obezbedjenje
                    {
                        Obezbedjenje obezbedjenje = db.Obezbedjenjes.Find(obez.id_radnika);
                        if (obezbedjenje.Posedujes.Count < brojStadiona + 1) //radnik mora da radi na jos nekom stadionu koji ne pripada tom klubu
                        {
                            MessageBox.Show("Od kluba zavise Radnici na stadionu, prvo njih obrisati", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return false;
                        }

                    }

                }
                //provera za vlasnike, pripada
                foreach (Vlasnik item in klubZaProveru.Vlasniks)
                {
                    Vlasnik vlasnik = db.Vlasniks.Find(item.id_vlasnika);
                    if (vlasnik.Klubs.Count <= 1)
                    {
                        MessageBox.Show("Od kluba zavise Vlasnici, prvo njih obrisati", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return false;
                    }
                }
                //provera za navijace , navija
                foreach (Navijac item in klubZaProveru.Navijacs)
                {
                    Navijac navijac = db.Navijacs.Find(item.id_navijaca);
                    if (navijac.Klubs.Count <= 1)
                    {
                        MessageBox.Show("Od kluba zavise Navijaci, prvo njih obrisati", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return false;
                    }
                }
                //sve je u redu:
                return true;
            }
        }

        public void Stampaj()
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../RezultatStampanja.txt");
            file.WriteLine("\t\t\t\t\t\t\t"+ DateTime.Now.ToShortDateString() +"  Klubovi: ");
            file.WriteLine("");
            file.WriteLine("\t Naziv: \t\t Grad: \t\t Liga: \t\t Trener: \t\t Navijaci: \t\t Vrednost: \t\t Prosecna Starost Igraca:\t");
            foreach (Klub_Selektovan item in klubovi.OrderBy(x=> x.Prosecna_Starost))
            {
                string spaceNaziv = "";
                string spaceLiga = "";
                string spaceTrener = "";
                if (item.K.naziv.Length < 10)
                {
                    spaceNaziv = "\t";
                }
                if (item.Naziv_lige.Length < 10)
                {
                    spaceLiga = "\t";
                }
                if (item.Trener.Length < 10)
                {
                    spaceTrener = "\t";
                }
                outPutText = string.Format("\t {0} "+ spaceNaziv + "\t {1} \t\t {2}"+ spaceLiga+"\t {3} "+spaceTrener+"\t {4} \t\t {5} \t\t{6}\n"
                    , item.K.naziv, item.K.grad, item.Naziv_lige, item.Trener,item.Broj_Navijaca, item.K.vrednost,item.Prosecna_Starost);

                file.WriteLine(outPutText);
            }
            file.Close();

            MessageBox.Show("Datoteka je sacuvana u RezultatStampanja.txt", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        public void LogReport(Klub logObjekat)
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../LogReport.txt", true);
            outPutText = string.Format("BRISANJE {0} \t KLUB:    Naziv: {1},Grad: {2} \n"
                 ,DateTime.Now.ToShortDateString(), logObjekat.naziv, logObjekat.grad);

            file.WriteLine(outPutText);
            file.Close();          
        }

        public double prosekStarosti(Klub klub)
        {
            using (var db = new BazaZaLiguEntities())
            {
                double starost = 0;
                double brojIgraca = 0;
                foreach (Igrac igrac in klub.Igracs)
                {
                    starost += (double)igrac.godine_igraca;
                    brojIgraca++;
                }
                if (brojIgraca > 0)
                {
                    starost = (double)db.Database.SqlQuery<double>($"SELECT [dbo].[Prosek]({starost},{brojIgraca})").FirstOrDefault();
                    starost = Math.Round(starost, 2);
                }
                    
                return starost;
            }
        }

    }
}
