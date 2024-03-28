/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Models;

/// <summary>
/// Defines the basic properties of a passive element.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public abstract class PassiveElement : Element
{
    #region Sealed Properties
    /// <summary>
    /// The type of the element.
    /// </summary>
    public sealed override ElementType Type => ElementType.Passive;
    #endregion
}
