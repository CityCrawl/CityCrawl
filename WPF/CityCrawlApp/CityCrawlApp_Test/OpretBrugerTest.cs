using CityCrawlApp.Models;
using NUnit.Framework;
using NSubstitute;
using CityCrawlApp.ViewModels;
using CityCrawlApp.Models.Interfaces;
using Prism.Commands;
using System;

namespace CityCrawlApp.Test
{
    public class OpretBrugerTest
    {

        private OpretBrugerViewModel uut;
        private IhttpClient httpClientMock;
        private Action<bool> closeActionMock;

        [SetUp]
        public void Setup()
        {
            httpClientMock = Substitute.For<IhttpClient>();
            closeActionMock = Substitute.For<Action<bool>>();
            uut = new OpretBrugerViewModel(httpClientMock);
            uut.CloseDialog = closeActionMock;
            uut.Email = "user@mail.dk";
            uut.Password = "testPassword";
            uut.Birthday = "11-11-1999";
            uut.FirstName = "Hans";
            uut.LastName = "Hansen";
        }

        [Test]
        public void TestVisProfilDelegateCanExecute()
        {
            // Act
            var visProfilExecute = uut.VisProfil.CanExecute();

            // Assert
            Assert.True(visProfilExecute);
        }

        [Test]
        public void TestVisProfilDelegateExecute()
        {
            // Act
            User calledUser = null;
            httpClientMock.HttpClientCreateUser(Arg.Do<User>(user => calledUser = user));
            uut.VisProfil.Execute();

            // Assert
            Assert.That(calledUser.Email, Is.EqualTo(uut.Email));
            Assert.That(calledUser.Password, Is.EqualTo(uut.Password));
            Assert.That(calledUser.Birthday, Is.EqualTo(uut.Birthday));
            Assert.That(calledUser.FirstName, Is.EqualTo(uut.FirstName));
            Assert.That(calledUser.LastName, Is.EqualTo(uut.LastName));

            closeActionMock.Received(1).Invoke(true);
        }
    }
}