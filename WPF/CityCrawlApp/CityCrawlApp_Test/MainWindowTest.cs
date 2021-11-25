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
        private IAppControlService appControlServiceMock;

        [SetUp]
        public void Setup()
        {
            httpClientMock = Substitute.For<IhttpClient>();
            dialogServiceMock = Substitute.For<IDialogService>();
            appControlServiceMock = Substitute.For<IAppControlService>();
            uut = new MainWindowViewModel(httpClientMock, dialogServiceMock, appControlServiceMock);
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
            var loginViewModel = new LoginViewModel(httpClientMock, dialogServiceMock);
            loginViewModel.Email = "user@mail.dk";
            loginViewModel.Password = "testPassword";
            dialogServiceMock.ShowLoginDialog(httpClientMock).Returns(loginViewModel);

            // Act
            uut.LoginBtn.Execute();
            
            // Assert
            dialogServiceMock.Received(1).ShowMinProfilDialog(loginViewModel.Email, loginViewModel.Password,
                                            httpClientMock, dialogServiceMock, appControlServiceMock);
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
            // Arrange
            var opretBrugerLoginViewModel = new OpretBrugerViewModel(httpClientMock);
            opretBrugerLoginViewModel.Email = "user@mail.dk";
            opretBrugerLoginViewModel.Password = "testPassword";
            dialogServiceMock.ShowOpretBrugerDialog(httpClientMock).Returns(opretBrugerLoginViewModel);

            // Act
            uut.OpretBrugerBtn.Execute();

            // Assert
            dialogServiceMock.Received(1).ShowOpretBrugerDialog(httpClientMock);
        }

    }
}