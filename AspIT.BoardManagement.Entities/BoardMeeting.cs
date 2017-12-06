using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AspIT.BoardManagement.Entities
{
    public class BoardMeeting : IPersistable
    {
        #region fields
        private readonly int id;
        private List<BoardMember> members;
        private Agenda agenda;
        #endregion


        #region constructors
        public BoardMeeting(Agenda agenda)
        {
            Agenda = agenda;
        }
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
        public virtual bool Equals(BoardMeeting other)
                    => other.id == id && ReferenceEquals(this, other);

        public override bool Equals(object obj)
           => Equals(obj as BoardMeeting);

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
        public override string ToString()
    => $"{id}: {Agenda.ToString()}, {Members.ToString()}";
        #endregion
    }
}
