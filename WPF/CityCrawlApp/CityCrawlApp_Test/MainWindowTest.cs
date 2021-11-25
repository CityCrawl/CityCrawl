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

        [SetUp]
        public void Setup()
        {
            httpClientMock = Substitute.For<IhttpClient>();
            dialogServiceMock = Substitute.For<IDialogService>();
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
        public void TestOpretBrugerDelegateCanExecute()
        {
            // Act
            var opretBrugerExecute = uut.OpretBrugerBtn.CanExecute();

            // Assert
            Assert.True(opretBrugerExecute);
        }

        [Test]
        public void TestloginBtnSomething()
        {
            
            var loginModel = dialogServiceMock.ShowLoginDialog(httpClientMock);

            uut.LoginBtn.Execute();

            Assert.That(httpClientMock, Is.Not.Null);

            dialogServiceMock.Received(1)
                .ShowMinProfilDialog(loginModel.Email, loginModel.Password, httpClientMock, dialogServiceMock);

        }

    }
}