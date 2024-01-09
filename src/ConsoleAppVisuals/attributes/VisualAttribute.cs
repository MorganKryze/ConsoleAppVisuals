/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// The <see cref="VisualAttribute"/> class is used to mark a class, struct, enum, constructor, method, property, field, event, interface, or delegate as a visual and so interact with the console.
/// </summary>
/// <remarks> [ WARNING ] This element cannot be tested. </remarks>
[AttributeUsage(
    AttributeTargets.All,
    Inherited = false
)]
public sealed class VisualAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VisualAttribute"/> class.
    /// </summary>
    public VisualAttribute() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="VisualAttribute"/> class with a specified workaround message.
    /// </summary>
    /// <param name="message">The text string that describes alternative workarounds.</param>
    public VisualAttribute(string? message)
    {
        Message = message;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="VisualAttribute"/> class with a workaround message and a Boolean value indicating whether the obsolete element usage is considered an error.
    /// </summary>
    /// <param name="message">The text string that describes alternative workarounds.</param>
    /// <param name="error">True if the obsolete element usage generates a compiler error; false if it generates a compiler warning.</param>
    public VisualAttribute(string? message, bool error)
    {
        Message = message;
        IsError = error;
    }

    /// <summary>
    /// Gets or sets the ID that the compiler will use when reporting a use of the API.
    /// </summary>
    public string? DiagnosticId { get; set; }

    /// <summary>
    /// Gets a value that indicates whether the compiler will treat usage of the obsolete program element as an error.
    /// </summary>
    /// <returns>True if the obsolete element usage is considered an error; otherwise, false. The default is false.</returns>
    public bool IsError { get; }

    /// <summary>
    /// Gets the workaround message.
    /// </summary>
    /// <returns>The workaround text string.</returns>
    public string? Message { get; }

    /// <summary>
    /// Gets or sets the URL for corresponding documentation. The API accepts a format string instead of an actual URL, creating a generic URL that includes the diagnostic ID.
    /// </summary>
    /// <returns>The format string that represents a URL to corresponding documentation.</returns>
    public string? UrlFormat { get; set; }
}
