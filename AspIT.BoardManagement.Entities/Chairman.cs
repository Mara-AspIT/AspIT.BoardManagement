/**************************************************************************************************
*  Author: Jesper Krag (jesp6763@edu.campusvejle.dk), github: https://github.com/jesp6763/        *
*  Solution: .NET version: 4.7.1, C# version: 7.1                                                 *
*  Visual Studio version: Visual Studio Enterprise 2017, version 15.4.5                           *
*  Repository: https://github.com/Mara-AspIT/AspIT.BoardManagement                                *
**************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspIT.BoardManagement.Entities
{
    /// <summary>
    /// Represents a chairman.
    /// </summary>
    public class Chairman : BoardMember
    {
        /// <summary>
        /// Initializes a new instance of the Chairman class
        /// </summary>
        /// <param name="firstName">The person's firstname.</param>
        /// <param name="lastName">The person's lastname.</param>
        /// <param name="birthDate">The person's birthdate.</param>
        /// <param name="address">The person's address.</param>
        /// <param name="city">The city of the person.</param>
        /// <param name="region">The region of the city.</param>
        /// <param name="postalCode">The postal code of the city.</param>
        /// <param name="country">The country.</param>
        /// <param name="contactInfo">The person's contact informations.</param>
        /// <exception cref="ArgumentException">Thrown when firstName or lastname, address, city, region, postalCode, or country is empty, null, numbers, or has special characters</exception>
        public Chairman(string firstName, string lastName, DateTime birthDate, string address, string city, string region, string postalCode, string country, ContactInfo contactInfo) : base(firstName, lastName, birthDate, address, city, region, postalCode, country, contactInfo)
        {

        }

        /// <summary>
        /// Opens an agenda point
        /// </summary>
        /// <param name="agendaPoint">The agenda point to open.</param>
        public void OpenAgendaPoint(AgendaPoint agendaPoint)
        {
            // TODO: Add open agenda point code.
        }

        /// <summary>
        /// Closes an agenda point.
        /// </summary>
        /// <param name="agendaPoint">The agenda point to close.</param>
        public void CloseAgendaPoint(AgendaPoint agendaPoint)
        {
            // TODO: Add close agenda point code.
        }

        /// <summary>
        /// Starts the voting of a agenda point.
        /// </summary>
        /// <param name="votableAgendaPoint">The agenda to start voting.</param>
        public void StartVote(VotableAgendaPoint votableAgendaPoint)
        {
            // TODO: Start voting of agenda point.
        }
    }
}