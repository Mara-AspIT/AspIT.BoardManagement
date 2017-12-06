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
        private readonly int id;
        private string username;
        private string password;
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
        public int Id
        {
            get { return id; }
        }
        /// <summary>
        /// the username for the user
        /// </summary>
        public string Username
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
        public string Password
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
        public virtual bool Equals(UserCredentials other)
        {
            if(other == null)
            {
                return false;
            }
            return other.id == id && ReferenceEquals(this, other);
        }
        public override bool Equals(object obj)
           => Equals(obj as UserCredentials);

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
        public override string ToString()
    => $"{id}: {Username}, {Password}";

        public static (bool, string) IsValidUsername(string Username)
        {
            if (string.IsNullOrEmpty(Username))
            {
                return (false, "username can't be null or empty");
            }

            if (!Regex.IsMatch(Username, "^[ A-Za-z0-9]+$"))
            {
                return (false, "username may only contain letters and spaces.");
            }
            return (true, string.Empty);
        }
        public static (bool, string) IsValidPassword(string Password)
        {
            if (string.IsNullOrEmpty(Password))
            {
                return (false, "Password can't be null or empty");
            }

            if (!Regex.IsMatch(Password, "^[ A-Za-z0-9]+$"))
            {
                return (false, "Password may only contain letters and spaces.");
            }
            return (true, string.Empty);
        }
        #endregion
    }
}
