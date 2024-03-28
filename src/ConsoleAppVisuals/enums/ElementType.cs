/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Enums;

/// <summary>
/// The <see cref="ElementType"/> enum defines the type of an element.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    Interactive,

    /// <summary>
    /// The animated element type.
    /// </summary>
    Animated
}