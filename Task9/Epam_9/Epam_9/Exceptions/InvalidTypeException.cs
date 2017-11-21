// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidTypeException.cs" company="my company">
//   free to copy
// </copyright>
// <summary>
//   Defines the InvalidTypeException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epam_9.Exceptions
{
    using System;

    /// <summary>
    /// The invalid type exception.
    /// </summary>
    public class InvalidTypeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTypeException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        public InvalidTypeException(string message)
            : base(message)
        {
        }
    }
}