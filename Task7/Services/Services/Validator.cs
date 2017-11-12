using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Services.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Services
{
    /// <summary>
    /// Provides validation for User class
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// Constants determining length of elements
        /// </summary>
        private const int LOGIN_MAX = 50;
        private const int LOGIN_MIN = 10;
        private const int NAME_MIN = 1;
        private const int NAME_MAX = 100;
        private const int PASSWORD_MIN = 10;
        private const int PASSWORD_MAX = 20;

        /// <summary>
        /// Check's if email address is valid
        /// </summary>
        /// <param name="emailAdress">User email address</param>
        /// <exception cref="FormatException">Throws if email is invalid</exception>
        /// <exception cref="ArgumentNullException">Throws if email is null</exception>
        public void IsEmailValid(string emailAdress)
        {
            if (emailAdress == null)
            {
                throw new ArgumentNullException(nameof(emailAdress));
            }
            MailAddress mail = new MailAddress(emailAdress);                       
        }

        /// <summary>
        /// Check's if login is valid
        /// </summary>
        /// <param name="login">User login</param>
        /// <exception cref="ValidationException">Throws if login is invalid</exception>
        /// <exception cref="ArgumentNullException">Throws if login is null</exception>
        public void IsLoginValid(string login)
        {
            if (login == null)
            {
                throw new ArgumentNullException(nameof(login));
            }
            if (!Regex.IsMatch(login, $"[0-9a-zA-Z]{{{LOGIN_MIN},{LOGIN_MAX}}}$"))
            {
                throw new ValidationException($"Invalid Login format (MAX - {LOGIN_MAX} , " +
                    $"MIN - {LOGIN_MIN}, digits and letters (a-z,A-Z,0-9)");
            }
        }

        /// <summary>
        /// Check's if user name if valid
        /// </summary>
        /// <param name="name">User name</param>
        /// <exception cref="ValidationException">Throws if name is invalid</exception>
        /// <exception cref="ArgumentNullException">Throws if name is null</exception>
        public void IsNameValid(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (!Regex.IsMatch(name, $"^[a-zA-Z]{{{NAME_MIN},{NAME_MAX}}}$"))
            {
                throw new ValidationException($"Invalid name format (MAX - {NAME_MAX} , " +
                    $"MIN - {NAME_MIN}, letters (a-z,A-Z)");
            }
        }

        /// <summary>
        /// Check's if password is valid
        /// </summary>
        /// <param name="passwd">User password</param>
        /// <exception cref="ValidationException">Throws if password is invalid</exception>
        /// <exception cref="ArgumentNullException">Throws if password is null</exception>
        public void IsPasswdValid(string passwd)
        {
            if (passwd == null)
            {
                throw new ArgumentNullException(nameof(passwd));
            }
            if (!Regex.IsMatch(passwd, $"[0-9a-zA-Z]{{{PASSWORD_MIN},{PASSWORD_MAX}}}$"))
            {
                throw new ValidationException($"Invalid password format (MAX - {PASSWORD_MAX} , " +
                    $"MIN - {PASSWORD_MIN}, digits and letters (a-z,A-Z,0-9)");
            }
        }

        /// <summary>
        /// Check's if birth date of the user is valid
        /// </summary>
        /// <param name="birthDate">User birth date</param>
        /// <exception cref="ValidationException">Throws if date is invalid</exception>
        public void IsBirthDateValid(DateTime birthDate)
        {
            if (birthDate > DateTime.Today)
            {
                throw new ValidationException("Birth date cannot by more than today date");
            }
            if (birthDate < new DateTime(1900,1,1))
            {
                throw new ValidationException("User is to old");
            }
        }

        /// <summary>
        /// Check's if user ID is valid
        /// </summary>
        /// <param name="id">User ID</param>
        /// <exception cref="ValidationException">Throws if ID is invalid</exception>
        public void IsIdValid(int id)
        {
           if (id < 0)
            {
                throw new ValidationException("Id cannot 0 or less than 0");
            }
        }

        /// <summary>
        /// Check's if user is valid 
        /// </summary>
        /// <param name="user">User to check</param>
        /// <exception cref="ArgumentNullException">Throws when user is null</exception>
        /// <exception cref="ArgumentNullException">Throws if user is null</exception>
        public void IsUserValid(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            IsEmailValid(user.Email);
            IsLoginValid(user.Login);
            IsNameValid(user.FirstName);
            IsNameValid(user.LastName);
            IsPasswdValid(user.Password);
            IsBirthDateValid(user.BirthDate);
            IsIdValid(user.Id);        
        }
    }
}
