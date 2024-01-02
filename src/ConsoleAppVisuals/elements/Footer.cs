/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// Defines the footer of the console window.
/// </summary>
public class Footer : Element
{
    #region Fields
    private (string, string, string) _text;

    /// <summary>
    /// The placement of the footer.
    /// </summary>
    public override Placement Placement { get; set; } = Placement.BottomCenter;

    /// <summary>
    /// The line of the footer in the console.
    /// </summary>
    public override int Line => Console.WindowHeight - 1;

    /// <summary>
    /// The height of the footer.
    /// </summary>
    public override int Height => 1;

    /// <summary>
    /// The width of the footer.
    /// </summary>
    public override int Width => Console.WindowWidth;
    #endregion

    #region Constructor
    /// <summary>
    /// The natural constructor of the footer.
    /// </summary>
    /// <param name="leftText">The text on the left of the footer.</param>
    /// <param name="centerText">The text in the center of the footer.</param>
    /// <param name="rightText">The text on the right of the footer.</param>
    public Footer(
        string leftText = " Footer Left",
        string centerText = " Footer Center",
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
    public void UpdateLeftText(string leftText)
    {
        _text.Item1 = leftText;
    }

    /// <summary>
    /// This method is used to update the text in the center of the footer.
    /// </summary>
    /// <param name="centerText">The new text in the center of the footer.</param>
    public void UpdateCenterText(string centerText)
    {
        _text.Item2 = centerText;
    }

    /// <summary>
    /// This method is used to update the text on the right of the footer.
    /// </summary>
    /// <param name="rightText">The new text on the right of the footer.</param>
    public void UpdateRightText(string rightText)
    {
        _text.Item3 = rightText;
    }

    /// <summary>
    /// This method is used to render the footer on the console.
    /// </summary>
    protected override void RenderActions()
    {
        Core.WritePositionedString(_text.BannerToString(), Placement.TopCenter, true, Line, false);
    }
    #endregion
}
