/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.PassiveElements;

/// <summary>
/// A <see cref="ElementsDashboard"/> is a passive element that displays a dashboard of all the elements currently in the <see cref="Window"/> class.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public class ElementsDashboard : PassiveElement
{
    #region Fields: title, headers, lines, display array, rounded corners
    private List<List<string>> _lines;
    private string[] _displayArray;
    private Placement _placement;
    private readonly Borders _borders;
    #endregion

    #region Properties: get headers, get lines
    /// <summary>
    /// This property returns the title of the dashboard.
    /// </summary>
    public static string Title => "Window Elements Dashboard";

    /// <summary>
    /// This property returns the headers of the dashboard.
    /// </summary>
    public static List<string> Headers =>
        new()
        {
            "Id",
            "Type",
            "Visibility",
            "Height",
            "Width",
            "Line",
            "Placement",
            "IsInteractive"
        };

    /// <summary>
    /// This property returns the lines of the dashboard.
    /// </summary>
    public List<List<string>> Lines => _lines;

    /// <summary>
    /// This property returns the title of the dashboard.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// This property returns the height of the dashboard.
    /// </summary>
    public override int Height => _displayArray.Length;

    /// <summary>
    /// This property returns the width of the dashboard.
    /// </summary>
    public override int Width => _displayArray.Max(x => x.Length);

    /// <summary>
    /// This property returns the number of lines in the dashboard.
    /// </summary>
    public int Count => _lines.Count;

    /// <summary>
    /// This property returns the border manager of the dashboard.
    /// </summary>
    public Borders Borders => _borders;

    /// <summary>
    /// This property returns the type of borders to be used in the dashboard.
    /// </summary>
    public BordersType BordersType => _borders.Type;
    #endregion

    #region Constructor
    /// <summary>
    /// A <see cref="ElementsDashboard"/> is a passive element that displays a dashboard of all the elements currently in the <see cref="Window"/> class.
    /// </summary>
    /// <param name="placement">The placement of the dashboard.</param>
    /// <param name="bordersType">The type of borders to be used in the dashboard.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public ElementsDashboard(
        Placement placement = Placement.TopCenter,
        BordersType bordersType = BordersType.SingleStraight
    )
    {
        _lines = UpdateLines();
        _placement = placement;
        _borders = new Borders(bordersType);
        _displayArray = Array.Empty<string>();
        BuildDisplay();
    }
    #endregion

    #region Methods
    /// <summary>
    /// This method updates the placement of the dashboard.
    /// </summary>
    /// <param name="placement">The new placement of the dashboard.</param>
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
        BuildDisplay();
    }

    /// <summary>
    /// This method updates the type of borders to be used in the dashboard.
    /// </summary>
    /// <param name="bordersType">The new type of borders to be used in the dashboard.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateBordersType(BordersType bordersType)
    {
        _borders.UpdateBordersType(bordersType);
        BuildDisplay();
    }

    private static List<List<string>> UpdateLines()
    {
        var elements = new List<List<string>>();
        foreach (var element in Window.Elements)
        {
            elements.Add(
                new List<string>
                {
                    element.Id.ToString(),
                    element.GetType().Name,
                    element.Visibility.ToString(),
                    element.Height.ToString(),
                    element.Width.ToString(),
                    element.Line.ToString(),
                    element.Placement.ToString(),
                    element.IsInteractive.ToString()
                }
            );
        }
        return elements;
    }

    private void BuildDisplay()
    {
        var stringList = new List<string>();
        var localMax = new int[Headers.Count];
        for (int i = 0; i < Headers.Count; i++)
        {
            if (Headers[i]?.Length > localMax[i])
            {
                localMax[i] = Headers[i]?.Length ?? 0;
            }
        }

        for (int i = 0; i < _lines.Count; i++)
        {
            for (int j = 0; j < _lines[i].Count; j++)
            {
                if (_lines[i][j]?.ToString()?.Length > localMax[j])
                {
                    localMax[j] = _lines[i][j]?.ToString()?.Length ?? 0;
                }
            }
        }

        StringBuilder headerBuilder = new($"{Borders.Vertical} ");
        for (int i = 0; i < Headers.Count; i++)
        {
            headerBuilder.Append(Headers[i]?.PadRight(localMax[i]) ?? "");
            if (i != Headers.Count - 1)
            {
                headerBuilder.Append($" {Borders.Vertical} ");
            }
            else
            {
                headerBuilder.Append($" {Borders.Vertical}");
            }
        }
        stringList.Add(headerBuilder.ToString());

        StringBuilder upperBorderBuilder = new(Borders.TopLeft.ToString());
        for (int i = 0; i < Headers.Count; i++)
        {
            upperBorderBuilder.Append(new string(Borders.Horizontal, localMax[i] + 2));
            upperBorderBuilder.Append(
                (i != Headers.Count - 1) ? Borders.Top.ToString() : Borders.TopRight.ToString()
            );
        }
        stringList.Insert(0, upperBorderBuilder.ToString());

        StringBuilder intermediateBorderBuilder = new(Borders.Left.ToString());
        for (int i = 0; i < Headers.Count; i++)
        {
            intermediateBorderBuilder.Append(new string(Borders.Horizontal, localMax[i] + 2));
            intermediateBorderBuilder.Append(
                (i != Headers.Count - 1) ? Borders.Cross.ToString() : Borders.Right.ToString()
            );
        }
        stringList.Add(intermediateBorderBuilder.ToString());

        for (int i = 0; i < _lines.Count; i++)
        {
            StringBuilder lineBuilder = new($"{Borders.Vertical} ");
            for (int j = 0; j < _lines[i].Count; j++)
            {
                lineBuilder.Append(_lines[i][j]?.ToString()?.PadRight(localMax[j]) ?? "");
                if (j != _lines[i].Count - 1)
                {
                    lineBuilder.Append($" {Borders.Vertical} ");
                }
                else
                {
                    lineBuilder.Append($" {Borders.Vertical}");
                }
            }
            stringList.Add(lineBuilder.ToString());
        }

        StringBuilder lowerBorderBuilder = new(Borders.BottomLeft.ToString());
        for (int i = 0; i < Headers.Count; i++)
        {
            lowerBorderBuilder.Append(new string(Borders.Horizontal, localMax[i] + 2));
            lowerBorderBuilder.Append(
                (i != Headers.Count - 1)
                    ? Borders.Bottom.ToString()
                    : Borders.BottomRight.ToString()
            );
        }
        stringList.Add(lowerBorderBuilder.ToString());

        _displayArray = stringList.ToArray();
        BuildTitle();
    }

    private void BuildTitle()
    {
        var len = _displayArray![0].Length;
        var title = Title.ResizeString(len - 4);
        title = $"{Borders.Vertical} {title} {Borders.Vertical}";
        var upperBorderBuilder = new StringBuilder(Borders.TopLeft.ToString());
        upperBorderBuilder.Append(new string(Borders.Horizontal, len - 2));
        upperBorderBuilder.Append(Borders.TopRight.ToString());
        var display = _displayArray.ToList();
        display[0] = display[0]
            .Remove(0, 1)
            .Insert(0, Borders.Left.ToString())
            .Remove(display[1].Length - 1, 1)
            .Insert(display[1].Length - 1, Borders.Right.ToString());
        display.Insert(0, title);
        display.Insert(0, upperBorderBuilder.ToString());
        _displayArray = display.ToArray();
    }

    /// <summary>
    /// This method displays the dashboard.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        _lines = UpdateLines();
        BuildDisplay();
        string[] array = new string[_displayArray!.Length];
        for (int j = 0; j < _displayArray.Length; j++)
        {
            array[j] = _displayArray[j];
            Core.WritePositionedString(array[j], _placement, false, Line + j);
        }
    }
    #endregion
}
