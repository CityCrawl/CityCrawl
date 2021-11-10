using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;
using Prism.Commands;
using CityCrawlApp.Views;

namespace CityCrawlApp.ViewModels
{
    public class TilmeldPubcrawlViewModel : BindableBase
    {
        private string loggedInUser;
        private string userPassword;


        private DelegateCommand visProfil;
        public DelegateCommand VisProfil =>
            visProfil ?? (visProfil = new DelegateCommand(ExecuteVisProfil));

        void ExecuteVisProfil()
        {
          
            var vmMinProfil = new MinProfilViewModel(loggedInUser, userPassword);
            var dialog = new MinProfil(vmMinProfil);

            dialog.ShowDialog();
        }


        public TilmeldPubcrawlViewModel(string loggedInUser, string userPassword)
        {
            this.loggedInUser = loggedInUser;
            this.userPassword = userPassword;
            App.Current.MainWindow.Visibility = Visibility.Hidden;
        }
    }
}
