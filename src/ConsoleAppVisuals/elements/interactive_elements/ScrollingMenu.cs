/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.InteractiveElements;

/// <summary>
/// A <see cref="ScrollingMenu"/> is an interactive element that displays a question with multiple scrollable choices.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public class ScrollingMenu : InteractiveElement<int>
{
    #region Fields
    private string _question;
    private string[] _choices;
    private int _defaultIndex;
    private Placement _placement;
    private char _selector = DEFAULT_CURSOR;
    #endregion

    #region Constants
    /// <summary>
    /// The default cursor of the menu.
    /// </summary>
    /// <remarks>
    /// Can be updated with the <see cref="UpdateSelector(char)"/> method.
    /// </remarks>
    public const char DEFAULT_CURSOR = '>';
    #endregion

    #region Properties
    /// <summary>
    /// The placement of the menu on the console.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// The height of the menu.
    /// </summary>
    public override int Height => _choices.Length + 2;

    /// <summary>
    /// The width of the menu.
    /// </summary>
    public override int Width =>
        Math.Max(_question.Length + 1, _choices.Max((string s) => s.Length) + 5);

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

    /// <summary>
    /// The selector char of the menu.
    /// </summary>
    public char Selector => _selector;

    #endregion

    #region Constructor
    /// <summary>
    /// A <see cref="ScrollingMenu"/> is an interactive element that displays a question with multiple scrollable choices.
    /// </summary>
    /// <param name="question">The question to ask the user.</param>
    /// <param name="defaultIndex">The index of the default choice(initially 0).</param>
    /// <param name="placement">The placement of the menu on the console.</param>
    /// <param name="choices">The different choices of the menu.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public ScrollingMenu(
        string question,
        int defaultIndex = 0,
        Placement placement = Placement.TopCenter,
        params string[] choices
    )
    {
        _question = question;
        _defaultIndex = defaultIndex;
        _placement = placement;
        _choices = choices;
    }
    #endregion

    #region Methods
    /// <summary>
    /// This method is used to update the question of the menu.
    /// </summary>
    /// <param name="question">The new question of the menu.</param>
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
    /// This method is used to update the choices of the menu.
    /// </summary>
    /// <param name="choices">The new choices of the menu.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateChoices(params string[] choices)
    {
        _choices = choices;
    }

    /// <summary>
    /// This method is used to update the default index of the menu.
    /// </summary>
    /// <param name="defaultIndex">The new default index of the menu.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateDefaultIndex(int defaultIndex)
    {
        _defaultIndex = defaultIndex;
    }

    /// <summary>
    /// This method is used to update the placement of the menu.
    /// </summary>
    /// <param name="placement">The new placement of the menu.</param>
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
    /// This method is used to update the selector of the menu.
    /// </summary>
    /// <param name="selector">The new selector of the menu.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateSelector(char selector = '▶')
    {
        _selector = selector;
    }

    /// <summary>
    /// This method is used to draw the menu on the console.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        EqualizeChoicesLength(_choices);
        Core.WriteContinuousString(
            _question,
            Line,
            false,
            1500,
            50,
            Width,
            TextAlignment.Center,
            _placement
        );
        int lineChoice = Line + 2;
        bool delay = true;
        bool loop = true;
        while (loop)
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
                    SendResponse(
                        this,
                        new InteractionEventArgs<int>(Status.Selected, _defaultIndex)
                    );
                    loop = false;
                    break;
                case ConsoleKey.Escape:
                    SendResponse(
                        this,
                        new InteractionEventArgs<int>(Status.Escaped, _defaultIndex)
                    );
                    loop = false;
                    break;
                case ConsoleKey.Backspace:
                    SendResponse(
                        this,
                        new InteractionEventArgs<int>(Status.Deleted, _defaultIndex)
                    );
                    loop = false;
                    break;
            }
        }

        [Visual]
        void EqualizeChoicesLength(string[] choices)
        {
            int totalWidth = (choices.Length != 0) ? choices.Max((string s) => s.Length) : 0;
            for (int i = 0; i < choices.Length; i++)
            {
                choices[i] = choices[i].PadRight(totalWidth);
            }
        }

        [Visual]
        void DisplayChoices(
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
                    (i == defaultIndex) ? $" {Selector} {choices[i]}  " : $"   {choices[i]}  ";
                Core.WritePositionedString(array[i], placement, i == defaultIndex, lineChoice + i);
                if (delay)
                    Thread.Sleep(30);
            }
        }
    }
    #endregion
}
