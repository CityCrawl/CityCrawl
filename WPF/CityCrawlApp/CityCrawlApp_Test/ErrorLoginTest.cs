using NUnit.Framework;
using NSubstitute;
using CityCrawlApp.ViewModels;
using Prism.Commands;


namespace CityCrawlApp.Test
{
    public class ErrorLoginTest
    {
        private ErrorLoginViewModel uut; 

        [SetUp]
        public void Setup()
        {
            uut = new ErrorLoginViewModel();
        }

        [Test]
        public void TestErrorLoginDelegateCanExecute()
        {
            // Assert
            uut.CloseBtn.CanExecute();
        }
    }
}