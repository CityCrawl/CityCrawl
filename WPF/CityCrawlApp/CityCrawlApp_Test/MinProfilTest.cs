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
        private string loggedInUser = "User@mail.dk";
        private string userPassword = "testPassword";

        [SetUp]
        public void Setup()
        {
            httpClientMock = Substitute.For<IhttpClient>();
            dialogServiceMock = Substitute.For<IDialogService>();
            uut = new MinProfilViewModel(loggedInUser, userPassword, httpClientMock, dialogServiceMock);
        }


        [Test]
        public void TestMinProfilConstructorGetUserDataFromServer()
        {
            // Arrange
            var user = new User();

            // Act
            httpClientMock.HttpClientGetUserFromServer(loggedInUser, userPassword).Returns(user);


            // Assert
           Assert.That(uut.FirstName, Is.EqualTo(user.FirstName));
           Assert.That(uut.LastName, Is.EqualTo(user.LastName));
           Assert.That(uut.Birthday, Is.EqualTo(user.Birthday));
           Assert.That(uut.Email, Is.EqualTo(user.Email));

           foreach (var pubcrawl in uut.Pubcrawls)
           {
               Assert.That(uut.Pubcrawls, Is.EqualTo(user.PubCrawls));
            }
        }

        [Test]
        public void TestTilmeldPubcrawlDelegateCanExecute()
        {
            // Act
            var tilmeldPubcrawl = uut.TilmeldPubcrawl.CanExecute();

            // Assert

            Assert.True(tilmeldPubcrawl);
        }

        [Test]
        public void TestTilmeldPubcrawlDelegateExecute()
        {
            // Act
            uut.TilmeldPubcrawl.Execute();

            // Assert
            dialogServiceMock.Received(1).ShowTilmeldPubcrawlDialog(loggedInUser, userPassword, httpClientMock, dialogServiceMock);
        }

    }
}
