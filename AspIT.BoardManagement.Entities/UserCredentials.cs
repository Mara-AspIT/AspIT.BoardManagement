/*********************************************************************************************
*  Author: Emil Georgi (emil376g@edu.campusvejle.dk), github: https://github.com/emil376g/   *
*  Solution: .NET version: 4.7.1, C# version: 7.1                                            *
*  Visual Studio version: Visual Studio Enterprise 2017, version 15.4.5                      *
*  Repository: https://github.com/Mara-AspIT/AspIT.Bms.git                                   *
*********************************************************************************************/

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AspIT.BoardManagement.Entities
{
    public class UserCredentials : IPersistable, IEquatable<UserCredentials>
    {
        #region Fields
        protected readonly int id;
        protected string username;
        protected string password;
        #endregion


        #region Constructors
        /// <summary>
        /// A new userlogin
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public UserCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }
        /// <summary>
        /// a new user login with an id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public UserCredentials(int id, string username, string password) : this(username, password)
        {
            this.id = id;
        }
        #endregion


        #region Props
        /// <summary>
        /// The id for the database
        /// </summary>
        public virtual int Id
        {
            get { return id; }
        }
        /// <summary>
        /// the username for the user
        /// </summary>
        public virtual string Username
        {
            get { return username; }
            set
            {
                (bool Isvalid, string errorMsg) = IsValidUsername(value);
                if (!Isvalid)
                {
                    throw new ArgumentException(errorMsg);
                }
                else
                {
                    username = value;
                }
            }
        }
        /// <summary>
        /// the password for the user
        /// </summary>
        public virtual string Password
        {
            get { return password; }
            set
            {
                (bool Isvalid, string errorMsg) = IsValidPassword(value);
                if (!Isvalid)
                {
                    throw new ArgumentException(errorMsg);
                }
                else
                {
                    password = value;
                }
            }
        }
        #endregion


        #region Methods
        /// <summary>Determines whether two instances are equal. Equallity is determined by the <see cref="id"/> and the object references. Inmplements <see cref="IEquatable{T}"/>.</summary>
        /// <param name="other">The instance of <see cref="ContactInfo"/> to compare with this instance, for equallity.</param>
        /// <returns>A <see cref="Bool"/> indicating whether the provided instance is equal to this instance.</returns>
        public virtual bool Equals(UserCredentials other)
        {
            if (other == null)
            {
                return false;
            }
            return other.id == id && ReferenceEquals(this, other);
        }
        /// <summary>Determines whether two instances are equal. Equallity is determined by the <see cref="id"/> and the object references.</summary>
        /// <param name="other">The instance of <see cref="Object"/> to compare with this instance, for equallity.</param>
        /// <returns>A <see cref="Bool"/> indicating whether the provided instance is equal to this instance.</returns>
        public override bool Equals(object obj)
           => Equals(obj as UserCredentials);

        /// <summary>Gets the hash code for this object. Overrides <see cref="Object.GetHashCode"/>.</summary>
        /// <returns>The calculated hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = -796035300;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(username);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(password);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Username);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            return hashCode;
        }
        /// <summary>
        /// Get the overridden ToString for the object. giv you the username, password
        /// </summary>
        /// <returns>overridden ToString</returns>
        public override string ToString()
    => $"{id}: {Username}, {Password}";

        /// <summary>Validates the username.</summary>
        /// <param name="username">The username to validate.</param>
        /// <returns>A <see cref="Boolean"/> indicating whether the validation succeeds or not, and a <see cref="String"/> containg an error message (empty if the validation succeeds).</returns>
        public static (bool, string) IsValidUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return (false, "username can't be null or empty");
            }

            if (!Regex.IsMatch(username, "^[ A-Za-z0-9]+$"))
            {
                return (false, "username may only contain letters, spaces and numbers.");
            }
            return (true, string.Empty);
        }
        /// <summary>Validates the password.</summary>
        /// <param name="password">The password to validate.</param>
        /// <returns>A <see cref="Boolean"/> indicating whether the validation succeeds or not, and a <see cref="String"/> containg an error message (empty if the validation succeeds).</returns>
        public static (bool, string) IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return (false, "Password can't be null or empty");
            }

            if (!Regex.IsMatch(password, "^[ A-Za-z0-9]+$"))
            {
                return (false, "Password may only contain letters, spaces and numbers.");
            }
            return (true, string.Empty);
        }
        #endregion
    }
}
