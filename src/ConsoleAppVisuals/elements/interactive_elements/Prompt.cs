/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals.InteractiveElements;

/// <summary>
/// A <see cref="Prompt"/> is an interactive element that allows the user to input a string response.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public class Prompt : InteractiveElement<string>
{
    #region Fields
    private string _question;
    private string _defaultValue;
    private Placement _placement;
    private int _maxLength;
    private int _printDuration;
    private char _selector = DEFAULT_CURSOR;
    #endregion

    #region Constants
    private const int DEFAULT_PROMPT_MAX_LENGTH = 10;
    private const int DEFAULT_PRINT_DURATION = 1500;
    private const int PROMPT_HEIGHT = 3;
    private const int PROMPT_LEFT_MARGIN = 3;
    private const char DEFAULT_CURSOR = '>';
    #endregion

    #region Properties
    /// <summary>
    /// The placement of the prompt element.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// The height of the prompt element.
    /// </summary>
    public override int Height => PROMPT_HEIGHT;

    /// <summary>
    /// The width of the prompt element.
    /// </summary>
    public override int Width => Math.Max(_question.Length + 1, PROMPT_LEFT_MARGIN + _maxLength);

    /// <summary>
    /// The question of the prompt element.
    /// </summary>
    public string Question => _question;

    /// <summary>
    /// The default value of the response.
    /// </summary>
    public string DefaultValue => _defaultValue;

    /// <summary>
    /// The maximum length of the response.
    /// </summary>
    public int MaxLength => _maxLength;

    /// <summary>
    /// The duration of the print animation of the question.
    /// </summary>
    public int PrintDuration => _printDuration;

    /// <summary>
    /// The selector of the prompt element.
    /// </summary>
    public char Selector => _selector;
    #endregion

    #region Constructor
    /// <summary>
    /// A <see cref="Prompt"/> is an interactive element that allows the user to input a string response.
    /// </summary>
    /// <param name="question">The text on the left of the prompt element.</param>
    /// <param name="defaultValue">The text in the center of the prompt element.</param>
    /// <param name="placement">The placement of the prompt element.</param>
    /// <param name="maxLength">The maximum length of the response.</param>
    /// <param name="printDuration">The duration of the print animation.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public Prompt(
        string question,
        string? defaultValue = null,
        Placement placement = Placement.TopCenter,
        int maxLength = DEFAULT_PROMPT_MAX_LENGTH,
        int printDuration = DEFAULT_PRINT_DURATION
    )
    {
        _question = question;
        _defaultValue = defaultValue ?? string.Empty;
        _placement = placement;
        _maxLength = maxLength;
        _printDuration = printDuration;
    }
    #endregion

    #region Methods
    /// <summary>
    /// This method is used to update the question of the prompt element.
    /// </summary>
    /// <param name="question">The new question of the prompt element.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateQuestion(string question)
    {
        _question = question;
    }

    /// <summary>
    /// This method is used to update the default value of the prompt element.
    /// </summary>
    /// <param name="defaultValue">The new default value of the prompt element.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateDefaultValue(string defaultValue)
    {
        _defaultValue = defaultValue;
    }

    /// <summary>
    /// This method is used to update the placement of the prompt element.
    /// </summary>
    /// <param name="placement">The new placement of the prompt element.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdatePlacement(Placement placement)
    {
        _placement = placement;
    }

    /// <summary>
    /// This method is used to update the maximum length of the response.
    /// </summary>
    /// <param name="maxLength">The new maximum length of the response.</param>
    /// <exception cref="ArgumentOutOfRangeException">The maximum length of the response must be greater than 0 and less than the width of the console window.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateMaxLength(int maxLength)
    {
        if (maxLength < 1)
            throw new ArgumentOutOfRangeException(
                nameof(maxLength),
                "The maximum length of the response must be greater than 0 and less than the width of the console window."
            );
        _maxLength = maxLength;
    }

    /// <summary>
    /// This method is used to update the duration of the print animation.
    /// </summary>
    /// <param name="printDuration">The new duration of the print animation.</param>
    /// <exception cref="ArgumentOutOfRangeException">The print duration must be greater than or equal to 0.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdatePrintDuration(int printDuration)
    {
        if (printDuration < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(printDuration),
                "The print duration must be greater than or equal to 0."
            );
        }
        _printDuration = printDuration;
    }

    /// <summary>
    /// This method is used to update the selector of the prompt element.
    /// </summary>
    /// <param name="selector">The new selector of the prompt element.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateSelector(char selector)
    {
        _selector = selector;
    }

    /// <summary>
    /// This method is used to render the prompt element on the console.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        Core.WriteContinuousString(
            _question,
            Line,
            false,
            1500,
            50,
            Width,
            TextAlignment.Left,
            _placement
        );

        var field = new StringBuilder(_defaultValue);
        int fieldLine = Line + 2;
        int offset = _placement switch
        {
            Placement.TopCenter => Console.WindowWidth / 2 - Width / 2,
            Placement.TopCenterFullWidth => Console.WindowWidth / 2 - Width / 2,
            Placement.BottomCenterFullWidth => Console.WindowWidth / 2 - Width / 2,
            Placement.TopLeft => 0,
            Placement.TopRight => Console.WindowWidth - Width,
            _ => 0
        };

        ConsoleKeyInfo key;
        do
        {
            Console.CursorVisible = false;

            Core.WritePositionedString(GetRenderSpace()[0], _placement, false, fieldLine);

            Console.SetCursorPosition(offset, Console.CursorTop);
            Console.Write($"{_selector} {field}");

            Console.CursorVisible = true;
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Backspace && field.Length > 0)
            {
                field.Remove(field.Length - 1, 1);
            }
            else if (
                key.Key != ConsoleKey.Enter
                && key.Key != ConsoleKey.Escape
                && key.Key != ConsoleKey.Backspace
                && field.Length < MaxLength
            )
            {
                field.Append(key.KeyChar);
            }
        } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
        Console.CursorVisible = false;

        SendResponse(
            this,
            new InteractionEventArgs<string>(
                key.Key == ConsoleKey.Enter ? Status.Selected : Status.Escaped,
                field.ToString()
            )
        );
    }
    #endregion
}
