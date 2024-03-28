/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.InteractiveElements;

/// <summary>
/// The <see cref="EmbedText"/> is an interactive element that displays text in a box with an optional button.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class EmbedText : PassiveElement
{
    #region Constants
    const TextAlignment DEFAULT_ALIGN = TextAlignment.Left;
    const Placement DEFAULT_PLACEMENT = Placement.TopCenter;
    const BordersType DEFAULT_BORDERS_TYPE = BordersType.SingleStraight;
    #endregion

    #region Fields
    private List<string> _lines;
    private TextAlignment _align;
    private Placement _placement;
    private readonly Borders _borders;
    private List<string>? _textToDisplay;
    #endregion

    #region Default Properties

    #endregion

    #region Properties
    /// <summary>
    /// Gets the position of the Embed text.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// Gets the alignment of the Embed text.
    /// </summary>
    public override TextAlignment TextAlignment => _align;

    /// <summary>
    /// Gets the height of the Embed text.
    /// </summary>
    public override int Height => _textToDisplay!.Count;

    /// <summary>
    /// Gets the width of the Embed text.
    /// </summary>
    public override int Width => _textToDisplay!.Max((string s) => s.Length);

    /// <summary>
    /// Gets the rows of the Embed text.
    /// </summary>
    public List<string> Lines => _lines;

    /// <summary>
    /// Gets the borders of the Embed text.
    /// </summary>
    public Borders Borders => _borders;

    /// <summary>
    /// Gets the border type of the selector.
    /// </summary>
    public BordersType BordersType => _borders.Type;

    /// <summary>
    /// Gets the text to display.
    /// </summary>
    public List<string>? TextToDisplay => _textToDisplay;
    #endregion

    #region Constructor
    /// <summary>
    /// The <see cref="EmbedText"/> is an interactive element that displays text in a box with an optional button.
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
        TextAlignment align = DEFAULT_ALIGN,
        Placement placement = DEFAULT_PLACEMENT,
        BordersType bordersType = DEFAULT_BORDERS_TYPE
    )
    {
        _lines = text;
        _align = align;
        _placement = placement;
        _borders = new Borders(bordersType);
        if (IsLinesNotEmpty())
            Build();
    }

    private bool IsLinesNotEmpty() => _lines.Count > 0;
    #endregion

    #region Update Methods
    /// <summary>
    /// Updates the text of the Embed text.
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
    /// Updates the placement of the Embed text.
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
    /// Updates the alignment of the Embed text.
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
    /// Updates the borders of the Embed text.
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
    /// Defines the actions to perform when the element is called to be rendered on the console.
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
