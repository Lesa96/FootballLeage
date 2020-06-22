using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    public class LigaViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private BindableBase currentViewModel;
        private AddLigaViewModel addLigaViewModel = new AddLigaViewModel();
        private ShowLigaViewModel showLigaViewModel = new ShowLigaViewModel();
        private UpdateLigaViewModel updateLigaViewModel = new UpdateLigaViewModel();
        private Visibility visibility;

        public LigaViewModel()
        {
            string role = (string) Application.Current.Properties["Role"];
            if(role != "Admin")
            {
                Visibility = Visibility.Hidden;   
            }
            else
            {
                Visibility = Visibility.Visible;   
            }
            

             NavCommand = new MyICommand<string>(OnNav);
            CurrentViewModel = showLigaViewModel;
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
                    CurrentViewModel = addLigaViewModel;
                    break;
                case "myShow":
                    CurrentViewModel = showLigaViewModel;
                    break;
                case "myUpdate":
                    CurrentViewModel = updateLigaViewModel;
                    break;

            }
        }
    }
}
