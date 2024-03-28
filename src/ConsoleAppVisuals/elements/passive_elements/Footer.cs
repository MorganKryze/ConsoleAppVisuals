/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.PassiveElements;

/// <summary>
/// The <see cref="Footer"/> is a passive element that displays a footer on the console.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class Footer : PassiveElement
{
    #region Constants
    const int TEXT_HEIGHT = 1;
    const string DEFAULT_FOOTER_LEFT = "Footer Left";
    const string DEFAULT_FOOTER_CENTER = "Footer Center";
    const string DEFAULT_FOOTER_RIGHT = "Footer Right";
    const int DEFAULT_MARGIN = 1;
    const Placement DEFAULT_PLACEMENT = Placement.BottomCenterFullWidth;
    #endregion

    #region Fields
    private (string, string, string) _text;
    private int _upperMargin;
    #endregion

    #region Default Properties
    /// <summary>
    /// Gets the height of the footer.
    /// </summary>
    public override int Height => UpperMargin + TEXT_HEIGHT;

    /// <summary>
    /// Gets the width of the footer.
    /// </summary>
    public override int Width => Console.WindowWidth;

    /// <summary>
    /// Gets the placement of the footer.
    /// </summary>
    public override Placement Placement => DEFAULT_PLACEMENT;
    #endregion

    #region Properties
    /// <summary>
    /// Gets the text of the footer.
    /// </summary>
    public (string, string, string) Text => _text;

    /// <summary>
    /// Gets the upper margin of the footer.
    /// </summary>
    public int UpperMargin => _upperMargin;

    /// <summary>
    /// Gets the maximum number of this element.
    /// </summary>
    public override int MaxNumberOfThisElement => 1;
    #endregion

    #region Constructor
    /// <summary>
    /// The <see cref="Footer"/> is a passive element that displays a footer on the console.
    /// </summary>
    /// <param name="leftText">The text on the left of the footer.</param>
    /// <param name="centerText">The text in the center of the footer.</param>
    /// <param name="rightText">The text on the right of the footer.</param>
    /// <param name="upperMargin">The upper margin of the footer.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public Footer(
        string leftText = DEFAULT_FOOTER_LEFT,
        string centerText = DEFAULT_FOOTER_CENTER,
        string rightText = DEFAULT_FOOTER_RIGHT,
        int upperMargin = DEFAULT_MARGIN
    )
    {
        _text.Item1 = leftText;
        _text.Item2 = centerText;
        _text.Item3 = rightText;
        _upperMargin = upperMargin;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Updates the text on the left of the footer.
    /// </summary>
    /// <param name="leftText">The new text on the left of the footer.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateLeftText(string leftText)
    {
        _text.Item1 = leftText;
    }

    /// <summary>
    /// Updates the text in the center of the footer.
    /// </summary>
    /// <param name="centerText">The new text in the center of the footer.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateCenterText(string centerText)
    {
        _text.Item2 = centerText;
    }

    /// <summary>
    /// Updates the text on the right of the footer.
    /// </summary>
    /// <param name="rightText">The new text on the right of the footer.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateRightText(string rightText)
    {
        _text.Item3 = rightText;
    }

    /// <summary>
    /// Updates the upper margin of the footer.
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
        Core.WritePositionedString(_text.BannerToString(), Placement, true, Line, false);
    }
    #endregion
}
