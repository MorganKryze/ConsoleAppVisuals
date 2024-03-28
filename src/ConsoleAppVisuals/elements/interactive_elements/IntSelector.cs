/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.InteractiveElements;

/// <summary>
/// The <see cref="IntSelector"/> is an interactive element that allows the user to select an integer value from a range of values.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class IntSelector : InteractiveElement<int>
{
    #region Constants
    private const char DEFAULT_SELECTOR_LEFT = '>';
    private const char DEFAULT_SELECTOR_RIGHT = '<';
    private const char DEFAULT_UPDATED_SELECTOR_LEFT = '▶';
    private const char DEFAULT_UPDATED_SELECTOR_RIGHT = '◀';
    private const int DEFAULT_HEIGHT = 7;
    private const Placement DEFAULT_PLACEMENT = Placement.TopCenter;
    private const BordersType DEFAULT_BORDERS_TYPE = BordersType.SingleStraight;
    private const TextAlignment DEFAULT_TEXT_ALIGNMENT = TextAlignment.Center;
    private const int DEFAULT_PRINT_DURATION = 1500;
    private const int DEFAULT_PRINT_ADDITIONAL_DURATION = 50;
    #endregion

    #region Fields
    private string _question;
    private int _minimumValue;
    private int _maximumValue;
    private int _startValue;
    private int _step;
    private Placement _placement;
    private readonly Borders _borders;
    private (char, char) _selector = (DEFAULT_SELECTOR_LEFT, DEFAULT_SELECTOR_RIGHT);
    #endregion

    #region Default Properties
    /// <summary>
    /// Gets the placement of the selector on the console.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// Gets the height of the selector.
    /// </summary>
    public override int Height => DEFAULT_HEIGHT;

    /// <summary>
    /// Gets the width of the selector.
    /// </summary>
    public override int Width =>
        Math.Max(
            _question.Length,
            $" {LeftSelector} {BuildNumber(_maximumValue)} {RightSelector} ".Length
        );
    #endregion

    #region Properties
    /// <summary>
    /// Gets the question to ask the user.
    /// </summary>
    public string Question => _question;

    /// <summary>
    /// Gets the minimum value of the selector.
    /// </summary>
    public int Min => _minimumValue;

    /// <summary>
    /// Gets the maximum value of the selector.
    /// </summary>
    public int Max => _maximumValue;

    /// <summary>
    /// Gets the start value of the selector.
    /// </summary>
    public int Start => _startValue;

    /// <summary>
    /// Gets the step of the selector.
    /// </summary>
    public int Step => _step;

    /// <summary>
    /// Gets the left selector of the selector.
    /// </summary>
    public char LeftSelector => _selector.Item1;

    /// <summary>
    /// Gets the right selector of the selector.
    /// </summary>
    public char RightSelector => _selector.Item2;

    /// <summary>
    /// Gets the borders manager of the selector.
    /// </summary>
    public Borders Borders => _borders;

    /// <summary>
    /// Gets the border type of the selector.
    /// </summary>
    public BordersType BordersType => _borders.Type;
    #endregion

    #region Constructor
    /// <summary>
    /// The <see cref="IntSelector"/> is an interactive element that allows the user to select an integer value from a range of values.
    /// </summary>
    /// <param name="question">The question to ask the user.</param>
    /// <param name="min">The minimum value of the selector.</param>
    /// <param name="max">The maximum value of the selector.</param>
    /// <param name="start">The start value of the selector.</param>
    /// <param name="step">The step of the selector.</param>
    /// <param name="placement">The placement of the selector on the console.</param>
    /// <param name="bordersType">The border type of the selector.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public IntSelector(
        string question,
        int min,
        int max,
        int start,
        int step,
        Placement placement = DEFAULT_PLACEMENT,
        BordersType bordersType = DEFAULT_BORDERS_TYPE
    )
    {
        _question = question;
        CheckMinNotHigherThanMax(min, max);
        _minimumValue = min;
        _maximumValue = max;
        _startValue = CheckStart(start, _minimumValue, _maximumValue);
        _step = CheckStep(step, _minimumValue, _maximumValue);
        _placement = placement;
        _borders = new Borders(bordersType);
    }

    private static void CheckMinNotHigherThanMax(int min, int max)
    {
        if (min > max)
            throw new ArgumentException(
                "The minimum value cannot be greater than the maximum value."
            );
    }

    private static int CheckStart(int start, int min, int max)
    {
        if (start < min)
            throw new ArgumentException("The start value cannot be less than the minimum value.");
        if (start > max)
            throw new ArgumentException(
                "The start value cannot be greater than the maximum value."
            );
        return start;
    }

    private static int CheckStep(int step, int min, int max)
    {
        if (step > max - min)
            throw new ArgumentException(
                "The step cannot be greater than the difference between the minimum and maximum values."
            );
        if (step < 1)
            throw new ArgumentException("The step cannot be less than 1.");
        return step;
    }
    #endregion

    #region Update Methods
    /// <summary>
    /// Updates the question of the selector.
    /// </summary>
    /// <param name="question">The question to ask the user.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateQuestion(string question)
    {
        _question = question;
    }

    /// <summary>
    /// Updates the minimum value of the selector.
    /// </summary>
    /// <param name="min">The minimum value of the selector.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateMin(int min)
    {
        CheckMinNotHigherThanMax(min, _maximumValue);
        _minimumValue = min;
        _startValue = CheckStart(_startValue, _minimumValue, _maximumValue);
        _step = CheckStep(_step, _minimumValue, _maximumValue);
    }

    /// <summary>
    /// Updates the maximum value of the selector.
    /// </summary>
    /// <param name="max">The maximum value of the selector.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateMax(int max)
    {
        CheckMinNotHigherThanMax(_minimumValue, max);
        _maximumValue = max;
        _startValue = CheckStart(_startValue, _minimumValue, _maximumValue);
        _step = CheckStep(_step, _minimumValue, _maximumValue);
    }

    /// <summary>
    /// Updates the start value of the selector.
    /// </summary>
    /// <param name="start">The start value of the selector.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateStart(int start)
    {
        _startValue = CheckStart(start, _minimumValue, _maximumValue);
    }

    /// <summary>
    /// Updates the step of the selector.
    /// </summary>
    /// <param name="step">The step of the selector.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateStep(int step)
    {
        _step = CheckStep(step, _minimumValue, _maximumValue);
    }

    /// <summary>
    /// Updates the placement of the selector.
    /// </summary>
    /// <param name="placement">The placement of the selector on the console.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdatePlacement(Placement placement)
    {
        _placement = placement;
    }

    /// <summary>
    /// Updates the selector of the selector.
    /// </summary>
    /// <param name="leftSelector">The new left selector of the selector.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateLeftSelector(char leftSelector = DEFAULT_UPDATED_SELECTOR_LEFT)
    {
        _selector.Item1 = leftSelector;
    }

    /// <summary>
    /// Updates the selector of the selector.
    /// </summary>
    /// <param name="rightSelector">The new right selector of the selector.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateRightSelector(char rightSelector = DEFAULT_UPDATED_SELECTOR_RIGHT)
    {
        _selector.Item2 = rightSelector;
    }

    /// <summary>
    /// Updates the border type of the selector.
    /// </summary>
    /// <param name="bordersType">The border type of the selector.</param>
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
    private string BuildNumber(int number)
    {
        StringBuilder numberStr = new();
        numberStr.Append($"{Borders.Vertical} ");
        numberStr.Append(
            number.ToString().ResizeString(_maximumValue.ToString().Length, DEFAULT_TEXT_ALIGNMENT)
        );
        numberStr.Append($" {Borders.Vertical}");
        return numberStr.ToString();
    }

    /// <summary>
    /// Defines the actions to perform when the element is called to be rendered on the console.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        Core.WriteContinuousString(
            _question,
            Line,
            false,
            DEFAULT_PRINT_DURATION,
            DEFAULT_PRINT_ADDITIONAL_DURATION
        );
        int currentNumber = _startValue;
        int lineSelector = Line + 4;
        while (true)
        {
            DisplayChoices(lineSelector, currentNumber);

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.Z:
                    currentNumber = NextNumber(Direction.Up, currentNumber);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    currentNumber = NextNumber(Direction.Down, currentNumber);
                    break;
                case ConsoleKey.Enter:
                    SendResponse(
                        this,
                        new InteractionEventArgs<int>(Status.Selected, currentNumber)
                    );
                    return;
                case ConsoleKey.Escape:
                    SendResponse(
                        this,
                        new InteractionEventArgs<int>(Status.Escaped, currentNumber)
                    );
                    return;
                default:
                    break;
            }
            Thread.Sleep(1);
        }

        [Visual]
        void DisplayChoices(int lineSelector, int currentNumber)
        {
            Core.WritePositionedString(BuildLine(Direction.Up), Placement, false, lineSelector - 2);
            Core.WritePositionedString(
                BuildNumber(NextNumber(Direction.Up, currentNumber)),
                Placement,
                false,
                lineSelector - 1
            );
            Core.WritePositionedString(
                $" {LeftSelector} {BuildNumber(currentNumber)} {RightSelector} ",
                Placement,
                true,
                lineSelector
            );
            Core.WritePositionedString(
                BuildNumber(NextNumber(Direction.Down, currentNumber)),
                Placement,
                false,
                lineSelector + 1
            );
            Core.WritePositionedString(
                BuildLine(Direction.Down),
                Placement,
                false,
                lineSelector + 2
            );
        }

        [Visual]
        int NextNumber(Direction direction, int currentNumber)
        {
            if (direction == Direction.Up)
            {
                if (currentNumber + _step <= _maximumValue)
                    return currentNumber + _step;
                else if (currentNumber + _step > _maximumValue)
                    return _minimumValue;
            }
            else
            {
                if (currentNumber - _step >= _minimumValue)
                    return currentNumber - _step;
                else if (currentNumber - _step < _minimumValue)
                    return _maximumValue;
            }
            return currentNumber;
        }

        [Visual]
        string BuildLine(Direction direction)
        {
            StringBuilder line = new();
            for (int i = 0; i < _maximumValue.ToString().Length + 2; i++)
                line.Append(Borders.Horizontal, 1);
            if (direction == Direction.Up)
                line.Insert(0, Borders.TopLeft.ToString(), 1).Append(Borders.TopRight, 1);
            else
                line.Insert(0, Borders.BottomLeft.ToString(), 1).Append(Borders.BottomRight, 1);
            return line.ToString();
        }
    }
    #endregion
}
