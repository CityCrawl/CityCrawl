using CityCrawlApp.Models;
using NUnit.Framework;
using NSubstitute;
using CityCrawlApp.ViewModels;
using CityCrawlApp.Models.Interfaces;
using Prism.Commands;


namespace CityCrawlApp.Test
{
    public class MainWindowTest
    {
        private MainWindowViewModel uut;
        private IhttpClient httpClientMock;
        private IDialogService dialogServiceMock;
        private LoginViewModel loginViewModel;

        [SetUp]
        public void Setup()
        {
            httpClientMock = Substitute.For<IhttpClient>();
            dialogServiceMock = Substitute.For<IDialogService>();
            loginViewModel = new LoginViewModel(httpClientMock, dialogServiceMock);
            uut = new MainWindowViewModel(httpClientMock, dialogServiceMock);
        }

        [Test]
        public void TestLoginBtnDelegateCanExecute()
        {
            // Act
            var loginExecute = uut.LoginBtn.CanExecute();

            // Assert
            Assert.True(loginExecute);
        }

        [Test]
        public void TestLoginBtnDelegateExecuteLoginDialog()
        {
           // Act
            uut.LoginBtn.Execute();

            // Assert
            dialogServiceMock.Received(1).ShowLoginDialog(httpClientMock);
        }

        [Test]
        public void TestLoginBtnDelegateExecuteLoginDialogAndThenShowUser()
        {
            // Arrange
            loginViewModel.Email = "user@localhost.dk";
            loginViewModel.Password = "secretLogin";
            var loginDialog = dialogServiceMock.ShowLoginDialog(httpClientMock);
            // Act
            uut.LoginBtn.Execute();
            loginDialog.Returns(loginViewModel);

            // Assert
            dialogServiceMock.Received(1).ShowMinProfilDialog(loginViewModel.Email, loginViewModel.Password, httpClientMock, dialogServiceMock);
        }

        [Test]
        public void TestOpretBrugerBtnDelegateExecuteOpretBrugerDialog()
        {
            // Act
            uut.OpretBrugerBtn.Execute();

            // Assert
            dialogServiceMock.Received(1).ShowOpretBrugerDialog(httpClientMock);
        }

        [Test]
        public void TestOpretBrugerBtnDelegateExecuteOpretBrugerDialogAndThenShowUser()
        {
            // Act
            uut.OpretBrugerBtn.Execute();
            //dialogServiceMock.ShowOpretBrugerDialog(httpClientMock).Returns(!null);

            // Assert
            dialogServiceMock.Received(1).ShowOpretBrugerDialog(httpClientMock);
        }

    }
}