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

            dialog.ShowDialog();
        }

        private DelegateCommand opretBrugerBtn;
        public DelegateCommand OpretBrugerBtn =>
            opretBrugerBtn ?? (opretBrugerBtn = new DelegateCommand(ExecuteOpretBrugerBtn));

        void ExecuteOpretBrugerBtn()
        {
            var vmOpretBruger = new OpretBrugerViewModel();
            var dialog = new OpretBruger(vmOpretBruger);

            dialog.ShowDialog();
        }
    }
}
