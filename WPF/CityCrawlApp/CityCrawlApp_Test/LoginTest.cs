using CityCrawlApp.Models;
using NUnit.Framework;
using NSubstitute;
using CityCrawlApp.ViewModels;
using CityCrawlApp.Models.Interfaces;
using Prism.Commands;
using NSubstitute.ReceivedExtensions;

namespace CityCrawlApp.Test
{
    public class LoginTest
    {

        private LoginViewModel uut;
        private LoginViewModel login;
        private IUser user;
        private IhttpClient httpClient;


        [SetUp]
        public void Setup()
        {
            httpClient = Substitute.For<IhttpClient>();
            user = Substitute.For<IUser>();
            login = new LoginViewModel();
            uut = new LoginViewModel();
            login.Email = "User@mail.dk";
            login.Password = "testPassword";
        }

        [Test]
        public void TestLoginDelegateCanExecute()
        {
            // Assert
            uut.Login.CanExecute();
        }

        [Test]
        public void TestHttpClientGetUserFromServerIsCalled()
        {
            // Assert
            httpClient.Received(1).HttpClientGetUserFromServer(user.Email, user.Password);
        }
    }
}
