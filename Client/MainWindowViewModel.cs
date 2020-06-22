using Client.Model;
using Client.ViewModels;
using Client.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xaml;
using System.Xml;

namespace Client
{
    public class MainWindowViewModel : BindableBase
    {
        public MenuItem menuItem { get; set; }
        public MyICommand<string> NavCommand { get; private set; }
        private LigaViewModel ligaViewModel = new LigaViewModel();
        private KlubViewModel klubViewModel = new KlubViewModel();
        private IgracViewModel igracViewModel = new IgracViewModel();
        private TrenerViewModel trenerViewModel = new TrenerViewModel();
        private SudijaViewModel sudijaViewModel = new SudijaViewModel();
        private NavijacViewModel navijacViewModel = new NavijacViewModel();
        private StadionViewModel stadionViewModel = new StadionViewModel();
        private ObezbedjenjeViewModel obezbedjenjeViewModel = new ObezbedjenjeViewModel();
        private VlasnikViewModel vlasnikViewModel = new VlasnikViewModel();
        private MenadzerViewModel menadzerViewModel = new MenadzerViewModel();
        private ProfileView profileView; 
        private BindableBase currentViewModel;

        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            ucitajSponzore();
        }

        private void ucitajSponzore() 
        {
            using (var db = new BazaZaLiguEntities())
            {
                
                XmlDocument doc = new XmlDocument();
                doc.Load(@"../../../Sponzori.xml");
                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    string nazivSponzora = node.InnerText;
                    Sponzor sponzor = db.Sponzors.Where(x => x.naziv == nazivSponzora).FirstOrDefault();
                    if(sponzor == null)
                    {
                        sponzor = new Sponzor() { id_sponzora = db.Sponzors.Count() + 1, naziv = nazivSponzora };
                        db.Sponzors.Add(sponzor);
                        db.SaveChanges();
                    }
                }

            }
        }
       

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                
                SetProperty(ref currentViewModel, value);
            }
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "myLiga":
                    CurrentViewModel = ligaViewModel;                   
                    break;
                case "myKlub":
                    CurrentViewModel = klubViewModel;
                    break;
                case "myIgrac":
                    CurrentViewModel = igracViewModel;
                    break;
                case "myTrener":
                    CurrentViewModel = trenerViewModel;
                    break;
                case "mySudija":
                    CurrentViewModel = sudijaViewModel;
                    break;
                case "myNavijac":
                    CurrentViewModel = navijacViewModel;
                    break;
                case "myStadion":
                    CurrentViewModel = stadionViewModel;
                    break;
                case "myObezbedjenje":
                    CurrentViewModel = obezbedjenjeViewModel;
                    break;
                case "myVlasnik":
                    CurrentViewModel = vlasnikViewModel;
                    break;
                case "myMenadzer":
                    CurrentViewModel = menadzerViewModel;
                    break;
                case "myProfil":
                    profileView = new ProfileView();
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.Title == "Fudbalska Liga")
                        {

                            profileView.Show();
                            window.Close();
                        }
                    }                   
                    break;

            }
        }

        
    }
}
