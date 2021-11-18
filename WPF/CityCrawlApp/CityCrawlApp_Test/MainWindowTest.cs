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
            // Assert
            uut.LoginBtn.CanExecute();
        }

        [Test]
        public void TestOpretBrugerBtnDelegateCanExecute()
        {
            // Assert
            uut.OpretBrugerBtn.CanExecute();
        }

    }
}