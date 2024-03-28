/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.PassiveElements;

/// <summary>
/// The <see cref="Title"/> is a passive element that displays a title on the console.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class Title : PassiveElement
{
    #region Constants
    const int DEFAULT_MARGIN = 1;
    const TextAlignment DEFAULT_ALIGN = TextAlignment.Center;
    const Placement DEFAULT_PLACEMENT = Placement.TopCenterFullWidth;
    const int DEFAULT_LINE = 0;
    const Font DEFAULT_FONT = Font.ANSI_Shadow;
    const string DEFAULT_FONT_PATH = null;
    #endregion

    #region Fields
    private string _text;
    private int _margin;
    private TextAlignment _align;
    private TextStyler _styler;
    #endregion

    #region Default Properties
    /// <summary>
    /// Gets the height of the title.
    /// </summary>
    public override int Height => StyledText.Length + _margin * 2;

    /// <summary>
    /// Gets the width of the title.
    /// </summary>
    public override int Width => Console.WindowWidth;

    /// <summary>
    /// Gets the placement of the title.
    /// </summary>
    public override Placement Placement => DEFAULT_PLACEMENT;

    /// <summary>
    /// Gets the line of the title.
    /// </summary>
    public override int Line => DEFAULT_LINE;

    /// <summary>
    /// Gets the maximum number of this element.
    /// </summary>
    public override int MaxNumberOfThisElement => 1;
    #endregion

    #region Properties
    /// <summary>
    /// Gets the styled text of the title.
    /// </summary>
    public string[] StyledText => _styler.Style(_text);

    /// <summary>
    /// Gets the text styler of the title.
    /// </summary>
    public TextStyler Styler => _styler;

    /// <summary>
    /// Gets the font of the title.
    /// </summary>
    public Font Font => _styler.Font;
    #endregion

    #region Constructor
    /// <summary>
    /// The <see cref="Title"/> is a passive element that displays a title on the console.
    /// </summary>
    /// <param name="text">The text of the title.</param>
    /// <param name="margin">The margin of the title.</param>
    /// <param name="align">The alignment of the title.</param>
    /// <param name="font">The font of the title.</param>
    /// <param name="fontPath">ATTENTION: fill this parameter only if you want to use a custom font (Font.Custom).</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public Title(
        string text,
        int margin = DEFAULT_MARGIN,
        TextAlignment align = DEFAULT_ALIGN,
        Font font = DEFAULT_FONT,
        string? fontPath = DEFAULT_FONT_PATH
    )
    {
        _text = text;
        _margin = margin;
        _align = align;
        _styler = new TextStyler(font, fontPath);
    }
    #endregion

    #region Update Methods
    /// <summary>
    /// Updates the text of the title.
    /// </summary>
    /// <param name="text">The new text of the title.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateText(string text)
    {
        _text = text;
    }

    /// <summary>
    /// Updates the margin of the title.
    /// </summary>
    /// <param name="margin">The new margin of the title.</param>
    /// <exception cref="ArgumentOutOfRangeException">The margin must be between 0 and the half of the console height.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// Updates the alignment of the title.
    /// </summary>
    /// <param name="align">The new alignment of the title.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateAlignment(TextAlignment align)
    {
        _align = align;
    }

    /// <summary>
    /// Updates the font of the title.
    /// </summary>
    /// <param name="font">The new font of the title.</param>
    /// <param name="fontPath">ATTENTION: fill this parameter only if you want to use a custom font (Font.Custom).</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateFont(Font font, string? fontPath = DEFAULT_FONT_PATH)
    {
        _styler = new TextStyler(font, fontPath);
    }
    #endregion

    #region Rendering
    /// <summary>
    /// Defines the actions to perform when the element is called to be rendered on the console.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        Core.WritePositionedStyledText(StyledText, Line, Width, _margin, _align, false);
    }
    #endregion
}
