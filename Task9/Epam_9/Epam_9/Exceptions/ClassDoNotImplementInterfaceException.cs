// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassDoNotImplementInterfaceException.cs" company="my company">
//   free to copy
// </copyright>
// <summary>
//   Defines the ClassDoNotImplementInterfaceException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epam_9.Exceptions
{
    using System;

    /// <inheritdoc />
    /// <summary>
    /// The class do not implement interface exception.
    /// </summary>
    public class ClassDoNotImplementInterfaceException : NotImplementedException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassDoNotImplementInterfaceException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        public ClassDoNotImplementInterfaceException(string message)
            : base(message)
        {
        }
    }
}