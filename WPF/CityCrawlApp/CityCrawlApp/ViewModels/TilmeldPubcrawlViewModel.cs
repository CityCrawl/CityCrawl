﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
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

        public TilmeldPubcrawlViewModel(string loggedInUser, string userPassword,
            IhttpClient httpClient, IDialogService dialogService)
        {
            this.loggedInUser = loggedInUser;
            this.userPassword = userPassword;
            this.httpClient = httpClient;
            this.dialogService = dialogService;
            App.Current.MainWindow.Visibility = Visibility.Hidden;
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
            if (selectedDate.ToString("dd/MM/yyyy") == "01-01-0001")
                MessageBox.Show("Venligst vælg dato, før pakke vælges");
            else
            {
                var pubcrawl = "Pakke 1 d. " + selectedDate.ToString("dd/MM/yyyy");
                var newRequest = new NewPubcrawlRequest
                {
                    Email = loggedInUser,
                    Pubcrawl = pubcrawl
                };
                httpClient.HttpClientAddPubCrawls(newRequest);

                MessageBox.Show($"PubCrawl booket: {pubcrawl}");
            }
        }

        

        private DelegateCommand getPubCrawlTwoAndDate;
        public DelegateCommand GetPubCrawlTwoAndDate =>
            getPubCrawlTwoAndDate ?? (getPubCrawlTwoAndDate = new DelegateCommand(ExecuteCombineToListTwo));

        void ExecuteCombineToListTwo()
        {
            if (selectedDate.ToString("dd/MM/yyyy") == "01-01-0001")
                MessageBox.Show("Venligst vælg dato, før pakke vælges");
            else
            {
                var pubcrawl = "Pakke 2 d. " + selectedDate.ToString("dd/MM/yyyy");
                var newRequest = new NewPubcrawlRequest
                {
                    Email = loggedInUser,
                    Pubcrawl = pubcrawl
                };
                httpClient.HttpClientAddPubCrawls(newRequest);
                 
                MessageBox.Show($"PubCrawl booket: {pubcrawl}");
            }
        }


        private DelegateCommand visProfil;
        public DelegateCommand VisProfil =>
            visProfil ?? (visProfil = new DelegateCommand(ExecuteVisProfil));

        void ExecuteVisProfil()
        {
          
            var vmMinProfil = new MinProfilViewModel(loggedInUser, userPassword, httpClient, dialogService);
            var dialog = new MinProfil(vmMinProfil);

            dialog.ShowDialog();
        }
    }
}
