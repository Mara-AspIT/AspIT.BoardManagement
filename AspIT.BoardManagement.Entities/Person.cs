﻿/**************************************************************************************************
*  Author: Jesper Krag (jesp6763@edu.campusvejle.dk), github: https://github.com/jesp6763/        *
*  Solution: .NET version: 4.7.1, C# version: 7.1                                                 *
*  Visual Studio version: Visual Studio Enterprise 2017, version 15.4.5                           *
*  Repository: https://github.com/Mara-AspIT/AspIT.BoardManagement                                *
**************************************************************************************************/
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AspIT.BoardManagement.Entities
{
    /// <summary>
    /// Represents a person
    /// </summary>
    public class Person : IPersistable, IEquatable<Person>
    {
        #region Fields
        /// <summary>
        /// The first name of the person
        /// </summary>
        protected string firstName;
        /// <summary>
        /// The last name of the person
        /// </summary>
        protected string lastName;
        /// <summary>
        /// The birth date of the person
        /// </summary>
        protected DateTime birthDate;
        /// <summary>
        /// The address of the person
        /// </summary>
        protected string address;
        /// <summary>
        /// The city of the person
        /// </summary>
        protected string city;
        /// <summary>
        /// The region of the person
        /// </summary>
        protected string region;
        /// <summary>
        /// The postal code of the person
        /// </summary>
        protected string postalCode;
        /// <summary>
        /// The country the person lives in
        /// </summary>
        protected string country;
        /// <summary>
        /// The contact info of the person
        /// </summary>
        protected ContactInfo contactInfo;
        /// <summary>
        /// The user credentials.
        /// </summary>
        protected UserCredentials userCredentials;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Person class
        /// </summary>
        /// <param name="firstName">The person's firstname.</param>
        /// <param name="lastName">The person's lastname.</param>
        /// <param name="birthDate">The person's birthdate.</param>
        /// <param name="address">The person's address.</param>
        /// <param name="city">The city of the person.</param>
        /// <param name="region">The region of the city.</param>
        /// <param name="postalCode">The postal code of the city.</param>
        /// <param name="country">The country.</param>
        /// <param name="contactInfo">The person's contact informations.</param>
        /// <exception cref="ArgumentException">Thrown when firstName or lastname, address, city, region, postalCode, or country is empty, null, numbers, or has special characters</exception>
        public Person(string firstName, string lastName, DateTime birthDate, string address, string city, string region, string postalCode, string country, ContactInfo contactInfo)
        {
            Id = 0;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
            ContactInfo = contactInfo;
        }


        /// <summary>
        /// Initializes a new instance of the Person class.
        /// </summary>
        /// <param name="firstName">The person's firstname.</param>
        /// <param name="lastName">The person's lastname.</param>
        /// <param name="birthDate">The person's birthdate.</param>
        /// <param name="address">The person's address.</param>
        /// <param name="city">The city of the person.</param>
        /// <param name="region">The region of the city.</param>
        /// <param name="postalCode">The postal code of the city.</param>
        /// <param name="country">The country.</param>
        /// <param name="contactInfo">The person's contact informations.</param>
        /// <param name="userCredentials">The person's user credentials.</param>
        /// <exception cref="ArgumentException">Thrown when firstName or lastname, address, city, region, postalCode, or country is empty, null, numbers, or has special characters</exception>
        public Person(string firstName, string lastName, DateTime birthDate, string address, string city, string region, string postalCode, string country, ContactInfo contactInfo, UserCredentials userCredentials) : this(firstName, lastName, birthDate, address, city, region, postalCode, country, contactInfo)
        {
            UserCredentials = userCredentials;
        }

        /// <summary>
        /// Initializes a new instance of the Person class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="firstName">The person's firstname.</param>
        /// <param name="lastName">The person's lastname.</param>
        /// <param name="birthDate">The person's birthdate.</param>
        /// <param name="address">The person's address.</param>
        /// <param name="city">The city of the person.</param>
        /// <param name="region">The region of the city.</param>
        /// <param name="postalCode">The postal code of the city.</param>
        /// <param name="country">The country.</param>
        /// <param name="contactInfo">The person's contact informations.</param>
        /// <param name="userCredentials">The person's user credentials.</param>
        /// <exception cref="ArgumentException">Thrown when firstName or lastname, address, city, region, postalCode, or country is empty, null, numbers, or has special characters</exception>
        public Person(int id, string firstName, string lastName, DateTime birthDate, string address, string city, string region, string postalCode, string country, ContactInfo contactInfo, UserCredentials userCredentials) : this(firstName, lastName, birthDate, address, city, region, postalCode, country, contactInfo, userCredentials)
        {
            Id = id;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the value is invalid.</exception>>
        public string FirstName
        {
            get => firstName;
            set
            {
                (bool isValid, string errorMessage) = IsValidName(value);
                if (isValid)
                {
                    firstName = value;
                }
                else
                {
                    throw new ArgumentException(errorMessage, nameof(FirstName));
                }
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the value is invalid.</exception>
        public string LastName
        {
            get => lastName;
            set
            {
                (bool isValid, string errorMessage) = IsValidName(value);
                if (isValid)
                {
                    lastName = value;
                }
                else
                {
                    throw new ArgumentException(errorMessage, nameof(LastName));
                }
            }
        }

        /// <summary>
        /// Gets or sets the birthdate
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the value is invalid.</exception>
        public DateTime BirthDate
        {
            get => birthDate;
            set
            {
                (bool isValid, string errorMessage) = IsValidBirthdate(value);
                if(isValid)
                {
                    birthDate = value;
                }
                else
                {
                    throw new ArgumentException(errorMessage);
                }
            }
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the value is invalid.</exception>
        public string Address
        {
            get => address;
            set
            {
                (bool isValid, string errorMessage) = IsValidAddress(value);
                if (isValid)
                {
                    address = value;
                }
                else
                {
                    throw new ArgumentException(errorMessage, nameof(Address));
                }
            }
        }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the value is invalid.</exception>
        public string City
        {
            get => city;
            set
            {
                (bool isValid, string errorMessage) = IsValidCity(value);
                if (isValid)
                {
                    city = value;
                }
                else
                {
                    throw new ArgumentException(errorMessage, nameof(City));
                }
            }
        }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the value is invalid.</exception>
        public string Region
        {
            get => region;
            set
            {
                if (value != null)
                {
                    (bool isValid, string errorMessage) = IsValidRegion(value);
                    if (isValid)
                    {
                        region = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(Region));
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the value is invalid.</exception>
        public string PostalCode
        {
            get => postalCode;
            set
            {
                (bool isValid, string errorMessage) = IsValidPostalCode(value);
                if (isValid)
                {
                    postalCode = value;
                }
                else
                {
                    throw new ArgumentException(errorMessage, nameof(PostalCode));
                }
            }
        }

        /// <summary>
        /// Gets or sets the country
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the value is invalid</exception>
        public string Country
        {
            get => country;
            set
            {
                (bool isValid, string errorMessage) = IsValidCountry(value);
                if (isValid)
                {
                    country = value;
                }
                else
                {
                    throw new ArgumentException(errorMessage, nameof(Country));
                }
            }
        }

        /// <summary>
        /// Gets or sets the contact info of the person
        /// </summary>
        public ContactInfo ContactInfo { get => contactInfo; set => contactInfo = value; }

        /// <summary>
        /// Gets or sets the user credentials.
        /// </summary>
        public UserCredentials UserCredentials { get => userCredentials; set => userCredentials = value; }

        /// <summary>
        /// Gets the ID of the person
        /// </summary>
        public int Id { get; }

        #endregion

        #region Methods
        /// <summary>
        /// Checks the specified name to see if it is valid.
        /// </summary>
        /// <param name="name">The name you want to validate</param>
        /// <returns>A boolean telling whether it is valid or not, and a string error message</returns>
        public static (bool, string) IsValidName(string name)
        {
            // TODO: Change most of the validations to regex
            if (string.IsNullOrEmpty(name))
            {
                return (false, "Name can't be null or empty.");
            }

            if (name.Contains('-'))
            {
                if (name.StartsWith("-") || name.EndsWith("-"))
                {
                    return (false, "The hyphen character is not allowed at the start or at the end of the name.");
                }

                if (!char.IsUpper(name[name.IndexOf('-') + 1]))
                {
                    return (false, "The name after the hyphen must start with a capital letter.");
                }
            }
            if (!char.IsUpper(name[0]))
            {
                return (false, "Name must start with capital letter.");
            }

            // Return false if there's a number in the string
            if (name.FirstOrDefault(char.IsNumber) != char.MinValue)
            {
                return (false, "Numbers is not allowed");
            }

            return (true, string.Empty);
        }

        /// <summary>
        /// Checks the specified birthdate to see if it is valid.
        /// </summary>
        /// <param name="name">The birthdate you want to validate</param>
        /// <returns>A <see cref="bool"/> telling whether it is valid or not, and a string error message</returns>
        public static (bool, string) IsValidBirthdate(DateTime birthdate)
        {
            if(birthdate == default(DateTime))
            {
                return (false, "Birthdate can't be empty.");
            }

            DateTime nowDate = DateTime.Now;
            if(birthdate.Year > nowDate.Year)
            {
                return (false, "Birthdate year can't be greater than todays year.");
            }

            if(birthdate.Year == nowDate.Year)
            {
                if(birthdate.Month > nowDate.Month)
                {
                    return (false, "Birthdate month can't be greater than todays month.");
                }

                if(birthdate.Month == birthdate.Month)
                {
                    if(birthdate.Day > nowDate.Day)
                    {
                        return (false, "Birthdate day can't be greater than todays day.");
                    }
                }
            }

            return (true, string.Empty);
        }

        /// <summary>
        /// Checks the specified address to see if it is valid.
        /// </summary>
        /// <param name="address">The address you want to validate</param>
        /// <returns>A boolean telling whether it is valid or not, and a string error message</returns>
        public static (bool, string) IsValidAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                return (false, "Address can't be null or empty.");
            }

            if (!Regex.IsMatch(address, @"^[\sA-Za-z0-9-.]+$"))
            {
                return (false, "Address may only contain letters, numbers, spaces and hyphens.");
            }
            return (true, string.Empty);
        }

        /// <summary>
        /// Checks the specified city to see if it is valid.
        /// </summary>
        /// <param name="city">The city you want to validate</param>
        /// <returns>A boolean telling whether it is valid or not, and a string error message</returns>
        public static (bool, string) IsValidCity(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return (false, "City can't be empty or null.");
            }

            if (!Regex.IsMatch(city, "^[ A-Za-z]+$"))
            {
                return (false, "City may only contain spaces and letters.");
            }
            return (true, string.Empty);
        }

        /// <summary>
        /// Checks the specified region to see if it is valid.
        /// </summary>
        /// <param name="region">The region you want to validate</param>
        /// <returns>A boolean telling whether it is valid or not, and a string error message</returns>
        public static (bool, string) IsValidRegion(string region)
        {
            if (region == String.Empty || !Regex.IsMatch(region, @"^[ A-Za-z]+$"))
            {
                return (false, "Region may only contain letters and spaces");
            }

            return (true, string.Empty);
        }

        /// <summary>
        /// Checks the specified postal code to see if it is valid.
        /// </summary>
        /// <param name="postalCode">The postal code you want to validate</param>
        /// <returns>A boolean telling whether it is valid or not, and a string error message</returns>
        public static (bool, string) IsValidPostalCode(string postalCode)
        {
            if (string.IsNullOrEmpty(postalCode))
            {
                return (false, "Postal code can't be null or empty.");
            }

            if (!Regex.IsMatch(postalCode, "^[ 0-9A-Z]+$"))
            {
                return (false, "Postal code may only contain numbers, spaces and letters.");
            }
            return (true, string.Empty);
        }

        /// <summary>
        /// Checks the specified country to see if it is valid.
        /// </summary>
        /// <param name="country">The country you want to validate.</param>
        /// <returns>A <see cref="bool"/> telling whether it is valid or not, and a <see cref="string"/> error message.</returns>
        public static (bool, string) IsValidCountry(string country)
        {
            if (string.IsNullOrEmpty(country))
            {
                return (false, "Country can't be null or empty");
            }

            if (!Regex.IsMatch(country, "^[ A-Za-z]+$"))
            {
                return (false, "Country may only contain letters and spaces.");
            }
            return (true, string.Empty);
        }

        /// <summary>
        /// Determines whether this <see cref="Person"/> instance is the same as the other <see cref="Person"/> instance, and have the same unique ID.
        /// </summary>
        /// <param name="other">The other <see cref="Person"/> to compare with.</param>
        /// <returns>A <see cref="bool"/> that tells if both <see cref="Person"/> instances are equal, and have the same unique ID.</returns>
        public bool Equals(Person other)
        {
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        /// <summary>
        /// Determines whether this <see cref="Person"/> instance is the same as the other <see cref="Person"/> instance.
        /// </summary>
        /// <param name="obj">The other <see cref="Person"/> to compare with.</param>
        /// <returns>A <see cref="bool"/> that tells if both <see cref="Person"/> instances are equal, and are of same type.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Person);
        }

        /// <summary>
        /// Calculates a hashcode for this <see cref="Person"/> object.
        /// </summary>
        /// <returns>A calculated hashcode.</returns>
        public override int GetHashCode()
        {
            const int prime = 397;
            int hash = Id;
            hash = (hash * prime) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
            hash = (hash * prime) ^ (LastName != null ? LastName.GetHashCode() : 0);
            hash = (hash * prime) ^ (BirthDate != null ? BirthDate.GetHashCode() : 0);
            hash = (hash * prime) ^ (Address != null ? Address.GetHashCode() : 0);
            hash = (hash * prime) ^ (City != null ? City.GetHashCode() : 0);
            hash = (hash * prime) ^ (Region != null ? Region.GetHashCode() : 0);
            hash = (hash * prime) ^ (PostalCode != null ? PostalCode.GetHashCode() : 0);
            hash = (hash * prime) ^ (Country != null ? Country.GetHashCode() : 0);
            hash = (hash * prime) ^ (ContactInfo != null ? ContactInfo.GetHashCode() : 0);
            hash = (hash * prime) ^ (UserCredentials != null ? UserCredentials.GetHashCode() : 0);
            return hash;
        }

        /// <summary>
        /// The current state of this <see cref="Person"/> object as a <see cref="string"/>.
        /// </summary>
        /// <returns>A <see cref="string"/> that shows the current state of this <see cref="Person"/> object.</returns>
        public override string ToString()
        {
            if(UserCredentials == null)
            {
                return $"{Id}: {FirstName}, {LastName}, {BirthDate.ToShortDateString()}, {Address}, {City}, {Region}, {PostalCode}, {Country}, {ContactInfo.Email}, {ContactInfo.PhoneNumber}";
            }

            return $"{Id}: {FirstName}, {LastName}, {BirthDate.ToShortDateString()}, {Address}, {City}, {Region}, {PostalCode}, {Country}, {ContactInfo.Email}, {ContactInfo.PhoneNumber}, {UserCredentials.Username}, {UserCredentials.Password}";
        }
        #endregion
    }
}
