using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using CityCrawlApp.Views;
using Microsoft.Win32;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using CityCrawlApp.Models.Interfaces;

namespace CityCrawlApp.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private ICCHttpClient httpClient;
        private IDialogService dialogService;

        public LoginViewModel(ICCHttpClient httpClient, IDialogService dialogService)
        {
            this.httpClient = httpClient;
            this.dialogService = dialogService;
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

       
        private DelegateCommand login;
        public DelegateCommand Login =>
            login ?? (login = new DelegateCommand(ExecuteLogin));

        public Action<bool> CloseDialog { get; set; }

        void ExecuteLogin()
        {
            if (email == null || password == null)
            {
                dialogService.ShowErrorDialog();
                return; // on error stop flow
            }

            // erstattes med httpClient og get fra API controller
            var user = httpClient.HttpClientGetUserFromServer(email, password);
            if (user == null)
            {
                dialogService.ShowErrorDialog();
            }
            else
            {
                CloseDialog(true);
            }
        }

    }
}
