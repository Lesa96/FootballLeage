using Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Client.ViewModels
{
    public class RegisterViewModel : BindableBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public MyICommand<PasswordBox> RegisterCommand { get; set; }

        public RegisterViewModel()
        {
            RegisterCommand = new MyICommand<PasswordBox>(OnRegister);
        }       

        private void OnRegister(PasswordBox passwordBox)
        {
            Password = passwordBox.Password;
            using (var db = new BazaZaLiguEntities())
            {
                if (Validate())
                {
                    int nextID = 0;
                    LogUser proveraID = null;
                    do
                    {
                        proveraID = db.LogUsers.Where(x => x.id_usera == nextID + 1).FirstOrDefault();
                        nextID++;
                    }
                    while (proveraID != null);
                    LogUser user = new LogUser() { id_usera = nextID , username_usera = Username, password_usera = Password, role_usera = "User" };
                    db.LogUsers.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("Uspesno ste se registrovali", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.Title == "Register")
                        {
                            window.Close();
                        }
                    }
                }
            }
        }

        private bool Validate()
        {
            using (var db = new BazaZaLiguEntities())
            {
                if(Username == "" || Username == null || Password == "" || Password == null)
                {
                    MessageBox.Show("Potrebno je popuniti polja","Oprez" , MessageBoxButton.OK , MessageBoxImage.Warning);
                    return false;
                }
                if(Username.Length <=5 || Password.Length <= 5)
                {
                    MessageBox.Show("Username i Password moraju imati najmanje 6 karaktera", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                LogUser logUser = db.LogUsers.Where(x => x.username_usera == Username).FirstOrDefault();
                if(logUser != null)
                {
                    MessageBox.Show("Postoji korisnik sa tim Username-om", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }

                return true;
            }
        }
    }
}
