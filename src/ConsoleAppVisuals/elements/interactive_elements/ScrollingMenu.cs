/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.InteractiveElements;

/// <summary>
/// The <see cref="ScrollingMenu"/> is an interactive element that displays a question with multiple scrollable choices.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class ScrollingMenu : InteractiveElement<int>
{
    #region Constants
    private const char DEFAULT_CURSOR = '>';
    private const char DEFAULT_UPDATED_CURSOR = '▶';
    private const int QUESTION_AND_MARGIN_HEIGHT = 2;
    private const int SELECTION_MARGIN_WIDTH = 5;
    private const int DEFAULT_INDEX = 0;
    private const int DEFAULT_PRINT_DURATION = 1500;
    private const int DEFAULT_PRINT_ADDITIONAL_DURATION = 50;
    private const int DEFAULT_PRINT_DELAY = 30;
    private const Placement DEFAULT_PLACEMENT = Placement.TopCenter;
    private const TextAlignment DEFAULT_TEXT_ALIGNMENT = TextAlignment.Center;
    #endregion

    #region Fields
    private string _question;
    private string[] _choices;
    private int _defaultIndex;
    private Placement _placement;
    private char _selector = DEFAULT_CURSOR;
    #endregion

    #region Default Properties
    /// <summary>
    /// Gets the placement of the menu on the console.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// Gets the height of the menu.
    /// </summary>
    public override int Height => _choices.Length + QUESTION_AND_MARGIN_HEIGHT;

    /// <summary>
    /// Gets the width of the menu.
    /// </summary>
    public override int Width =>
        Math.Max(
            _question.Length + 1,
            _choices.Max((string s) => s.Length) + SELECTION_MARGIN_WIDTH
        );
    #endregion

    #region Properties
    /// <summary>
    /// Gets the question to ask the user.
    /// </summary>
    public string Question => _question;

    /// <summary>
    /// Gets the different choices of the menu.
    /// </summary>
    public string[] Choices => _choices;

    /// <summary>
    /// Gets the index of the default choice.
    /// </summary>
    public int DefaultIndex => _defaultIndex;

    /// <summary>
    /// Gets the selector char of the menu.
    /// </summary>
    public char Selector => _selector;

    #endregion

    #region Constructor
    /// <summary>
    /// The <see cref="ScrollingMenu"/> is an interactive element that displays a question with multiple scrollable choices.
    /// </summary>
    /// <param name="question">The question to ask the user.</param>
    /// <param name="defaultIndex">The index of the default choice(initially 0).</param>
    /// <param name="placement">The placement of the menu on the console.</param>
    /// <param name="choices">The different choices of the menu.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public ScrollingMenu(
        string question,
        int defaultIndex = DEFAULT_INDEX,
        Placement placement = DEFAULT_PLACEMENT,
        params string[] choices
    )
    {
        _question = question;
        _defaultIndex = defaultIndex;
        _placement = placement;
        _choices = choices;
    }
    #endregion

    #region Update Methods
    /// <summary>
    /// Updates the question of the menu.
    /// </summary>
    /// <param name="question">The new question of the menu.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateQuestion(string question)
    {
        _question = question;
    }

    /// <summary>
    /// Updates the choices of the menu.
    /// </summary>
    /// <param name="choices">The new choices of the menu.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateChoices(params string[] choices)
    {
        _choices = choices;
    }

    /// <summary>
    /// Updates the default index of the menu.
    /// </summary>
    /// <param name="defaultIndex">The new default index of the menu.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateDefaultIndex(int defaultIndex)
    {
        _defaultIndex = defaultIndex;
    }

    /// <summary>
    /// Updates the placement of the menu.
    /// </summary>
    /// <param name="placement">The new placement of the menu.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdatePlacement(Placement placement)
    {
        _placement = placement;
    }

    /// <summary>
    /// Updates the selector of the menu.
    /// </summary>
    /// <param name="selector">The new selector of the menu.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateSelector(char selector = DEFAULT_UPDATED_CURSOR)
    {
        _selector = selector;
    }
    #endregion

    #region Rendering
    /// <summary>
    /// Defines the actions to perform when the element is called to be rendered on the console.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        EqualizeChoicesLength(_choices);
        Core.WriteContinuousString(
            _question,
            Line,
            false,
            DEFAULT_PRINT_DURATION,
            DEFAULT_PRINT_ADDITIONAL_DURATION,
            Width,
            DEFAULT_TEXT_ALIGNMENT,
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
                    Thread.Sleep(DEFAULT_PRINT_DELAY);
            }
        }
    }
    #endregion
}
