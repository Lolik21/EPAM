namespace WebStore.Exceptions
{
    using System;

    /// <summary>
    /// The empty string exception.
    /// </summary>
    public class EmptyStringException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyStringException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        public EmptyStringException(string message) : base(message)
        {
        }
    }
}