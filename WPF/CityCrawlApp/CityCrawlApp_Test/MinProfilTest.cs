using System;
using System.Collections.Generic;
using CityCrawlApp.Models;
using NUnit.Framework;
using NSubstitute;
using CityCrawlApp.ViewModels;
using CityCrawlApp.Models.Interfaces;
using CityCrawlApp.Views;
using Prism.Commands;


namespace CityCrawlApp.Test
{
    public class MinProfilTest
    {
        private MinProfilViewModel uut;
        private IhttpClient httpClientMock;
        private IDialogService dialogServiceMock;
        private IAppControlService appControlServiceMock;
        private string loggedInUser = "User@mail.dk";
        private string userPassword = "testPassword";
        private User user = new User();

        [SetUp]
        public void Setup()
        {
            httpClientMock = Substitute.For<IhttpClient>();
            dialogServiceMock = Substitute.For<IDialogService>();
            appControlServiceMock = Substitute.For<IAppControlService>();

            user.FirstName = "Test user";
            user.LastName = "Test user lastname";
            user.Birthday = "09-09-1991";
            user.Email = "userEmail@email.dk";
            user.PubCrawls = new List<string>();
            user.PubCrawls.Add("Pakke 1");
            user.PubCrawls.Add("Pakke 2");

            httpClientMock.HttpClientGetUserFromServer(loggedInUser, userPassword).Returns(user);
        }


        [Test]
        public void TestMinProfilConstructorGetUserDataFromServerWhenReturnsUser()
        {
            // Act
            uut = new MinProfilViewModel(loggedInUser, userPassword, httpClientMock, dialogServiceMock, appControlServiceMock);

            // Assert
            Assert.That(uut.FirstName, Is.EqualTo(user.FirstName));
            Assert.That(uut.LastName, Is.EqualTo(user.LastName));
            Assert.That(uut.Birthday, Is.EqualTo(user.Birthday));
            Assert.That(uut.Email, Is.EqualTo(user.Email));
            
            Assert.That(uut.Pubcrawls[0], Is.EqualTo(user.PubCrawls[0]));
            Assert.That(uut.Pubcrawls[1], Is.EqualTo(user.PubCrawls[1]));

        }

        [Test]
        public void TestMinProfilConstructorGetUserDataFromServerWhenReturnsNull()
        {
            // Arrange
            httpClientMock.HttpClientGetUserFromServer(loggedInUser, userPassword).Returns((User) null);
            
            // Act and Assert
            var exception = Assert.Throws<Exception>(() =>
                {
                    uut = new MinProfilViewModel(loggedInUser, userPassword, httpClientMock, dialogServiceMock, appControlServiceMock);
                });

            Assert.That(exception.Message, Is.EqualTo("User is not found!"));
        }


        [Test]
        public void TestTilmeldPubcrawlDelegateCanExecute()
        {
            // Arrange
            uut = new MinProfilViewModel(loggedInUser, userPassword, httpClientMock, dialogServiceMock, appControlServiceMock);

            // Act
            var tilmeldPubcrawl = uut.TilmeldPubcrawl.CanExecute();

            // Assert
            Assert.True(tilmeldPubcrawl);
        }

        [Test]
        public void TestTilmeldPubcrawlDelegateExecute()
        {
            // Arrange
            uut = new MinProfilViewModel(loggedInUser, userPassword, httpClientMock, dialogServiceMock, appControlServiceMock);

            // Act
            uut.TilmeldPubcrawl.Execute();

            // Assert
            dialogServiceMock.Received(1).ShowTilmeldPubcrawlDialog(loggedInUser, userPassword, httpClientMock, dialogServiceMock, appControlServiceMock);
        }

    }
}
