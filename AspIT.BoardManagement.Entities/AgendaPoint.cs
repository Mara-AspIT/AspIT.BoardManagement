using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspIT.BoardManagement.Entities
{
    public class AgendaPoint: IEquatable<AgendaPoint>, IPersistable
    {
        #region fields
        /// <summary>
        /// The unic id 
        /// </summary>
        protected readonly int id;

        /// <summary>
        /// The name of the agendaPoint
        /// </summary>
        protected string header;

        /// <summary>
        /// A litle description if needed
        /// </summary>
        protected string context;

        #endregion

        #region Constructors
        public AgendaPoint(string header, string context = "")
        {
            Header = header;
            Context = context;
        }

        public AgendaPoint(int id,string header,string context = "") : this(header,context)
        {
            this.id = id;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the header. Can be overridden.
        /// </summary>
        public virtual string Header
        {

            get => header;
            set
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(Header));
                (bool isValid, string errorMessage) = IsHeaderValid(value);
                if (!isValid)
                    throw new ArgumentException(errorMessage, nameof(Header));
                else if (value != header)
                    header = value;
            }
        }

        /// <summary>
        /// Get or sets the context. Can be overridden.
        /// </summary>
        public virtual string Context
        {
            get => context;
            set
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(Context));
                (bool isValid, string errorMessage) = IsContextValid(value);
                if (!isValid)
                    throw new ArgumentException(errorMessage, nameof(Context));
                else if (value != context)
                    context = value;
            }
        }

        /// <summary>
        /// Gets the id. Can be overriden
        /// </summary>
        public virtual int Id => id;

        #endregion

        #region Methods
        /// <summary>Determines whether two instances are equal. Equallity is determined by the <see cref="id"/> and the object references. Inmplements <see cref="IEquatable{T}"/>.</summary>
        /// <param name="other">The instance of <see cref="ContactInfo"/> to compare with this instance, for equallity.</param>
        /// <returns>A <see cref="Bool"/> indicating whether the provided instance is equal to this instance.</returns>
        public virtual bool Equals(AgendaPoint other)
            => other.id == id && ReferenceEquals(this, other);


        /// <summary>Determines whether two instances are equal. Equallity is determined by the <see cref="id"/> and the object references.</summary>
        /// <param name="other">The instance of <see cref="Object"/> to compare with this instance, for equallity.</param>
        /// <returns>A <see cref="Bool"/> indicating whether the provided instance is equal to this instance.</returns>
        public override bool Equals(object obj)
            => Equals(obj as AgendaPoint);

        /// <summary>Gets the hash code for this object. Overrides <see cref="Object.GetHashCode"/>.</summary>
        /// <returns>The calculated hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = -796035300;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(header);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(context);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Header);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Context);
            return hashCode;
        }


        /// <summary> Validates the header </summary>
        /// <param name="headertext">The header of the point</param>
        /// <returns>>A <see cref="Boolean"/> indicating whether the validation succeeds or not, and a <see cref="String"/> containg an error message (empty if the validation succeeds).</returns>
        public static (bool, string) IsHeaderValid(string headertext)
        {
            if (headertext is null)
                return (false, "Value was mull");
            if (headertext.Length <= 128)
                return (true, string.Empty);
            else
                return (false, "The value was to long");
        }


        /// <summary> Validates the context </summary>
        /// <param name="headertext">The header of the point</param>
        /// <returns>>A <see cref="Boolean"/> indicating whether the validation succeeds or not, and a <see cref="String"/> containg an error message (empty if the validation succeeds).</returns>
        public static (bool, string) IsContextValid(string context)
        {
            if (context is null)
                return (false, "Value was mull");
            if (context.Length <= 50)
                return (true, string.Empty);
            else
                return (false, "The value was to long");
        }

        /// <summary>Represents the current state of this <see cref="AgendaPoint"/> object as a <see cref="String"/>.</summary>
        /// <returns>A <see cref="String"/> representing the current state of this object.</returns>
        public override string ToString()
            => $"{id} {header}, {context}";
        #endregion

       
    }
}
