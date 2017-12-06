using System;
using AspIT.BoardManagement.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AspIT.BoardManagement.Tests.EntitiesTests
{
    [TestClass]
    public class UserCredentialsTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionIfUsernameIsNullOrBlank()
        {
            UserCredentials credentials = new UserCredentials("", "");
            Assert.ThrowsException<ArgumentNullException>(() => new UserCredentials("", ""));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionIfPasswordIsNullOrBlank()
        {
            UserCredentials credentials = new UserCredentials("", "");
            Assert.ThrowsException<ArgumentNullException>(() => new UserCredentials("", ""));
        }
    }
}
