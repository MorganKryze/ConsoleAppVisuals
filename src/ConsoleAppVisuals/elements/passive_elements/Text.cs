/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.PassiveElements;

/// <summary>
/// The <see cref="Text"/> is an passive element that displays one or multiple lines of text.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class Text : PassiveElement
{
    #region Constants
    const TextAlignment DEFAULT_ALIGN = TextAlignment.Left;
    const Placement DEFAULT_PLACEMENT = Placement.TopCenter;

    #endregion

    #region Fields
    private List<string> _lines;
    private TextAlignment _align;
    private Placement _placement;
    private List<string>? _textToDisplay;
    #endregion

    #region Default Properties
    /// <summary>
    /// Gets the position of the Text element.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// Gets the alignment of the Text element.
    /// </summary>
    public override TextAlignment TextAlignment => _align;

    /// <summary>
    /// Gets the height of the Text element.
    /// </summary>
    public override int Height => _textToDisplay!.Count;

    /// <summary>
    /// Gets the width of the Text element.
    /// </summary>
    public override int Width => _textToDisplay!.Max(s => s.Length);
    #endregion

    #region Properties
    /// <summary>
    /// Gets the text of the Text element.
    /// </summary>
    public List<string> Lines => _lines;

    /// <summary>
    /// Gets the text to display.
    /// </summary>
    public List<string>? TextToDisplay => _textToDisplay;
    #endregion

    #region Constructor
    /// <summary>
    /// The <see cref="Text"/> is an passive element that displays one or multiple lines of text.
    /// </summary>
    /// <param name="lines">The text to display.</param>
    /// <param name="align">The alignment of the Text element.</param>
    /// <param name="placement">The placement of the Text element.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public Text(
        List<string> lines,
        TextAlignment align = DEFAULT_ALIGN,
        Placement placement = DEFAULT_PLACEMENT
    )
    {
        _lines = lines;
        _align = align;
        _placement = placement;
        if (CheckIntegrity())
            Build();
    }
    #endregion

    #region Update Methods
    private bool CheckIntegrity() => _lines.Count != 0;

    /// <summary>
    /// Updates the lines of the Text element.
    /// </summary>
    /// <param name="lines">The new text of the Text element.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateLines(List<string> lines)
    {
        _lines.Clear();
        _lines = lines;
        Build();
    }

    /// <summary>
    /// Updates the placement of the Text element.
    /// </summary>
    /// <param name="newPlacement">The new placement of the Text element.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdatePlacement(Placement newPlacement)
    {
        _placement = newPlacement;
    }

    /// <summary>
    /// Updates the alignment of the Text element.
    /// </summary>
    /// <param name="newAlignment">The new alignment of the Text element.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateTextAlignment(TextAlignment newAlignment)
    {
        _align = newAlignment;
        Build();
    }
    #endregion

    #region Manipulating Methods
    /// <summary>
    /// Adds a line to the Text element.
    /// </summary>
    /// <param name="line">The line to add.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void AddLine(string line)
    {
        _lines.Add(line);
        Build();
    }

    /// <summary>
    /// Inserts a line to the Text element.
    /// </summary>
    /// <param name="index">The index where to insert the line.</param>
    /// <param name="line">The line to insert.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void InsertLine(int index, string line)
    {
        _lines.Insert(index, line);
        Build();
    }

    /// <summary>
    /// Removes a line from the Text element.
    /// </summary>
    /// <param name="line">The line to remove.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void RemoveLine(string line)
    {
        if (!_lines.Contains(line))
        {
            throw new ArgumentException("The line is not in the text.", nameof(line));
        }
        _lines.Remove(line);
    }

    /// <summary>
    /// Removes a line from the Text element.
    /// </summary>
    /// <param name="index">The index of the line to remove.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void RemoveLine(int index)
    {
        if (index < 0 || index >= _lines.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "The index is out of range.");
        }
        _lines.RemoveAt(index);
    }
    #endregion

    #region Rendering
    [Visual]
    private void Build()
    {
        if (_lines.Count == 0)
        {
            throw new ArgumentException("The element is empty.");
        }

        var maxLength = _lines.Max(s => s.Length);
        _textToDisplay = new List<string>();

        foreach (var line in _lines)
        {
            string lineToDisplay;
            switch (_align)
            {
                case TextAlignment.Center:
                    int totalPadding = maxLength - line.Length;
                    int padLeft = totalPadding / 2;
                    lineToDisplay = line.PadLeft(line.Length + padLeft).PadRight(maxLength);
                    break;
                case TextAlignment.Left:
                    lineToDisplay = line.PadRight(maxLength);
                    break;
                case TextAlignment.Right:
                    lineToDisplay = line.PadLeft(maxLength);
                    break;
                default:
                    lineToDisplay = line;
                    break;
            }
            _textToDisplay.Add(lineToDisplay);
        }
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
