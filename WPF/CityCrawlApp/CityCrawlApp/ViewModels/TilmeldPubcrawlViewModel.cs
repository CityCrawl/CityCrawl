using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using CityCrawlApp.Models;
using Prism.Mvvm;
using Prism.Commands;
using CityCrawlApp.Views;

namespace CityCrawlApp.ViewModels
{
    public class TilmeldPubcrawlViewModel : BindableBase
    {
        

        private string loggedInUser;
        private string userPassword;

        private string selectedDate;
        public string SelectedDate
        {
            get { return selectedDate; }
            set { SetProperty(ref selectedDate, value); }
        }

        private DelegateCommand getPubCrawlOneAndDate;
        public DelegateCommand GetPubCrawlOneAndDate =>
            getPubCrawlOneAndDate ?? (getPubCrawlOneAndDate = new DelegateCommand(ExecuteCombineToListOne));

        void ExecuteCombineToListOne()
        {
            if (selectedDate == null)
                MessageBox.Show("Venligst vælg dato, før pakke vælges");
            else
            {
                User userInDB = new User();
                userInDB.pubCrawls.Add("Pakke 1, " + selectedDate);

                HttpClientPostUserToServerAsync(userInDB);

                MessageBox.Show($"PubCrawl booket: {userInDB.pubCrawls.ElementAt(0)}");
            }
            
        }

        

        private DelegateCommand getPubCrawlTwoAndDate;
        public DelegateCommand GetPubCrawlTwoAndDate =>
            getPubCrawlTwoAndDate ?? (getPubCrawlTwoAndDate = new DelegateCommand(ExecuteCombineToListTwo));

        void ExecuteCombineToListTwo()
        {
            if (selectedDate == null)
                MessageBox.Show("Venligst vælg dato, før pakke vælges");
            else
            {
                User userInDB = new User();
                userInDB.pubCrawls.Add("Pakke 2, " + selectedDate);

                HttpClientPostUserToServerAsync(userInDB);

                MessageBox.Show($"PubCrawl booket: {userInDB.pubCrawls.ElementAt(0)}");
            }
        }

        private DelegateCommand visProfil;
        public DelegateCommand VisProfil =>
            visProfil ?? (visProfil = new DelegateCommand(ExecuteVisProfil));

        void ExecuteVisProfil()
        {
          
            var vmMinProfil = new MinProfilViewModel(loggedInUser, userPassword);
            var dialog = new MinProfil(vmMinProfil);

            dialog.ShowDialog();
        }


        public TilmeldPubcrawlViewModel(string loggedInUser, string userPassword)
        {
            this.loggedInUser = loggedInUser;
            this.userPassword = userPassword;
            App.Current.MainWindow.Visibility = Visibility.Hidden;
        }

        private async Task HttpClientPostUserToServerAsync(User user)
        {
            using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, Settings.baseUrl))
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                HttpClient client = new HttpClient();
                //var content = new User()
                //{
                //    FirstName = user.FirstName,
                //    LastName = user.LastName,
                //    Birthday = user.Birthday,
                //    Email = user.Email,
                //    Password = user.Password
                //};

                var json = System.Text.Json.JsonSerializer.Serialize(user, options);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    httpRequest.Content = stringContent;
                    using (var httpResponse = await client
                        .SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
                    {
                        httpResponse.EnsureSuccessStatusCode();
                    }
                }
            }
        }
    }
}
