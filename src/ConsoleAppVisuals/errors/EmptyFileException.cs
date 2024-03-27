/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Errors;

/// <summary>
/// Exception thrown when no data is found in a file.
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
public class EmptyFileException : Exception, ISerializable
{
    /// <summary>
    /// Exception thrown when no data is found in a file.
    /// </summary>
    public EmptyFileException() { }

    /// <summary>
    /// Exception thrown when no data is found in a file.
    /// </summary>
    /// <param name="message">Message to be displayed.</param>
    public EmptyFileException(string message)
        : base(message) { }

    /// <summary>
    /// Exception thrown when no data is found in a file.
    /// </summary>
    /// <param name="message">Message to be displayed.</param>
    /// <param name="inner">Inner exception.</param>
    public EmptyFileException(string message, Exception inner)
        : base(message, inner) { }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
