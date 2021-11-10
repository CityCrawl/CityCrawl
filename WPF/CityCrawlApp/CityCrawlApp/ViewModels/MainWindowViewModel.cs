using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using CityCrawlApp.Views;


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
                // if(Email == EmailInDB && Password == PasswordInDB)
                var vmMinProfil = new MinProfilViewModel();
                var dialogMinProfil = new MinProfil(vmMinProfil);

                dialogMinProfil.ShowDialog();

                // else: åbne LoginError
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
                var vmMinProfil = new MinProfilViewModel();
                var dialogMinProfil = new MinProfil(vmMinProfil);

                dialogMinProfil.ShowDialog();

            }
        }
    }
}
