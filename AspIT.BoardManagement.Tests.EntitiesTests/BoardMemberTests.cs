using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AspIT.BoardManagement.Entities;

namespace AspIT.BoardManagement.Tests.EntitiesTests
{
    [TestClass]
    public class BoardMemberTests
    {
        #region Constructor tests
        /// <summary>Tests that an object of <see cref="Person"/> reaches a valid state after initialization.</summary>
        [TestMethod]
        public void CorrectInitialization()
        {
            // Arrange
            string firstName = "John";
            string lastName = "Smith";
            DateTime birthDate = DateTime.Now;
            string address = "21 jump street";
            string city = "California";
            string region = "Somewhere";
            string postalCode = "9290";
            string country = "Vandland";
            ContactInfo contactInfo = new ContactInfo("johnsmith@lawsi.chill", "99999999");
            BoardMember boardMember;

            // Act
            boardMember = new BoardMember(new Person(firstName, lastName, birthDate, address, city, region, postalCode, country, contactInfo));

            // Assert person 1
            Assert.AreEqual(firstName, boardMember.FirstName);
            Assert.AreEqual(lastName, boardMember.LastName);
            Assert.AreEqual(birthDate, boardMember.BirthDate);
            Assert.AreEqual(address, boardMember.Address);
            Assert.AreEqual(city, boardMember.City);
            Assert.AreEqual(region, boardMember.Region);
            Assert.AreEqual(postalCode, boardMember.PostalCode);
            Assert.AreEqual(country, boardMember.Country);
            Assert.AreEqual(contactInfo, boardMember.ContactInfo);
        }

        /// <summary>
        /// This test should throw an <see cref="ArgumentException"/> to pass
        /// </summary>
        [TestMethod]
        public void IncorretStateThrows()
        {
            // Arrange
            string incorrectFirstName = "-John";
            string correctLastName = "Smith";
            DateTime correctBirthDate = DateTime.Now;
            string correctAddress = "21 jump street";
            string correctCity = "California";
            string correctRegion = "Somewhere";
            string correctPostalCode = "9290";
            string correctCountry = "Vandland";
            ContactInfo contactInfo = new ContactInfo("johnsmith@lawsi.chill", "99999999");

            // Actsert
            Assert.ThrowsException<ArgumentException>(() => new BoardMember(new Person(incorrectFirstName, correctLastName, correctBirthDate, correctAddress, correctCity, correctRegion, correctPostalCode, correctCountry, contactInfo)));
        }
        #endregion

        #region Equatable tests
        /// <summary>
        /// Tests the equatable implementation. This will fail if the 2 <see cref="Person"/> objects are not equal
        /// </summary>
        [TestMethod]
        public void TestCorrectEquatable()
        {
            // Arrange
            string firstName = "John";
            string lastName = "Smith";
            DateTime birthDate = DateTime.Now;
            string address = "21 jump street";
            string city = "California";
            string region = "Somewhere";
            string postalCode = "9290";
            string country = "Vandland";
            ContactInfo contactInfo = new ContactInfo("johnsmith@lawsi.chill", "99999999");
            BoardMember bm1, bm2;

            // Act
            bm1 = new BoardMember(new Person(firstName, lastName, birthDate, address, city, region, postalCode, country, contactInfo));
            bm2 = new BoardMember(new Person(firstName, lastName, birthDate, address, city, region, postalCode, country, contactInfo));

            // Assert
            Assert.AreEqual(bm1, bm2);
        }

        /// <summary>
        /// Tests the equatable implementation. This will fail if the 2 <see cref="Person"/> objects are equal
        /// </summary>
        [TestMethod]
        public void TestIncorrectEquatable()
        {
            // Arrange
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
            BoardMember bm1, bm2;

            // Act
            bm1 = new BoardMember(new Person(firstName, lastName, birthDate, address, city, region, postalCode, country, contactInfo));
            bm2 = new BoardMember(new Person(1, firstName, lastName, birthDate, address, city, region, postalCode, country, contactInfo, userCredentials));

            // Assert
            Assert.AreNotEqual(bm1, bm2);
        }
        #endregion
    }
}
