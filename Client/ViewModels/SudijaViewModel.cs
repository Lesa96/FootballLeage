using Client.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    public class SudijaViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private BindableBase currentViewModel;
        private AddSudijaViewModel addSudijaViewModel = new AddSudijaViewModel();
        private ShowSudijaViewModel showSudijaViewModel = new ShowSudijaViewModel();
        private UpdateSudijaViewModel updateSudijaViewModel = new UpdateSudijaViewModel();
        private Visibility visibility;

        public SudijaViewModel()
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
            CurrentViewModel = showSudijaViewModel;
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
                    CurrentViewModel = addSudijaViewModel;
                    break;
                case "myShow":
                    CurrentViewModel = showSudijaViewModel;
                    break;
                case "myUpdate":
                    CurrentViewModel = updateSudijaViewModel;
                    break;

            }
        }

        
    }
}
