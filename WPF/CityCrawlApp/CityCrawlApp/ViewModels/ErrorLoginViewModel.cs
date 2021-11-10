using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using CityCrawlApp.Views;
using Prism.Commands;
using Prism.Mvvm;

namespace CityCrawlApp.ViewModels
{
    public class ErrorLoginViewModel: BindableBase
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
                var vmMinProfil = new MinProfilViewModel();
                var dialogMinProfil = new MinProfil(vmMinProfil);

                dialogMinProfil.ShowDialog();

            }
        }


        private DelegateCommand opretBruger;
        public DelegateCommand OpretBruger =>
            opretBruger ?? (opretBruger = new DelegateCommand(ExecuteOpretBruger));

        void ExecuteOpretBruger()
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
