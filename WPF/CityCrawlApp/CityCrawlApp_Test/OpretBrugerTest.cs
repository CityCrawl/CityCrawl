using CityCrawlApp.Models;
using NUnit.Framework;
using NSubstitute;
using CityCrawlApp.ViewModels;
using CityCrawlApp.Models.Interfaces;
using Prism.Commands;



namespace CityCrawlApp.Test
{
    public class OpretBrugerTest
    {

        private OpretBrugerViewModel uut;

        [SetUp]
        public void Setup()
        {
            uut = new OpretBrugerViewModel();
        }

        [Test]
        public void TestVisProfilDelegateCanExecute()
        {
            // Assert
            uut.VisProfil.CanExecute();
        }
    }
}