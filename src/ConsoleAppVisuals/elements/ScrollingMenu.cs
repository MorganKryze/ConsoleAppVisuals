/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// Defines the loading bar of the console window.
/// </summary>
public class ScrollingMenu : InteractiveElement<int>
{
    private readonly string _question;
    private readonly string[] _choices;
    private int _defaultIndex;
    private readonly Placement _placement;
    private readonly int _line;

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
        Math.Max(_question.Length, _choices.Max((string s) => s.Length) + 4);

    /// <summary>
    /// The constructor of the ScrollingMenu class.
    /// </summary>
    /// <param name="question">The question to ask the user.</param>
    /// <param name="defaultIndex">The index of the default choice(initially 0).</param>
    /// <param name="placement">The placement of the menu on the console.</param>
    /// <param name="line">The line where the menu will be displayed.</param>
    /// <param name="choices">The different choices of the menu.</param>
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
        _line = line ?? Window.GetLineAvailable(_placement);
        _choices = choices;
    }

    /// <summary>
    /// This method is used to draw the menu on the console.
    /// </summary>
    protected override void RenderActions()
    {
        EndOfInteractionEvent += SetInteractionResponse;
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
                    TriggerEvent(this, new InteractionEventArgs<int>(Output.Select, _defaultIndex));
                    ExitFunction();
                    return;
                case ConsoleKey.Escape:
                    TriggerEvent(this, new InteractionEventArgs<int>(Output.Exit, _defaultIndex));
                    ExitFunction();
                    return;
                case ConsoleKey.Backspace:
                    TriggerEvent(this, new InteractionEventArgs<int>(Output.Delete, _defaultIndex));
                    ExitFunction();
                    return;
            }
        }
        void ExitFunction()
        {
            Core.ClearMultipleLines(Line, _choices.Length + 2);
            EndOfInteractionEvent -= SetInteractionResponse;
        }

        static void EqualizeChoicesLength(string[] choices)
        {
            int totalWidth = (choices.Length != 0) ? choices.Max((string s) => s.Length) : 0;
            for (int i = 0; i < choices.Length; i++)
            {
                choices[i] = choices[i].PadRight(totalWidth);
            }
        }
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
                Core.WritePositionedString(array[i], placement, i == defaultIndex, lineChoice + i);
                if (delay)
                    Thread.Sleep(30);
            }
        }
    }
}
