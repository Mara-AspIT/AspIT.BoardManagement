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
    public class BoardMember : Person, IEquatable<BoardMember>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BoardMember"/> class
        /// </summary>
        /// <param name="person">The board member's person details.</param>
        /// <exception cref="ArgumentException">Thrown when firstName or lastname, address, city, region, postalCode, or country is empty, null, numbers, or has special characters</exception>
        public BoardMember(Person person) : base(person.Id, person.FirstName, person.LastName, person.BirthDate, person.Address, person.City, person.Region, person.PostalCode, person.Country, person.ContactInfo, person.UserCredentials)
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Casts a vote.
        /// </summary>
        /// <param name="vote">The vote to cast.</param>
        /// <param name="votableAgendaPoint">The agenda point to cast the vote to.</param>
        public void CastVote(Vote vote, VotableAgendaPoint votableAgendaPoint)
        {

        }

        /// <summary>
        /// Determines whether this <see cref="BoardMember"/> instance is the same as the other <see cref="BoardMember"/> instance, and have the same unique ID.
        /// </summary>
        /// <param name="other">The other <see cref="BoardMember"/> to compare with.</param>
        /// <returns>A <see cref="bool"/> that tells if both <see cref="BoardMember"/> instances are equal, and have the same unique ID.</returns>
        public bool Equals(BoardMember other)
        {
            if(ReferenceEquals(null, other)) return false;
            if(ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        /// <summary>
        /// Determines whether this <see cref="BoardMember"/> instance is the same as the other <see cref="BoardMember"/> instance.
        /// </summary>
        /// <param name="obj">The other <see cref="BoardMember"/> to compare with.</param>
        /// <returns>A <see cref="bool"/> that tells if both <see cref="BoardMember"/> instances are equal, and are of same type.</returns>
        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj)) return false;
            if(ReferenceEquals(this, obj)) return true;
            if(obj.GetType() != typeof(BoardMember)) return false;
            return Equals((BoardMember)obj);
        }

        /// <summary>
        /// Calculates a hashcode for this <see cref="BoardMember"/> object.
        /// </summary>
        /// <returns>A calculated hashcode.</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        #endregion
    }
}