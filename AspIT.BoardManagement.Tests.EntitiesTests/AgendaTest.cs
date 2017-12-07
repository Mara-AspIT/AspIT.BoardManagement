using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AspIT.BoardManagement.Entities;
namespace AspIT.BoardManagement.Tests.EntitiesTests
{
    [TestClass]
    public class AgendaTest
    {
        [TestMethod]
        public void CorrectInitialization()
        {
            // Arrange:
            string Ttile = "Best Title";
            string header = "Best Header";
            AgendaPoint firstPoint, secondPoint;
            Agenda agenda;
            int id = 1;
            // Act:
            firstPoint = new AgendaPoint(header);
            secondPoint = new AgendaPoint(id, header);
            agenda = new Agenda(Ttile,firstPoint);
            agenda.AddAgenda(secondPoint);
            agenda.ConclueCurrentAgendaPoint();

            // Assert:
            Assert.AreEqual(header, firstPoint.Header);
            Assert.AreEqual(Ttile, agenda.Title);
            Assert.AreEqual(0, firstPoint.Id);
            Assert.AreEqual(id, secondPoint.Id);
            Assert.AreEqual(secondPoint, agenda.CurrentAgendaPoint);
        }

        [TestMethod]
        public void ThrowExeptionIfTitleIsNullOrToLong()
        {
            // Arrange:
            string title1 = null;
            string title2 = "1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111";

            Assert.ThrowsException<ArgumentException>(() => new Agenda(title2, null));
            Assert.ThrowsException<ArgumentNullException>(() => new Agenda(title1, null));
        }

        [TestMethod]
        public void ThrowExeptionIfHeaderIsNullOrToLong()
        {
            string header1 = null;
            string header2 = "1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111";

            Assert.ThrowsException<ArgumentException>(() => new AgendaPoint(header2));
            Assert.ThrowsException<ArgumentNullException>(() => new AgendaPoint(header1));
        }

        [TestMethod]
        public void ThrowExeptionIfContextIsNullOrToLong()
        {
            string context1 = null;
            string context2 = "11111111111111111111111111111111111111111111111111111111111111111111111";
            string header = "Nice header";

            Assert.ThrowsException<ArgumentNullException>(() => new AgendaPoint(header, context1));
            Assert.ThrowsException<ArgumentException>(() => new AgendaPoint(header, context2));
        }

        [TestMethod]
        public void ReturnFalseIfNoUsingEqualsAndNotAAgenda()
        {
            //Arrange
            ContactInfo contact;
            Agenda agenda;
            AgendaPoint agendaPoint;

            //Act
            agendaPoint = new AgendaPoint("fff"); 
            contact = new ContactInfo("notReall@real.dk", "99999999");
            agenda = new Agenda("kdkdkd",agendaPoint);
            bool result = agenda.Equals(agendaPoint);
            //Assert
            Assert.AreEqual(result, false);
          
        }

        [TestMethod]
        public void ReturnFalseIfObjectIsNotEqualAgendPoint()
        {
            //Arrange
            AgendaPoint agendaPoint;
            ContactInfo contact;

            //Act
            agendaPoint = new AgendaPoint("Titleff");
            contact = new ContactInfo("notReall@real.dk", "99999999");
            bool result = agendaPoint.Equals(contact);
            //Assert
            Assert.AreEqual(false,result);
           
        }
    }
}
