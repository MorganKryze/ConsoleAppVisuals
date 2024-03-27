/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.PassiveElements;

/// <summary>
/// A <see cref="Title"/> is a passive element that displays a title on the console.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public class Title : PassiveElement
{
    #region Fields
    private string _text;
    private int _margin;
    private TextAlignment _align;
    private TextStyler _styler;

    #endregion

    #region Properties
    /// <summary>
    ///
    /// </summary>
    public string[] StyledText => _styler.Style(_text);

    /// <summary>
    /// The placement of the title.
    /// </summary>
    public override Placement Placement => Placement.TopCenterFullWidth;

    /// <summary>
    /// The height of the title.
    /// </summary>
    public override int Height => StyledText.Length + _margin * 2;

    /// <summary>
    /// The width of the title.
    /// </summary>
    public override int Width => Console.WindowWidth;

    /// <summary>
    /// The line of the title.
    /// </summary>
    public override int Line => 0;

    /// <summary>
    /// The maximum number of this element.
    /// </summary>
    public override int MaxNumberOfThisElement => 1;

    /// <summary>
    /// The text styler of the title.
    /// </summary>
    public TextStyler Styler => _styler;

    /// <summary>
    /// The font of the title.
    /// </summary>
    public Font Font => _styler.Font;
    #endregion

    #region Constructor
    /// <summary>
    /// A <see cref="Title"/> is a passive element that displays a title on the console.
    /// </summary>
    /// <param name="text">The text of the title.</param>
    /// <param name="margin">The margin of the title.</param>
    /// <param name="align">The alignment of the title.</param>
    /// <param name="font">The font of the title.</param>
    /// <param name="fontPath">ATTENTION: fill this parameter only if you want to use a custom font (Font.Custom).</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public Title(
        string text,
        int margin = 1,
        TextAlignment align = TextAlignment.Center,
        Font font = Font.ANSI_Shadow,
        string? fontPath = null
    )
    {
        _text = text;
        _margin = margin;
        _align = align;
        _styler = new TextStyler(font, fontPath);
    }
    #endregion

    #region Methods
    /// <summary>
    /// This method updates the text of the title.
    /// </summary>
    /// <param name="text">The new text of the title.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateText(string text)
    {
        _text = text;
    }

    /// <summary>
    /// This method updates the margin of the title.
    /// </summary>
    /// <param name="margin">The new margin of the title.</param>
    /// <exception cref="ArgumentOutOfRangeException">The margin must be between 0 and the half of the console height.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateMargin(int margin)
    {
        if (margin < 0 || margin > Console.WindowHeight / 2)
        {
            throw new ArgumentOutOfRangeException(
                nameof(margin),
                "The margin must be between 0 and the half of the console height."
            );
        }
        _margin = margin;
    }

    /// <summary>
    /// This method updates the alignment of the title.
    /// </summary>
    /// <param name="align">The new alignment of the title.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateAlignment(TextAlignment align)
    {
        _align = align;
    }

    /// <summary>
    /// This method updates the font of the title.
    /// </summary>
    /// <param name="font">The new font of the title.</param>
    /// <param name="fontPath">ATTENTION: fill this parameter only if you want to use a custom font (Font.Custom).</param>
    public void UpdateFont(Font font, string? fontPath = null)
    {
        _styler = new TextStyler(font, fontPath);
    }

    /// <summary>
    /// This method is used to draw the title on the console.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        Core.WritePositionedStyledText(StyledText, Line, Width, _margin, _align, false);
    }
    #endregion
}
