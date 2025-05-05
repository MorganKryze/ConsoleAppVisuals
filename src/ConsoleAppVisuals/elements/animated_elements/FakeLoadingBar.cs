/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.AnimatedElements;

/// <summary>
/// The <see cref="FakeLoadingBar"/> is an animated element that simulates a loading bar with a fixed duration.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class FakeLoadingBar : AnimatedElement
{
    #region Constants
    const char LOADING_BAR_CHAR = '█';
    const int DEFAULT_HEIGHT = 5;
    const string DEFAULT_TEXT = "Loading ...";
    const int DEFAULT_WIDTH = 0;
    const Placement DEFAULT_PLACEMENT = Placement.TopCenter;
    const int DEFAULT_PROCESS_DURATION = 2000;
    const int DEFAULT_ADDITIONAL_DURATION = 1000;
    const BordersType DEFAULT_BORDERS_TYPE = BordersType.SingleStraight;
    #endregion

    #region Fields
    private string _text;
    private int _barWidth;
    private Placement _placement;
    private int _processDuration;
    private int _additionalDuration;
    private readonly Borders _borders;
    #endregion

    #region Default Properties
    /// <summary>
    /// Gets the height of the loading bar.
    /// </summary>
    public override int Height => DEFAULT_HEIGHT + 2;

    /// <summary>
    /// Gets the width of the loading bar.
    /// </summary>
    public override int Width => (_barWidth > 0 ? _barWidth : _text.Length) + 6;

    /// <summary>
    /// Gets the placement of the loading bar.
    /// </summary>
    public override Placement Placement => _placement;
    #endregion

    #region Properties
    /// <summary>
    /// Gets the text of the loading bar.
    /// </summary>
    public string Text => _text;

    /// <summary>
    /// Gets the explicit width of the loading bar.
    /// </summary>
    public int BarWidth => _barWidth;

    /// <summary>
    /// Gets the duration of the loading bar.
    /// </summary>
    public int ProcessDuration => _processDuration;

    /// <summary>
    /// Gets the additional duration of the loading bar at the end.
    /// </summary>
    public int AdditionalDuration => _additionalDuration;

    /// <summary>
    /// Gets the borders of the loading bar.
    /// </summary>
    public Borders Borders => _borders;

    /// <summary>
    /// Gets the border type of the loading bar.
    /// </summary>
    public BordersType BordersType => _borders.Type;
    #endregion

    #region Constructor
    /// <summary>
    /// The <see cref="FakeLoadingBar"/> is an animated element that simulates a loading bar with a fixed duration.
    /// </summary>
    /// <param name="text">The text of the loading bar.</param>
    /// <param name="barWidth">The width of the loading bar. If 0 or less than text length, text length is used.</param>
    /// <param name="placement">The placement of the loading bar.</param>
    /// <param name="processDuration">The duration of the loading bar.</param>
    /// <param name="additionalDuration">The additional duration of the loading bar at the end.</param>
    /// <param name="bordersType">The type of borders to display around the loading bar.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public FakeLoadingBar(
        string text = DEFAULT_TEXT,
        int barWidth = DEFAULT_WIDTH,
        Placement placement = DEFAULT_PLACEMENT,
        int processDuration = DEFAULT_PROCESS_DURATION,
        int additionalDuration = DEFAULT_ADDITIONAL_DURATION,
        BordersType bordersType = DEFAULT_BORDERS_TYPE
    )
    {
        // Account for border size in max width calculation
        if (Console.WindowWidth - 5 >= 0)
        {
            _text = text[..Math.Min(text.Length, Console.WindowWidth - 5)];
        }
        else
        {
            _text = text[..Math.Min(text.Length, 0)];
        }

        // Set the bar width, ensuring it's at least as wide as the text
        _barWidth = barWidth > 0 ? Math.Max(barWidth, _text.Length) : 0;

        _placement = placement;
        _processDuration = processDuration;
        _additionalDuration = additionalDuration;
        _borders = new Borders(bordersType);
    }
    #endregion

    #region Update Methods
    /// <summary>
    /// Updates the text of the loading bar.
    /// </summary>
    /// <param name="text">The new text of the loading bar.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateText(string text)
    {
        if (text.Length == 0)
        {
            throw new ArgumentException("The text cannot be empty.", nameof(text));
        }
        _text = text;
    }

    /// <summary>
    /// Updates the placement of the loading bar.
    /// </summary>
    /// <param name="placement">The new placement of the loading bar.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdatePlacement(Placement placement)
    {
        _placement = placement;
    }

    /// <summary>
    /// Updates the duration of the loading bar.
    /// </summary>
    /// <param name="processDuration">The new duration of the loading bar.</param>
    /// <exception cref="ArgumentOutOfRangeException">Throw when the process duration is negative.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateProcessDuration(int processDuration)
    {
        if (processDuration < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(processDuration),
                "The process duration must be greater than or equal to 0."
            );
        }
        _processDuration = processDuration;
    }

    /// <summary>
    /// Updates the additional duration of the loading bar.
    /// </summary>
    /// <param name="additionalDuration">The new additional duration of the loading bar.</param>
    /// <exception cref="ArgumentOutOfRangeException">The additional duration of the loading bar cannot be negative.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateAdditionalDuration(int additionalDuration)
    {
        if (additionalDuration < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(additionalDuration),
                "The additional duration must be greater than or equal to 0."
            );
        }
        _additionalDuration = additionalDuration;
    }

    /// <summary>
    /// Updates the borders type of the loading bar.
    /// </summary>
    /// <param name="bordersType">The new border type of the loading bar.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateBordersType(BordersType bordersType)
    {
        _borders.UpdateBordersType(bordersType);
    }

    /// <summary>
    /// Updates the width of the loading bar.
    /// </summary>
    /// <param name="barWidth">The new width of the loading bar. If 0, text length is used.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateBarWidth(int barWidth)
    {
        if (barWidth < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(barWidth),
                "The bar width must be greater than or equal to 0."
            );
        }
        _barWidth = barWidth;
    }
    #endregion

    #region Rendering
    /// <summary>
    /// Defines the actions to perform when the element is called to be rendered on the console.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        // Determine content width (text or explicit width, whichever is greater)
        int contentWidth = _barWidth > 0 ? _barWidth : _text.Length;

        // Calculate consistent widths
        int outerWidth = contentWidth + 4; // +4 for consistent outer border (includes padding)
        int innerWidth = contentWidth; // Inner border width matches content width

        // Rest of method remains the same, just using contentWidth instead of _text.Length

        // Get current cursor position to restore later
        int originalLeft = Console.CursorLeft;
        int originalTop = Console.CursorTop;

        // OUTER BORDER - TOP
        string topBorder =
            _borders.TopLeft + new string(_borders.Horizontal, outerWidth) + _borders.TopRight;
        Core.WritePositionedString(topBorder, _placement, false, Line, false);

        // OUTER BORDER - TEXT LINE
        string textLine =
            _borders.Vertical + " " + _text.PadRight(contentWidth + 2) + " " + _borders.Vertical;
        Core.WritePositionedString(textLine, _placement, false, Line + 1, false);

        // INNER BORDER - TOP
        string innerTopBorder =
            _borders.Vertical
            + " "
            + _borders.TopLeft
            + new string(_borders.Horizontal, innerWidth)
            + _borders.TopRight
            + " "
            + _borders.Vertical;
        Core.WritePositionedString(innerTopBorder, _placement, false, Line + 2, false);

        // INNER BORDER - EMPTY BAR AREA
        string innerEmptyBar =
            _borders.Vertical
            + " "
            + _borders.Vertical
            + new string(' ', innerWidth)
            + _borders.Vertical
            + " "
            + _borders.Vertical;
        Core.WritePositionedString(innerEmptyBar, _placement, false, Line + 3, false);

        // INNER BORDER - BOTTOM
        string innerBottomBorder =
            _borders.Vertical
            + " "
            + _borders.BottomLeft
            + new string(_borders.Horizontal, innerWidth)
            + _borders.BottomRight
            + " "
            + _borders.Vertical;
        Core.WritePositionedString(innerBottomBorder, _placement, false, Line + 4, false);

        // OUTER BORDER - BOTTOM
        string bottomBorder =
            _borders.BottomLeft
            + new string(_borders.Horizontal, outerWidth)
            + _borders.BottomRight;
        Core.WritePositionedString(bottomBorder, _placement, false, Line + 5, false);

        // Position cursor for animation
        int barLineTop = Line + 3; // Position at the empty bar line
        int barLeft;

        // Calculate horizontal position based on placement
        switch (_placement)
        {
            case Placement.TopLeft:
                barLeft = 3; // Left outer border + space + inner border
                break;
            case Placement.TopRight:
                barLeft = Console.WindowWidth - outerWidth + 3;
                break;
            case Placement.TopCenter:
            case Placement.TopCenterFullWidth:
            case Placement.BottomCenterFullWidth:
            default:
                barLeft = (Console.WindowWidth - outerWidth) / 2 + 3;
                break;
        }

        // Animate the loading bar inside inner border (limiting to innerWidth)
        Console.SetCursorPosition(barLeft - 1, barLineTop);
        for (int i = 0; i < innerWidth; i++)
        {
            Console.Write(LOADING_BAR_CHAR);
            Thread.Sleep(_processDuration / innerWidth);
        }

        // Additional wait at the end
        Thread.Sleep(_additionalDuration);

        // Restore cursor position
        Console.SetCursorPosition(originalLeft, originalTop);
    }
    #endregion
}
