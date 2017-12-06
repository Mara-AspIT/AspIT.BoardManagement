/**************************************************************************************************
*  Author: Jesper Krag (jesp6763@edu.campusvejle.dk), github: https://github.com/jesp6763/        *
*  Solution: .NET version: 4.7.1, C# version: 7.1                                                 *
*  Visual Studio version: Visual Studio Enterprise 2017, version 15.4.5                           *
*  Repository: https://github.com/Mara-AspIT/AspIT.BoardManagement                                *
**************************************************************************************************/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AspIT.BoardManagement.Entities;

namespace AspIT.BoardManagement.Tests.EntitiesTests
{
    [TestClass]
    public class PersonTests
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
            UserCredentials userCredentials = new UserCredentials("Username", "Password");
            Person p1, p2, p3;

            // Act
            p1 = new Person(firstName, lastName, birthDate, address, city, region, postalCode, country, contactInfo);
            p2 = new Person(firstName, lastName, birthDate, address, city, region, postalCode, country, contactInfo, userCredentials);
            p3 = new Person(1, firstName, lastName, birthDate, address, city, region, postalCode, country, contactInfo, userCredentials);

            // Assert person 1
            Assert.AreEqual(firstName, p1.FirstName);
            Assert.AreEqual(lastName, p1.LastName);
            Assert.AreEqual(birthDate, p1.BirthDate);
            Assert.AreEqual(address, p1.Address);
            Assert.AreEqual(city, p1.City);
            Assert.AreEqual(region, p1.Region);
            Assert.AreEqual(postalCode, p1.PostalCode);
            Assert.AreEqual(country, p1.Country);
            Assert.AreEqual(contactInfo, p1.ContactInfo);

            // Assert person 2
            Assert.AreEqual(firstName, p2.FirstName);
            Assert.AreEqual(lastName, p2.LastName);
            Assert.AreEqual(birthDate, p2.BirthDate);
            Assert.AreEqual(address, p2.Address);
            Assert.AreEqual(city, p2.City);
            Assert.AreEqual(region, p2.Region);
            Assert.AreEqual(postalCode, p2.PostalCode);
            Assert.AreEqual(country, p2.Country);
            Assert.AreEqual(contactInfo, p2.ContactInfo);
            Assert.AreEqual(userCredentials, p2.UserCredentials);

            // Assert person 3
            Assert.AreEqual(1, p3.Id);
            Assert.AreEqual(firstName, p3.FirstName);
            Assert.AreEqual(lastName, p3.LastName);
            Assert.AreEqual(birthDate, p3.BirthDate);
            Assert.AreEqual(address, p3.Address);
            Assert.AreEqual(city, p3.City);
            Assert.AreEqual(region, p3.Region);
            Assert.AreEqual(postalCode, p3.PostalCode);
            Assert.AreEqual(country, p3.Country);
            Assert.AreEqual(contactInfo, p3.ContactInfo);
            Assert.AreEqual(userCredentials, p3.UserCredentials);
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
            Assert.ThrowsException<ArgumentException>(() => new Person(incorrectFirstName, correctLastName, correctBirthDate, correctAddress, correctCity, correctRegion, correctPostalCode, correctCountry, contactInfo));
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
            UserCredentials userCredentials = new UserCredentials("Username", "Password");
            Person p1, p2;

            // Act
            p1 = new Person(firstName, lastName, birthDate, address, city, region, postalCode, country, contactInfo);
            p2 = new Person(firstName, lastName, birthDate, address, city, region, postalCode, country, contactInfo, userCredentials);

            // Assert
            Assert.AreEqual(p1, p2);
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
            Person p1, p2;

            // Act
            p1 = new Person(firstName, lastName, birthDate, address, city, region, postalCode, country, contactInfo);
            p2 = new Person(1, firstName, lastName, birthDate, address, city, region, postalCode, country, contactInfo, userCredentials);

            // Assert
            Assert.AreNotEqual(p1, p2);
        }
        #endregion
    }
}