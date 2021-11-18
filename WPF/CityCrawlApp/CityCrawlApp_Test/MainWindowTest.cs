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

        [SetUp]
        public void Setup()
        {
            uut = new MainWindowViewModel();
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