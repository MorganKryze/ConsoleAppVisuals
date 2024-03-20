/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals.InteractiveElements;

/// <summary>
/// A <see cref="EmbedText"/> is an interactive element that displays text in a box with an optional button.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public class EmbedText : InteractiveElement<string>
{
    #region Fields
    private List<string> _text;
    private string? _button;
    private TextAlignment _align;
    private Placement _placement;
    private Borders _borders;
    private List<string>? _textToDisplay;

    #endregion

    #region Properties
    /// <summary>
    /// The position of the Embed text.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// The alignment of the Embed text.
    /// </summary>
    public override TextAlignment TextAlignment => _align;

    /// <summary>
    /// The height of the Embed text.
    /// </summary>
    public override int Height => _textToDisplay!.Count;

    /// <summary>
    /// The width of the Embed text.
    /// </summary>
    public override int Width => _textToDisplay!.Max((string s) => s.Length);

    /// <summary>
    /// The text of the Embed text.
    /// </summary>
    public List<string> Text => _text;

    /// <summary>
    /// The text of the button.
    /// </summary>
    public string? ButtonText => _button;

    /// <summary>
    /// The borders of the Embed text.
    /// </summary>
    public Borders Borders => _borders;

    /// <summary>
    /// The text to display.
    /// </summary>
    public List<string>? TextToDisplay => _textToDisplay;

    #endregion

    #region Constructor
    /// <summary>
    /// A <see cref="EmbedText"/> is an interactive element that displays text in a box with an optional button.
    /// </summary>
    /// <param name="text">The text to display.</param>
    /// <param name="button">The text of the button. Null to not display a button.</param>
    /// <param name="align">The alignment of the Embed text.</param>
    /// <param name="placement">The placement of the Embed text element.</param>
    /// <param name="borderType">The type of border to display.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public EmbedText(
        List<string> text,
        string? button = null,
        TextAlignment align = TextAlignment.Left,
        Placement placement = Placement.TopCenter,
        BorderType borderType = BorderType.SingleStraight
    )
    {
        _text = text;
        _button = button;
        _align = align;
        _placement = placement;
        _borders = new Borders(borderType);
        if (CheckIntegrity())
            BuildText();
    }
    #endregion

    #region Methods
    private bool CheckIntegrity()
    {
        if (_text.Count == 0)
        {
            return false;
        }
        if (_button is not null)
        {
            if (_text.Max((string s) => s.Length) < _button.Length)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// This method updates the text of the button.
    /// </summary>
    /// <param name="newButton">The new text of the button.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateButtonText(string? newButton)
    {
        _button = newButton;
    }

    /// <summary>
    /// This method updates the text of the Embed text.
    /// </summary>
    /// <param name="newText">The new text of the Embed text.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateText(List<string> newText)
    {
        _text.Clear();
        _text = newText;
    }

    /// <summary>
    /// This method updates the placement of the Embed text.
    /// </summary>
    /// <param name="newPlacement">The new placement of the Embed text.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdatePlacement(Placement newPlacement)
    {
        _placement = newPlacement;
    }

    /// <summary>
    /// This method updates the alignment of the Embed text.
    /// </summary>
    /// <param name="newAlignment">The new alignment of the Embed text.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateTextAlignment(TextAlignment newAlignment)
    {
        _align = newAlignment;
    }

    /// <summary>
    /// This method updates the borders of the Embed text.
    /// </summary>
    /// <param name="newBorderType">The new border type of the Embed text.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateBorderType(BorderType newBorderType)
    {
        _borders = new Borders(newBorderType);
    }

    /// <summary>
    /// Adds a line to the Embed text.
    /// </summary>
    /// <param name="line">The line to add.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void AddLine(string line)
    {
        _text.Add(line);
    }

    /// <summary>
    /// Inserts a line to the Embed text.
    /// </summary>
    /// <param name="line">The line to insert.</param>
    /// <param name="index">The index where to insert the line.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void InsertLine(string line, int index)
    {
        _text.Insert(index, line);
    }

    /// <summary>
    /// Removes a line from the Embed text.
    /// </summary>
    /// <param name="line">The line to remove.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void RemoveLine(string line)
    {
        if (!_text.Contains(line))
        {
            throw new ArgumentException("The line is not in the text.");
        }
        _text.Remove(line);
    }

    /// <summary>
    /// Removes a line from the Embed text.
    /// </summary>
    /// <param name="index">The index of the line to remove.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void RemoveLine(int index)
    {
        if (index < 0 || index >= _text.Count)
        {
            throw new ArgumentOutOfRangeException("The index is out of range.");
        }
        _text.RemoveAt(index);
    }

    /// <summary>
    /// Renders the Embed text.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        BuildText();
        Core.WriteMultiplePositionedLines(
            false,
            TextAlignment,
            Placement,
            false,
            Line,
            _textToDisplay!.ToArray()
        );
        Window.Freeze();
    }

    private void BuildText()
    {
        var maxLength = _text.Max((string s) => s.Length);
        _textToDisplay = new List<string>();
        foreach (var line in _text)
        {
            var lineToDisplay = $"{Borders.Vertical} ";
            switch (_align)
            {
                case TextAlignment.Center:
                    int totalPadding = maxLength - line.Length;
                    int padLeft = totalPadding / 2;
                    lineToDisplay += line.PadLeft(line.Length + padLeft).PadRight(maxLength);
                    break;
                case TextAlignment.Left:
                    lineToDisplay += line.PadRight(maxLength);
                    break;
                case TextAlignment.Right:
                    lineToDisplay += line.PadLeft(maxLength);
                    break;
            }
            lineToDisplay += $" {Borders.Vertical}";
            _textToDisplay.Add(lineToDisplay);
        }
        _textToDisplay.Insert(
            0,
            Borders.TopLeft + new string(Borders.Horizontal, maxLength + 2) + Borders.TopRight
        );
        if (_button is not null)
        {
            _textToDisplay.Add(
                $"{Borders.Vertical} " + new string(' ', maxLength) + $" {Borders.Vertical}"
            );
            _textToDisplay.Add(
                $"{Borders.Vertical} "
                    + "".PadRight(maxLength - _button.Length - 2)
                    + Core.NEGATIVE_ANCHOR
                    + " "
                    + _button
                    + " "
                    + Core.NEGATIVE_ANCHOR
                    + $" {Borders.Vertical}"
            );
        }
        _textToDisplay.Add(
            Borders.BottomLeft + new string(Borders.Horizontal, maxLength + 2) + Borders.BottomRight
        );
    }
    #endregion
}
