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

            user.Fornavn = "Test user";
            user.Efternavn = "Test user lastname";
            user.Foedselsdag = "09-09-1991";
            user.Email = "userEmail@email.dk";
            user.Pubcrawls = new List<Pubcrawl>();
            Pubcrawl pakke1 = new Pubcrawl();
            Pubcrawl pakke2 = new Pubcrawl();
            pakke1.PakkeNavn = "Pakke 1";
            pakke2.PakkeNavn = "Pakke 2";
            pakke1.MoedeTid = new DateTime(2021, 12, 09);
            pakke2.MoedeTid = new DateTime(2021, 12, 10);
            user.Pubcrawls.Add(pakke1);
            user.Pubcrawls.Add(pakke2);

            httpClientMock.HttpClientGetUserFromServer(loggedInUser, userPassword).Returns(user);
        }


        [Test]
        public void TestMinProfilConstructorGetUserDataFromServerWhenReturnsUser()
        {
            // Act
            uut = new MinProfilViewModel(loggedInUser, userPassword, httpClientMock, dialogServiceMock, appControlServiceMock);

            // Assert
            Assert.That(uut.FirstName, Is.EqualTo(user.Fornavn));
            Assert.That(uut.LastName, Is.EqualTo(user.Efternavn));
            Assert.That(uut.Birthday, Is.EqualTo(user.Foedselsdag));
            Assert.That(uut.Email, Is.EqualTo(user.Email));
            
            Assert.That(uut.Pubcrawls[0], Is.EqualTo("Pakke 1 d. 09-12-2021 00:00:00"));
            Assert.That(uut.Pubcrawls[1], Is.EqualTo("Pakke 2 d. 10-12-2021 00:00:00"));

        }

        [Test]
        public void TestMinProfilConstructorGetUserDataFromServerWhenReturnsNull()
        {
            // Arrange
            httpClientMock.HttpClientGetUserFromServer(loggedInUser, userPassword).Returns((User) null);
            
            // Act and Assert
            var exception = Assert.Throws<Exception>(() => uut = new MinProfilViewModel(loggedInUser, userPassword, httpClientMock, dialogServiceMock, appControlServiceMock));

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
