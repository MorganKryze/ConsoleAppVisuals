/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals.PassiveElements;

/// <summary>
/// A <see cref="Header"/> is a passive element that displays a header on the console.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public class Header : PassiveElement
{
    #region Fields
    private (string, string, string) _text;
    private int _margin;
    #endregion

    #region Constants
    private const int TEXT_HEIGHT = 1;
    #endregion

    #region Properties
    /// <summary>
    /// The placement of the header.
    /// </summary>
    public override Placement Placement => Placement.TopCenterFullWidth;

    /// <summary>
    /// The height of the header.
    /// </summary>
    public override int Height => TEXT_HEIGHT + _margin;

    /// <summary>
    /// The width of the header.
    /// </summary>
    public override int Width => Console.WindowWidth;

    /// <summary>
    /// The text of the header.
    /// </summary>
    public (string, string, string) Text => _text;

    /// <summary>
    /// The margin of the header.
    /// </summary>
    public int Margin => _margin;

    /// <summary>
    /// The maximum number of this element.
    /// </summary>
    public override int MaxNumberOfThisElement => 1;
    #endregion

    #region Constructor
    /// <summary>
    /// A <see cref="Header"/> is a passive element that displays a header on the console.
    /// </summary>
    /// <param name="leftText">The text on the left of the header.</param>
    /// <param name="centerText">The text in the center of the header.</param>
    /// <param name="rightText">The text on the right of the header.</param>
    /// <param name="margin">The margin of the header.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public Header(
        string leftText = "Header Left",
        string centerText = "Header Center",
        string rightText = "Header Right",
        int margin = 1
    )
    {
        _text.Item1 = leftText;
        _text.Item2 = centerText;
        _text.Item3 = rightText;
        _margin = margin;
    }
    #endregion

    #region Methods
    /// <summary>
    /// This method is used to update the text on the left of the header.
    /// </summary>
    /// <param name="leftText">The new text on the left of the header.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateLeftText(string leftText)
    {
        _text.Item1 = leftText;
    }

    /// <summary>
    /// This method is used to update the text in the center of the header.
    /// </summary>
    /// <param name="centerText">The new text in the center of the header.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateCenterText(string centerText)
    {
        _text.Item2 = centerText;
    }

    /// <summary>
    /// This method is used to update the text on the right of the header.
    /// </summary>
    /// <param name="rightText">The new text on the right of the header.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateRightText(string rightText)
    {
        _text.Item3 = rightText;
    }

    /// <summary>
    /// This method is used to update the margin of the header.
    /// </summary>
    /// <param name="margin">The new margin of the header.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateMargin(int margin)
    {
        _margin = margin;
    }

    /// <summary>
    /// This method is used to render the header on the console.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        Core.WritePositionedString(Text.BannerToString(), Placement, true, Line, false);
    }
    #endregion
}
