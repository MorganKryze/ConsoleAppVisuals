/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.InteractiveElements;

/// <summary>
/// The <see cref="FloatSelector"/> is an interactive element that allows the user to select a float value from a range of values.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class FloatSelector : InteractiveElement<float>
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
    private float _minimumValue;
    private float _maximumValue;
    private float _startValue;
    private float _step;
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
            $" {LeftSelector} {BuildNumber((float)Math.Round(_maximumValue, 1))} {RightSelector} ".Length
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
    public float Min => _minimumValue;

    /// <summary>
    /// Gets the maximum value of the selector.
    /// </summary>
    public float Max => _maximumValue;

    /// <summary>
    /// Gets the start value of the selector.
    /// </summary>
    public float Start => _startValue;

    /// <summary>
    /// Gets the step of the selector.
    /// </summary>
    public float Step => _step;

    /// <summary>
    /// Gets the borders manager of the selector.
    /// </summary>
    public Borders Borders => _borders;

    /// <summary>
    /// Gets the type of the borders of the selector.
    /// </summary>
    public BordersType BordersType => _borders.Type;

    /// <summary>
    /// Gets the left selector of the selector.
    /// </summary>
    public char LeftSelector => _selector.Item1;

    /// <summary>
    /// Gets the right selector of the selector.
    /// </summary>
    public char RightSelector => _selector.Item2;
    #endregion

    #region Constructor
    /// <summary>
    /// The <see cref="FloatSelector"/> is an interactive element that allows the user to select a float value from a range of values.
    /// </summary>
    /// <param name="question">The question to ask the user.</param>
    /// <param name="min">The minimum value of the selector.</param>
    /// <param name="max">The maximum value of the selector.</param>
    /// <param name="start">The start value of the selector.</param>
    /// <param name="step">The step of the selector.</param>
    /// <param name="placement">The placement of the selector on the console.</param>
    /// <param name="bordersType">The type of the borders of the selector.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public FloatSelector(
        string question,
        float min,
        float max,
        float start,
        float step,
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

    private static void CheckMinNotHigherThanMax(float min, float max)
    {
        if (min > max)
            throw new ArgumentException(
                "The minimum value cannot be greater than the maximum value."
            );
    }

    private static float CheckStart(float start, float min, float max)
    {
        if (start < min)
            throw new ArgumentException("The start value cannot be less than the minimum value.");
        if (start > max)
            throw new ArgumentException(
                "The start value cannot be greater than the maximum value."
            );
        return start;
    }

    private static float CheckStep(float step, float min, float max)
    {
        if (step > max - min)
            throw new ArgumentException(
                "The step cannot be greater than the difference between the minimum and maximum values."
            );
        if (step <= 0f)
            throw new ArgumentException("The step cannot be less than 0.");
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
    public void UpdateMin(float min)
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
    public void UpdateMax(float max)
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
    public void UpdateStart(float start)
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
    public void UpdateStep(float step)
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
    /// Updates the type of the borders of the selector.
    /// </summary>
    /// <param name="bordersType">The new type of the borders of the selector.</param>
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
    private string BuildNumber(float number)
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
        float currentNumber = _startValue;
        int lineSelector = Line + 4;
        bool loop = true;
        while (loop)
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
                        new InteractionEventArgs<float>(Status.Selected, currentNumber)
                    );
                    Window.DeactivateElement(this);
                    loop = false;
                    break;
                case ConsoleKey.Escape:
                    SendResponse(
                        this,
                        new InteractionEventArgs<float>(Status.Escaped, currentNumber)
                    );
                    loop = false;
                    break;
                default:
                    break;
            }
            Thread.Sleep(1);
        }

        [Visual]
        void DisplayChoices(int lineSelector, float currentNumber)
        {
            Core.WritePositionedString(BuildLine(Direction.Up), Placement, false, lineSelector - 2);
            Core.WritePositionedString(
                BuildNumber((float)Math.Round(NextNumber(Direction.Up, currentNumber), 1)),
                Placement,
                false,
                lineSelector - 1
            );
            Core.WritePositionedString(
                $" {LeftSelector} {BuildNumber((float)Math.Round(currentNumber, 1))} {RightSelector} ",
                Placement,
                true,
                lineSelector
            );
            Core.WritePositionedString(
                BuildNumber((float)Math.Round(NextNumber(Direction.Down, currentNumber), 1)),
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
        float NextNumber(Direction direction, float currentNumber)
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
