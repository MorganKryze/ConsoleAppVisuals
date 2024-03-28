/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Models;

/// <summary>
/// The <see cref="AnimatedElement"/> class is an abstract class that represents an element that can be rendered on the console and animated.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public abstract class AnimatedElement : Element
{
    #region Sealed Properties
    /// <summary>
    /// Gets the type of the element.
    /// </summary>
    public sealed override ElementType Type => ElementType.Animated;

    /// <summary>
    /// Gets the maximum number of this element that can be displayed on the console simultaneously.
    /// </summary>
    public sealed override int MaxNumberOfThisElement { get; } = 1;
    #endregion

    #region Methods
    /// <summary>
    /// Deactivates the element after having been rendered.
    /// </summary>
    [Visual]
    protected sealed override void RenderOptionsAfterHand()
    {
        Window.DeactivateElement(this);
    }
    #endregion
}
