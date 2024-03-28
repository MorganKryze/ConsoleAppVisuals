/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.PassiveElements;

/// <summary>
/// The <see cref="Banner"/> is a passive element that displays a banner on the console.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class Banner : PassiveElement
{
    #region Constants
    const int INNER_BANNER_HEIGHT = 1;
    const string DEFAULT_BANNER_LEFT = "Banner Left";
    const string DEFAULT_BANNER_CENTER = "Banner Center";
    const string DEFAULT_BANNER_RIGHT = "Banner Right";
    const int DEFAULT_MARGIN = 0;
    const Placement DEFAULT_PLACEMENT = Placement.TopCenterFullWidth;
    #endregion

    #region Fields
    private (string, string, string) _text;
    private int _upperMargin;
    private int _lowerMargin;
    private Placement _placement;
    #endregion

    #region Default Properties
    /// <summary>
    /// Gets the placement of the banner.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// Gets the height of the banner.
    /// </summary>
    public override int Height => UpperMargin + INNER_BANNER_HEIGHT + LowerMargin;

    /// <summary>
    /// Gets the width of the banner.
    /// </summary>
    public override int Width => Console.WindowWidth;
    #endregion

    #region Properties
    /// <summary>
    /// Gets the text of the banner.
    /// </summary>
    public (string, string, string) Text => _text;

    /// <summary>
    /// Gets the upper margin of the banner.
    /// </summary>
    public int UpperMargin => _upperMargin;

    /// <summary>
    /// Gets the lower margin of the banner.
    /// </summary>
    public int LowerMargin => _lowerMargin;
    #endregion

    #region Constructor
    /// <summary>
    /// The <see cref="Banner"/> is a passive element that displays a banner on the console.
    /// </summary>
    /// <param name="leftText">The text on the left of the banner.</param>
    /// <param name="centerText">The text in the center of the banner.</param>
    /// <param name="rightText">The text on the right of the banner.</param>
    /// <param name="upperMargin">The upper margin of the banner.</param>
    /// <param name="lowerMargin">The lower margin of the banner.</param>
    /// <param name="placement">The placement of the banner.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public Banner(
        string leftText = DEFAULT_BANNER_LEFT,
        string centerText = DEFAULT_BANNER_CENTER,
        string rightText = DEFAULT_BANNER_RIGHT,
        int upperMargin = DEFAULT_MARGIN,
        int lowerMargin = DEFAULT_MARGIN,
        Placement placement = DEFAULT_PLACEMENT
    )
    {
        _text.Item1 = leftText;
        _text.Item2 = centerText;
        _text.Item3 = rightText;
        _upperMargin = upperMargin;
        _lowerMargin = lowerMargin;
        _placement = CheckPlacement(placement);
    }

    private static Placement CheckPlacement(Placement placement)
    {
        if (placement is not (Placement.BottomCenterFullWidth or Placement.TopCenterFullWidth))
        {
            throw new ArgumentException(
                "The placement of the banner must be TopCenterFullWidth or BottomCenterFullWidth."
            );
        }
        return placement;
    }
    #endregion

    #region Update Methods
    /// <summary>
    /// Updates the text on the left of the banner.
    /// </summary>
    /// <param name="leftText">The new text on the left of the banner.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateLeftText(string leftText)
    {
        _text.Item1 = leftText;
    }

    /// <summary>
    /// Updates the text in the center of the banner.
    /// </summary>
    /// <param name="centerText">The new text in the center of the banner.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateCenterText(string centerText)
    {
        _text.Item2 = centerText;
    }

    /// <summary>
    /// Updates the text on the right of the banner.
    /// </summary>
    /// <param name="rightText">The new text on the right of the banner.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateRightText(string rightText)
    {
        _text.Item3 = rightText;
    }

    /// <summary>
    /// Updates the placement of the banner.
    /// </summary>
    /// <param name="placement">The new placement of the banner.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdatePlacement(Placement placement)
    {
        _placement = CheckPlacement(placement);
    }

    /// <summary>
    /// Updates the upper margin of the banner.
    /// </summary>
    /// <param name="upperMargin">The new upper margin of the banner.</param>
    /// <exception cref="ArgumentOutOfRangeException">The upper margin of the banner must be between 0 and the height of the console window.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateUpperMargin(int upperMargin)
    {
        var maxWidth = Console.WindowHeight == 0 ? 0 : Console.WindowHeight - 1;
        if (upperMargin < 0 || upperMargin > maxWidth)
        {
            throw new ArgumentOutOfRangeException(
                nameof(upperMargin),
                "The upper margin of the banner must be between 0 and the height of the console window."
            );
        }
        _upperMargin = upperMargin;
    }

    /// <summary>
    /// Updates the lower margin of the banner.
    /// </summary>
    /// <param name="lowerMargin">The new lower margin of the banner.</param>
    /// <exception cref="ArgumentOutOfRangeException">The lower margin of the banner must be between 0 and the height of the console window.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateLowerMargin(int lowerMargin)
    {
        var maxWidth = Console.WindowHeight == 0 ? 0 : Console.WindowHeight - 1;
        if (lowerMargin < 0 || lowerMargin > maxWidth)
        {
            throw new ArgumentOutOfRangeException(
                nameof(lowerMargin),
                "The lower margin of the banner must be between 0 and the height of the console window."
            );
        }
        _lowerMargin = lowerMargin;
    }
    #endregion

    #region Rendering
    /// <summary>
    /// Defines the actions to perform when the element is called to be rendered on the console.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        for (int i = 0; i < UpperMargin; i++)
        {
            Core.WritePositionedString(string.Empty, Placement, true, Line + i, false);
        }
        Core.WritePositionedString(Text.BannerToString(), Placement, true, Line, false);
        for (int i = 0; i < LowerMargin; i++)
        {
            Core.WritePositionedString(string.Empty, Placement, true, Line + Height - 1 - i, false);
        }
    }
    #endregion
}
