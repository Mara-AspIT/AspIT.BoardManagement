using System;
using AspIT.BoardManagement.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AspIT.BoardManagement.Tests.EntitiesTests
{
    [TestClass]
    public class UserCredentialsTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExceptionIfUsernameIsNullOrBlank()
        {
            UserCredentials credentials = new UserCredentials("", "");
            Assert.ThrowsException<ArgumentException>(() => new UserCredentials("", ""));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExceptionIfPasswordIsNullOrBlank()
        {
            UserCredentials credentials = new UserCredentials("", "");
            Assert.ThrowsException<ArgumentException>(() => new UserCredentials("", ""));
        }
    }
}
