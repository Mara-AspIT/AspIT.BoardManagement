/**************************************************************************************************
*  Author: Mads Mikkel Rasmussen (mara@aspit.dk), github: https://github.com/Mara-AspIT/          *
*  Solution: .NET version: 4.7.1, C# version: 7.1                                                 *
*  Visual Studio version: Visual Studio Enterprise 2017, version 15.4.5                           *
*  Repository: https://github.com/Mara-AspIT/AspIT.Bms.git                                        *
**************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AspIT.BoardManagement.Entities
{
    /// <summary>Represents contact information. Can be inherited.</summary>
    public class ContactInfo: IPersistable , IEquatable<ContactInfo>
    {
        #region Fields
        /// <summary>The unique id.</summary>
        protected readonly int id;

        /// <summary>The email.</summary>
        protected string email;

        /// <summary>The phone number.</summary>
        protected string phoneNumber;
        #endregion


        #region Constructors
        /// <summary>Creates a new <see cref="ContactInfo"/> object with the specified email and phone number.</summary>
        /// <param name="id">The unique id.</param>
        /// <param name="email">The email.</param>
        /// <param name="phoneNumber">The phone number.</param>
        public ContactInfo(string email, string phoneNumber)
        {
            Email = email;
            PhoneNumber = phoneNumber;
        }

        /// <summary>Creates a new <see cref="ContactInfo"/> object with the specified id email and phone number.</summary>
        /// <param name="email">The email.</param>
        /// <param name="phoneNumber">The phone number.</param>
        public ContactInfo(int id, string email, string phoneNumber)
            : this(email, phoneNumber)
        {
            this.id = id;
        }
        #endregion


        #region Properties
        /// <summary>Gets or sets the email. Can be overridden.</summary>
        /// <value>The <see cref="String"/> representing the email address. An <see cref="ArgumentException"/> is thrown if the value does not validate.</value>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        public virtual string Email
        {
            get => email;
            set
            {
                if(value is null)
                    throw new ArgumentNullException(nameof(Email));
                (bool isValid, string errorMessage) = IsEmailValid(value);
                if(!isValid)
                    throw new ArgumentException(errorMessage, nameof(Email));
                else if(value != email)
                    email = value;
            }
        }

        /// <summary>Gets the id of this obejct. Can be overridden.</summary>
        public virtual int Id => id;

        /// <summary>Gets or sets the phone number. Can be overridden.</summary>
        /// <value>The <see cref="String"/> representing the phone number. An <see cref="ArgumentException"/> is thrown if the value does not validate.</value>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        public virtual string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if(value is null)
                    throw new ArgumentNullException(nameof(PhoneNumber));
                (bool isValid, string errorMessage) = IsPhoneNumberValid(value);
                if(!isValid)
                    throw new ArgumentException(errorMessage, nameof(PhoneNumber));
                else if(value != phoneNumber)
                    phoneNumber = value;
            }
        }
        #endregion


        #region Methods
        /// <summary>Determines whether two instances are equal. Equallity is determined by the <see cref="id"/> and the object references. Inmplements <see cref="IEquatable{T}"/>.</summary>
        /// <param name="other">The instance of <see cref="ContactInfo"/> to compare with this instance, for equallity.</param>
        /// <returns>A <see cref="Bool"/> indicating whether the provided instance is equal to this instance.</returns>
        public virtual bool Equals(ContactInfo other)
            => other.id == id && ReferenceEquals(this, other);  // Consider: Can two instances really have two different states?

        /// <summary>Determines whether two instances are equal. Equallity is determined by the <see cref="id"/> and the object references.</summary>
        /// <param name="other">The instance of <see cref="Object"/> to compare with this instance, for equallity.</param>
        /// <returns>A <see cref="Bool"/> indicating whether the provided instance is equal to this instance.</returns>
        public override bool Equals(object obj)
            => Equals(obj as ContactInfo);  // This cast will NOT throw an exception. See: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/as

        /// <summary>Gets the hash code for this object. Overrides <see cref="Object.GetHashCode"/>.</summary>
        /// <returns>The calculated hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = -796035300;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(phoneNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PhoneNumber);
            return hashCode;
        }

        /// <summary>Validates an email address.</summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns>A <see cref="Boolean"/> indicating whether the validation succeeds or not, and a <see cref="String"/> containg an error message (empty if the validation succeeds).</returns>
        public static (bool, string) IsEmailValid(string email)
        {
            if(email is null)
                return (false, "Value was null.");
            const string pattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";    // source: https://stackoverflow.com/questions/16167983/best-regular-expression-for-email-validation-in-c-sharp
            return Regex.IsMatch(email, pattern) ? (true, String.Empty) : (false, "Error in email syntax");
        }

        /// <summary>Validates aphone number.</summary>
        /// <param name="phoneNumber">The phone number to validate.</param>
        /// <returns>A <see cref="Boolean"/> indicating whether the validation succeeds or not, and a <see cref="String"/> containg an error message (empty if the validation succeeds).</returns>
        public static (bool, string) IsPhoneNumberValid(string phoneNumber)
        {
            if(phoneNumber is null)
                return (false, "Value was null.");
            // TODO: Validate for digits seperated by hephens and spaces, number preceeded by +, paranthesis around digit groups.
            bool isValid = phoneNumber.All(c => Char.IsDigit(c));
            if(isValid)
                return (true, String.Empty);
            else
                return (false, "Incorrect phone number syntax");
        }

        /// <summary>Represents the current state of this <see cref="ContactInfo"/> object as a <see cref="String"/>.</summary>
        /// <returns>A <see cref="String"/> representing the current state of this object.</returns>
        public override string ToString()
            => $"{id}: {email}, {phoneNumber}";
        #endregion
    }
}