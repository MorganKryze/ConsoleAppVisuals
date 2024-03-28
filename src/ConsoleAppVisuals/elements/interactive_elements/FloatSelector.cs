/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.InteractiveElements;

/// <summary>
/// A <see cref="FloatSelector"/> is an interactive element that allows the user to select a float value from a range of values.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class FloatSelector : InteractiveElement<float>
{
    #region Constants
    /// <summary>
    /// The default left selector of the number selector.
    /// </summary>
    /// <remarks>
    /// Can be updated with the <see cref="UpdateLeftSelector(char)"/> method.
    /// </remarks>
    public const char DEFAULT_SELECTOR_LEFT = '>';

    /// <summary>
    /// The default right selector of the number selector.
    /// </summary>
    /// <remarks>
    /// Can be updated with the <see cref="UpdateRightSelector(char)"/> method.
    /// </remarks>
    public const char DEFAULT_SELECTOR_RIGHT = '<';
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
    /// The placement of the selector on the console.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// The height of the selector.
    /// </summary>
    public override int Height => 7;
    #endregion

    #region Properties
    /// <summary>
    /// The width of the selector.
    /// </summary>
    public override int Width =>
        Math.Max(
            _question.Length,
            $" {LeftSelector} {BuildNumber((float)Math.Round(_maximumValue, 1))} {RightSelector} ".Length
        );

    /// <summary>
    /// The question to ask the user.
    /// </summary>
    public string Question => _question;

    /// <summary>
    /// The minimum value of the selector.
    /// </summary>
    public float Min => _minimumValue;

    /// <summary>
    /// The maximum value of the selector.
    /// </summary>
    public float Max => _maximumValue;

    /// <summary>
    /// The start value of the selector.
    /// </summary>
    public float Start => _startValue;

    /// <summary>
    /// The step of the selector.
    /// </summary>
    public float Step => _step;

    /// <summary>
    /// The borders manager of the selector.
    /// </summary>
    public Borders Borders => _borders;

    /// <summary>
    /// The type of the borders of the selector.
    /// </summary>
    public BordersType BordersType => _borders.Type;

    /// <summary>
    /// The left selector of the selector.
    /// </summary>
    public char LeftSelector => _selector.Item1;

    /// <summary>
    /// The right selector of the selector.
    /// </summary>
    public char RightSelector => _selector.Item2;
    #endregion

    #region Constructor
    /// <summary>
    /// A <see cref="FloatSelector"/> is an interactive element that allows the user to select a float value from a range of values.
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
        float start = 0,
        float step = 100,
        Placement placement = Placement.TopCenter,
        BordersType bordersType = BordersType.SingleStraight
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

    #region Methods

    /// <summary>
    /// This method is used to update the question of the selector.
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
    /// This method is used to update the minimum value of the selector.
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
    /// This method is used to update the maximum value of the selector.
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
    /// This method is used to update the start value of the selector.
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
    /// This method is used to update the step of the selector.
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
    /// This method is used to update the placement of the selector.
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
    /// This method is used to update the selector of the selector.
    /// </summary>
    /// <param name="leftSelector">The new left selector of the selector.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateLeftSelector(char leftSelector = '▶')
    {
        _selector.Item1 = leftSelector;
    }

    /// <summary>
    /// This method is used to update the selector of the selector.
    /// </summary>
    /// <param name="rightSelector">The new right selector of the selector.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateRightSelector(char rightSelector = '◀')
    {
        _selector.Item2 = rightSelector;
    }

    /// <summary>
    /// This method is used to update the type of the borders of the selector.
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
            number.ToString().ResizeString(_maximumValue.ToString().Length, TextAlignment.Center)
        );
        numberStr.Append($" {Borders.Vertical}");
        return numberStr.ToString();
    }

    /// <summary>
    /// This method is used to draw the selector on the console.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        Core.WriteContinuousString(_question, Line, default, 1500, 50);
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
