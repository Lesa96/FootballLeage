using Client.Model;
using Client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Client
{
    public class LogInViewModel : BindableBase
    {
        private bool canLogIn;
        public MyICommand<PasswordBox> LogInCommand { get; set; }
        public MyICommand RegisterCommand { get; set; }
        public string Username { get; set; }

        public LogInViewModel()
        {
            RegisterCommand = new MyICommand(Register);
            CanLogIn = true;
            LogInCommand = new MyICommand<PasswordBox>(LogIn);
        }

        private void Register()
        {
            RegisterView registerView = new RegisterView();
            registerView.Show();
        }

        public bool CanLogIn
        {
            get { return canLogIn; }
            set
            {
                canLogIn = value;
                OnPropertyChanged("CanLogIn");
            }
        }

        public void LogIn(PasswordBox passBox)
        {
            string pass = passBox.Password;
            using (var db = new BazaZaLiguEntities())
            {
                LogUser user = db.LogUsers.Where(x => x.username_usera == Username && x.password_usera == pass).FirstOrDefault();
                if(user != null)
                {
                    Application.Current.Properties["Role"] = user.role_usera;
                    Application.Current.Properties["Username"] = user.username_usera;

                    MainWindow mainWindow = new MainWindow();
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.Title == "LogIn")
                        {
                            mainWindow.Show();
                            window.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Korisnik ne postoji", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }           
        }
    }
}
