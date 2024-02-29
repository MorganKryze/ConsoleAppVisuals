/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals.Errors;

/// <summary>
/// Exception thrown when a character is not supported by the TextStyler class.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
/// </list>
/// </remarks>
[Serializable]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class NotSupportedCharException : Exception, ISerializable
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    public NotSupportedCharException() { }

    /// <summary>
    /// Constructor with message.
    /// </summary>
    /// <param name="message">Message to be displayed.</param>
    public NotSupportedCharException(string message)
        : base(message) { }

    /// <summary>
    /// Constructor with message and inner exception.
    /// </summary>
    /// <param name="message">Message to be displayed.</param>
    /// <param name="inner">Inner exception.</param>
    public NotSupportedCharException(string message, Exception inner)
        : base(message, inner) { }

    /// <summary>
    /// Serialization constructor.
    /// </summary>
    /// <param name="info">Serialization info.</param>
    /// <param name="context">Streaming context.</param>
    protected NotSupportedCharException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }

    /// <summary>
    /// Get object data for serialization.
    /// </summary>
    /// <param name="info">Serialization info.</param>
    /// <param name="context">Streaming context.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public override void GetObjectData(SerializationInfo? info, StreamingContext context)
    {
        if (info == null)
        {
            throw new ArgumentNullException(nameof(info));
        }
        base.GetObjectData(info, context);
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
