using System;
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
        private ICCHttpClient httpClientMock;
        private IDialogService dialogServiceMock;
        private Action<bool> closeActionMock;


        [SetUp]
        public void Setup()
        {
            httpClientMock = Substitute.For<ICCHttpClient>();
            dialogServiceMock = Substitute.For<IDialogService>();
            closeActionMock = Substitute.For<Action<bool>>();
            uut = new LoginViewModel(httpClientMock, dialogServiceMock);
            uut.CloseDialog = closeActionMock;
        }

        [Test]
        public void TestLoginDelegateCanExecute()
        {
            // Act
            var loginExecute = uut.Login.CanExecute();

            // Assert
            Assert.True(loginExecute);
        }

        [Test]
        public void TestLoginWhenUserEmailAndPasswordIsNull()
        {
            // Arrange
            uut.Email = null;
            uut.Password = null;

            // Act
            uut.Login.Execute();

            // Assert
            dialogServiceMock.Received(1).ShowErrorDialog();
            httpClientMock.Received(0).HttpClientGetUserFromServer(uut.Email, uut.Password);
        }


        [Test]
        public void TestLoginWhenServerReturnsNull()
        {
            // Arrange
            uut.Email = "User@mail.dk";
            uut.Password = "testPassword";
            httpClientMock.HttpClientGetUserFromServer(uut.Email, uut.Password).Returns((User) null);

            // Act
            uut.Login.Execute();

            // Assert
            httpClientMock.Received(1).HttpClientGetUserFromServer(uut.Email, uut.Password);
            dialogServiceMock.Received(1).ShowErrorDialog();
        }

        [Test]
        public void TestLoginWhenDialogCloseWithFalse()
        {
            // Arrange
            uut.Email = "User@mail.dk";
            uut.Password = "testPassword";
            var user = new User();
            httpClientMock.HttpClientGetUserFromServer(uut.Email, uut.Password).Returns(user);

            // Act
            uut.Login.Execute();

            // Assert
            httpClientMock.Received(1).HttpClientGetUserFromServer(uut.Email, uut.Password);
            dialogServiceMock.Received(0).ShowErrorDialog();
            closeActionMock.Received(1).Invoke(true);
        }
    }
}
