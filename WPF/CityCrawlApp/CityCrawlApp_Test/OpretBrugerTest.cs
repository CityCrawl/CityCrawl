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
        private IhttpClient httpClient;

        [SetUp]
        public void Setup()
        {
            httpClient = Substitute.For<IhttpClient>();
            uut = new OpretBrugerViewModel(httpClient);
        }

        [Test]
        public void TestVisProfilDelegateCanExecute()
        {
            // Assert
            uut.VisProfil.CanExecute();
        }
    }
}