using CityCrawlApp.ViewModels;
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
    /// Interaction logic for LoginError.xaml
    /// </summary>
    public partial class LoginError : Window
    {
        public LoginError(ViewModels.ErrorLoginViewModel vmErrorLogin)
        {
            InitializeComponent();
            DataContext = vmErrorLogin;
            vmErrorLogin.CloseDialog = (bool dialogResult) =>
            {
                this.DialogResult = dialogResult;
            };
        }
    }
}
