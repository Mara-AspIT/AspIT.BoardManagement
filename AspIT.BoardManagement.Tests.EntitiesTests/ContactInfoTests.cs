using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AspIT.BoardManagement.Entities;

namespace AspIT.BoardManagement.Tests.EntitiesTests
{
    [TestClass]
    public class ContactInfoTests
    {
        /// <summary>Tests that an object of <see cref="ContactInfo"/> reaches a valid state after initialization.</summary>
        [TestMethod]
        public void CorrectInitialization()
        {
            // Arrange:
            string email = "mara@aspit.dk";
            string phone = "4512345678";
            int id = 1;
            ContactInfo c1, c2;

            // Act;
            c1 = new ContactInfo(email, phone);
            c2 = new ContactInfo(id, email, phone);

            // Assert:
            Assert.AreEqual(email, c1.Email);
            Assert.AreEqual(phone, c1.PhoneNumber);
            Assert.AreEqual(0, c1.Id);
            Assert.AreEqual(email, c2.Email);
            Assert.AreEqual(phone, c2.PhoneNumber);
            Assert.AreEqual(id, c2.Id);
        }

        [TestMethod]
        public void IncorretStateThrows()
        {
            // Arrange:
            string incorrectEmail = "maraaspit.dk";
            string correctPhone = "1234567890";

            // Actsert:
            Assert.ThrowsException<ArgumentException>(() => new ContactInfo(incorrectEmail, correctPhone));
        }
    }
}