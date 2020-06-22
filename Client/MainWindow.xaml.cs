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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            
        }

        

        #region TabChanges

        private void ChangeMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            ChangeColors(menuItem);
        }
        
        private void ChangeColors(MenuItem tabName)
        {

            LigaMenu.Background = SystemColors.MenuBrush;
            KlubMenu.Background = SystemColors.MenuBrush;
            IgracMenu.Background = SystemColors.MenuBrush;
            TrenerMenu.Background = SystemColors.MenuBrush;
            SudijaMenu.Background = SystemColors.MenuBrush;
            NavijacMenu.Background = SystemColors.MenuBrush;
            StadionMenu.Background = SystemColors.MenuBrush;
            RadnikMenu.Background = SystemColors.MenuBrush;
            VlasnikMenu.Background = SystemColors.MenuBrush;
            MenadzerMenu.Background = SystemColors.MenuBrush;

            tabName.Background = Brushes.Gainsboro;

        }
        #endregion
    }
}
