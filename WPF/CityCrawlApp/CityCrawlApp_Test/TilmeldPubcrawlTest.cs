using CityCrawlApp.Models.Interfaces;
using NUnit.Framework;
using NSubstitute;
using CityCrawlApp.ViewModels;
using Prism.Commands;

namespace CityCrawlApp.Test
{
    public class TilmeldPubcrawlTest
    {
        private TilmeldPubcrawlViewModel uut;
        private IhttpClient httpClient;
        private IDialogService dialogService;
        private string loggedInUser = "User@mail.dk";
        private string userPassword = "testPassword";

        [SetUp]
        public void Setup()
        {
            httpClient = Substitute.For<IhttpClient>();
            dialogService = Substitute.For<IDialogService>();
            uut = new TilmeldPubcrawlViewModel(loggedInUser, userPassword, httpClient, dialogService);
        }

        [Test]
        public void TestGetPubcrawlOneAndDateDelegateCanExecute()
        {
            // Assert
            uut.GetPubCrawlOneAndDate.CanExecute();
        }

        [Test]
        public void TestGetPubcrawlTwoAndDateDelegateCanExecute()
        {
            // Assert
            uut.GetPubCrawlTwoAndDate.CanExecute();
        }

        [Test]
        public void TestVisProfilDelegateCanExecute()
        {
            // Assert
            uut.VisProfil.CanExecute();
        }
    }
}