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
using CityCrawlApp.ViewModels;

namespace CityCrawlApp.Views
{
    /// <summary>
    /// Interaction logic for OpretBruger.xaml
    /// </summary>
    public partial class OpretBruger : Window
    {
        public OpretBruger(ViewModels.OpretBrugerViewModel vmOpretBruger)
        {
            InitializeComponent();
            DataContext = vmOpretBruger;
            vmOpretBruger.CloseDialog = (bool dialogResult) =>
            {
                this.DialogResult = dialogResult;
            };
        }

        private void PasswordOpretTextBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((OpretBrugerViewModel)this.DataContext).Password = ((PasswordBox)sender).Password; }
        }
    }
}
