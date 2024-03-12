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
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
[Serializable]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class NotSupportedCharException : Exception, ISerializable
{
    /// <summary>
    /// Exception thrown when a character is not supported by the TextStyler class.
    /// </summary>
    public NotSupportedCharException() { }

    /// <summary>
    /// Exception thrown when a character is not supported by the TextStyler class.
    /// </summary>
    /// <param name="message">Message to be displayed.</param>
    public NotSupportedCharException(string message)
        : base(message) { }

    /// <summary>
    /// Exception thrown when a character is not supported by the TextStyler class.
    /// </summary>
    /// <param name="message">Message to be displayed.</param>
    /// <param name="inner">Inner exception.</param>
    public NotSupportedCharException(string message, Exception inner)
        : base(message, inner) { }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
