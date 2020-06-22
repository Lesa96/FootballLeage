using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    public class TrenerViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private BindableBase currentViewModel;
        private AddTrenerViewModel addTrenerViewModel = new AddTrenerViewModel();
        private ShowTrenerViewModel showTrenerViewModel = new ShowTrenerViewModel();
        private UpdateTrenerViewModel updateTrenerViewModel = new UpdateTrenerViewModel();
        private Visibility visibility;

        public TrenerViewModel()
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
            CurrentViewModel = showTrenerViewModel;
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
                    CurrentViewModel = addTrenerViewModel;
                    break;
                case "myShow":
                    CurrentViewModel = showTrenerViewModel;
                    break;
                case "myUpdate":
                    CurrentViewModel = updateTrenerViewModel;
                    break;

            }
        }
    }
}
