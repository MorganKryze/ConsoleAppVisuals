/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// Defines the basic properties of an embedded text.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
/// </list>
/// </remarks>
public class EmbeddedText : InteractiveElement<string>
{
    #region Fields
    private readonly List<string> _text;
    private readonly string _button;
    private readonly TextAlignment _align;
    private readonly Placement _placement;
    private readonly int _line;
    private List<string>? _textToDisplay;
    #endregion

    #region Properties
    /// <summary>
    /// The position of the Embedded text.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// The Line of the Embedded text.
    /// </summary>
    public override int Line => _line;

    /// <summary>
    /// The height of the Embedded text.
    /// </summary>
    public override int Height => _textToDisplay!.Count;

    /// <summary>
    /// The width of the Embedded text.
    /// </summary>
    public override int Width => _textToDisplay!.Max((string s) => s.Length) - 8;
    #endregion

    #region Constructor
    /// <summary>
    /// The natural constructor of the Embedded text.
    /// </summary>
    /// <param name="text">The text to display.</param>
    /// <param name="button">The text of the button.</param>
    /// <param name="align">The alignment of the Embedded text.</param>
    /// <param name="placement">The placement of the Embedded text element.</param>
    /// <param name="line">The line of the Embedded text.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public EmbeddedText(
        List<string> text,
        string? button = null,
        TextAlignment align = TextAlignment.Left,
        Placement placement = Placement.TopCenter,
        int? line = null
    )
    {
        _text = text;
        _button = button ?? "Press [Enter] to continue";
        _align = align;
        _placement = placement;
        _line = Window.CheckLine(line) ?? Window.GetLineAvailable(placement);
        BuildText();
    }
    #endregion

    #region Methods
    /// <summary>
    /// Adds a line to the Embedded text.
    /// </summary>
    /// <param name="line">The line to add.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void AddLine(string line)
    {
        _text.Add(line);
    }

    /// <summary>
    /// Inserts a line to the Embedded text.
    /// </summary>
    /// <param name="line">The line to insert.</param>
    /// <param name="index">The index where to insert the line.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void InsertLine(string line, int index)
    {
        _text.Insert(index, line);
    }

    /// <summary>
    /// Removes a line from the Embedded text.
    /// </summary>
    /// <param name="line">The line to remove.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void RemoveLine(string line)
    {
        _text.Remove(line);
    }

    /// <summary>
    /// Removes a line from the Embedded text.
    /// </summary>
    /// <param name="index">The index of the line to remove.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void RemoveLine(int index)
    {
        _text.RemoveAt(index);
    }

    /// <summary>
    /// Renders the Embedded text.
    /// </summary>
    protected override void RenderElementActions()
    {
        BuildText();
        Core.WriteMultiplePositionedLines(
            false,
            _placement.ToTextAlignment(),
            false,
            _line,
            _textToDisplay!.ToArray()
        );
        Window.StopExecution();
        Window.DeactivateElement<EmbeddedText>();
    }

    private void BuildText()
    {
        var maxLength = _text.Max((string s) => s.Length);
        _textToDisplay = new List<string>();
        foreach (var line in _text)
        {
            var lineToDisplay = "│ ";
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
            lineToDisplay += " │";
            _textToDisplay.Add(lineToDisplay);
        }
        _textToDisplay.Insert(0, "┌" + new string('─', maxLength + 2) + "┐");
        _textToDisplay.Add("│ " + new string(' ', maxLength) + " │");
        _textToDisplay.Add(
            "│ "
                + "".PadRight(maxLength - _button.Length - 2)
                + Core.NEGATIVE_ANCHOR
                + " "
                + _button
                + " "
                + Core.NEGATIVE_ANCHOR
                + " │"
        );
        _textToDisplay.Add("└" + new string('─', maxLength + 2) + "┘");
    }
    #endregion
}
