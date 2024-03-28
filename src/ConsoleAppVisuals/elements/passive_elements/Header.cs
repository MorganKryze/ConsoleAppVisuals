/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.PassiveElements;

/// <summary>
/// The <see cref="Header"/> is a passive element that displays a header on the console.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class Header : PassiveElement
{
    #region Constants
    const int TEXT_HEIGHT = 1;
    const string DEFAULT_HEADER_LEFT = "Header Left";
    const string DEFAULT_HEADER_CENTER = "Header Center";
    const string DEFAULT_HEADER_RIGHT = "Header Right";
    const int DEFAULT_MARGIN = 1;
    const Placement DEFAULT_PLACEMENT = Placement.TopCenterFullWidth;
    #endregion

    #region Fields
    private (string, string, string) _text;
    private int _margin;
    #endregion

    #region Default Properties
    /// <summary>
    /// Gets the height of the header.
    /// </summary>
    public override int Height => TEXT_HEIGHT + _margin;

    /// <summary>
    /// Gets the width of the header.
    /// </summary>
    public override int Width => Console.WindowWidth;

    /// <summary>
    /// Gets the placement of the header.
    /// </summary>
    public override Placement Placement => DEFAULT_PLACEMENT;

    /// <summary>
    /// Gets the maximum number of this element.
    /// </summary>
    public override int MaxNumberOfThisElement => 1;
    #endregion

    #region Properties
    /// <summary>
    /// Gets the text of the header.
    /// </summary>
    public (string, string, string) Text => _text;

    /// <summary>
    /// Gets the margin of the header.
    /// </summary>
    public int Margin => _margin;
    #endregion

    #region Constructor
    /// <summary>
    /// The <see cref="Header"/> is a passive element that displays a header on the console.
    /// </summary>
    /// <param name="leftText">The text on the left of the header.</param>
    /// <param name="centerText">The text in the center of the header.</param>
    /// <param name="rightText">The text on the right of the header.</param>
    /// <param name="margin">The margin of the header.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public Header(
        string leftText = DEFAULT_HEADER_LEFT,
        string centerText = DEFAULT_HEADER_CENTER,
        string rightText = DEFAULT_HEADER_RIGHT,
        int margin = DEFAULT_MARGIN
    )
    {
        _text.Item1 = leftText;
        _text.Item2 = centerText;
        _text.Item3 = rightText;
        _margin = margin;
    }
    #endregion

    #region Update Methods
    /// <summary>
    /// Updates the text on the left of the header.
    /// </summary>
    /// <param name="leftText">The new text on the left of the header.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateLeftText(string leftText)
    {
        _text.Item1 = leftText;
    }

    /// <summary>
    /// Updates the text in the center of the header.
    /// </summary>
    /// <param name="centerText">The new text in the center of the header.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateCenterText(string centerText)
    {
        _text.Item2 = centerText;
    }

    /// <summary>
    /// Updates the text on the right of the header.
    /// </summary>
    /// <param name="rightText">The new text on the right of the header.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateRightText(string rightText)
    {
        _text.Item3 = rightText;
    }

    /// <summary>
    /// Updates the margin of the header.
    /// </summary>
    /// <param name="margin">The new margin of the header.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateMargin(int margin)
    {
        _margin = margin;
    }
    #endregion

    #region Rendering
    /// <summary>
    /// Defines the actions to perform when the element is called to be rendered on the console.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        Core.WritePositionedString(Text.BannerToString(), Placement, true, Line, false);
    }
    #endregion
}
