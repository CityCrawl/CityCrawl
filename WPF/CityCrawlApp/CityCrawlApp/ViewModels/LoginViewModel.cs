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
using CityCrawlApp.Models;

namespace CityCrawlApp.ViewModels
{
    public class LoginViewModel : BindableBase
    {
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
                var vmErrorLogin = new ErrorLoginViewModel();
                var dialogErrorLogin = new LoginError(vmErrorLogin);

                dialogErrorLogin.ShowDialog();
                return; // on error stop flow
            }

            // erstattes med httpClient og get fra API controller
            var user = HttpClientGetUserFromServer(email, password);
            if (user == null)
            {
                var vmErrorLogin = new ErrorLoginViewModel();
                var dialogErrorLogin = new LoginError(vmErrorLogin);
                dialogErrorLogin.ShowDialog();
            }
            else
            {
                CloseDialog(true);
            }

            /*OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    var jsonText = sr.ReadToEnd();
                    var user = JsonConvert.DeserializeObject<User>(jsonText);

                    if (user.Email != email || user.Password != password)
                    {
                        var vmErrorLogin = new ErrorLoginViewModel();
                        var dialogErrorLogin = new LoginError(vmErrorLogin);

                        dialogErrorLogin.ShowDialog();
                        // bad user email or/and password, flow ends
                    }
                    else
                    {
                        // closes login with true: user is logged in
                        CloseDialog(true); 
                    }
                }
            }*/
        }

        private User HttpClientGetUserFromServer(string email, string password)
        {
            string url = $"{Settings.baseUrl}/User?email={email}&password={password}"; // tages fra app settings
            HttpClient client = new HttpClient();
            try
            {
                Task<string> responseBody = client.GetStringAsync(url);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                var user = JsonSerializer.Deserialize<User>(responseBody.Result, options);
                return user;
            }
            catch (Exception e)
            {
                // show erro failed to talk to server...
                return null;
            }
        }
    }
}
