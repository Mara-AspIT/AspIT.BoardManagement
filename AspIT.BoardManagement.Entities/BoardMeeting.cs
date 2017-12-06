using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AspIT.BoardManagement.Entities
{
    public class BoardMeeting : IPersistable, IEquatable<BoardMeeting>
    {
        #region fields
        private readonly int id;
        private List<BoardMember> members;
        private Agenda agenda;
        #endregion


        #region constructors
        /// <summary>
        /// ment take create a boardmeeting
        /// </summary>
        /// <param name="agenda"></param>
        public BoardMeeting(Agenda agenda)
        {
            Agenda = agenda;
        }
        /// <summary>
        /// ment to create a boardmeeting forexample for the database, with id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="agenda"></param>
        public BoardMeeting(int id, Agenda agenda) : this(agenda)
        {
            this.id = id;
        }
        #endregion


        #region Props
        public int Id
        {
            get { return id; }
        }
        public Agenda Agenda
        {
            get { return agenda; }
            set { agenda = value; }
        }

        public List<BoardMember> Members
        {
            get { return members; }
            set { members = value; }
        }
        #endregion


        #region Methods
        /// <summary>
        /// Check if it is equal
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool Equals(BoardMeeting other)
                    => other.id == id && ReferenceEquals(this, other);
        /// <summary>
        /// overridden equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
           => Equals(obj as BoardMeeting);
        /// <summary>
        /// hashcode
        /// </summary>
        /// <returns></returns>
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
        #endregion
    }
}
