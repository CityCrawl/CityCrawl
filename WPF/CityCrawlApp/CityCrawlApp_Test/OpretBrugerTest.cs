using CityCrawlApp.Models;
using NUnit.Framework;
using NSubstitute;
using CityCrawlApp.ViewModels;
using CityCrawlApp.Models.Interfaces;
using Prism.Commands;
using System;

namespace CityCrawlApp.Test
{
    public class OpretBrugerTest
    {

        private OpretBrugerViewModel uut;
        private IhttpClient httpClientMock;
        private Action<bool> closeActionMock;

        [SetUp]
        public void Setup()
        {
            httpClientMock = Substitute.For<IhttpClient>();
            closeActionMock = Substitute.For<Action<bool>>();
            uut = new OpretBrugerViewModel(httpClientMock);
            uut.Email = "user@mail.dk";
            uut.Password = "testPassword";
            uut.Birthday = "11-11-1999";
            uut.FirstName = "Hans";
            uut.LastName = "Hansen";
        }

        [Test]
        public void TestVisProfilDelegateCanExecute()
        {
            // Act
            var visProfilExecute = uut.VisProfil.CanExecute();

            // Assert
            Assert.True(visProfilExecute);
        }

        [Test]
        public void TestVisProfilDelegateExecute()
        {
            // Arrange
            var User = new User();
            User.FirstName = uut.FirstName;
            User.LastName = uut.LastName;
            User.Birthday = uut.Birthday;
            User.Email = uut.Email;
            User.Password = uut.Email;
            
            // Act
            uut.VisProfil.Execute();

            // Assert
            httpClientMock.Received(1).HttpClientCreateUser(User);
            closeActionMock.Received(1).Invoke(true);
        }
    }
}