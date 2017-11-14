using System;

namespace OOP_Examples
{
    public class Encapsulation1
    {
        /// <summary>
        /// This is bad example of encapsulation
        /// because mathod SetPassword is public and
        /// anyone can set user password without validation
        /// </summary>
        public class User
        {
            private string _password;

            /// <summary>
            /// Changes user password
            /// and validate newPassword
            /// </summary>
            /// <param name="newPassword">New password for user</param>
            public void ChangePassword(string newPassword)
            {
                //validation

                if (string.IsNullOrEmpty(newPassword))
                {
                    throw  new ArgumentNullException(nameof(newPassword));
                }

                SetPassword(newPassword);
            }

            /// <summary>
            /// Set's user password
            /// </summary>
            /// <param name="newPassword">Password to set</param>
            public void SetPassword(string newPassword)
            {
                _password = newPassword;
            }
        }



    }
}
