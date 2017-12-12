/*********************************************************************************************
*  Author: Emil Georgi (emil376g@edu.campusvejle.dk), github: https://github.com/emil376g/   *
*  Solution: .NET version: 4.7.1, C# version: 7.1                                            *
*  Visual Studio version: Visual Studio Enterprise 2017, version 15.4.5                      *
*  Repository: https://github.com/Mara-AspIT/AspIT.Bms.git                                   *
*********************************************************************************************/

using System;
using System.Collections.Generic;

namespace AspIT.BoardManagement.Entities
{
    public class BoardMeeting : IPersistable, IEquatable<BoardMeeting>
    {
        #region fields
        /// <summary>
        /// a unique id
        /// </summary>
        protected readonly int id;
        /// <summary>
        /// a list of members min. 4
        /// </summary>
        protected List<BoardMember> members;
        /// <summary>
        /// an agenda
        /// </summary>
        protected Agenda agenda;
        #endregion


        #region constructors
        /// <summary>
        /// create a boardmeeting
        /// </summary>
        /// <param name="agenda"></param>
        public BoardMeeting(Agenda agenda)
        {
            Agenda = agenda;
        }
        /// <summary>
        /// create a boardmeeting with id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="agenda"></param>
        public BoardMeeting(int id, Agenda agenda) : this(agenda)
        {
            this.id = id;
        }
        #endregion


        #region Props
        public virtual int Id
        {
            get { return id; }
        }
        /// <summary>
        /// takes an agenda
        /// </summary>
        public virtual Agenda Agenda
        {
            get { return agenda; }
            set { agenda = value; }
        }
        /// <summary>
        /// takes a list of members
        /// <exception cref="ArgumentException"/>
        /// </summary>
        public virtual List<BoardMember> Members
        {
            get { return members; }
            set
            {
                (bool valid, string errorMsg) = IsValidMember(value);
                if (!valid)
                {
                    throw new ArgumentException(errorMsg);
                }
                else
                {
                    members = value;
                }
            }
        }
        #endregion


        #region Methods
        /// <summary>Determines whether two instances are equal. Equallity is determined by the <see cref="id"/> and the object references. Inmplements <see cref="IEquatable{T}"/>.</summary>
        /// <param name="other">The instance of <see cref="ContactInfo"/> to compare with this instance, for equallity.</param>
        /// <returns>A <see cref="Bool"/> indicating whether the provided instance is equal to this instance.</returns>
        public virtual bool Equals(BoardMeeting other)
        {
            if(other == null)
            {
                return false;
            }
            return other.id == id && ReferenceEquals(this, other);
        }
        /// <summary>Determines whether two instances are equal. Equallity is determined by the <see cref="id"/> and the object references.</summary>
        /// <param name="other">The instance of <see cref="Object"/> to compare with this instance, for equallity.</param>
        /// <returns>A <see cref="Bool"/> indicating whether the provided instance is equal to this instance.</returns>
        public override bool Equals(object obj)
           => Equals(obj as BoardMeeting);

        /// <summary>Gets the hash code for this object. Overrides <see cref="Object.GetHashCode"/>.</summary>
        /// <returns>The calculated hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = -796035300;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Agenda>.Default.GetHashCode(agenda);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<BoardMember>>.Default.GetHashCode(members);
            hashCode = hashCode * -1521134295 + EqualityComparer<Agenda>.Default.GetHashCode(Agenda);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<BoardMember>>.Default.GetHashCode(Members);
            return hashCode;
        }
        /// <summary>
        /// ToString with the agenda.ToString() and members.ToString(), overridden
        /// </summary>
        /// <returns></returns>
        public override string ToString()
    => $"{id}: {Agenda.ToString()}, {Members.ToString()}";

        /// <summary>Validates the username.</summary>
        /// <param name="members">The username to validate.</param>
        /// <returns>A <see cref="Boolean"/> indicating whether the validation succeeds or not, and a <see cref="String"/> containg an error message (empty if the validation succeeds).</returns>
        public static (bool, string) IsValidMember(List<BoardMember> members)
        {
            if (members.Count >= 3)
            {
                return (false, "it can't be less then 4");
            }
            return (true, string.Empty);
        }
        #endregion
    }
}
