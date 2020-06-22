using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    public class IgracViewModel : BindableBase
    {
        

        public MyICommand<string> NavCommand { get; private set; }
        private BindableBase currentViewModel;
        private AddIgracViewModel addIgracViewModel = new AddIgracViewModel();
        private ShowIgracViewModel showIgracViewModel = new ShowIgracViewModel();
        private UpdateIgracViewModel updateIgracViewModel = new UpdateIgracViewModel();
        private Visibility visibility;

        public IgracViewModel()
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
            CurrentViewModel = showIgracViewModel;
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
                    CurrentViewModel = addIgracViewModel;
                    break;
                case "myShow":
                    CurrentViewModel = showIgracViewModel;
                    break;
                case "myUpdate":
                    CurrentViewModel = updateIgracViewModel;
                    break;

            }
        }
    }
}
