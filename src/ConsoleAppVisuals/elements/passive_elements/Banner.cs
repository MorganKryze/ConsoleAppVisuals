/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals.PassiveElements;

/// <summary>
/// Defines the banner of the console window.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public class Banner : PassiveElement
{
    #region Fields
    private (string, string, string) _text;
    private int _upperMargin;
    private int _lowerMargin;
    private Placement _placement;
    #endregion

    #region Properties
    /// <summary>
    /// The placement of the banner.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// The height of the banner.
    /// </summary>
    public override int Height => UpperMargin + 1 + LowerMargin;

    /// <summary>
    /// The width of the banner.
    /// </summary>
    public override int Width => Console.WindowWidth;

    /// <summary>
    /// The text of the banner.
    /// </summary>
    public (string, string, string) Text => _text;

    /// <summary>
    /// The upper margin of the banner.
    /// </summary>
    public int UpperMargin => _upperMargin;

    /// <summary>
    /// The lower margin of the banner.
    /// </summary>
    public int LowerMargin => _lowerMargin;
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
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public Banner(
        string leftText = "Banner Left",
        string centerText = "Banner Center",
        string rightText = "Banner Right",
        int upperMargin = 0,
        int lowerMargin = 0,
        Placement placement = Placement.TopCenterFullWidth
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

    #region Methods
    /// <summary>
    /// This method is used to update the text on the left of the banner.
    /// </summary>
    /// <param name="leftText">The new text on the left of the banner.</param>
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
    /// This method is used to update the text in the center of the banner.
    /// </summary>
    /// <param name="centerText">The new text in the center of the banner.</param>
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
    /// This method is used to update the text on the right of the banner.
    /// </summary>
    /// <param name="rightText">The new text on the right of the banner.</param>
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
    /// This method is used to update the placement of the banner.
    /// </summary>
    /// <param name="placement">The new placement of the banner.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdatePlacement(Placement placement)
    {
        _placement = CheckPlacement(placement);
    }

    /// <summary>
    /// This method is used to update the upper margin of the banner.
    /// </summary>
    /// <param name="upperMargin">The new upper margin of the banner.</param>
    /// <exception cref="ArgumentOutOfRangeException">The upper margin of the banner must be between 0 and the height of the console window.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
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
    /// This method is used to update the lower margin of the banner.
    /// </summary>
    /// <param name="lowerMargin">The new lower margin of the banner.</param>
    /// <exception cref="ArgumentOutOfRangeException">The lower margin of the banner must be between 0 and the height of the console window.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
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
