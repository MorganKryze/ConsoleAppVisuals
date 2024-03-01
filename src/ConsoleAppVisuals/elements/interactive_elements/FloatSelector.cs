/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals.Elements;

/// <summary>
/// Defines the number selector of the console window.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public class FloatSelector : InteractiveElement<float>
{
    #region Fields
    private string _question;
    private float _minimumValue;
    private float _maximumValue;
    private float _startValue;
    private float _step;
    private bool _roundedCorners;
    private Placement _placement;
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
            $" {Core.GetSelector.Item1} {BuildNumber((float)Math.Round(_maximumValue, 1))} {Core.GetSelector.Item2} ".Length
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
    /// Whether the corners of the selector are rounded.
    /// </summary>
    public bool RoundedCorners => _roundedCorners;
    #endregion

    #region Constructor
    /// <summary>
    /// The constructor of the FloatSelector class.
    /// </summary>
    /// <param name="question">The question to ask the user.</param>
    /// <param name="min">The minimum value of the selector.</param>
    /// <param name="max">The maximum value of the selector.</param>
    /// <param name="start">The start value of the selector.</param>
    /// <param name="step">The step of the selector.</param>
    /// <param name="placement">The placement of the selector on the console.</param>
    /// <param name="roundedCorners">Whether the corners of the selector are rounded.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public FloatSelector(
        string question,
        float min,
        float max,
        float start = 0,
        float step = 100,
        Placement placement = Placement.TopCenter,
        bool roundedCorners = false
    )
    {
        _question = question;
        CheckMinNotHigherThanMax(min, max);
        _minimumValue = min;
        _maximumValue = max;
        _startValue = CheckStart(start, _minimumValue, _maximumValue);
        _step = CheckStep(step, _minimumValue, _maximumValue);
        _placement = placement;
        _roundedCorners = roundedCorners;
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
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
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
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
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
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
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
    /// This method is used to update the rounded corners of the selector.
    /// </summary>
    /// <param name="roundedCorners">Whether the corners of the selector are rounded.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void SetRoundedCorners(bool roundedCorners = true)
    {
        _roundedCorners = roundedCorners;
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
                        new InteractionEventArgs<float>(Output.Selected, currentNumber)
                    );
                    return;
                case ConsoleKey.Escape:
                    SendResponse(
                        this,
                        new InteractionEventArgs<float>(Output.Escaped, currentNumber)
                    );
                    return;
                default:
                    break;
            }
            Thread.Sleep(1);
        }
    }

    [Visual]
    void DisplayChoices(int lineSelector, float currentNumber)
    {
        Core.WritePositionedString(
            BuildLine(Direction.Up),
            TextAlignment.Center,
            false,
            lineSelector - 2
        );
        Core.WritePositionedString(
            BuildNumber((float)Math.Round(NextNumber(Direction.Up, currentNumber), 1)),
            TextAlignment.Center,
            false,
            lineSelector - 1
        );
        Core.WritePositionedString(
            $" {Core.GetSelector.Item1} {BuildNumber((float)Math.Round(currentNumber, 1))} {Core.GetSelector.Item2} ",
            TextAlignment.Center,
            true,
            lineSelector
        );
        Core.WritePositionedString(
            BuildNumber((float)Math.Round(NextNumber(Direction.Down, currentNumber), 1)),
            TextAlignment.Center,
            false,
            lineSelector + 1
        );
        Core.WritePositionedString(
            BuildLine(Direction.Down),
            TextAlignment.Center,
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
        string corners = _roundedCorners ? "╭╮╰╯" : "┌┐└┘";
        StringBuilder line = new();
        for (int i = 0; i < _maximumValue.ToString().Length + 2; i++)
            line.Append('─');
        if (direction == Direction.Up)
            line.Insert(0, corners[0].ToString(), 1).Append(corners[1], 1);
        else
            line.Insert(0, corners[2].ToString(), 1).Append(corners[3], 1);
        return line.ToString();
    }

    string BuildNumber(float number)
    {
        StringBuilder numberStr = new();
        numberStr.Append("│ ");
        numberStr.Append(
            number.ToString().ResizeString(_maximumValue.ToString().Length, TextAlignment.Center)
        );
        numberStr.Append(" │");
        return numberStr.ToString();
    }
    #endregion
}
