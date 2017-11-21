// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerAlreadyExistsException.cs" company="my company">
//   free to copy
// </copyright>
// <summary>
//   The container already exists exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epam_9.Exceptions
{
    using System;

    /// <summary>
    /// The container already exists exception.
    /// </summary>
    public class ContainerAlreadyExistsException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerAlreadyExistsException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        public ContainerAlreadyExistsException(string message)
            : base(message)
        {
        }
    }
}