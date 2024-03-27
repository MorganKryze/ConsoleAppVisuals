/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Enums;

/// <summary>
/// Enum for the status of any interactive element.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public enum Status
{
    /// <summary>
    /// Default value.
    /// </summary>
    None,

    /// <summary>
    /// Chose to validate the input.
    /// </summary>
    Selected,

    /// <summary>
    /// Chose to delete an item.
    /// </summary>
    Deleted,

    /// <summary>
    /// Chose to exit the menu.
    /// </summary>
    Escaped
}
