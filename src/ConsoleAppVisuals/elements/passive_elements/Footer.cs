/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.PassiveElements;

/// <summary>
/// A <see cref="Footer"/> is a passive element that displays a footer on the console.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class Footer : PassiveElement
{
    #region Fields
    private (string, string, string) _text;
    #endregion

    #region Constants
    private const int TEXT_HEIGHT = 1;
    #endregion

    #region Properties
    /// <summary>
    /// The placement of the footer.
    /// </summary>
    public override Placement Placement => Placement.BottomCenterFullWidth;

    /// <summary>
    /// The height of the footer.
    /// </summary>
    public override int Height => TEXT_HEIGHT;

    /// <summary>
    /// The width of the footer.
    /// </summary>
    public override int Width => Console.WindowWidth;

    /// <summary>
    /// The maximum number of this element.
    /// </summary>
    public override int MaxNumberOfThisElement => 1;

    /// <summary>
    /// The text of the footer.
    /// </summary>
    public (string, string, string) Text => _text;
    #endregion



    #region Constructor
    /// <summary>
    /// A <see cref="Footer"/> is a passive element that displays a footer on the console.
    /// </summary>
    /// <param name="leftText">The text on the left of the footer.</param>
    /// <param name="centerText">The text in the center of the footer.</param>
    /// <param name="rightText">The text on the right of the footer.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public Footer(
        string leftText = "Footer Left",
        string centerText = "Footer Center",
        string rightText = "Footer Right"
    )
    {
        _text.Item1 = leftText;
        _text.Item2 = centerText;
        _text.Item3 = rightText;
    }
    #endregion

    #region Methods
    /// <summary>
    /// This method is used to update the text on the left of the footer.
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
    /// This method is used to update the text in the center of the footer.
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
    /// This method is used to update the text on the right of the footer.
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
    /// This method is used to render the footer on the console.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        Core.WritePositionedString(_text.BannerToString(), Placement, true, Line, false);
    }
    #endregion
}
