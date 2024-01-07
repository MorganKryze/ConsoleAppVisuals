/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// Defines the prompt element of the console window.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
/// </list>
/// </remarks>
public class Prompt : InteractiveElement<string>
{
    #region Fields
    private readonly string _question;
    private readonly string _defaultValue;
    private readonly Placement _placement;
    private readonly int _line;
    #endregion

    #region Properties
    /// <summary>
    /// The placement of the prompt element.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// The line of the prompt element in the console.
    /// </summary>
    /// <remarks>We add 2 because so the prompt element does not overlap with the title.</remarks>
    public override int Line => _line;

    /// <summary>
    /// The height of the prompt element.
    /// </summary>
    public override int Height => 3;

    /// <summary>
    /// The width of the prompt element.
    /// </summary>
    public override int Width => _question.Length;
    #endregion

    #region Constructor
    /// <summary>
    /// The natural constructor of the prompt element.
    /// </summary>
    /// <param name="question">The text on the left of the prompt element.</param>
    /// <param name="defaultValue">The text in the center of the prompt element.</param>
    /// <param name="placement">The placement of the prompt element.</param>
    /// <param name="line">The line of the prompt element in the console.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public Prompt(
        string question,
        string? defaultValue = null,
        Placement placement = Placement.TopCenter,
        int? line = null
    )
    {
        _question = question;
        _defaultValue = defaultValue ?? string.Empty;
        _placement = placement;
        _line = Window.CheckLine(line) ?? Window.GetLineAvailable(_placement);
    }
    #endregion

    #region Methods
    /// <summary>
    /// This method is used to render the prompt element on the console.
    /// </summary>
    protected override void RenderElementActions()
    {
        Core.WriteContinuousString(
            _question,
            _line,
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
            Core.WritePositionedString(GetRenderSpace()[0], TextAlignment.Center, false, _line + 2);
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
                key.Key == ConsoleKey.Enter ? Output.Select : Output.Exit,
                field.ToString()
            )
        );
    }
    #endregion
}
