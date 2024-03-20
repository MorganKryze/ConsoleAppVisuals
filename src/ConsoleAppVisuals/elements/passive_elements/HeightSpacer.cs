/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals.PassiveElements;

/// <summary>
/// A <see cref="HeightSpacer"/> is a passive element that displays a space between elements with a fixed height.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public class HeightSpacer : PassiveElement
{
    #region Fields
    private int _height;
    private Placement _placement;
    #endregion

    #region Properties
    /// <summary>
    /// The height of the spacer.
    /// </summary>
    public override int Height => _height;

    /// <summary>
    /// The placement of the spacer.
    /// </summary>
    public override Placement Placement => _placement;
    #endregion

    #region Constructor
    /// <summary>
    /// A <see cref="HeightSpacer"/> is a passive element that displays a space between elements with a fixed height.
    /// </summary>
    /// <param name="height">The height of the spacer.</param>
    /// <param name="placement">The placement of the spacer.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public HeightSpacer(int height = 1, Placement placement = Placement.TopCenter)
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
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
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
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdatePlacement(Placement newPlacement)
    {
        _placement = newPlacement;
    }

    /// <summary>
    /// This method is used to render the footer on the console.
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
