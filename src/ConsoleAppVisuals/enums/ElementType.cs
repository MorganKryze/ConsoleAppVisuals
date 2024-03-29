/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals.Enums;

/// <summary>
/// The <see cref="ElementType"/> enum defines the type of an element.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public enum ElementType
{
    /// <summary>
    /// The default element type, not regarding wether it is passive or interactive.
    /// </summary>
    Default,

    /// <summary>
    /// The passive element type.
    /// </summary>
    Passive,

    /// <summary>
    /// The interactive element type.
    /// </summary>
    Interactive
}