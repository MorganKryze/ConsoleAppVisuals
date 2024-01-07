/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// Defines the number selector of the console window.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
/// </list>
/// </remarks>
public class FloatSelector : InteractiveElement<float>
{
    #region Fields
    private readonly string _question;
    private readonly float _minimumValue;
    private readonly float _maximumValue;
    private readonly float _startValue;
    private readonly float _step;
    private readonly bool _roundedCorners;
    private readonly Placement _placement;
    private readonly int _line;
    #endregion

    #region Properties
    /// <summary>
    /// The placement of the selector on the console.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// The line where the selector will be displayed.
    /// </summary>
    public override int Line => _line;

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
    /// <param name="line">The line where the selector will be displayed.</param>
    /// <param name="roundedCorners">Whether the corners of the selector are rounded.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public FloatSelector(
        string question,
        float min,
        float max,
        float start = 0,
        float step = 100,
        Placement placement = Placement.TopCenter,
        int? line = null,
        bool roundedCorners = false
    )
    {
        _question = question;
        _minimumValue = CheckMin(min, max);
        _maximumValue = CheckMax(min, max);
        _startValue = CheckStart(start, _minimumValue, _maximumValue);
        _step = CheckStep(step, _minimumValue, _maximumValue);
        _placement = placement;
        _line = Window.CheckLine(line) ?? Window.GetLineAvailable(_placement);
        _roundedCorners = roundedCorners;
    }

    private static float CheckMin(float min, float max)
    {
        if (min > max)
            throw new ArgumentException(
                "The minimum value cannot be greater than the maximum value."
            );
        return min;
    }

    private static float CheckMax(float min, float max)
    {
        if (max < min)
            throw new ArgumentException("The maximum value cannot be less than the minimum value.");
        return max;
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
        return step;
    }
    #endregion

    #region Methods
    /// <summary>
    /// This method is used to draw the selector on the console.
    /// </summary>
    protected override void RenderElementActions()
    {
        Core.WriteContinuousString(_question, _line, default, 1500, 50);
        float currentNumber = _startValue;
        int lineSelector = _line + 4;
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
                        new InteractionEventArgs<float>(Output.Select, currentNumber)
                    );
                    return;
                case ConsoleKey.Escape:
                    SendResponse(this, new InteractionEventArgs<float>(Output.Exit, currentNumber));
                    return;
                default:
                    break;
            }
            Thread.Sleep(1);
        }
    }

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
