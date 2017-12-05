/**************************************************************************************************
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
    public class Person : IPersistable
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
        /// <exception cref="ArgumentOutOfRangeException">Thrown when firstname, or postalCode is greater than 10. Thrown when lastName is greater than 20. Thrown when city, region, or country is greater than 15. Thrown when address is greater than 60</exception>
        /// <exception cref="ArgumentException">Thrown when firstName or lastname, address, city, region, postalCode, or country is empty, null, numbers, or has special characters</exception>
        public Person(string firstName, string lastName, DateTime birthDate, string address, string city, string region, string postalCode, string country, ContactInfo contactInfo)
        {
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
        /// <exception cref="ArgumentOutOfRangeException">Thrown when firstname, or postalCode is greater than 10. Thrown when lastName is greater than 20. Thrown when city, region, or country is greater than 15. Thrown when address is greater than 60</exception>
        /// <exception cref="ArgumentException">Thrown when firstName or lastname, address, city, region, postalCode, or country is empty, null, numbers, or has special characters</exception>
        public Person(string firstName, string lastName, DateTime birthDate, string address, string city, string region, string postalCode, string country, ContactInfo contactInfo, UserCredentials userCredentials) : this(firstName, lastName, birthDate, address, city, region, postalCode, country, contactInfo)
        {
            UserCredentials = userCredentials;
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
                if(isValid)
                {
                    firstName = value;
                }
                else
                {
                    throw new ArgumentException();
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
                if(isValid)
                {
                    lastName = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        /// <summary>
        /// Gets or sets the birthdate
        /// </summary>
        public DateTime BirthDate
        {
            get => birthDate;
            set
            {
                birthDate = value;
                // TODO: Validate, so you can't set birthdate to something higher than todays date
                /*
                if()
                {
                    throw new ArgumentException();
                }*/
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
                if(isValid)
                {
                    address = value;
                }
                else
                {
                    throw new ArgumentException();
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
                if(isValid)
                {
                    city = value;
                }
                else
                {
                    throw new ArgumentException();
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
                if(value != null)
                {
                    (bool isValid, string errorMessage) = IsValidRegion(value);
                    if(isValid)
                    {
                        region = value;
                    }
                    else
                    {
                        throw new ArgumentException();
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
                if(isValid)
                {
                    postalCode = value;
                }
                else
                {
                    throw new ArgumentException();
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
                if(isValid)
                {
                    country = value;
                }
                else
                {
                    throw new ArgumentException();
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
            if(string.IsNullOrEmpty(name))
            {
                return (false, "Name can't be null or empty.");
            }

            if(name.Contains('-'))
            {
                if(name.StartsWith("-") || name.EndsWith("-"))
                {
                    return (false, "The hyphen character is not allowed at the start or at the end of the name.");
                }

                if(!char.IsUpper(name[name.IndexOf('-') + 1]))
                {
                    return (false, "The name after the hyphen must start with a capital letter.");
                }
            }
            if(!char.IsUpper(name[0]))
            {
                return (false, "Name must start with capital letter.");
            }

            // Return false if there's a number in the string
            if(name.All(character => char.IsNumber(character)))
            {
                return (false, "Numbers is not allowed");
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
            if(string.IsNullOrEmpty(address))
            {
                return (false, "Address can't be null or empty.");
            }

            if(!Regex.IsMatch(address, @"^[\sA-Za-z0-9-.]+$"))
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
            if(string.IsNullOrEmpty(city))
            {
                return (false, "City can't be empty or null.");
            }

            if(!Regex.IsMatch(city, "^[ A-Za-z]+$"))
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
            if(region != String.Empty && !Regex.IsMatch(region, @"^[ A-Za-z]+$"))
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
            if(string.IsNullOrEmpty(postalCode))
            {
                return (false, "Postal code can't be null or empty.");
            }

            if(!Regex.IsMatch(postalCode, "^[ 0-9A-Z]+$"))
            {
                return (false, "Postal code may only contain numbers, spaces and letters.");
            }
            return (true, string.Empty);
        }

        /// <summary>
        /// Checks the specified country to see if it is valid.
        /// </summary>
        /// <param name="country">The country you want to validate</param>
        /// <returns>A boolean telling whether it is valid or not, and a string error message</returns>
        public static (bool, string) IsValidCountry(string country)
        {
            if(string.IsNullOrEmpty(country))
            {
                return (false, "Country can't be null or empty");
            }

            if(!Regex.IsMatch(country, "^[ A-Za-z]+$"))
            {
                return (false, "Country may only contain letters and spaces.");
            }
            return (true, string.Empty);
        }
        #endregion
    }
}
