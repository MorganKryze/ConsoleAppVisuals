/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals
{
    /// <summary>
    /// Exception thrown when no data is found in a file.
    /// </summary>
    [Serializable]
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class EmptyFileException : Exception, ISerializable
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public EmptyFileException() { }

        /// <summary>
        /// Constructor with message.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public EmptyFileException(string message)
            : base(message) { }

        /// <summary>
        /// Constructor with message and inner exception.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        /// <param name="inner">Inner exception.</param>
        public EmptyFileException(string message, Exception inner)
            : base(message, inner) { }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected EmptyFileException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        /// <summary>
        /// Get object data for serialization.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            // Call the base class implementation to add the Message, InnerException, StackTrace, etc.
            base.GetObjectData(info, context);

            // Add any custom data here.
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
