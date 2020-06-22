using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    public class ObezbedjenjeViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private BindableBase currentViewModel;
        private AddObezbedjenjeViewModel addObezbedjenjeViewModel = new AddObezbedjenjeViewModel();
        private ShowObezbedjenjeViewModel showObezbedjenjeViewModel = new ShowObezbedjenjeViewModel();
        private UpdateObezbedjenjeViewModel updateObezbedjenjeViewModel = new UpdateObezbedjenjeViewModel();
        private Visibility visibility;

        public ObezbedjenjeViewModel()
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
            CurrentViewModel = showObezbedjenjeViewModel;
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
                    CurrentViewModel = addObezbedjenjeViewModel;
                    break;
                case "myShow":
                    CurrentViewModel = showObezbedjenjeViewModel;
                    break;
                case "myUpdate":
                    CurrentViewModel = updateObezbedjenjeViewModel;
                    break;

            }
        }
    }
}
