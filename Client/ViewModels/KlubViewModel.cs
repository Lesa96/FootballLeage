using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    public class KlubViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private BindableBase currentViewModel;
        private AddKlubViewModel addKlubViewModel = new AddKlubViewModel();
        private ShowKlubViewModel showKlubViewModel = new ShowKlubViewModel();
        private UpdateKlubViewModel updateKlubViewModel = new UpdateKlubViewModel();
        private Visibility visibility;

        public KlubViewModel()
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
            NavCommand = new MyICommand<string>(OnNav);
            CurrentViewModel = showKlubViewModel;
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
                case "myAdd":
                    CurrentViewModel = addKlubViewModel;
                    break;
                case "myShow":
                    CurrentViewModel = showKlubViewModel;
                    break;
                case "myUpdate":
                    CurrentViewModel = updateKlubViewModel;
                    break;

            }
        }
    }
}
