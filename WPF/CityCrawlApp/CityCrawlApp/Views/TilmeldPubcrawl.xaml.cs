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

namespace CityCrawlApp.Views
{
    /// <summary>
    /// Interaction logic for RegisterPubcrawl.xaml
    /// </summary>
    public partial class TilmeldPubcrawl : Window
    {
        public TilmeldPubcrawl(ViewModels.TilmeldPubcrawlViewModel vmTilmeld)
        {
            InitializeComponent();
            DataContext = vmTilmeld;
        }

        private void MenuItemLogOut_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
            App.Current.MainWindow.Visibility = Visibility.Visible;

        }

        private void MenuItemShowProfile_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
 
}
