/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.InteractiveElements;

/// <summary>
/// The <see cref="Prompt"/> is an interactive element that allows the user to input a string response.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class Prompt : InteractiveElement<string>
{
    #region Constants
    private const int PROMPT_HEIGHT = 5;
    private const int MAX_LENGTH_LEFT_MARGIN = 2;
    private const int LEFT_AND_RIGHT_MARGIN = 2;
    private const char DEFAULT_CURSOR = '>';
    private const char DEFAULT_UPDATED_CURSOR = '▶';
    private const char SECRET_CHAR = '*';
    private const char FILL_CHAR = '-';
    private const int DEFAULT_PROMPT_MAX_LENGTH = 12;
    private const Placement DEFAULT_PLACEMENT = Placement.TopCenter;
    private const PromptInputStyle DEFAULT_STYLE = PromptInputStyle.Default;
    private const BordersType DEFAULT_BORDER_TYPE = BordersType.SingleStraight;
    #endregion

    #region Fields
    private string _question;
    private string _defaultValue;
    private Placement _placement;
    private int _maxInputLength;
    private PromptInputStyle _style;
    private readonly Borders _borders;
    private char _selector = DEFAULT_CURSOR;
    private string[]? _displayArray;
    #endregion

    #region Default Properties
    /// <summary>
    /// Gets the placement of the prompt element.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// Gets the height of the prompt element.
    /// </summary>
    public override int Height => PROMPT_HEIGHT;

    /// <summary>
    /// Gets the width of the prompt element.
    /// </summary>
    public override int Width => LEFT_AND_RIGHT_MARGIN + MaxLength + LEFT_AND_RIGHT_MARGIN;
    #endregion

    #region Properties
    private int MaxLength => Math.Max(_question.Length, _maxInputLength + MAX_LENGTH_LEFT_MARGIN);

    /// <summary>
    /// Gets the question of the prompt element.
    /// </summary>
    public string Question => _question;

    /// <summary>
    /// Gets the default value of the response.
    /// </summary>
    public string DefaultValue => _defaultValue;

    /// <summary>
    /// Gets the maximum length of the response.
    /// </summary>
    public int MaxInputLength => _maxInputLength;

    /// <summary>
    /// Gets the style of the prompt input.
    /// </summary>
    public PromptInputStyle Style => _style;

    /// <summary>
    /// Gets the borders of the prompt element.
    /// </summary>
    public Borders Borders => _borders;

    /// <summary>
    /// Gets the border type of the selector.
    /// </summary>
    public BordersType BordersType => _borders.Type;

    /// <summary>
    /// Gets the selector of the prompt element.
    /// </summary>
    public char Selector => _selector;
    #endregion

    #region Constructor
    /// <summary>
    /// The <see cref="Prompt"/> is an interactive element that allows the user to input a string response.
    /// </summary>
    /// <param name="question">The text on the left of the prompt element.</param>
    /// <param name="defaultValue">The text in the center of the prompt element.</param>
    /// <param name="placement">The placement of the prompt element.</param>
    /// <param name="maxInputLength">The maximum length of the response.</param>
    /// <param name="style">The style of the prompt input.</param>
    /// <param name="borderType">The type of border to use for the element.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public Prompt(
        string question,
        string? defaultValue = null,
        Placement placement = DEFAULT_PLACEMENT,
        int maxInputLength = DEFAULT_PROMPT_MAX_LENGTH,
        PromptInputStyle style = DEFAULT_STYLE,
        BordersType borderType = DEFAULT_BORDER_TYPE
    )
    {
        _question = question;
        _maxInputLength = Prompt.CheckMaxLength(maxInputLength);
        _defaultValue = defaultValue is null ? string.Empty : CheckDefaultValue(defaultValue);
        _placement = placement;
        _style = style;
        _borders = new Borders(borderType);
    }

    private static int CheckMaxLength(int maxLength)
    {
        int windowWidth =
            Console.WindowWidth == 0 ? DEFAULT_PROMPT_MAX_LENGTH + 1 : Console.WindowWidth;
        if (maxLength < 1 || maxLength >= windowWidth)
        {
            throw new ArgumentOutOfRangeException(
                nameof(maxLength),
                $"The maximum length of the response must be greater than 0 and less than the width of the console window.(1 <= {maxLength} < {windowWidth})"
            );
        }
        return maxLength;
    }

    private string CheckDefaultValue(string defaultValue)
    {
        if (defaultValue.Length > _maxInputLength)
        {
            throw new ArgumentOutOfRangeException(
                nameof(defaultValue),
                $"The default value must be less than or equal to the maximum input length of the response ({defaultValue.Length} > {MaxInputLength})."
            );
        }
        return defaultValue;
    }
    #endregion

    #region Update Methods
    /// <summary>
    /// Updates the question of the prompt element.
    /// </summary>
    /// <param name="question">The new question of the prompt element.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateQuestion(string question)
    {
        _question = question;
    }

    /// <summary>
    /// Updates the default value of the prompt element.
    /// </summary>
    /// <param name="defaultValue">The new default value of the prompt element.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateDefaultValue(string? defaultValue)
    {
        _defaultValue = defaultValue is null ? string.Empty : CheckDefaultValue(defaultValue);
    }

    /// <summary>
    /// Updates the placement of the prompt element.
    /// </summary>
    /// <param name="placement">The new placement of the prompt element.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdatePlacement(Placement placement)
    {
        _placement = placement;
    }

    /// <summary>
    /// Updates the maximum length of the response.
    /// </summary>
    /// <param name="maxLength">The new maximum length of the response.</param>
    /// <exception cref="ArgumentOutOfRangeException">The maximum length of the response must be greater than 0 and less than the width of the console window.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateMaxLength(int maxLength)
    {
        _maxInputLength = Prompt.CheckMaxLength(maxLength);
    }

    /// <summary>
    /// Updates the selector of the prompt element.
    /// </summary>
    /// <param name="selector">The new selector of the prompt element.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateSelector(char selector = DEFAULT_UPDATED_CURSOR)
    {
        _selector = selector;
    }

    /// <summary>
    /// Updates the style of the prompt input.
    /// </summary>
    /// <param name="style">The new style of the prompt input.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateStyle(PromptInputStyle style)
    {
        _style = style;
    }

    /// <summary>
    /// Updates the border type of the prompt element.
    /// </summary>
    /// <param name="bordersType">The new border type of the prompt element.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateBordersType(BordersType bordersType)
    {
        _borders.UpdateBordersType(bordersType);
    }
    #endregion

    #region Rendering
    [Visual]
    private void Build()
    {
        string finalQuestion = _question.ResizeString(MaxLength, TextAlignment.Left);
        string finalField = ($"{_selector} " + _defaultValue).ResizeString(
            MaxLength,
            TextAlignment.Left
        );

        _displayArray = new string[PROMPT_HEIGHT];
        _displayArray[0] =
            Borders.TopLeft.ToString()
            + new string(Borders.Horizontal, Width - 2)
            + Borders.TopRight.ToString();
        _displayArray[1] = $"{Borders.Vertical} " + finalQuestion + $" {Borders.Vertical}";
        _displayArray[2] =
            $"{Borders.Vertical} " + new string(' ', MaxLength) + $" {Borders.Vertical}";
        if (_style == PromptInputStyle.Fill)
        {
            _displayArray[3] =
                $"{Borders.Vertical} {_selector} "
                + new string(FILL_CHAR, MaxInputLength)
                + new string(' ', MaxLength - MaxInputLength - 2)
                + $" {Borders.Vertical}";
        }
        else
        {
            _displayArray[3] =
                $"{Borders.Vertical} "
                + new string(' ', finalField.Length)
                + $" {Borders.Vertical}";
        }
        _displayArray[4] =
            Borders.BottomLeft.ToString()
            + new string(Borders.Horizontal, Width - 2)
            + Borders.BottomRight.ToString();
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
            TextAlignment.Center,
            Placement,
            false,
            Line,
            _displayArray!
        );
        var field = new StringBuilder(_defaultValue);
        int fieldLine = Line + 3;
        int offset = _placement switch
        {
            Placement.TopCenter => Console.WindowWidth / 2 - Width / 2 + 2,
            Placement.TopCenterFullWidth => Console.WindowWidth / 2 - Width / 2 + 2,
            Placement.BottomCenterFullWidth => Console.WindowWidth / 2 - Width / 2 + 2,
            Placement.TopLeft => 2,
            Placement.TopRight => Console.WindowWidth - Width + 2,
            _ => 0
        };

        ConsoleKeyInfo key;
        do
        {
            Console.CursorVisible = false;

            Core.WritePositionedString(_displayArray![2], Placement, false, fieldLine);

            Console.SetCursorPosition(offset, Console.CursorTop);
            if (_style == PromptInputStyle.Secret)
            {
                Console.Write($"{_selector} {new string(SECRET_CHAR, field.Length)}");
            }
            else
            {
                Console.Write($"{_selector} {field}");
            }

            Console.CursorVisible = _style == PromptInputStyle.Default;
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Backspace && field.Length > 0)
            {
                field.Remove(field.Length - 1, 1);
            }
            else if (
                key.Key != ConsoleKey.Enter
                && key.Key != ConsoleKey.Escape
                && key.Key != ConsoleKey.Backspace
                && field.Length < MaxInputLength
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
