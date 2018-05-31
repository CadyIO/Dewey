using System;

namespace Dewey.Exceptions
{
    /// <summary>
    /// An exception to be returned when there is a unique restraint violation.
    /// </summary>
    public class UniqueException : Exception
    {
        /// <summary>
        /// The property name where the unique validation exception occurred.
        /// </summary>
        public string Property { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public UniqueException()
        {
        }

        /// <summary>
        /// Builder Constructor.
        /// </summary>
        /// <param name="property">The property name where the unique validation exception occurred.</param>
        /// <param name="message">The message to be returned.</param>
        public UniqueException(string property, string message)
        {
            Property = property;
            Message = message;
        }

        /// <summary>
        /// The message to be returned.
        /// </summary>
        public override string Message { get; } = "There was a unique constraint exception.";
    }
}
