/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.InteractiveElements;

/// <summary>
/// A <see cref="EmbedText"/> is an interactive element that displays text in a box with an optional button.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class EmbedText : PassiveElement
{
    #region Fields
    private List<string> _lines;
    private TextAlignment _align;
    private Placement _placement;
    private readonly Borders _borders;
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
    /// The rows of the Embed text.
    /// </summary>
    public List<string> Lines => _lines;

    /// <summary>
    /// The borders of the Embed text.
    /// </summary>
    public Borders Borders => _borders;

    /// <summary>
    /// The border type of the selector.
    /// </summary>
    public BordersType BordersType => _borders.Type;

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
    /// <param name="align">The alignment of the Embed text.</param>
    /// <param name="placement">The placement of the Embed text element.</param>
    /// <param name="bordersType">The type of border to display.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public EmbedText(
        List<string> text,
        TextAlignment align = TextAlignment.Left,
        Placement placement = Placement.TopCenter,
        BordersType bordersType = BordersType.SingleStraight
    )
    {
        _lines = text;
        _align = align;
        _placement = placement;
        _borders = new Borders(bordersType);
        if (IsLinesNotEmpty())
            Build();
    }
    #endregion

    #region Methods
    private bool IsLinesNotEmpty() => _lines.Count > 0;

    /// <summary>
    /// This method updates the text of the Embed text.
    /// </summary>
    /// <param name="newText">The new text of the Embed text.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateLines(List<string> newText)
    {
        _lines.Clear();
        _lines = newText;
    }

    /// <summary>
    /// This method updates the placement of the Embed text.
    /// </summary>
    /// <param name="newPlacement">The new placement of the Embed text.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateTextAlignment(TextAlignment newAlignment)
    {
        _align = newAlignment;
    }

    /// <summary>
    /// This method updates the borders of the Embed text.
    /// </summary>
    /// <param name="bordersType">The new border type of the Embed text.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateBordersType(BordersType bordersType)
    {
        _borders.UpdateBordersType(bordersType);
    }

    /// <summary>
    /// Adds a line to the Embed text.
    /// </summary>
    /// <param name="line">The line to add.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void AddLine(string line)
    {
        _lines.Add(line);
    }

    /// <summary>
    /// Inserts a line to the Embed text.
    /// </summary>
    /// <param name="line">The line to insert.</param>
    /// <param name="index">The index where to insert the line.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void InsertLine(int index, string line)
    {
        _lines.Insert(index, line);
    }

    /// <summary>
    /// Removes a line from the Embed text.
    /// </summary>
    /// <param name="line">The line to remove.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void RemoveLine(string line)
    {
        if (!_lines.Contains(line))
        {
            throw new ArgumentException("The line is not in the text.");
        }
        _lines.Remove(line);
    }

    /// <summary>
    /// Removes a line from the Embed text.
    /// </summary>
    /// <param name="index">The index of the line to remove.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void RemoveLine(int index)
    {
        if (index < 0 || index >= _lines.Count)
        {
            throw new ArgumentOutOfRangeException("The index is out of range.");
        }
        _lines.RemoveAt(index);
    }
    #endregion

    #region Rendering
    private void Build()
    {
        var maxLength = _lines.Max((string s) => s.Length);
        _textToDisplay = new List<string>();
        foreach (var line in _lines)
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
        _textToDisplay.Add(
            Borders.BottomLeft + new string(Borders.Horizontal, maxLength + 2) + Borders.BottomRight
        );
    }

    /// <summary>
    /// Renders the Embed text.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        Build();
        Core.WriteMultiplePositionedLines(
            false,
            TextAlignment,
            Placement,
            false,
            Line,
            _textToDisplay!.ToArray()
        );
    }
    #endregion
}
