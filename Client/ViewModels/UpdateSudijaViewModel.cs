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
    public class UpdateSudijaViewModel : BindableBase
    {
        public static ObservableCollection<string> Naziv_lige { get; set; }        
        private Sudija_Selektovan selektovani_sudija;
        private bool canUpdate;
        public MyICommand UpdateCommand { get; set; }
        public ObservableCollection<string> Drzave { get; set; }
        public static ObservableCollection<Sudija_Selektovan> sudijeS { get; set; }

        public UpdateSudijaViewModel()
        {
            Drzave = new ObservableCollection<string>();
            UpdateCommand = new MyICommand(onUpdate);            
            Naziv_lige = new ObservableCollection<string>();
            ucitajSudije();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Liga item in db.Ligas)
                {
                    //sve lige
                    Naziv_lige.Add(item.naziv_lige);                    
                }
                Naziv_lige.Add("");     //za davanje otkaza iz lige
            }
            OnPropertyChanged("Naziv_lige");
            ucitajDrzave();
        }

        private void ucitajDrzave()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"../../../Drzave.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string nazivDrzave = node.InnerText;
                Drzave.Add(nazivDrzave);

            }
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

        public Sudija_Selektovan Selektovani_sudija
        {
            get { return selektovani_sudija; }
            set
            {
                SetProperty(ref selektovani_sudija, value);
                OnPropertyChanged("Selektovani_sudija");

                if (selektovani_sudija != null)
                {
                    CanUpdate = true;                    
                }
                   
                else
                    CanUpdate = false;
            }
        }

        public void onUpdate()
        {
           if(validate())
            {
                using (var db = new BazaZaLiguEntities())
                {
                    Sudija updateSudija = db.Sudijas.Find(Selektovani_sudija.S.id_sudije);
                    updateSudija.ime_sudije = Selektovani_sudija.S.ime_sudije;
                    updateSudija.prezime_sudije = Selektovani_sudija.S.prezime_sudije;
                    updateSudija.nacionalnost_sudije = Selektovani_sudija.S.nacionalnost_sudije;

                    Liga StaraLiga = db.Ligas.Where(x => x.id_lige == Selektovani_sudija.S.liga_id_lige).FirstOrDefault();
                    Liga NovaLiga = db.Ligas.Where(x => x.naziv_lige == Selektovani_sudija.Liga_Sudije).FirstOrDefault();

                    if (StaraLiga == null)       //Sudija nije sudio nigde 
                    {
                        if (NovaLiga != null) //odabrao je novu ligu
                        {
                            updateSudija.Liga = NovaLiga;
                        }
                        db.Entry(updateSudija).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        Selektovani_sudija.S = updateSudija;
                        MessageBox.Show("Uspesno ste promenili sudiju", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        ucitajSudije();
                        return;

                    }
                    else if (StaraLiga.naziv_lige == Selektovani_sudija.Liga_Sudije) // nije promenio polje za ligu
                    {
                        db.Entry(updateSudija).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        Selektovani_sudija.S = updateSudija;
                        ucitajSudije();

                        MessageBox.Show("Uspesno ste promenili sudiju", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        return;
                    }
                    else //promenio je polje a sudio je negde
                    {

                        if (StaraLiga.Sudijas.Count <= 1) //jedini je sudija u ligi
                        {
                            MessageBox.Show("Izabrani sudija je jedini u ligi " + Selektovani_sudija.S.Liga.naziv_lige + ",ne moze promeniti ligu dok liga ne nadje bar jos jednog sudiju.", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        //brisemo sudiju iz lige
                        Sudija trazeniSudija = db.Sudijas.Find(Selektovani_sudija.S.id_sudije);
                        StaraLiga.Sudijas.Remove(trazeniSudija);
                        db.SaveChanges();

                        updateSudija.Liga = NovaLiga;
                        db.Entry(updateSudija).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        Selektovani_sudija.S = updateSudija;
                        ucitajSudije();

                        MessageBox.Show("Uspesno ste promenili sudiju", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);                        
                        return;

                    }

                }
            }
            
        }

        public bool validate()
        {
            if (Selektovani_sudija.S.ime_sudije == "" || Selektovani_sudija.S.prezime_sudije == "" || Selektovani_sudija.S.nacionalnost_sudije == "")
            {
                MessageBox.Show("Potrebno je popuniti sva polja !");
                return false;
            }


            return true;


        }

        private void ucitajSudije()
        {
            
            sudijeS = new ObservableCollection<Sudija_Selektovan>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Sudija sud in db.Sudijas.ToList())
                {
                    
                    Sudija pomSudija = sud;
                    Liga pomLiga = new Liga();
                    if (sud.Liga != null)
                        pomLiga.naziv_lige = sud.Liga.naziv_lige;

                    pomSudija.Liga = pomLiga;
                    //
                    Sudija_Selektovan sudS = new Sudija_Selektovan();
                    sudS.S = pomSudija;
                    sudS.Liga_Sudije = pomLiga.naziv_lige;
                    sudijeS.Add(sudS);


                }
                OnPropertyChanged("sudijeS");
            }
        }
    }
}
