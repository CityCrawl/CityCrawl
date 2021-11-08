using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using CityCrawlApp.Views;

namespace CityCrawlApp.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private DelegateCommand login;
        public DelegateCommand Login =>
            login ?? (login = new DelegateCommand(ExecuteLogin));

        void ExecuteLogin()
        {
            var vmMinProfil = new MinProfilViewModel();
            var dialog = new MinProfil(vmMinProfil);

            dialog.ShowDialog();
        }
    }
}
