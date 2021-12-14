using System;
using CityCrawlApp.Models;
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
        private ICCHttpClient httpClientMock;
        private IDialogService dialogServiceMock;
        private IAppControlService appControlServiceMock;
        private string loggedInUser = "User@mail.dk";
        private string userPassword = "testPassword";

        [SetUp]
        public void Setup()
        {
            httpClientMock = Substitute.For<ICCHttpClient>();
            dialogServiceMock = Substitute.For<IDialogService>();
            appControlServiceMock = Substitute.For<IAppControlService>();
            uut = new TilmeldPubcrawlViewModel(loggedInUser, userPassword, httpClientMock,
                                                dialogServiceMock, appControlServiceMock);
        }

        [Test]
        public void TestGetPubcrawlOneAndDateDelegateCanExecute()
        {
            // Act
            var getPubcrawlOne = uut.GetPubCrawlOneAndDate.CanExecute();

            // Assert
            Assert.True(getPubcrawlOne);
        }

        [Test]
        public void TestGetPubcrawlTwoAndDateDelegateCanExecute()
        {
            // Act
            var getPubcrawlTwo = uut.GetPubCrawlTwoAndDate.CanExecute();

            // Assert
            Assert.True(getPubcrawlTwo);
        }

        [Test]
        public void TestGetPubcrawlOneAndDateInvalidDate()
        {
            // Arrange
            DateTime invalidDate = new DateTime(0001, 01, 01);
            uut.SelectedDate = invalidDate;

            // Act
            uut.GetPubCrawlOneAndDate.Execute();

            // Assert
            appControlServiceMock.Received(1).ShowMessageBox("Venligst vælg dato, før pakke vælges");
        }


        [Test]
        public void TestGetPubcrawlOneAndDateValidDate()
        {
            // Arrange
            DateTime validDate = new DateTime(2021, 11, 29);
            uut.SelectedDate = validDate;

            // Act
            uut.GetPubCrawlOneAndDate.Execute();

            // Assert
            httpClientMock.Received(1).HttpClientAddPubCrawls(Arg.Any<NewPubcrawlRequest>());
            appControlServiceMock.Received(1).ShowMessageBox("PubCrawl booket: Pakke 1, d. 29-11-2021 00:00:00");
        }

        [Test]
        public void TestGetPubcrawlTwoAndDateInvalidDate()
        {
            // Arrange
            DateTime invalidDate = new DateTime(0001, 01, 01);
            uut.SelectedDate = invalidDate;

            // Act
            uut.GetPubCrawlTwoAndDate.Execute();

            // Assert
            appControlServiceMock.Received(1).ShowMessageBox("Venligst vælg dato, før pakke vælges");
        }

        [Test]
        public void TestGetPubcrawlTwoAndDateValidDate()
        {
            // Arrange
            DateTime validDate = new DateTime(2021, 11, 29);
            uut.SelectedDate = validDate;

            // Act
            uut.GetPubCrawlTwoAndDate.Execute();

            // Assert
            httpClientMock.Received(1).HttpClientAddPubCrawls(Arg.Any<NewPubcrawlRequest>());
            appControlServiceMock.Received(1).ShowMessageBox("PubCrawl booket: Pakke 2, d. 29-11-2021 00:00:00");
        }

        [Test]
        public void TestVisProfilDelegateCanExecute()
        {
            // Act
            var visProfil = uut.VisProfil.CanExecute();

            // Assert
            Assert.True(visProfil);
        }

        [Test]
        public void TestVisProfilDelegateExecuteMinProfilDialog()
        {
            // Act
            uut.VisProfil.Execute();

            // Assert
            dialogServiceMock.Received(1).ShowMinProfilDialog(loggedInUser, userPassword, 
                httpClientMock, dialogServiceMock, appControlServiceMock);
        }

        [Test]
        public void TestSetAndGetSelectedDateProperty()
        {
            // Arrange
            uut.SelectedDate = new DateTime(2021, 11, 29);

            // Assert
            Assert.That(uut.SelectedDate, Is.EqualTo(new DateTime(2021, 11, 29)));
        }
    }
}