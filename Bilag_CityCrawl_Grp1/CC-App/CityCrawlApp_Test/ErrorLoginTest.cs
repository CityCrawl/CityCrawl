using NUnit.Framework;
using NSubstitute;
using CityCrawlApp.ViewModels;
using Prism.Commands;
using System;

namespace CityCrawlApp.Test
{
    public class ErrorLoginTest
    {
        private ErrorLoginViewModel uut;
        private Action<bool> closeActionMock;

        [SetUp]
        public void Setup()
        {
            closeActionMock = Substitute.For<Action<bool>>();
            uut = new ErrorLoginViewModel();
            uut.CloseDialog = closeActionMock;
        }

        [Test]
        public void TestErrorLoginDelegateCanExecute()
        {
            // Act
            var loginErrorExecute = uut.CloseBtn.CanExecute();

            // Assert
            Assert.True(loginErrorExecute);
        }

        [Test]
        public void TestErrorLoginWhenDialogCloseWithFalse()
        {
            // Act
            uut.CloseBtn.Execute();

            // Assert
            closeActionMock.Received(1).Invoke(false);
        }
    }
}