using Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace Client.ViewModels
{
    public class MyProfileVIewModel : BindableBase
    {
        private bool canChange;
        public MyICommand<PasswordBox> ChangeCommand { get; set; }
        public string Username { get; private set; }

        public MyProfileVIewModel()
        {
            Username = System.Windows.Application.Current.Properties["Username"].ToString();
            canChange = true;
            ChangeCommand = new MyICommand<PasswordBox>(ChangePass);
        }

        

        public bool CanChange
        {
            get { return canChange; }
            set
            {
                canChange = value;
                OnPropertyChanged("CanChange");
            }
        }

        private void ChangePass(PasswordBox newPass)
        {
            string pass = newPass.Password;
            if(pass.Length <= 5)
            {
                MessageBox.Show("Potrebno je uneti najmanje 6 karaktera", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            using (var db = new BazaZaLiguEntities())
            {
                LogUser user = db.LogUsers.Where(x => x.username_usera == Username).FirstOrDefault();
                if (user != null)
                {
                    user.password_usera = pass;
                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    newPass.Password = "";
                    
                    MessageBox.Show("Uspesno ste promenili lozinku", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                }
                else
                {
                    MessageBox.Show("Korisnik ne postoji", "Oprez", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
