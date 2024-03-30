/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.InteractiveElements;

/// <summary>
/// The <see cref="Dialog"/> is an interactive element that displays a dialog bow with one or two choices.
/// See <see cref="DialogOption"/> enum for the possible outputs of a dialog.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class Dialog : InteractiveElement<DialogOption>
{
    #region Constants
    const int EMBED_MARGIN = 2;

    /// <summary>
    /// The width ratio between the two options of the Dialog.
    /// It ensures that the options are not too close to each other.
    /// </summary>
    const double WIDTH_RATIO = 1.2;
    #endregion

    #region Fields
    private List<string> _lines;
    private string? _leftOption;
    private string? _rightOption;
    private TextAlignment _align;
    private Placement _placement;
    private readonly Borders _borders;
    private List<string>? _textToDisplay;
    #endregion

    #region Default Properties
    /// <summary>
    /// Gets the position of the Dialog.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// Gets the alignment of the Dialog.
    /// </summary>
    public override TextAlignment TextAlignment => _align;

    /// <summary>
    /// Gets the height of the Dialog.
    /// </summary>
    public override int Height => _textToDisplay!.Count;

    /// <summary>
    /// Gets the width of the Dialog.
    /// </summary>
    public override int Width => _textToDisplay!.Max(s => s.Length);
    #endregion

    #region Properties
    /// <summary>
    /// Gets the rows of the Dialog.
    /// </summary>
    public List<string> Lines => _lines;

    /// <summary>
    /// Gets the text of the left option.
    /// </summary>
    public string? LeftOption => _leftOption;

    /// <summary>
    /// Gets the text of the right option.
    /// </summary>
    public string? RightOption => _rightOption;

    /// <summary>
    /// Gets the borders of the Dialog.
    /// </summary>
    public Borders Borders => _borders;

    /// <summary>
    /// Gets the border type of the selector.
    /// </summary>
    public BordersType BordersType => _borders.Type;

    /// <summary>
    /// Gets the text to display.
    /// </summary>
    public List<string>? TextToDisplay => _textToDisplay;

    private int MaxLineLength =>
        Math.Max(
            _lines.Max(s => s.Length),
            (int)((_rightOption?.Length ?? 0) + (_leftOption?.Length ?? 0) * WIDTH_RATIO)
        );
    #endregion

    #region Constructor
    /// <summary>
    /// The <see cref="Dialog"/> is an interactive element that displays a dialog bow with one or two choices.
    /// See <see cref="DialogOption"/> enum for the possible outputs of a dialog.
    /// </summary>
    /// <param name="lines">The text to display.</param>
    /// <param name="leftOption">The text of the left option. Null for no button.</param>
    /// <param name="rightOption">The text of the right option. Null for no button.</param>
    /// <param name="align">The alignment of the Dialog.</param>
    /// <param name="placement">The placement of the Dialog element.</param>
    /// <param name="bordersType">The type of border to display.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public Dialog(
        List<string> lines,
        string? leftOption = null,
        string? rightOption = null,
        TextAlignment align = TextAlignment.Left,
        Placement placement = Placement.TopCenter,
        BordersType bordersType = BordersType.SingleStraight
    )
    {
        _lines = lines;
        _leftOption = leftOption;
        _rightOption = rightOption;
        _align = align;
        _placement = placement;
        _borders = new Borders(bordersType);
        if (_lines.Count != 0)
        {
            Build();
        }
    }
    #endregion

    #region Update Methods
    /// <summary>
    /// Updates the text of the first option.
    /// </summary>
    /// <param name="text">The new text of the first option.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateRightOption(string? text)
    {
        _rightOption = text;
        Build();
    }

    /// <summary>
    /// Updates the text of the second option.
    /// </summary>
    /// <param name="text">The new text of the second option.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateLeftOption(string? text)
    {
        _leftOption = text;
        Build();
    }

    /// <summary>
    /// Updates the text of the Dialog.
    /// </summary>
    /// <param name="lines">The new text of the Dialog.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateLines(List<string> lines)
    {
        _lines.Clear();
        _lines = lines;
        Build();
    }

    /// <summary>
    /// Updates the placement of the Dialog.
    /// </summary>
    /// <param name="placement">The new placement of the Dialog.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdatePlacement(Placement placement)
    {
        _placement = placement;
    }

    /// <summary>
    /// Updates the alignment of the Dialog.
    /// </summary>
    /// <param name="align">The new alignment of the Dialog.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateTextAlignment(TextAlignment align)
    {
        _align = align;
        Build();
    }

    /// <summary>
    /// Updates the borders of the Dialog.
    /// </summary>
    /// <param name="bordersType">The new border type of the Dialog.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateBordersType(BordersType bordersType)
    {
        _borders.UpdateBordersType(bordersType);
        Build();
    }
    #endregion

    #region Manipulation Methods
    /// <summary>
    /// Adds a line to the Dialog.
    /// </summary>
    /// <param name="line">The line to add.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void AddLine(string line)
    {
        _lines.Add(line);
        Build();
    }

    /// <summary>
    /// Inserts a line to the Dialog.
    /// </summary>
    /// <param name="index">The index where to insert the line.</param>
    /// <param name="line">The line to insert.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void InsertLine(int index, string line)
    {
        if (index < 0 || index >= _lines.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "The index is out of range.");
        }
        _lines.Insert(index, line);
        Build();
    }

    /// <summary>
    /// Removes a line from the Dialog.
    /// </summary>
    /// <param name="line">The line to remove.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void RemoveLine(string line)
    {
        if (!_lines.Contains(line))
        {
            throw new ArgumentException("The line is not in the text.");
        }
        _lines.Remove(line);
        Build();
    }

    /// <summary>
    /// Removes a line from the Dialog.
    /// </summary>
    /// <param name="index">The index of the line to remove.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void RemoveLine(int index)
    {
        if (index < 0 || index >= _lines.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "The index is out of range.");
        }
        _lines.RemoveAt(index);
        Build();
    }
    #endregion

    #region Rendering
    [Visual]
    private void Build()
    {
        if (_lines.Count == 0)
        {
            throw new InvalidOperationException(
                "The lines are empty. You must provide at least one line to display in the Dialog"
            );
        }

        _textToDisplay = new List<string>();

        _textToDisplay.Add(
            Borders.TopLeft
                + new string(Borders.Horizontal, MaxLineLength + EMBED_MARGIN)
                + Borders.TopRight
        );

        foreach (var line in _lines)
        {
            var lineToDisplay = $"{Borders.Vertical} ";
            switch (_align)
            {
                case TextAlignment.Center:
                    int totalPadding = MaxLineLength - line.Length;
                    int padLeft = totalPadding / 2;
                    lineToDisplay += line.PadLeft(line.Length + padLeft).PadRight(MaxLineLength);
                    break;
                case TextAlignment.Left:
                    lineToDisplay += line.PadRight(MaxLineLength);
                    break;
                case TextAlignment.Right:
                    lineToDisplay += line.PadLeft(MaxLineLength);
                    break;
            }
            lineToDisplay += $" {Borders.Vertical}";
            _textToDisplay.Add(lineToDisplay);
        }

        if (_rightOption is not null || _leftOption is not null)
        {
            AddOptions();
        }

        _textToDisplay.Add(
            Borders.BottomLeft
                + new string(Borders.Horizontal, MaxLineLength + EMBED_MARGIN)
                + Borders.BottomRight
        );

        [Visual]
        void AddOptions()
        {
            _textToDisplay!.Add(
                $"{Borders.Vertical} " + new string(' ', MaxLineLength) + $" {Borders.Vertical}"
            );

            string optionLine =
                $"{Borders.Vertical} " + new string(' ', MaxLineLength) + $" {Borders.Vertical}";

            if (_leftOption is not null)
            {
                optionLine = optionLine.Remove(2, _leftOption.Length);
                optionLine = optionLine.Insert(2, _leftOption);
            }

            if (_rightOption is not null)
            {
                int insertPosition = optionLine.Length - _rightOption.Length - 2;
                optionLine = optionLine.Remove(insertPosition, _rightOption.Length);
                optionLine = optionLine.Insert(insertPosition, _rightOption);
            }

            _textToDisplay.Add(optionLine);
        }
    }

    /// <summary>
    /// Renders the Dialog.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        Build();

        DialogOption optionSelectedIndex = SetDefaultValue();

        bool loop = true;
        while (loop)
        {
            UpdateOptionSelected();
            Core.WriteMultiplePositionedLines(
                false,
                TextAlignment,
                Placement,
                false,
                Line,
                _textToDisplay!.ToArray()
            );

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Enter:
                    SendResponse(
                        this,
                        new InteractionEventArgs<DialogOption>(Status.Selected, optionSelectedIndex)
                    );
                    loop = false;
                    break;

                case ConsoleKey.Escape:
                    SendResponse(
                        this,
                        new InteractionEventArgs<DialogOption>(Status.Escaped, DialogOption.None)
                    );
                    loop = false;
                    break;

                case ConsoleKey.Q:
                case ConsoleKey.LeftArrow:
                    SwitchOptions();
                    break;

                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    SwitchOptions();
                    break;

                case ConsoleKey.Tab:
                    SwitchOptions();
                    break;
            }
        }

        [Visual]
        DialogOption SetDefaultValue()
        {
            if (_leftOption is null && _rightOption is null)
            {
                return DialogOption.None;
            }
            else if (_leftOption is not null && _rightOption is null)
            {
                return DialogOption.Left;
            }
            else if (_leftOption is null && _rightOption is not null)
            {
                return DialogOption.Right;
            }

            return DialogOption.Right;
        }

        [Visual]
        void SwitchOptions()
        {
            if (_leftOption is not null && _rightOption is not null)
            {
                optionSelectedIndex =
                    optionSelectedIndex == DialogOption.Left
                        ? DialogOption.Right
                        : DialogOption.Left;
            }
        }

        [Visual]
        void UpdateOptionSelected()
        {
            if (_leftOption is not null || _rightOption is not null)
            {
                string optionLine =
                    $"{Borders.Vertical} "
                    + new string(' ', MaxLineLength)
                    + $" {Borders.Vertical}";

                if (_rightOption is not null && optionSelectedIndex == DialogOption.Right)
                {
                    int insertPosition = optionLine.Length - 1 - _rightOption.Length - 1 - 2;
                    optionLine = optionLine.Remove(insertPosition, _rightOption.Length + 2);
                    optionLine = optionLine.Insert(
                        insertPosition,
                        Core.NEGATIVE_ANCHOR + " " + _rightOption + " " + Core.NEGATIVE_ANCHOR
                    );
                }
                else if (_rightOption is not null && optionSelectedIndex == DialogOption.Left)
                {
                    int insertPosition = optionLine.Length - 1 - _rightOption.Length - 1 - 2;
                    optionLine = optionLine.Remove(insertPosition, _rightOption.Length + 2);
                    optionLine = optionLine.Insert(insertPosition, " " + _rightOption + " ");
                }

                if (_leftOption is not null && optionSelectedIndex == DialogOption.Left)
                {
                    optionLine = optionLine.Remove(2, _leftOption.Length + 2);
                    optionLine = optionLine.Insert(
                        2,
                        Core.NEGATIVE_ANCHOR + " " + _leftOption + " " + Core.NEGATIVE_ANCHOR
                    );
                }
                else if (_leftOption is not null && optionSelectedIndex == DialogOption.Right)
                {
                    optionLine = optionLine.Remove(2, _leftOption.Length + 2);
                    optionLine = optionLine.Insert(2, " " + _leftOption + " ");
                }

                _textToDisplay![^2] = optionLine;
            }
        }
    }

    #endregion
}
