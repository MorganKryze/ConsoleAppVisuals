/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.PassiveElements;

/// <summary>
/// The <see cref="HeightSpacer"/> is a passive element that displays a space between elements with a fixed height.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class HeightSpacer : PassiveElement
{
    #region Constants
    const int DEFAULT_HEIGHT = 1;
    const Placement DEFAULT_PLACEMENT = Placement.TopCenter;
    #endregion

    #region Fields
    private int _height;
    private Placement _placement;
    #endregion

    #region Default Properties
    /// <summary>
    /// Gets the height of the spacer.
    /// </summary>
    public override int Height => _height;

    /// <summary>
    /// Gets the placement of the spacer.
    /// </summary>
    public override Placement Placement => _placement;
    #endregion

    #region Constructor
    /// <summary>
    /// The <see cref="HeightSpacer"/> is a passive element that displays a space between elements with a fixed height.
    /// </summary>
    /// <param name="height">The height of the spacer.</param>
    /// <param name="placement">The placement of the spacer.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public HeightSpacer(int height = DEFAULT_HEIGHT, Placement placement = DEFAULT_PLACEMENT)
    {
        int windowHeightMax = Console.WindowHeight == 0 ? 0 : Console.WindowHeight - 1;
        if (height < 0 || height > windowHeightMax)
        {
            throw new ArgumentOutOfRangeException(
                "The height of the spacer cannot be negative or greater than the window height."
            );
        }
        _height = height;
        _placement = placement;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Updates the height of the spacer.
    /// </summary>
    /// <param name="newHeight">The new height of the spacer.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the new height is negative or greater than the window height.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateHeight(int newHeight)
    {
        int windowHeightMax = Console.WindowHeight == 0 ? 0 : Console.WindowHeight - 1;
        if (newHeight < 0 || newHeight > windowHeightMax)
        {
            throw new ArgumentOutOfRangeException(
                "The height of the spacer cannot be negative or greater than the window height."
            );
        }
        _height = newHeight;
    }

    /// <summary>
    /// Updates the placement of the spacer.
    /// </summary>
    /// <param name="newPlacement">The new placement of the spacer.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdatePlacement(Placement newPlacement)
    {
        _placement = newPlacement;
    }
    #endregion

    #region Rendering
    /// <summary>
    /// Defines the actions to perform when the element is called to be rendered on the console.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        Core.WriteMultiplePositionedLines(
            false,
            TextAlignment.Center,
            _placement,
            false,
            Line,
            GetRenderSpace()
        );
    }
    #endregion
}
