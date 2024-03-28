/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Enums;

/// <summary>
/// The <see cref="Status"/> enum represents the exit status of an interaction.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public enum Status
{
    /// <summary>
    /// Pressed the enter key.
    /// </summary>
    Selected,

    /// <summary>
    /// Pressed the delete key.
    /// </summary>
    Deleted,

    /// <summary>
    /// Pressed the escape key.
    /// </summary>
    Escaped
}
