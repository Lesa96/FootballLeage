using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    public class ProfileViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private BindableBase currentViewModel;
        private MyProfileVIewModel myProfileVIewModel = new MyProfileVIewModel();
        private KorisniciVIewModel korisniciVIewModel = new KorisniciVIewModel();
        private Visibility visibility { get; set; }
        MainWindow mainWindow;
        LogInView logInView;

        public ProfileViewModel()
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

            NavCommand = new MyICommand<string>(onNav);
            CurrentViewModel = myProfileVIewModel;
        }

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {

                SetProperty(ref currentViewModel, value);
            }
        }

        public Visibility Visibility
        {
            get { return visibility; }
            set
            {
                visibility = value;
                OnPropertyChanged("Visibility");
            }

        }

        private void onNav(string destination)
        {
            switch(destination)
            {
                case "myBack":
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.Title == "Profile")
                        {
                            mainWindow = new MainWindow();
                            mainWindow.Show();
                            window.Close();
                        }
                    }
                    break;
                case "myKorisnici":
                    CurrentViewModel = korisniciVIewModel;
                    break;
                case "myProfil":
                    CurrentViewModel = myProfileVIewModel;
                    break;
                case "myLogOut":
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.Title == "Profile")
                        {
                            logInView = new LogInView();
                            logInView.Show();
                            window.Close();
                        }
                    }
                    break;
            }
        }
    }
}
