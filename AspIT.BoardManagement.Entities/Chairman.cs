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
    /// Represents a chairman.
    /// </summary>
    public class Chairman : BoardMember, IEquatable<Chairman>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Chairman"/> class
        /// </summary>
        /// <param name="person">The chairman's person details.</param>
        /// <exception cref="ArgumentException">Thrown when firstName or lastname, address, city, region, postalCode, or country is empty, null, numbers, or has special characters</exception>
        public Chairman(Person person) : base(person)
        {
            
        }
        #endregion

        #region Methods
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
        /// <param name="votableAgendaPoint">The agenda point to start voting on.</param>
        public void StartVote(VotableAgendaPoint votableAgendaPoint)
        {
            // TODO: Start voting of agenda point.
        }

        /// <summary>
        /// Determines whether this <see cref="Chairman"/> instance is the same as the other <see cref="Chairman"/> instance, and have the same unique ID.
        /// </summary>
        /// <param name="other">The other <see cref="Chairman"/> to compare with.</param>
        /// <returns>A <see cref="bool"/> that tells if both <see cref="Chairman"/> instances are equal, and have the same unique ID.</returns>
        public bool Equals(Chairman other)
        {
            if(ReferenceEquals(null, other)) return false;
            if(ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        /// <summary>
        /// Determines whether this <see cref="Chairman"/> instance is the same as the other <see cref="Chairman"/> instance.
        /// </summary>
        /// <param name="obj">The other <see cref="Chairman"/> to compare with.</param>
        /// <returns>A <see cref="bool"/> that tells if both <see cref="Chairman"/> instances are equal, and are of same type.</returns>
        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj)) return false;
            if(ReferenceEquals(this, obj)) return true;
            if(obj.GetType() != typeof(Chairman)) return false;
            return Equals((Chairman)obj);
        }

        /// <summary>
        /// Calculates a hashcode for this <see cref="Chairman"/> object.
        /// </summary>
        /// <returns>A calculated hashcode.</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        #endregion
    }
}