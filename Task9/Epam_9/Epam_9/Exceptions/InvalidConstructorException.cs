// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidConstructorException.cs" company="my company">
//   free to copy
// </copyright>
// <summary>
//   The invalid constructor exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epam_9.Exceptions
{
    using System.Management.Instrumentation;

    /// <summary>
    /// The invalid constructor exception.
    /// </summary>
    public class InvalidConstructorException : InstanceNotFoundException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidConstructorException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        public InvalidConstructorException(string message): base(message)
        {
            
        }
    }
}