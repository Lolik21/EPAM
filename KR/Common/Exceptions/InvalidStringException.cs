namespace WebStore.Exceptions
{
    using System.Activities;

    /// <summary>
    /// The invalid string exception.
    /// </summary>
    public class InvalidStringException : ValidationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidStringException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        public InvalidStringException(string message) : base(message)
        {
        }
    }
}