using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using CityCrawlApp.Views;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using Microsoft.Win32;
using Newtonsoft.Json;
using CityCrawlApp.Models.Interfaces;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CityCrawlApp.ViewModels
{
    public class MinProfilViewModel : BindableBase
    {
        private ICCHttpClient httpClient;
        private IDialogService dialogService;
        private IAppControlService appControlService;


        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { SetProperty(ref lastName, value); }
        }

        private string birthday;
        public string Birthday
        {
            get { return birthday; }
            set { SetProperty(ref birthday, value); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        private ObservableCollection<string> listOfPubcrawls = new ObservableCollection<string>();
        public ObservableCollection<string> Pubcrawls
        {
            get { return listOfPubcrawls; }
        }

        private string loggedInUser;
        private string userPassword;

        public MinProfilViewModel(string loggedInUser, string userPassword,
                                ICCHttpClient httpClient, IDialogService dialogService,
                                IAppControlService appControlService)
        {
            this.loggedInUser = loggedInUser;
            this.userPassword = userPassword;
            this.httpClient = httpClient;
            this.dialogService = dialogService;
            this.appControlService = appControlService;

            this.appControlService.SetMainWindowVisibilityToHidden();

            var user = httpClient.HttpClientGetUserFromServer(loggedInUser, userPassword);
            if (user != null)
            {
                FirstName = user.Fornavn;
                LastName = user.Efternavn;
                Birthday = user.Foedselsdag;
                Email = user.Email;

                foreach (var pubcrawl in user.Pubcrawls)
                {
                    var booketPubcrawl = pubcrawl.PakkeNavn + ", d. " + pubcrawl.MoedeTid;
                    this.Pubcrawls.Add(booketPubcrawl);
                }
            }
            else
            {
                throw new Exception("User is not found!");
            }
        }


        private DelegateCommand tilmeldPubcrawl;
        public DelegateCommand TilmeldPubcrawl =>
            tilmeldPubcrawl ?? (tilmeldPubcrawl = new DelegateCommand(ExecuteTilmeldPubcrawl));

        void ExecuteTilmeldPubcrawl()
        {
            dialogService.ShowTilmeldPubcrawlDialog(loggedInUser, userPassword, httpClient, dialogService, appControlService);
        }

    }
}
