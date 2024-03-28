/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Enums;

/// <summary>
/// Enum for the status of any interactive element.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
