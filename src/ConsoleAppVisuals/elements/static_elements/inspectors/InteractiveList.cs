/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals.Elements;

/// <summary>
/// This class is used to display a InteractiveList of all the elements in the window.
/// </summary>
public class InteractiveList : Element
{
    #region Fields: title, headers, lines, display array, rounded corners
    private List<List<string>> _lines;
    private string[] _displayArray;
    private bool _roundedCorners;
    private Placement _placement;
    #endregion

    #region Properties: get headers, get lines

    /// <summary>
    /// This property returns the title of the InteractiveList.
    /// </summary>
    public static string Title => "Interactive Element types available";

    /// <summary>
    /// This property returns the headers of the dashboard.
    /// </summary>
    public static List<string> Headers => new() { "Id", "Type", "Project" };
    private string GetCorners => _roundedCorners ? "╭╮╰╯" : "┌┐└┘";

    /// <summary>
    /// This property wether the corners of the InteractiveList are rounded.
    /// </summary>
    public bool RoundedCorners => _roundedCorners;

    /// <summary>
    /// This property returns the lines of the InteractiveList.
    /// </summary>
    public List<List<string>> Lines => _lines;

    /// <summary>
    /// This property returns the title of the InteractiveList.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// This property returns the line to display the InteractiveList on.
    /// </summary>

    /// <summary>
    /// This property returns the height of the InteractiveList.
    /// </summary>
    public override int Height => _displayArray.Length;

    /// <summary>
    /// This property returns the width of the InteractiveList.
    /// </summary>
    public override int Width => _displayArray.Max(x => x.Length);

    /// <summary>
    /// This property returns the number of lines in the InteractiveList.
    /// </summary>
    public int Count => _lines.Count;

    #endregion

    #region Constructor
    /// <summary>
    /// This constructor creates a new instance of the WindowElementsInteractiveList class.
    /// </summary>
    /// <param name="placement">The placement of the InteractiveList.</param>
    /// <param name="roundedCorners">If true, the corners of the InteractiveList will be rounded.</param>
    public InteractiveList(Placement placement = Placement.TopCenter, bool roundedCorners = false)
    {
        _lines = UpdateLines();
        _placement = placement;
        _roundedCorners = roundedCorners;
        _displayArray = Array.Empty<string>();
        BuildDisplay();
    }
    #endregion

    #region Methods
    /// <summary>
    /// Toggles the rounded corners of the element.
    /// </summary>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/ </remarks>
    public void SetRoundedCorners(bool rounded = true)
    {
        _roundedCorners = rounded;
        BuildDisplay();
    }

    /// <summary>
    /// This method updates the placement of the InteractiveList.
    /// </summary>
    /// <param name="placement">The new placement of the InteractiveList.</param>
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

    private static List<List<string>> UpdateLines()
    {
        var elements = new List<List<string>>();
        var types = new List<Type>();
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            if (
                assembly.FullName != null
                && !assembly.FullName.StartsWith("mscorlib")
                && !assembly.FullName.StartsWith("System")
                && !assembly.FullName.StartsWith("Microsoft")
            )
            {
                types.AddRange(
                    assembly
                        .GetTypes()
                        .Where(t =>
                            t.BaseType != null
                            && t.BaseType.IsGenericType
                            && t.BaseType.GetGenericTypeDefinition() == typeof(InteractiveElement<>)
                        )
                );
            }
        }
        var id = 0;
        foreach (var type in types)
        {
            elements.Add(
                new List<string> { $"{id}", type.Name, type.Assembly.GetName().Name ?? "Unknown" }
            );
            id += 1;
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

        StringBuilder headerBuilder = new("│ ");
        for (int i = 0; i < Headers.Count; i++)
        {
            headerBuilder.Append(Headers[i]?.PadRight(localMax[i]) ?? "");
            if (i != Headers.Count - 1)
            {
                headerBuilder.Append(" │ ");
            }
            else
            {
                headerBuilder.Append(" │");
            }
        }
        stringList.Add(headerBuilder.ToString());

        StringBuilder upperBorderBuilder = new(GetCorners[0].ToString());
        for (int i = 0; i < Headers.Count; i++)
        {
            upperBorderBuilder.Append(new string('─', localMax[i] + 2));
            upperBorderBuilder.Append((i != Headers.Count - 1) ? "┬" : GetCorners[1].ToString());
        }
        stringList.Insert(0, upperBorderBuilder.ToString());

        StringBuilder intermediateBorderBuilder = new("├");
        for (int i = 0; i < Headers.Count; i++)
        {
            intermediateBorderBuilder.Append(new string('─', localMax[i] + 2));
            intermediateBorderBuilder.Append((i != Headers.Count - 1) ? "┼" : "┤");
        }
        stringList.Add(intermediateBorderBuilder.ToString());

        for (int i = 0; i < _lines.Count; i++)
        {
            StringBuilder lineBuilder = new("│ ");
            for (int j = 0; j < _lines[i].Count; j++)
            {
                lineBuilder.Append(_lines[i][j]?.ToString()?.PadRight(localMax[j]) ?? "");
                if (j != _lines[i].Count - 1)
                {
                    lineBuilder.Append(" │ ");
                }
                else
                {
                    lineBuilder.Append(" │");
                }
            }
            stringList.Add(lineBuilder.ToString());
        }

        StringBuilder lowerBorderBuilder = new(GetCorners[2].ToString());
        for (int i = 0; i < Headers.Count; i++)
        {
            lowerBorderBuilder.Append(new string('─', localMax[i] + 2));
            lowerBorderBuilder.Append((i != Headers.Count - 1) ? "┴" : GetCorners[3].ToString());
        }
        stringList.Add(lowerBorderBuilder.ToString());

        _displayArray = stringList.ToArray();
        BuildTitle();
    }

    private void BuildTitle()
    {
        var len = _displayArray![0].Length;
        var title = Title.ResizeString(len - 4);
        title = $"│ {title} │";
        var upperBorderBuilder = new StringBuilder(GetCorners[0].ToString());
        upperBorderBuilder.Append(new string('─', len - 2));
        upperBorderBuilder.Append(GetCorners[1].ToString());
        var display = _displayArray.ToList();
        display[0] = display[0]
            .Remove(0, 1)
            .Insert(0, "├")
            .Remove(display[1].Length - 1, 1)
            .Insert(display[1].Length - 1, "┤");
        display.Insert(0, title);
        display.Insert(0, upperBorderBuilder.ToString());
        _displayArray = display.ToArray();
    }

    /// <summary>
    /// This method displays the InteractiveList.
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
            Core.WritePositionedString(array[j], _placement.ToTextAlignment(), false, Line + j);
        }
    }
    #endregion
}
