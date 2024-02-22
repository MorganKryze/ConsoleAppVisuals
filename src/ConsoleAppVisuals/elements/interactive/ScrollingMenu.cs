/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// Defines the scrolling menu the console window.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
/// </list>
/// </remarks>
public class ScrollingMenu : InteractiveElement<int>
{
    #region Fields
    private readonly string _question;
    private readonly string[] _choices;
    private int _defaultIndex;
    private readonly Placement _placement;
    private readonly int _line;
    #endregion

    #region Properties
    /// <summary>
    /// The placement of the menu on the console.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// The line where the menu will be displayed.
    /// </summary>
    public override int Line => _line;

    /// <summary>
    /// The height of the menu.
    /// </summary>
    public override int Height => _choices.Length + 2;

    /// <summary>
    /// The width of the menu.
    /// </summary>
    public override int Width =>
        Math.Max(_question.Length + 1, _choices.Max((string s) => s.Length) + 4);
    #endregion

    #region Getters

    /// <summary>
    /// The question to ask the user.
    /// </summary>
    public string Question => _question;

    /// <summary>
    /// The different choices of the menu.
    /// </summary>
    public string[] Choices => _choices;

    /// <summary>
    /// The index of the default choice(initially 0).
    /// </summary>
    public int DefaultIndex => _defaultIndex;

    #endregion

    #region Constructor
    /// <summary>
    /// The constructor of the ScrollingMenu class.
    /// </summary>
    /// <param name="question">The question to ask the user.</param>
    /// <param name="defaultIndex">The index of the default choice(initially 0).</param>
    /// <param name="placement">The placement of the menu on the console.</param>
    /// <param name="line">The line where the menu will be displayed.</param>
    /// <param name="choices">The different choices of the menu.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public ScrollingMenu(
        string question,
        int defaultIndex = 0,
        Placement placement = Placement.TopCenter,
        int? line = null,
        params string[] choices
    )
    {
        _question = question;
        _defaultIndex = defaultIndex;
        _placement = placement;
        _line = Window.CheckLine(line) ?? Window.GetLineAvailable(_placement);
        _choices = choices;
    }
    #endregion

    #region Methods
    /// <summary>
    /// This method is used to draw the menu on the console.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        EqualizeChoicesLength(_choices);
        Core.WriteContinuousString(_question, Line, false, 1500, 50);
        int lineChoice = Line + 2;
        bool delay = true;
        while (true)
        {
            DisplayChoices(_defaultIndex, _placement, _choices, lineChoice, delay);
            delay = false;

            switch (Console.ReadKey(intercept: true).Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.Z:
                    _defaultIndex = (_defaultIndex == 0) ? _choices.Length - 1 : _defaultIndex - 1;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    _defaultIndex = (_defaultIndex == _choices.Length - 1) ? 0 : _defaultIndex + 1;
                    break;
                case ConsoleKey.Enter:
                    SendResponse(this, new InteractionEventArgs<int>(Output.Selected, _defaultIndex));
                    return;
                case ConsoleKey.Escape:
                    SendResponse(this, new InteractionEventArgs<int>(Output.Escaped, _defaultIndex));
                    return;
                case ConsoleKey.Backspace:
                    SendResponse(this, new InteractionEventArgs<int>(Output.Deleted, _defaultIndex));
                    return;
            }
        }
        [Visual]
        static void EqualizeChoicesLength(string[] choices)
        {
            int totalWidth = (choices.Length != 0) ? choices.Max((string s) => s.Length) : 0;
            for (int i = 0; i < choices.Length; i++)
            {
                choices[i] = choices[i].PadRight(totalWidth);
            }
        }
        [Visual]
        static void DisplayChoices(
            int defaultIndex,
            Placement placement,
            string[] choices,
            int lineChoice,
            bool delay = false
        )
        {
            string[] array = new string[choices.Length];
            for (int i = 0; i < choices.Length; i++)
            {
                array[i] =
                    (i == defaultIndex)
                        ? $" {Core.GetSelector.Item1} {choices[i]}  "
                        : $"   {choices[i]}  ";
                Core.WritePositionedString(
                    array[i],
                    placement.ToTextAlignment(),
                    i == defaultIndex,
                    lineChoice + i
                );
                if (delay)
                    Thread.Sleep(30);
            }
        }
    }
    #endregion
}
