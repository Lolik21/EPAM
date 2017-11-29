namespace WebStore.Exceptions
{
    using System;

    /// <summary>
    /// The delete not completed exception.
    /// </summary>
    public class DeleteNotCompletedException : Exception 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteNotCompletedException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        /// <param name="innerException">
        /// The inner Exception.
        /// </param>
        public DeleteNotCompletedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}