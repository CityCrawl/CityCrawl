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
        private IUser user;
        private IhttpClient httpClient;
        private string loggedInUser = "User@mail.dk";
        private string userPassword = "testPassword";

        [SetUp]
        public void Setup()
        {
            user = Substitute.For<IUser>();
            user.Email = "User@mail.dk";
            user.Password = "testPassword";
            httpClient = Substitute.For<IhttpClient>();
            uut = new MinProfilViewModel(loggedInUser, userPassword);
        }

        [Test]
        public void TestHttpGetUserFromServerIsCalled()
        {
            // Assert
            httpClient.Received(1).HttpClientGetUserFromServer(user.Email, user.Password);
        }

        [Test]
        public void TestTilmeldPubcrawlDelegateCanExecute()
        {
            // Assert
            uut.TilmeldPubcrawl.CanExecute();
        }

    }
}
