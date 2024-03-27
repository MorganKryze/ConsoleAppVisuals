/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.PassiveElements;

/// <summary>
/// A <see cref="ElementsList"/> is a passive element that displays a list of all the elements types available.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public class ElementsList : PassiveElement
{
    #region Fields: title, headers, lines, display array, rounded corners
    private ElementType _elementsTypeExpected;
    private List<List<string>> _lines;
    private string[] _displayArray;
    private readonly Borders _borders;
    private Placement _placement;
    #endregion

    #region Constants
    private const string ELEMENTS_TITLE = "Element types available";
    private const string PASSIVE_ELEMENTS_TITLE = "Passive element types available";
    private const string INTERACTIVE_ELEMENTS_TITLE = "Interactive element types available";
    #endregion

    #region Properties: get headers, get lines

    /// <summary>
    /// This property returns the title of the InteractiveList.
    /// </summary>
    public string Title =>
        _elementsTypeExpected switch
        {
            ElementType.Default => ELEMENTS_TITLE,
            ElementType.Passive => PASSIVE_ELEMENTS_TITLE,
            ElementType.Interactive => INTERACTIVE_ELEMENTS_TITLE,
            _ => ELEMENTS_TITLE
        };

    /// <summary>
    /// This property returns the headers of the dashboard.
    /// </summary>
    public static List<string> Headers => new() { "Id", "Type", "Project" };

    /// <summary>
    /// This property returns the lines of the InteractiveList.
    /// </summary>
    public List<List<string>> Lines => _lines;

    /// <summary>
    /// This property returns the title of the InteractiveList.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// This property returns the borders of the InteractiveList.
    /// </summary>
    public Borders Borders => _borders;

    /// <summary>
    /// This property returns the type of borders of the InteractiveList.
    /// </summary>
    public BordersType BordersType => _borders.Type;

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

    /// <summary>
    /// This property returns the type of element expected.
    /// </summary>
    public ElementType ElementsTypeExpected => _elementsTypeExpected;

    #endregion

    #region Constructor
    /// <summary>
    /// A <see cref="ElementsList"/> is a passive element that displays a list of all the elements types available.
    /// </summary>
    /// <param name="elementTypeExpected">The type of element expected.</param>
    /// <param name="placement">The placement of the InteractiveList.</param>
    /// <param name="bordersType">The type of borders of the InteractiveList.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public ElementsList(
        ElementType elementTypeExpected = ElementType.Default,
        Placement placement = Placement.TopCenter,
        BordersType bordersType = BordersType.SingleStraight
    )
    {
        _elementsTypeExpected = elementTypeExpected;
        _lines = UpdateLines();
        _placement = placement;
        _borders = new Borders(bordersType);
        _displayArray = Array.Empty<string>();
        BuildDisplay();
    }
    #endregion

    #region Methods
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

    /// <summary>
    /// This method updates the type of borders of the InteractiveList.
    /// </summary>
    /// <param name="bordersType">The new type of borders of the InteractiveList.</param>
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

    /// <summary>
    /// This method updates the type of element expected.
    /// </summary>
    /// <param name="elementsTypeExpected">The new type of element expected.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateElementsTypeExpected(ElementType elementsTypeExpected)
    {
        _elementsTypeExpected = elementsTypeExpected;
        _lines = UpdateLines();
        BuildDisplay();
    }

    private List<List<string>> UpdateLines()
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
                switch (_elementsTypeExpected)
                {
                    case ElementType.Default:
                        types.AddRange(
                            assembly
                                .GetTypes()
                                .Where(t =>
                                    t.BaseType != null
                                    && t.IsSubclassOf(typeof(Element))
                                    && t != typeof(PassiveElement)
                                    && t != typeof(AnimatedElement)
                                    && t != typeof(InteractiveElement<>)
                                )
                        );
                        break;

                    case ElementType.Passive:
                        types.AddRange(
                            assembly
                                .GetTypes()
                                .Where(t =>
                                    t.BaseType != null && t.IsSubclassOf(typeof(PassiveElement))
                                )
                        );
                        break;

                    case ElementType.Interactive:
                        types.AddRange(
                            assembly
                                .GetTypes()
                                .Where(t =>
                                    t.BaseType != null
                                    && t.BaseType.IsGenericType
                                    && t.BaseType.GetGenericTypeDefinition()
                                        == typeof(InteractiveElement<>)
                                )
                        );
                        break;

                    case ElementType.Animated:
                        types.AddRange(
                            assembly
                                .GetTypes()
                                .Where(t =>
                                    t.BaseType != null && t.IsSubclassOf(typeof(AnimatedElement))
                                )
                        );
                        break;

                    default:
                        types.AddRange(
                            assembly
                                .GetTypes()
                                .Where(t => t.BaseType != null && t.IsSubclassOf(typeof(Element)))
                        );
                        break;
                }
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

    [Visual]
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
            Core.WritePositionedString(array[j], _placement, false, Line + j);
        }
    }
    #endregion
}
