/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// Defines the footer of the console window.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
/// </list>
/// </remarks>
public class Footer : Element
{
    #region Fields
    private (string, string, string) _text;
    #endregion

    #region Properties
    /// <summary>
    /// The placement of the footer.
    /// </summary>
    public override Placement Placement { get; set; } = Placement.BottomCenterFullWidth;

    /// <summary>
    /// The line of the footer in the console.
    /// </summary>
    public override int Line => Window.GetLineAvailable(Placement);

    /// <summary>
    /// The height of the footer.
    /// </summary>
    public override int Height => 1;

    /// <summary>
    /// The width of the footer.
    /// </summary>
    public override int Width => Console.WindowWidth;
    #endregion

    #region Getters and Setters

    public (string,string,string) Text{get => _text; set => _text = value;}
    
    #endregion



    #region Constructor
    /// <summary>
    /// The natural constructor of the footer.
    /// </summary>
    /// <param name="leftText">The text on the left of the footer.</param>
    /// <param name="centerText">The text in the center of the footer.</param>
    /// <param name="rightText">The text on the right of the footer.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
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
    /// This method is used to update the text in the center of the footer.
    /// </summary>
    /// <param name="centerText">The new text in the center of the footer.</param>
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
    /// This method is used to update the text on the right of the footer.
    /// </summary>
    /// <param name="rightText">The new text on the right of the footer.</param>
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
    /// This method is used to render the footer on the console.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        Core.WritePositionedString(_text.BannerToString(), TextAlignment.Center, true, Line, false);
    }
    #endregion
}
