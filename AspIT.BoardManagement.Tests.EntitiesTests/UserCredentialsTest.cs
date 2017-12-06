using System;
using AspIT.BoardManagement.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AspIT.BoardManagement.Tests.EntitiesTests
{
    [TestClass]
    public class UserCredentialsTest
    {
        [TestMethod]
        public void ThrowExceptionIfUsernameIsNull()
        {
            Assert.ThrowsException<ArgumentException>(() => new UserCredentials(null, null));
        }

        [TestMethod]
        public void ThrowExceptionIfPasswordIsNull()
        {
            Assert.ThrowsException<ArgumentException>(() => new UserCredentials(null, null));
        }
        [TestMethod]
        public void ReturnFalseIfNoUsingEqualsAndNotAUserCredentials()
        {
            string firstName = "John";
            string lastName = "Smith";
            DateTime birthDate = DateTime.Now;
            string address = "21 jump street";
            string city = "California";
            string region = "Somewhere";
            string postalCode = "9290";
            string country = "Vandland";
            ContactInfo contactInfo = new ContactInfo("johnsmith@lawsi.chill", "99999999");
            UserCredentials userCredentials = new UserCredentials("Username", "Password");
            Person p1;
            p1 = new Person(firstName, lastName, birthDate, address, city, region, postalCode, country, contactInfo);
            // Act
            bool result = userCredentials.Equals(p1);

            //assert
            Assert.AreEqual(result, false);
        }
    }
}
