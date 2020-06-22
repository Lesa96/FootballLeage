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
    public class UpdateLigaViewModel : BindableBase
    {
        public static ObservableCollection<Liga> ligeUpdate { get; set; }
        private Liga selektovana_liga;
        private bool canUpdate;
        public ObservableCollection<string> Drzave { get; set; }
        public MyICommand UpdateCommand { get; set; }

        public UpdateLigaViewModel()
        {
            Drzave = new ObservableCollection<string>();
            ligeUpdate = new ObservableCollection<Liga>();
            UpdateCommand = new MyICommand(onUpdate);

            using (var db = new BazaZaLiguEntities())
            {
                foreach (Liga item in db.Ligas)
                {
                    ligeUpdate.Add(item);
                }
            }
            OnPropertyChanged("ligeUpdate");
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

        public Liga Selektovana_ligaUpdate
        {
            get { return selektovana_liga; }
            set
            {
                SetProperty(ref selektovana_liga, value);
                OnPropertyChanged("Selektovana_ligaUpdate");

                if (selektovana_liga != null)
                    CanUpdate = true;
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
                    Liga liga_update = db.Ligas.Where(x => x.id_lige.Equals(Selektovana_ligaUpdate.id_lige)).First();

                    if(liga_update != null)
                    {
                        liga_update.drzava_lige = Selektovana_ligaUpdate.drzava_lige;
                        liga_update.naziv_lige = Selektovana_ligaUpdate.naziv_lige;

                        db.Entry(liga_update).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        MessageBox.Show("Uspesno ste promenili ligu", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                }
            }
        }

        public bool validate()
        {
            if(Selektovana_ligaUpdate.naziv_lige =="" || Selektovana_ligaUpdate.drzava_lige =="")
            {
                MessageBox.Show("Potrebno je popuniti sva polja !", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            

            return true;

            
        }
    }
}
