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

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            var json = JsonConvert.SerializeObject(userInDB, Newtonsoft.Json.Formatting.Indented);

            using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
            {
                sw.WriteLine(json);
            }
        }
    }
}

// burde hellere kun gemme informationer her, evt. først til properties i User klassen: efterfølgende i databasen
// Så hvis det går godt returnere true (dialog.ShowDialog() == true) til MainWindowViewModel:
// så kan det åbne MinProfil vinduet og lukke Opret bruger vinduet
// gentage dette princip for alle vinduerne så alle kaldes fra MainWindowViewModel

// hvis man sender klassen User med og så opdaterer dens properties med det som indtastes,
// så vil dette huskes når dette modal vindue returnerer til mainWindow