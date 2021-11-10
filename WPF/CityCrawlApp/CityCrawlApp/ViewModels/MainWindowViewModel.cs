using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using CityCrawlApp.Views;
using Microsoft.Win32;
using System.IO;
using Newtonsoft.Json;
using CityCrawlApp.Models;

namespace CityCrawlApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private DelegateCommand loginBtn;
        public DelegateCommand LoginBtn =>
            loginBtn ?? (loginBtn = new DelegateCommand(ExecuteLoginBtn));

        void ExecuteLoginBtn()
        {
            var vmLogin = new LoginViewModel();
            var dialog = new Login(vmLogin);

            if (dialog.ShowDialog() == true)
            {
                var user = vmLogin.Email;
                var password = vmLogin.Password;
                var vmMinProfil = new MinProfilViewModel(user, password);
                var dialogMinProfil = new MinProfil(vmMinProfil);

                dialogMinProfil.ShowDialog();

            }
        }

        private DelegateCommand opretBrugerBtn;
        public DelegateCommand OpretBrugerBtn =>
            opretBrugerBtn ?? (opretBrugerBtn = new DelegateCommand(ExecuteOpretBrugerBtn));

        void ExecuteOpretBrugerBtn()
        {
            var vmOpretBruger = new OpretBrugerViewModel();
            var dialog = new OpretBruger(vmOpretBruger);

            if (dialog.ShowDialog() == true)
            {
                var user = vmOpretBruger.Email;
                var password = vmOpretBruger.Password;
                var vmMinProfil = new MinProfilViewModel(user, password);
                var dialogMinProfil = new MinProfil(vmMinProfil);

                dialogMinProfil.ShowDialog();

            }
        }
    }
}
