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
using CityCrawlApp.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CityCrawlApp.ViewModels
{
    public class MinProfilViewModel : BindableBase
    {
        private httpClient httpClient = new httpClient();


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
            set { SetProperty(ref listOfPubcrawls, value); }
        }

        private string loggedInUser;
        private string userPassword;

        public MinProfilViewModel(string loggedInUser, string userPassword)
        {
            this.loggedInUser = loggedInUser;
            this.userPassword = userPassword;

            App.Current.MainWindow.Visibility = Visibility.Hidden;

            var user = httpClient.HttpClientGetUserFromServer(loggedInUser, userPassword);
            if (user != null)
            {
                FirstName = user.FirstName;
                LastName = user.LastName;
                Birthday = user.Birthday;
                Email = user.Email;

                foreach (var pubcrawl in user.PubCrawls)
                {
                    this.Pubcrawls.Add(pubcrawl);
                }
            }
            else
            {
                // show error / close window?
            }
            

            /*OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    var jsonText = sr.ReadToEnd();
                    var user = JsonConvert.DeserializeObject<User>(jsonText);

                    FirstName = user.FirstName;
                    LastName = user.LastName;
                    Birthday = user.Birthday;
                    Email = user.Email;
                }
            }*/
        }


        private DelegateCommand tilmeldPubcrawl;
        public DelegateCommand TilmeldPubcrawl =>
            tilmeldPubcrawl ?? (tilmeldPubcrawl = new DelegateCommand(ExecuteTilmeldPubcrawl));

        void ExecuteTilmeldPubcrawl()
        {
            var vmTilmeld = new TilmeldPubcrawlViewModel(loggedInUser, userPassword);
            var dialog = new TilmeldPubcrawl(vmTilmeld);

            dialog.ShowDialog();
        }

    }
}
