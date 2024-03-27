/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Attributes;

/// <summary>
/// The <see cref="VisualAttribute"/> class is used to mark a class, struct, enum,
/// constructor, method, property, field, event, interface, or delegate as a visual
/// and so interact with the console.
/// </summary>
/// <remarks>
/// [ WARNING ] This element cannot be tested.
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
[AttributeUsage(AttributeTargets.All, Inherited = false)]
public sealed class VisualAttribute : Attribute
{
    /// <summary>
    /// The <see cref="VisualAttribute"/> class is used to mark a class, struct, enum,
    /// constructor, method, property, field, event, interface, or delegate as a visual
    /// and so interact with the console.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public VisualAttribute() { }

    /// <summary>
    /// The <see cref="VisualAttribute"/> class is used to mark a class, struct, enum,
    /// constructor, method, property, field, event, interface, or delegate as a visual
    /// and so interact with the console.
    /// </summary>
    /// <param name="message">The text string that describes alternative workarounds.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public VisualAttribute(string? message)
    {
        Message = message;
    }

    /// <summary>
    /// The <see cref="VisualAttribute"/> class is used to mark a class, struct, enum,
    /// constructor, method, property, field, event, interface, or delegate as a visual
    /// and so interact with the console.
    /// </summary>
    /// <param name="message">The text string that describes alternative workarounds.</param>
    /// <param name="error">True if the visual element usage generates a compiler error; false if it generates a compiler warning.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
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
    /// Gets a value that indicates whether the compiler will treat usage of the visual program element as an error.
    /// </summary>
    /// <returns>True if the visual element usage is considered an error; otherwise, false. The default is false.</returns>
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
