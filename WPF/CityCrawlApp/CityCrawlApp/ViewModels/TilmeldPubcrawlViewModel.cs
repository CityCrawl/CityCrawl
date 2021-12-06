using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using CityCrawlApp.Models.Interfaces;
using CityCrawlApp.Models;
using Prism.Mvvm;
using Prism.Commands;
using CityCrawlApp.Views;

namespace CityCrawlApp.ViewModels
{
    public partial class TilmeldPubcrawlViewModel : BindableBase
    {
        private readonly string loggedInUser;
        private readonly string userPassword;
        private IhttpClient httpClient;
        private IDialogService dialogService;
        private IAppControlService appControlService;
        private Pubcrawl pubcrawl = new Pubcrawl();

        public TilmeldPubcrawlViewModel(string loggedInUser, string userPassword,
            IhttpClient httpClient, IDialogService dialogService, IAppControlService appControlService)
        {
            this.loggedInUser = loggedInUser;
            this.userPassword = userPassword;
            this.httpClient = httpClient;
            this.dialogService = dialogService;
            this.appControlService = appControlService;

            this.appControlService.SetMainWindowVisibilityToHidden();
        }

        private DateTime selectedDate;
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set { SetProperty(ref selectedDate, value); }
        }


        private DelegateCommand getPubCrawlOneAndDate;
        public DelegateCommand GetPubCrawlOneAndDate =>
            getPubCrawlOneAndDate ?? (getPubCrawlOneAndDate = new DelegateCommand(ExecuteCombineToListOne));

        void ExecuteCombineToListOne()
        {
            CreatePubcrawl("Pakke 1");
        }


        private DelegateCommand getPubCrawlTwoAndDate;
        public DelegateCommand GetPubCrawlTwoAndDate =>
            getPubCrawlTwoAndDate ?? (getPubCrawlTwoAndDate = new DelegateCommand(ExecuteCombineToListTwo));
        void ExecuteCombineToListTwo()
        {
            CreatePubcrawl("Pakke 2");
        }

        // metode som kaldes i Execute for pubcrawl Pakke 1 eller Pakke 2
        private void CreatePubcrawl(string package)
        {
            if (selectedDate.ToString("dd/MM/yyyy") == "01-01-0001")
                appControlService.ShowMessageBox("Venligst vælg dato, før pakke vælges");
            else
            {
                pubcrawl.PakkeNavn = package;
                pubcrawl.MoedeTid = selectedDate;
                pubcrawl.MoedeSted = "";

                var newPubcrawlRequest = new NewPubcrawlRequest();
                newPubcrawlRequest.Pubcrawl = pubcrawl;
                newPubcrawlRequest.Email = loggedInUser;
               
                httpClient.HttpClientAddPubCrawls(newPubcrawlRequest);

                appControlService.ShowMessageBox($"PubCrawl booket: {pubcrawl.PakkeNavn}, d. {pubcrawl.MoedeTid}");
            }
        }


        private DelegateCommand visProfil;
        public DelegateCommand VisProfil =>
            visProfil ?? (visProfil = new DelegateCommand(ExecuteVisProfil));

        void ExecuteVisProfil()
        {
            dialogService.ShowMinProfilDialog(loggedInUser, userPassword, httpClient, dialogService, appControlService);
        }
    }
}
