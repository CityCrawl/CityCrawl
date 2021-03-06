using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityCrawlApp.Models.Interfaces;
using CityCrawlApp.Models;
using Prism.Mvvm;
using Prism.Commands;
using CityCrawlApp.Views;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Win32;
using System.Net.Http;
using System.Text.Json;

namespace CityCrawlApp.ViewModels
{
    public class OpretBrugerViewModel : BindableBase
    {
        private readonly ICCHttpClient httpClient;

        public OpretBrugerViewModel(ICCHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


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

        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        public Action<bool> CloseDialog { get; set; }

        private DelegateCommand visProfil;
        public DelegateCommand VisProfil =>
            visProfil ?? (visProfil = new DelegateCommand(ExecuteVisProfil));

        void ExecuteVisProfil()
        {
            // dette skal udskiftes med post metode i API controller via HttpClient!!!
            User userInDB = new User();
            userInDB.Fornavn = firstName;
            userInDB.Efternavn = lastName;
            userInDB.Foedselsdag = birthday;
            userInDB.Email = email;
            userInDB.Password = password;

            httpClient.HttpClientCreateUser(userInDB);
            CloseDialog(true);
        }

    }
}
