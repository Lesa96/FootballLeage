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
    /// Interaction logic for ShowVlasnikView.xaml
    /// </summary>
    public partial class ShowVlasnikView : UserControl
    {
        public ShowVlasnikView()
        {
            InitializeComponent();
            this.DataContext = new ShowVlasnikViewModel();
        }
    }
}
