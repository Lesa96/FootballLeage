using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public partial class ProfileView : Window
    {
        public ProfileView()
        {
            InitializeComponent();
            this.DataContext = new ProfileViewModel();
        }

        #region TabChanges

        private void ChangeMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            ChangeColors(menuItem);
        }

        private void ChangeColors(MenuItem tabName)
        {            
            Profil.Background = SystemColors.MenuBrush;
            Korisnici.Background = SystemColors.MenuBrush;
            
            tabName.Background = Brushes.Gainsboro;

        }
        #endregion
    }
}
