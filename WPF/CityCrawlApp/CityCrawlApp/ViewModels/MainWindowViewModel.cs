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
using CityCrawlApp.Models.Interfaces;

namespace CityCrawlApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IhttpClient httpClient;
        private IDialogService dialogService;

        public MainWindowViewModel(IhttpClient httpClient, IDialogService dialogService)
        {
            this.httpClient = httpClient;
            this.dialogService = dialogService;
        }


        private DelegateCommand loginBtn;
        public DelegateCommand LoginBtn =>
            loginBtn ?? (loginBtn = new DelegateCommand(ExecuteLoginBtn));

        void ExecuteLoginBtn()
        {
            var loginModel = dialogService.ShowLoginDialog(httpClient);

            if (loginModel != null)
            {
                dialogService.ShowMinProfilDialog(loginModel.Email, loginModel.Password, httpClient, dialogService);
            }
        }

        private DelegateCommand opretBrugerBtn;
        public DelegateCommand OpretBrugerBtn =>
            opretBrugerBtn ?? (opretBrugerBtn = new DelegateCommand(ExecuteOpretBrugerBtn));

        void ExecuteOpretBrugerBtn()
        {
            var vmOpretBruger = dialogService.ShowOpretBrugerDialog(httpClient);

            if (vmOpretBruger != null)
            {
                dialogService.ShowMinProfilDialog(vmOpretBruger.Email, vmOpretBruger.Password, httpClient, dialogService);
            }
        }
    }
}
