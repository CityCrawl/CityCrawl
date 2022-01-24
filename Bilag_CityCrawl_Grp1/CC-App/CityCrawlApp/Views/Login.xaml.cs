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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login(ViewModels.LoginViewModel vmLogin)
        {
            InitializeComponent();
            DataContext = vmLogin;
            vmLogin.CloseDialog = (bool dialogResult) =>
            {
                this.DialogResult = dialogResult;
            };
        }

        private void PasswordLoginTextBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((LoginViewModel)this.DataContext).Password = ((PasswordBox)sender).Password; }
        }
    }
}
