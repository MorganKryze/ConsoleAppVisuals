/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals.Elements;

/// <summary>
/// Defines the prompt element of the console window.
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
    #endregion

    #region Properties
    /// <summary>
    /// The placement of the prompt element.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// The height of the prompt element.
    /// </summary>
    public override int Height => 3;

    /// <summary>
    /// The width of the prompt element.
    /// </summary>
    /// <remarks>We add a margin of 2 to be sur to take in account odd question lengths.</remarks>
    public override int Width => _question.Length + 2;

    /// <summary>
    /// The question of the prompt element.
    /// </summary>
    public string Question => _question;

    /// <summary>
    /// The default value of the response.
    /// </summary>
    public string DefaultValue => _defaultValue;
    #endregion

    #region Constructor
    /// <summary>
    /// The natural constructor of the prompt element.
    /// </summary>
    /// <param name="question">The text on the left of the prompt element.</param>
    /// <param name="defaultValue">The text in the center of the prompt element.</param>
    /// <param name="placement">The placement of the prompt element.</param>
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
        Placement placement = Placement.TopCenter
    )
    {
        _question = question;
        _defaultValue = defaultValue ?? string.Empty;
        _placement = placement;
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
            -1,
            _placement.ToTextAlignment()
        );
        var field = new StringBuilder(_defaultValue);
        ConsoleKeyInfo key;
        do
        {
            Console.CursorVisible = false;
            Core.WritePositionedString(GetRenderSpace()[0], TextAlignment.Center, false, Line + 2);
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write("{0," + (Console.WindowWidth / 2 - _question.Length / 2 + 2) + "}", "> ");
            Console.Write($"{field}");
            Console.CursorVisible = true;
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Backspace && field.Length > 0)
                field.Remove(field.Length - 1, 1);
            else if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape)
                field.Append(key.KeyChar);
        } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
        Console.CursorVisible = false;
        SendResponse(
            this,
            new InteractionEventArgs<string>(
                key.Key == ConsoleKey.Enter ? Output.Selected : Output.Escaped,
                field.ToString()
            )
        );
    }
    #endregion
}
