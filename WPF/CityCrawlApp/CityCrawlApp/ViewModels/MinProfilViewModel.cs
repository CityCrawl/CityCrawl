using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using CityCrawlApp.Views;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using Newtonsoft.Json;
using CityCrawlApp.Models;

namespace CityCrawlApp.ViewModels
{
    public class MinProfilViewModel : BindableBase
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

        public MinProfilViewModel()
        {
            App.Current.MainWindow.Visibility = Visibility.Hidden;

            OpenFileDialog openFileDialog = new OpenFileDialog();

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
            }
        }


        private DelegateCommand tilmeldPubcrawl;
        public DelegateCommand TilmeldPubcrawl =>
            tilmeldPubcrawl ?? (tilmeldPubcrawl = new DelegateCommand(ExecuteTilmeldPubcrawl));

        void ExecuteTilmeldPubcrawl()
        {
            var vmTilmeld = new TilmeldPubcrawlViewModel();
            var dialog = new TilmeldPubcrawl(vmTilmeld);

            dialog.ShowDialog();
        }
    }
}
