using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspIT.BoardManagement.Entities
{
    public class Agenda : IEquatable<Agenda>, IPersistable
    {
        #region Fields
        /// <summary>
        /// List of agendaPoints
        /// </summary>
        protected List<AgendaPoint> agendaPoints = new List<AgendaPoint>();


        /// <summary>
        /// A unic id
        /// </summary>
        protected readonly int id;

        /// <summary>
        /// Title of the agenda
        /// </summary>
        protected string title;

        /// <summary>
        /// The current agendaPoint they are working on
        /// </summary>
        protected AgendaPoint currentAgendaPoint;
        #endregion


        #region Constructors

        /// <summary>
        /// Intializes a new instance of the Agenda class
        /// </summary>
        /// <param name="title">The tile of the Agenda</param>
        /// <param name="first">The first point on the agenda</param>
        public Agenda(string title, AgendaPoint first)
        {
            agendaPoints.Add(first);
            currentAgendaPoint = first;
            Title = title;
        }
        /// <summary>
        /// Intializes a new instance of the Agenda class
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="title">The tile of the Agenda</param>
        /// <param name="first">The first point on the agenda</param>
        public Agenda(int id, string title, AgendaPoint first) : this(title,first)
        {
            this.id = id;
        }
        #endregion


        #region Properties

        /// <summary>
        /// Gets the id. Can be overriden
        /// </summary>
        public virtual int Id => id;


        /// <summary>
        /// Gets or sets the title. Can be overridden.
        /// </summary>
        public virtual string Title
        {
            get => title;
            set
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(Title));
                (bool isValid, string errorMessage) = IsTitleValid(value);
                if (!isValid)
                    throw new ArgumentException(errorMessage, nameof(Title));
                else if (value != title)
                    title = value;

            }
        }

        /// <summary>
        /// Gets the currenAgendPoint. Can be overriden
        /// </summary>
        public virtual AgendaPoint CurrentAgendaPoint
        {
            get => currentAgendaPoint;
        }
        #endregion

        #region Methods

        /// <summary>Determines whether two instances are equal. Equallity is determined by the <see cref="id"/> and the object references. Inmplements <see cref="IEquatable{T}"/>.</summary>
        /// <param name="other">The instance of <see cref="Agenda"/> to compare with this instance, for equallity.</param>
        /// <returns>A <see cref="Bool"/> indicating whether the provided instance is equal to this instance.</returns>
        public virtual bool Equals(Agenda other)
        {
            if (other == null)
                return false;
            return other.id == id && ReferenceEquals(this, other);
        }


        /// <summary>Determines whether two instances are equal. Equallity is determined by the <see cref="id"/> and the object references.</summary>
        /// <param name="other">The instance of <see cref="Object"/> to compare with this instance, for equallity.</param>
        /// <returns>A <see cref="Bool"/> indicating whether the provided instance is equal to this instance.</returns>
        public override bool Equals(object obj)
            => Equals(obj as Agenda);

        /// <summary>Gets the hash code for this object. Overrides <see cref="Object.GetHashCode"/>.</summary>
        /// <returns>The calculated hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = -796035300;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(title);
            hashCode = hashCode * -1521134295 + currentAgendaPoint.GetHashCode();
            hashCode = hashCode * -1521134295 + agendaPoints.GetHashCode();
            return hashCode;
        }

        /// <summary> Validates the title </summary>
        /// <param name="title">The header of the point</param>
        /// <returns>>A <see cref="Boolean"/> indicating whether the validation succeeds or not, and a <see cref="String"/> containg an error message (empty if the validation succeeds).</returns>
        public static (bool,string)IsTitleValid(string title)
        {
            if (title is null)
                return (false, "Value was mull");
            if (title.Length < 128)
                return (true, string.Empty);
            else
                return (false, "The value was to long");
        }


        /// <summary>
        /// Adds a agenda to the point list
        /// </summary>
        /// <param name="point">Name of the agneda point</param>
        public void AddAgenda(AgendaPoint point)
        {
            agendaPoints.Add(point);
        }

        /// <summary>
        /// Gets the next AgendaPoint in the list
        /// </summary>
        public void ConclueCurrentAgendaPoint()
        {
            int indexOfAgenda = agendaPoints.IndexOf(currentAgendaPoint);
            if (indexOfAgenda < agendaPoints.Count)
                currentAgendaPoint = agendaPoints[indexOfAgenda + 1];
        }

        /// <summary>Represents the current state of this <see cref="Agenda"/> object as a <see cref="String"/>.</summary>
        /// <returns>A <see cref="String"/> representing the current state of this object.</returns>
        public override string ToString()
        {
            return $"{id} {Title} {currentAgendaPoint.ToString()}";
        }
        #endregion

    }
}
