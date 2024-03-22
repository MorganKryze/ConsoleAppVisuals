/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals.InteractiveElements;

/// <summary>
/// A <see cref="IntSelector"/> is an interactive element that allows the user to select an integer value from a range of values.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public class IntSelector : InteractiveElement<int>
{
    #region Fields
    private string _question;
    private int _minimumValue;
    private int _maximumValue;
    private int _startValue;
    private int _step;
    private Placement _placement;
    private Borders _borders;
    private (char, char) _selector = (DEFAULT_SELECTOR_LEFT, DEFAULT_SELECTOR_RIGHT);
    #endregion

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

    #region Properties
    /// <summary>
    /// The placement of the selector on the console.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// The height of the selector.
    /// </summary>
    public override int Height => 7;

    /// <summary>
    /// The width of the selector.
    /// </summary>
    public override int Width =>
        Math.Max(
            _question.Length,
            $" {LeftSelector} {BuildNumber(_maximumValue)} {RightSelector} ".Length
        );

    /// <summary>
    /// The question to ask the user.
    /// </summary>
    public string Question => _question;

    /// <summary>
    /// The minimum value of the selector.
    /// </summary>
    public int Min => _minimumValue;

    /// <summary>
    /// The maximum value of the selector.
    /// </summary>
    public int Max => _maximumValue;

    /// <summary>
    /// The start value of the selector.
    /// </summary>
    public int Start => _startValue;

    /// <summary>
    /// The step of the selector.
    /// </summary>
    public int Step => _step;

    /// <summary>
    /// The left selector of the selector.
    /// </summary>
    public char LeftSelector => _selector.Item1;

    /// <summary>
    /// The right selector of the selector.
    /// </summary>
    public char RightSelector => _selector.Item2;

    /// <summary>
    /// The borders manager of the selector.
    /// </summary>
    public Borders Borders => _borders;

    /// <summary>
    /// The border type of the selector.
    /// </summary>
    public BorderType BorderType => _borders.Type;
    #endregion

    #region Constructor
    /// <summary>
    /// A <see cref="IntSelector"/> is an interactive element that allows the user to select an integer value from a range of values.
    /// </summary>
    /// <param name="question">The question to ask the user.</param>
    /// <param name="min">The minimum value of the selector.</param>
    /// <param name="max">The maximum value of the selector.</param>
    /// <param name="start">The start value of the selector.</param>
    /// <param name="step">The step of the selector.</param>
    /// <param name="placement">The placement of the selector on the console.</param>
    /// <param name="borderType">The border type of the selector.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public IntSelector(
        string question,
        int min,
        int max,
        int start = 0,
        int step = 100,
        Placement placement = Placement.TopCenter,
        BorderType borderType = BorderType.SingleStraight
    )
    {
        _question = question;
        CheckMinNotHigherThanMax(min, max);
        _minimumValue = min;
        _maximumValue = max;
        _startValue = CheckStart(start, _minimumValue, _maximumValue);
        _step = CheckStep(step, _minimumValue, _maximumValue);
        _placement = placement;
        _borders = new Borders(borderType);
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

    #region Methods
    /// <summary>
    /// This method is used to update the question of the selector.
    /// </summary>
    /// <param name="question">The question to ask the user.</param>
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
    /// This method is used to update the minimum value of the selector.
    /// </summary>
    /// <param name="min">The minimum value of the selector.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateMin(int min)
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
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateMax(int max)
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
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateStart(int start)
    {
        _startValue = CheckStart(start, _minimumValue, _maximumValue);
    }

    /// <summary>
    /// This method is used to update the step of the selector.
    /// </summary>
    /// <param name="step">The step of the selector.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateStep(int step)
    {
        _step = CheckStep(step, _minimumValue, _maximumValue);
    }

    /// <summary>
    /// This method is used to update the placement of the selector.
    /// </summary>
    /// <param name="placement">The placement of the selector on the console.</param>
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
    /// This method is used to update the selector of the selector.
    /// </summary>
    /// <param name="leftSelector">The new left selector of the selector.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
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
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateRightSelector(char rightSelector = '◀')
    {
        _selector.Item2 = rightSelector;
    }

    /// <summary>
    /// This method is used to update the border type of the selector.
    /// </summary>
    /// <param name="borderType">The border type of the selector.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateBorderType(BorderType borderType)
    {
        _borders.UpdateBorderType(borderType);
    }

    /// <summary>
    /// This method is used to draw the selector on the console.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        Core.WriteContinuousString(_question, Line, default, 1500, 50);
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
        Core.WritePositionedString(BuildLine(Direction.Down), Placement, false, lineSelector + 2);
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
            line.Append('─');
        if (direction == Direction.Up)
            line.Insert(0, Borders.TopLeft.ToString(), 1).Append(Borders.TopRight, 1);
        else
            line.Insert(0, Borders.BottomLeft.ToString(), 1).Append(Borders.BottomRight, 1);
        return line.ToString();
    }

    string BuildNumber(int number)
    {
        StringBuilder numberStr = new();
        numberStr.Append($"{Borders.Vertical} ");
        numberStr.Append(
            number.ToString().ResizeString(_maximumValue.ToString().Length, TextAlignment.Center)
        );
        numberStr.Append($" {Borders.Vertical}");
        return numberStr.ToString();
    }
    #endregion
}
