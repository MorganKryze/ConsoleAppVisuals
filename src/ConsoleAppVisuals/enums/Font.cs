/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals.Enums;

/// <summary>
/// The <see cref="Font"/> enum defines the font used to display styled text. (Used in the <see cref="Title"/> element)
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public enum Font
{
    /// <summary>
    /// Font defined by the user.
    /// </summary>
    Custom,

    /// <summary>
    /// Author: Unknown, Height: 6
    /// </summary>
    ANSI_Shadow,

    /// <summary>
    /// Author: Jef Poskanzer, Height: 4
    /// </summary>
    Bulbhead,
}
