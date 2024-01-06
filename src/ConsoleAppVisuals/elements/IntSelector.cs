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
public class IntSelector : InteractiveElement<int>
{
    #region Fields
    private readonly string _question;
    private readonly int _minimumValue;
    private readonly int _maximumValue;
    private readonly int _startValue;
    private readonly int _step;
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
            $" {Core.GetSelector.Item1} {BuildNumber(_maximumValue)} {Core.GetSelector.Item2} ".Length
        );
    #endregion

    #region Constructor
    /// <summary>
    /// The constructor of the intSelector class.
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
    public IntSelector(
        string question,
        int min,
        int max,
        int start = 0,
        int step = 100,
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

    private static int CheckMin(int min, int max)
    {
        if (min > max)
            throw new ArgumentException(
                "The minimum value cannot be greater than the maximum value."
            );
        return min;
    }

    private static int CheckMax(int min, int max)
    {
        if (max < min)
            throw new ArgumentException("The maximum value cannot be less than the minimum value.");
        return max;
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
        return step;
    }
    #endregion

    #region Methods
    /// <summary>
    /// This method is used to draw the selector on the console.
    /// </summary>
    protected override void RenderActions()
    {
        Core.WriteContinuousString(_question, _line, default, 1500, 50);
        int currentNumber = _startValue;
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
                    Core.ClearMultipleLines(_line, 4);
                    SendResponse(
                        this,
                        new InteractionEventArgs<int>(Output.Select, currentNumber)
                    );
                    return;
                case ConsoleKey.Escape:
                    Core.ClearMultipleLines(_line, 4);
                    SendResponse(this, new InteractionEventArgs<int>(Output.Exit, currentNumber));
                    return;
                default:
                    break;
            }
            Thread.Sleep(1);
            Core.ClearMultipleLines(lineSelector - 2, 5);
        }
    }

    void DisplayChoices(int lineSelector, int currentNumber)
    {
        Core.WritePositionedString(
            BuildLine(Direction.Up),
            Placement.TopCenter,
            false,
            lineSelector - 2
        );
        Core.WritePositionedString(
            BuildNumber(NextNumber(Direction.Up, currentNumber)),
            Placement.TopCenter,
            false,
            lineSelector - 1
        );
        Core.WritePositionedString(
            $" {Core.GetSelector.Item1} {BuildNumber(currentNumber)} {Core.GetSelector.Item2} ",
            Placement.TopCenter,
            true,
            lineSelector
        );
        Core.WritePositionedString(
            BuildNumber(NextNumber(Direction.Down, currentNumber)),
            Placement.TopCenter,
            false,
            lineSelector + 1
        );
        Core.WritePositionedString(
            BuildLine(Direction.Down),
            Placement.TopCenter,
            false,
            lineSelector + 2
        );
    }

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

    string BuildNumber(int number)
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
