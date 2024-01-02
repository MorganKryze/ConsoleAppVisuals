/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// Defines the header of the console window.
/// </summary>
public class Header : Element
{
    #region Fields
    private (string, string, string) _text;
    private readonly int _margin;

    /// <summary>
    /// The line of the header in the console.
    /// </summary>
    /// <remarks>We add 2 because so the header does not overlap with the title.</remarks>
    public override int Line => Window.GetVisibleElement<Title>()?.Height ?? default;

    /// <summary>
    /// The height of the header.
    /// </summary>
    public override int Height => 1 + _margin;

    /// <summary>
    /// The width of the header.
    /// </summary>
    public override int Width => Console.WindowWidth;
    #endregion

    #region Constructor
    /// <summary>
    /// The natural constructor of the header.
    /// </summary>
    /// <param name="leftText">The text on the left of the header.</param>
    /// <param name="centerText">The text in the center of the header.</param>
    /// <param name="rightText">The text on the right of the header.</param>
    /// <param name="margin">The margin of the header.</param>
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
    public void UpdateLeftText(string leftText)
    {
        _text.Item1 = leftText;
    }

    /// <summary>
    /// This method is used to update the text in the center of the header.
    /// </summary>
    /// <param name="centerText">The new text in the center of the header.</param>
    public void UpdateCenterText(string centerText)
    {
        _text.Item2 = centerText;
    }

    /// <summary>
    /// This method is used to update the text on the right of the header.
    /// </summary>
    /// <param name="rightText">The new text on the right of the header.</param>
    public void UpdateRightText(string rightText)
    {
        _text.Item3 = rightText;
    }

    /// <summary>
    /// This method is used to render the header on the console.
    /// </summary>
    protected override void RenderActions()
    {
        Core.WritePositionedString(_text.BannerToString(), Placement.TopCenter, true, Line, false);
    }
    #endregion
}
