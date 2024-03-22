/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals.Enums;

/// <summary>
/// The <see cref="BordersType"/> enum defines the type of border to use for embed elements.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public enum BordersType
{
    /// <summary>
    /// Single line borders with straight corners (┌┐└┘─│┬┴├┤┼)
    /// </summary>
    /// <remarks>
    /// Universal compatibility.
    /// </remarks>
    SingleStraight,

    /// <summary>
    /// Single line borders with rounded corners (╭╮╰╯─│┬┴├┤┼)
    /// </summary>
    /// <remarks>
    /// Not supported on PowerShell (Windows).
    /// </remarks>
    SingleRounded,

    /// <summary>
    /// Single line borders with bold lines (┏┓┗┛━┃┳┻┣┫╋)
    /// </summary>
    /// <remarks>
    /// Not supported on PowerShell (Windows).
    /// </remarks>
    SingleBold,

    /// <summary>
    /// Double line borders with straight corners (╔╗╚╝═║╦╩╠╣╬)
    /// </summary>
    /// <remarks>
    /// Universal compatibility.
    /// </remarks>
    DoubleStraight,

    /// <summary>
    /// ASCII borders (+-|+++++)
    /// </summary>
    /// <remarks>
    /// Universal compatibility.
    /// </remarks>
    ASCII
}
