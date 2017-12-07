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
        /// Casts a vote if the agenda point is open.
        /// </summary>
        /// <param name="vote">The vote to cast.</param>
        /// <param name="votableAgendaPoint">The agenda point to cast the vote to.</param>
        /// <returns>A <see cref="bool"/> that indicates whether the vote failed or not. Returns also an error message that tells why.</returns>
        public (bool, string) CastVote(Vote vote, VotableAgendaPoint votableAgendaPoint)
        {
            // Give an error message if the Agenda Point is closed for voting.
            // Error msg: Can't cast a vote on a closed agenda point.

            // TODO: The current return result is just a placeholder. Make a proper return result.
            return (false, string.Empty);
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
            return Id == other.Id
                && other.FirstName == FirstName
                && other.LastName == LastName
                && other.BirthDate == BirthDate
                && other.Address == Address
                && other.City == City
                && other.Region == Region
                && other.PostalCode == PostalCode
                && other.Country == Country
                && other.ContactInfo == ContactInfo
                && other.UserCredentials == UserCredentials;
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
            const int prime = 397;
            int hash = Id;
            hash = (hash * prime) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
            hash = (hash * prime) ^ (LastName != null ? LastName.GetHashCode() : 0);
            hash = (hash * prime) ^ (BirthDate != null ? BirthDate.GetHashCode() : 0);
            hash = (hash * prime) ^ (Address != null ? Address.GetHashCode() : 0);
            hash = (hash * prime) ^ (City != null ? City.GetHashCode() : 0);
            hash = (hash * prime) ^ (Region != null ? Region.GetHashCode() : 0);
            hash = (hash * prime) ^ (PostalCode != null ? PostalCode.GetHashCode() : 0);
            hash = (hash * prime) ^ (Country != null ? Country.GetHashCode() : 0);
            hash = (hash * prime) ^ (ContactInfo != null ? ContactInfo.GetHashCode() : 0);
            hash = (hash * prime) ^ (UserCredentials != null ? UserCredentials.GetHashCode() : 0);
            return hash;
        }
        #endregion
    }
}