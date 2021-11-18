using CityCrawlApp.Models;
using NUnit.Framework;
using NSubstitute;
using CityCrawlApp.ViewModels;
using CityCrawlApp.Models.Interfaces;
using Prism.Commands;


namespace CityCrawlApp.Test
{
    public class MinProfilTest
    {
        private MinProfilViewModel uut;
        private IhttpClient httpClient;
        private IDialogService dialogService;
        private string loggedInUser = "User@mail.dk";
        private string userPassword = "testPassword";

        [SetUp]
        public void Setup()
        {
            httpClient = Substitute.For<IhttpClient>();
            dialogService = Substitute.For<IDialogService>();
            uut = new MinProfilViewModel(loggedInUser, userPassword, httpClient, dialogService);
        }

        [Test]
        public void TestHttpGetUserFromServerIsCalled()
        {
            // Assert
            httpClient.Received(1).HttpClientGetUserFromServer(loggedInUser, userPassword);
        }

        [Test]
        public void TestTilmeldPubcrawlDelegateCanExecute()
        {
            // Assert
            uut.TilmeldPubcrawl.CanExecute();
        }

    }
}
