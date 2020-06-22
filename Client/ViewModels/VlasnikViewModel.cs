using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    public class VlasnikViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private BindableBase currentViewModel;
        private AddVlasnikViewModel addVlasnikViewModel = new AddVlasnikViewModel();
        private ShowVlasnikViewModel showVlasnikViewModel = new ShowVlasnikViewModel();
        private UpdateVlasnikViewModel updateVlasnikViewModel = new UpdateVlasnikViewModel();
        private Visibility visibility;

        public VlasnikViewModel()
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
            CurrentViewModel = showVlasnikViewModel;
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
                    CurrentViewModel = addVlasnikViewModel;
                    break;
                case "myShow":
                    CurrentViewModel = showVlasnikViewModel;
                    break;
                case "myUpdate":
                    CurrentViewModel = updateVlasnikViewModel;
                    break;

            }
        }
    }
}
