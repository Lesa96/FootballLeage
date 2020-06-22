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
    public class AddIgracViewModel : BindableBase
    {
        public MyICommand addCommand { get; set; }
        private Igrac igrac;
        private string selektovaniIgrac;
        public ObservableCollection<string> Naziv_kluba { get; set; }
        public ObservableCollection<Klub> klubovi { get; set; }
        public string Utakmice { get; set; }
        public string Golovi { get; set; }
        public string Godine { get; set; }

        public Igrac Igrac_prop
        {
            get { return igrac; }
            set
            {
                SetProperty(ref igrac, value);
                OnPropertyChanged("Igrac_prop");
            }
        }

        public string SelektovaniKlub
        {
            get { return selektovaniIgrac; }
            set
            {
                selektovaniIgrac = value;
                OnPropertyChanged("SelektovaniKlub");
            }
        }

        

        public AddIgracViewModel()
        {
            addCommand = new MyICommand(OnAdd);
            Naziv_kluba = new ObservableCollection<string>();
            
            klubovi = new ObservableCollection<Klub>();
            using (var db = new BazaZaLiguEntities())
            {
                foreach (Klub item in db.Klubs)
                {
                    //svi klubovi
                    klubovi.Add(item);
                    Naziv_kluba.Add(item.naziv);
                }
            }
            OnPropertyChanged("Naziv_kluba");
            OnPropertyChanged("klubovi");



            Igrac_prop = new Igrac() { id_igraca = 0, ime_igraca = "", prezime_igraca = "", vodi_id_trenera = 0, vodi_naziv = "" , Klub = null, naziv_kluba="" , odigranih_utakmica = -1, postignutih_golova = -1, prosek_golova = 0 , godine_igraca = -1 };
            //dodaj vodi za igraca
        }

        public void OnAdd()
        {
            if(validate())
            {
                using (var db = new BazaZaLiguEntities())
                {
                    double golovi = 0;
                    //generise sledeci ID:
                    int nextID = 0;
                    Igrac proveraID = null;
                    do
                    {
                        proveraID = db.Igracs.Where(x => x.id_igraca == nextID + 1).FirstOrDefault();
                        nextID++;
                    }
                    while (proveraID != null);

                    Igrac novi_igrac = new Igrac() { id_igraca = nextID, ime_igraca = Igrac_prop.ime_igraca, prezime_igraca = Igrac_prop.prezime_igraca , postignutih_golova = Igrac_prop.postignutih_golova , odigranih_utakmica = Igrac_prop.odigranih_utakmica , godine_igraca = Igrac_prop.godine_igraca };
                    //prosek golova
                    if (novi_igrac.postignutih_golova != 0 && novi_igrac.odigranih_utakmica != 0)
                    {
                        double postignutih = (double) novi_igrac.postignutih_golova ;
                        double odigranih = (double)novi_igrac.odigranih_utakmica ;
                        golovi = (double)db.Database.SqlQuery<double>($"SELECT [dbo].[Prosek]({postignutih},{odigranih})").FirstOrDefault();
                        golovi = Math.Round(golovi, 2);
                    }
                    novi_igrac.prosek_golova = Math.Round(golovi,2);
                    
                    if(SelektovaniKlub != null && SelektovaniKlub != "")
                    {
                        Klub njegov_klub = db.Klubs.Find(SelektovaniKlub);
                        novi_igrac.Klub = njegov_klub;
                        novi_igrac.naziv_kluba = njegov_klub.naziv;

                        Vodi njegov_vodi = db.Vodis.Where(x => x.klub_naziv == SelektovaniKlub).FirstOrDefault();
                        if (njegov_vodi != null)
                        {
                            novi_igrac.Vodi = njegov_vodi;
                            novi_igrac.vodi_id_trenera = njegov_vodi.trener_id_trenera;
                            novi_igrac.vodi_naziv = njegov_vodi.klub_naziv;
                        }
                        
                    }
                    
                    
                    db.Igracs.Add(novi_igrac);

                    try
                    {
                        db.SaveChanges();
                        //generise sledeci ID:
                        nextID = 0;
                        transferistorija proveraIDa = null;
                        do
                        {
                            proveraIDa = db.transferistorijas.Where(x => x.id == nextID + 1).FirstOrDefault();
                            nextID++;
                        }
                        while (proveraIDa != null);
                        transferistorija transfer = new transferistorija() { id = nextID, Igrac = novi_igrac , klub = novi_igrac.naziv_kluba };
                        transfer.datum = DateTime.Now.ToShortDateString();
                        db.transferistorijas.Add(transfer);
                        db.SaveChanges();

                        MessageBox.Show("Uspesno dodat igrac","Uspesno",MessageBoxButton.OK,MessageBoxImage.Asterisk);
                        LogReport(novi_igrac);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Greska prilikom dodaje igraca","Oprez",MessageBoxButton.OK,MessageBoxImage.Warning);
                    }
                    
                }
            }
        }

        public bool validate()
        {
            using (var db = new BazaZaLiguEntities())
            {                
                if (Igrac_prop.ime_igraca == "" || Igrac_prop.prezime_igraca == "" || Golovi == "" || Utakmice == "" || Godine == "")
                {
                    MessageBox.Show("Potrebno je popuniti sva polja korektno", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                bool isNan = int.TryParse(Golovi, out int x);
                if(!isNan)
                {
                    MessageBox.Show("Broj datih golova mora biti BROJ", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                isNan = int.TryParse(Utakmice, out int y);
                if (!isNan)
                {
                    MessageBox.Show("Broj odigranih utakmica mora biti BROJ", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                isNan = int.TryParse(Godine, out int z);
                if (!isNan)
                {
                    MessageBox.Show("Godine igraca mora biti BROJ", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }

            }
            Igrac_prop.postignutih_golova = int.Parse(Golovi);
            Igrac_prop.odigranih_utakmica = int.Parse(Utakmice);
            Igrac_prop.godine_igraca = int.Parse(Godine);
            return true;
        }

        public void LogReport(Igrac logObjekat)
        {
            string outPutText = "";
            StreamWriter file = new StreamWriter("@../../../../../LogReport.txt", true);
            outPutText = string.Format("KREIRANJE {0} \t IGRAC:    ID: {1} , Ime: {2}  , Prezime: {3}\n"
                 , DateTime.Now.ToShortDateString(), logObjekat.id_igraca, logObjekat.ime_igraca , logObjekat.prezime_igraca);

            file.WriteLine(outPutText);
            file.Close();
        }


    }
}
