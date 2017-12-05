/*********************************************************************************************
*  Author: Emil Georgi (emil376g@edu.campusvejle.dk), github: https://github.com/emil376g/   *
*  Solution: .NET version: 4.7.1, C# version: 7.1                                            *
*  Visual Studio version: Visual Studio Enterprise 2017, version 15.4.5                      *
*  Repository: https://github.com/Mara-AspIT/AspIT.Bms.git                                   *
*********************************************************************************************/

using System;

namespace AspIT.BoardManagement.Entities
{
    public class UserCredentials : IPersistable
    {
        private int id;
        private string username;
        private string password;

        public UserCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public UserCredentials(int id, string username, string password) : this(username, password)
        {
            Id = id;
        }

        /// <summary>
        /// The id for the database
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// the username for the user
        /// </summary>
        public string Username
        {
            get { return username; }
            set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("it can't be null");
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("it can't be null");
                }
                else
                {
                    password = value;
                }
            }
        }
    }
}
