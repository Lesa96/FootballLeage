using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    public class MenadzerViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private BindableBase currentViewModel;
        private AddMenadzerViewModel addMenadzerVIewModel = new AddMenadzerViewModel();
        private ShowMenadzerViewModel showMenadzerVIewModel = new ShowMenadzerViewModel();
        private UpdateMenadzerViewModel updateMenadzerVIewModel = new UpdateMenadzerViewModel();
        private Visibility visibility;

        public MenadzerViewModel()
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
            CurrentViewModel = showMenadzerVIewModel;
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
                    CurrentViewModel = addMenadzerVIewModel;
                    break;
                case "myShow":
                    CurrentViewModel = showMenadzerVIewModel;
                    break;
                case "myUpdate":
                    CurrentViewModel = updateMenadzerVIewModel;
                    break;

            }
        }
    }
}
