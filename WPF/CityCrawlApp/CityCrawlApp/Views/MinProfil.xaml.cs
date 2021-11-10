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
    /// Interaction logic for MinProfil.xaml
    /// </summary>
    public partial class MinProfil : Window
    {
        public MinProfil(ViewModels.MinProfilViewModel vmMinProfil)
        {
            InitializeComponent();
            DataContext = vmMinProfil;
            Closing += MinProfil_Closing;

        }

        private void MinProfil_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.MainWindow.Visibility = Visibility.Visible;
        }

        private void MenuItemLogOut_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
            App.Current.MainWindow.Visibility = Visibility.Visible;
            
        }

        private void MenuItemRegister_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}
