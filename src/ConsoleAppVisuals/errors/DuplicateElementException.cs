/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Errors;

/// <summary>
/// Exception thrown when an element is found twice in a collection.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
[Serializable]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class DuplicateElementException : Exception, ISerializable
{
    /// <summary>
    /// Exception thrown when an element is found twice in a collection.
    /// </summary>
    public DuplicateElementException() { }

    /// <summary>
    /// Exception thrown when an element is found twice in a collection.
    /// </summary>
    /// <param name="message">Message to be displayed.</param>
    public DuplicateElementException(string message)
        : base(message) { }

    /// <summary>
    /// Exception thrown when an element is found twice in a collection.
    /// </summary>
    /// <param name="message">Message to be displayed.</param>
    /// <param name="inner">Inner exception.</param>
    public DuplicateElementException(string message, Exception inner)
        : base(message, inner) { }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
