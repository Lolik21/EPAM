namespace WebStore.Exceptions
{
    using System;

    /// <summary>
    /// The invalid weight exception.
    /// </summary>
    public class InvalidWeightException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidWeightException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        public InvalidWeightException(string message)
            : base(message)
        {
        }
    }
}