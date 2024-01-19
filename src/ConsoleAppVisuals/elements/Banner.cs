/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
using System.Runtime.CompilerServices;

namespace ConsoleAppVisuals;

/// <summary>
/// Defines the banner of the console window.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
/// </list>
/// </remarks>
public class Banner : Element
{
    #region Fields
    private (string, string, string) _text;
    private  int _upperMargin;
    private  int _lowerMargin;
    private  Placement _placement;
    private  int _line;
    #endregion

    #region Properties
    /// <summary>
    /// The placement of the banner.
    /// </summary>
    public override Placement Placement => Placement1;

    /// <summary>
    /// The line of the banner in the console.
    /// </summary>
    /// <remarks>We add 2 because so the banner does not overlap with the title.</remarks>
    public override int Line => Line1;

    /// <summary>
    /// The height of the banner.
    /// </summary>
    public override int Height => UpperMargin + 1 + LowerMargin;

    /// <summary>
    /// The width of the banner.
    /// </summary>
    public override int Width => Console.WindowWidth;

    

    #endregion

    #region Getters and Setters 
    /// <summary>
    /// Getter and setter of the text of the banner.
    /// </summary>
    public (string, string, string) Text { get => _text; set => _text = value; }
    /// <summary>
    /// Getter and setter of the upper margin of the banner.
    /// </summary>
    public int UpperMargin { get => _upperMargin; set => _upperMargin = value;}
    /// <summary>
    /// Getter and setter of the lower margin of the banner.
    /// </summary>
    public int LowerMargin { get => _lowerMargin; set => _lowerMargin = value; }
    /// <summary>
    /// Getter and setter of the placement of the banner.
    /// </summary>
    public Placement Placement1 { get => _placement; set => _placement = value; }
    /// <summary>
    /// Getter and setter of the line of the banner in the console.
    /// </summary>
    public int Line1 { get => _line; set => _line = value; }

    #endregion


    #region Constructor
    /// <summary>
    /// The natural constructor of the banner.
    /// </summary>
    /// <param name="leftText">The text on the left of the banner.</param>
    /// <param name="centerText">The text in the center of the banner.</param>
    /// <param name="rightText">The text on the right of the banner.</param>
    /// <param name="upperMargin">The upper margin of the banner.</param>
    /// <param name="lowerMargin">The lower margin of the banner.</param>
    /// <param name="placement">The placement of the banner.</param>
    /// <param name="line">The line of the banner in the console.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public Banner(
        string leftText = "Banner Left",
        string centerText = "Banner Center",
        string rightText = "Banner Right",
        int upperMargin = 0,
        int lowerMargin = 0,
        Placement placement = Placement.TopCenterFullWidth,
        int? line = null
    )
    {
        _text.Item1 = leftText;
        _text.Item2 = centerText;
        _text.Item3 = rightText;
        UpperMargin = upperMargin;
        LowerMargin = lowerMargin;
        Placement1 = CheckPlacement(placement);
        Line1 = Window.CheckLine(line) ?? Window.GetLineAvailable(Placement1);
    }

    private static Placement CheckPlacement(Placement placement)
    {
        if (placement is not (Placement.BottomCenterFullWidth  or Placement.TopCenterFullWidth))
        {
            throw new ArgumentException(
                "The placement of the banner must be TopCenterFullWidth or BottomCenterFullWidth."
            );
        }
        return placement;
    }
    #endregion

    #region Methods
    /// <summary>
    /// This method is used to update the text on the left of the banner.
    /// </summary>
    /// <param name="leftText">The new text on the left of the banner.</param>
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
    /// This method is used to update the text in the center of the banner.
    /// </summary>
    /// <param name="centerText">The new text in the center of the banner.</param>
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
    /// This method is used to update the text on the right of the banner.
    /// </summary>
    /// <param name="rightText">The new text on the right of the banner.</param>
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
    /// This method is used to render the banner on the console.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        for (int i = 0; i < UpperMargin; i++)
        {
            Core.WritePositionedString(string.Empty, TextAlignment.Center, true, Line + i, false);
        }
        Core.WritePositionedString(Text.BannerToString(), TextAlignment.Center, true, Line, false);
        for (int i = 0; i < LowerMargin; i++)
        {
            Core.WritePositionedString(
                string.Empty,
                TextAlignment.Center,
                true,
                Line + Height - 1 - i,
                false
            );
        }
    }
    #endregion
}
