/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Enums;

/// <summary>
/// The <see cref="BordersType"/> enum defines the type of border to use for embed elements.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// May not be supported on PowerShell (Windows).
    /// </remarks>
    SingleRound,

    /// <summary>
    /// Single line borders with bold lines (┏┓┗┛━┃┳┻┣┫╋)
    /// </summary>
    /// <remarks>
    /// May not be supported on PowerShell (Windows).
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
