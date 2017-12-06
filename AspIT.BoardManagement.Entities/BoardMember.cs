/**************************************************************************************************
*  Author: Jesper Krag (jesp6763@edu.campusvejle.dk), github: https://github.com/jesp6763/        *
*  Solution: .NET version: 4.7.1, C# version: 7.1                                                 *
*  Visual Studio version: Visual Studio Enterprise 2017, version 15.4.5                           *
*  Repository: https://github.com/Mara-AspIT/AspIT.BoardManagement                                *
**************************************************************************************************/
using System;

namespace AspIT.BoardManagement.Entities
{
    /// <summary>
    /// Represents a board member.
    /// </summary>
    public class BoardMember : Person
    {
        /// <summary>
        /// Initializes a new instance of the BoardMember class
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
        public BoardMember(string firstName, string lastName, DateTime birthDate, string address, string city, string region, string postalCode, string country, ContactInfo contactInfo) : base(firstName, lastName, birthDate, address, city, region, postalCode, country, contactInfo)
        {

        }


        /// <summary>
        /// Casts a vote.
        /// </summary>
        /// <param name="vote">The vote to cast.</param>
        /// <param name="votableAgendaPoint">The agenda point to cast the vote to.</param>
        public void CastVote(Vote vote, VotableAgendaPoint votableAgendaPoint)
        {

        }
    }
}