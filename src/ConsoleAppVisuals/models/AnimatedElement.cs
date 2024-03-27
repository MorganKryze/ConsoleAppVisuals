/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Models;

/// <summary>
/// Defines the basic properties of an animated element.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public abstract class AnimatedElement : Element
{
    #region Sealed Properties
    /// <summary>
    /// The type of the element.
    /// </summary>
    public sealed override ElementType Type => ElementType.Animated;

    /// <summary>
    /// The maximum number of this element that can be drawn on the console. As an animated element, the value is 1.
    /// </summary>
    public sealed override int MaxNumberOfThisElement { get; } = 1;
    #endregion

    #region Methods
    /// <summary>
    /// This method is used to set options after drawing the element on the console.
    /// </summary>
    [Visual]
    protected sealed override void RenderOptionsAfterHand()
    {
        Window.DeactivateElement(this);
    }
    #endregion
}
