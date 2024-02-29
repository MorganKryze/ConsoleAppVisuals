/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals.Elements;

/// <summary>
/// Defines the header of the console window.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
/// </list>
/// </remarks>
public class Header : Element
{
    #region Fields
    private (string, string, string) _text;
    private int _margin;
    #endregion

    #region Properties
    /// <summary>
    /// The placement of the header.
    /// </summary>
    public override Placement Placement => Placement.TopCenterFullWidth;

    /// <summary>
    /// The line of the header in the console.
    /// </summary>
    public override int Line => Window.GetVisibleElement<Title>()?.Height ?? 0;

    /// <summary>
    /// The height of the header.
    /// </summary>
    public override int Height => 1 + _margin;

    /// <summary>
    /// The width of the header.
    /// </summary>
    public override int Width => Console.WindowWidth;
    #endregion

    #region Getters and Setters
    /// <summary>
    /// The getter of the text of the header.
    /// </summary>
    public (string, string, string) Text => _text;

    /// <summary>
    /// The getter and setter of the margin of the header.
    /// </summary>
    public int Margin => _margin;
    #endregion

    #region Constructor
    /// <summary>
    /// The natural constructor of the header.
    /// </summary>
    /// <param name="leftText">The text on the left of the header.</param>
    /// <param name="centerText">The text in the center of the header.</param>
    /// <param name="rightText">The text on the right of the header.</param>
    /// <param name="margin">The margin of the header.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
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
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
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
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
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
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
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
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
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
        Core.WritePositionedString(Text.BannerToString(), TextAlignment.Center, true, Line, false);
    }
    #endregion
}