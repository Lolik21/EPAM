namespace WebStore.Exceptions
{
    using System;

    /// <summary>
    /// The invalid size exception.
    /// </summary>
    public class InvalidSizeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSizeException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        public InvalidSizeException(string message)
            : base(message)
        {
        }
    }
}