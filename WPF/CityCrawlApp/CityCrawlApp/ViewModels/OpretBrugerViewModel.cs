using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            userInDB.FirstName = firstName;
            userInDB.LastName = lastName;
            userInDB.Birthday = birthday;
            userInDB.Email = email;
            userInDB.Password = password;

            HttpClientCreateUser(userInDB);
            CloseDialog(true);

            /*SaveFileDialog saveFileDialog = new SaveFileDialog();
            

            if (saveFileDialog.ShowDialog() == true)
            {
                var json = JsonConvert.SerializeObject(userInDB, Newtonsoft.Json.Formatting.Indented);

                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    sw.WriteLine(json);
                }

                // Return true to mainWindow, user is created
                CloseDialog(true);
            }*/
        }

        private void HttpClientCreateUser(User user)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(user, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, Settings.baseUrl + "/User/CreateUser");
            using var client = new HttpClient();
            using var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            httpRequest.Content = stringContent;

            var httpResponse = client.Send(httpRequest, HttpCompletionOption.ResponseHeadersRead);
            httpResponse.EnsureSuccessStatusCode();
        }
    }
}
