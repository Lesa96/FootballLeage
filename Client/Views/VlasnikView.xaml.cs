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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for VlasnikView.xaml
    /// </summary>
    public partial class VlasnikView : UserControl
    {
        public VlasnikView()
        {
            InitializeComponent();
            this.DataContext = new VlasnikViewModel();
        }

        #region TabChanges

        private void ChangeMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            ChangeColors(menuItem);
        }

        private void ChangeColors(MenuItem tabName)
        {

            Add.Background = SystemColors.MenuBrush;
            Show.Background = SystemColors.MenuBrush;
            Update.Background = SystemColors.MenuBrush;

            tabName.Background = Brushes.Gainsboro;

        }
        #endregion
    }
}
