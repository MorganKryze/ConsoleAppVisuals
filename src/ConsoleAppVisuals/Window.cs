/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// The Window class manages the elements that are to be displayed on the console.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public static class Window
{
    #region Setup
    /// <summary>
    /// This method sets up the console as soon as the Program starts.
    /// </summary>
    [Visual]
    static Window()
    {
        Console.Clear();
        Console.CursorVisible = false;
    }
    #endregion

    #region Fields: s_elements
    private static readonly List<Element> s_elements = new();
    #endregion

    #region Constants: DefaultVisibility
    /// <summary>
    /// The default visibility of the elements when they are added to the window.
    /// </summary>
    /// <remarks>
    /// This value should not be changed.
    /// Each time the user adds an element to the window, it will try to toggle the visibility of the element.
    /// </remarks>
    public const bool DEFAULT_VISIBILITY = false;
    #endregion

    #region Properties: NextId, NumberOfElements, Elements
    /// <summary>
    /// Gives the next id number each time a new element is added to the window.
    /// </summary>
    public static int NextId => s_elements.Count;

    /// <summary>
    /// Gives the number of elements in the window.
    /// </summary>
    public static int CountElements => s_elements.Count;

    /// <summary>
    /// Gives the list of elements in the window.
    /// </summary>
    public static List<Element> Elements => s_elements;
    #endregion

    #region Managing Methods: Get, Add, Insert, Remove, RemoveAll

    /// <summary>
    /// This method returns a range of elements given a start and end ids.
    /// </summary>
    /// <param name="start">The start id of the range.</param>
    /// <param name="end">The end id of the range.</param>
    /// <returns>The range of elements from the start to the end id.</returns>
    public static List<Element> GetRange(int start, int end)
    {
        return s_elements.GetRange(start, end);
    }

    /// <summary>
    /// This method returns the first element of the given type.
    /// </summary>
    /// <typeparam name="T">The type of the element.</typeparam>
    /// <returns>The element with the given type if it exists, null otherwise.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static T? GetElement<T>()
        where T : Element
    {
        return s_elements.Find(element => element.GetType() == typeof(T)) as T;
    }

    /// <summary>
    /// This method returns the first element of the given type and id.
    /// </summary>
    /// <param name="id">The id of the element.</param>
    /// <returns>The element with the given id if it exists, null otherwise.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the id is out of range.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static T? GetElement<T>(int id)
        where T : Element
    {
        if (id < 0 || id >= s_elements.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Invalid element ID.");
        }
        return (T)s_elements[id];
    }

    /// <summary>
    /// This method returns the first visible element with the given type.
    /// </summary>
    /// <typeparam name="T">The type of the element.</typeparam>
    /// <returns>The visible element with the given type if it exists, null otherwise.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static T? GetVisibleElement<T>()
        where T : Element
    {
        return s_elements.Find(element => element.GetType() == typeof(T) && element.Visibility)
            as T;
    }

    /// <summary>
    /// This method adds elements to the window.
    /// </summary>
    /// <param name="elements">The elements to be added.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void AddElement(params Element[] elements)
    {
        foreach (var element in elements)
        {
            element.Id = NextId;
            s_elements.Add(element);
            if (!element.IsInteractive && AllowVisibilityToggle(element.Id))
            {
                element.ToggleVisibility();
            }
        }
    }

    /// <summary>
    /// This method inserts an element to the window at the given id.
    /// </summary>
    /// <param name="element">The element to be inserted.</param>
    /// <param name="id">The id of the element.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the id is out of range.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void InsertElement(Element element, int id)
    {
        if (id < 0 || id > s_elements.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Invalid element ID.");
        }
        s_elements.Insert(id, element);
    }

    /// <summary>
    /// This method removes the first element with the given type.
    /// </summary>
    /// <typeparam name="T">The type of the element.</typeparam>
    /// <exception cref="ElementNotFoundException">Thrown when the element is invalid.</exception>
    /// <returns>True if the element is successfully removed, false otherwise.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static bool RemoveElement<T>()
        where T : Element
    {
        var element =
            GetElement<T>()
            ?? throw new ElementNotFoundException("Invalid element. Not found in the window.");
        var state = s_elements.Remove(element);
        UpdateIDs();
        return state;
    }

    /// <summary>
    /// This method removes the element with the given id.
    /// </summary>
    /// <param name="id">The id of the element.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the id is out of range.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void RemoveElement(int id)
    {
        if (id < 0 || id >= s_elements.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Invalid element ID.");
        }
        s_elements.RemoveAt(id);
        UpdateIDs();
    }

    /// <summary>
    /// This method removes the given element.
    /// </summary>
    /// <param name="elements">The elements to be removed.</param>
    /// <exception cref="ElementNotFoundException">Thrown when the element is invalid.</exception>
    /// <returns>True if the element is successfully removed, false otherwise.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static bool RemoveElement(params Element[] elements)
    {
        bool state = true;

        foreach (var element in elements)
        {
            if (!s_elements.Contains(element))
            {
                throw new ElementNotFoundException("Invalid element. Not found in the window.");
            }
            state &= s_elements.Remove(element);
        }

        UpdateIDs();
        return state;
    }

    /// <summary>
    /// This method removes all elements from the window.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void RemoveAllElements()
    {
        s_elements.Clear();
    }
    #endregion

    #region Visibility Methods: ActivateElement, ActivateAllElements, DeactivateElement, DeactivateAllElements
    /// <summary>
    /// This method attempts to activate the visibility of the element with the given id.
    /// </summary>
    /// <param name="id">The id of the element.</param>
    /// <param name="render">If true, the element will be rendered.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the id is out of range.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    [Visual]
    public static void ActivateElement(int id, bool render = true)
    {
        if (id < 0 || id >= s_elements.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Invalid element ID.");
        }
        if (!s_elements[id].Visibility)
        {
            s_elements[id].ToggleVisibility();
        }
        if (render)
        {
            Render(s_elements[id]);
        }
    }

    /// <summary>
    /// This method attempts to activate the visibility of the given element.
    /// </summary>
    /// <param name="element">The element to be activated.</param>
    /// <param name="render">If true, the element will be rendered.</param>
    /// <exception cref="ElementNotFoundException">Thrown when the element is invalid.</exception>
    [Visual]
    public static void ActivateElement(Element element, bool render = true)
    {
        if (!s_elements.Contains(element))
        {
            throw new ElementNotFoundException("Invalid element. Not found in the window.");
        }
        if (!element.Visibility)
        {
            element.ToggleVisibility();
        }
        if (render)
        {
            Render(element);
        }
    }

    /// <summary>
    /// This method attempts to activate the visibility of the first element of the given type.
    /// </summary>
    /// <param name="render">If true, the element will be rendered.</param>
    /// <typeparam name="T">The type of the element.</typeparam>
    /// <exception cref="ElementNotFoundException">Thrown when the element is invalid.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    [Visual]
    public static void ActivateElement<T>(bool render = true)
        where T : Element
    {
        var element =
            GetElement<T>()
            ?? throw new ElementNotFoundException("Invalid element. Not found in the window.");
        if (!element.Visibility)
        {
            element.ToggleVisibility();
        }
        if (render)
        {
            Render(element);
        }
    }

    /// <summary>
    /// This method attempts to activate the visibility of all elements.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void ActivateAllElements()
    {
        foreach (var element in s_elements)
        {
            if (!element.Visibility)
            {
                element.ToggleVisibility();
            }
        }
    }

    /// <summary>
    /// This method to deactivate the visibility of the element with the given id.
    /// </summary>
    /// <param name="id">The id of the element.</param>
    /// <param name="clear">If true, the element will be cleared from the console.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the id is out of range.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void DeactivateElement(int id, bool clear = true)
    {
        if (id < 0 || id >= s_elements.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Invalid element ID.");
        }
        if (s_elements[id].Visibility)
        {
            s_elements[id].ToggleVisibility();
            if (clear)
            {
                s_elements[id].Clear();
            }
        }
    }

    /// <summary>
    /// This method deactivate the visibility of the element with the given type.
    /// </summary>
    /// <param name="element">The element to be deactivated.</param>
    /// <param name="clear">If true, the element will be cleared from the console.</param>
    /// <exception cref="ElementNotFoundException">Thrown when the element is invalid.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void DeactivateElement(Element element, bool clear = true)
    {
        if (!s_elements.Contains(element))
        {
            throw new ElementNotFoundException("Invalid element. Not found in the window.");
        }

        if (element.Visibility)
        {
            element.ToggleVisibility();
            if (clear)
            {
                element.Clear();
            }
        }
    }

    /// <summary>
    /// This method deactivate the visibility of the first element with the given type.
    /// </summary>
    /// <param name="clear">If true, the element will be cleared.</param>
    /// <typeparam name="T">The type of the element.</typeparam>
    /// <exception cref="ElementNotFoundException">Thrown when the element is invalid.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void DeactivateElement<T>(bool clear = true)
        where T : Element
    {
        var element =
            GetVisibleElement<T>()
            ?? throw new ElementNotFoundException("Invalid element. Not found in the window.");
        if (element.Visibility)
        {
            element.ToggleVisibility();
            if (clear)
            {
                element.Clear();
            }
        }
    }

    /// <summary>
    /// This method deactivate the visibility of all elements.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void DeactivateAllElements()
    {
        foreach (var element in s_elements)
        {
            if (element.Visibility)
            {
                element.ToggleVisibility();
            }
        }
    }
    #endregion

    #region Utility Methods: AllowVisibilityToggle, GetLineAvailable, Clear, StopExecution, Refresh
    [ExcludeFromCodeCoverage]
    private static void UpdateIDs()
    {
        for (int i = 0; i < s_elements.Count; i++)
        {
            s_elements[i].Id = i;
        }
    }

    /// <summary>
    /// This method checks if the element can be toggled to visible.
    /// </summary>
    /// <param name="id">The id of the element.</param>
    /// <returns>True if the element can be toggled to visible, false otherwise.</returns>
    public static bool AllowVisibilityToggle(int id)
    {
        if (s_elements[id].IsInteractive)
        {
            int numberOfVisibleInteractiveElements = s_elements.Count(element =>
                element.IsInteractive && element.Visibility
            );
            return numberOfVisibleInteractiveElements == 0;
        }
        else
        {
            int numberOfVisibleElements = s_elements.Count(element =>
                element.GetType() == s_elements[id].GetType() && element.Visibility
            );
            return numberOfVisibleElements < s_elements[id].MaxNumberOfThisElement;
        }
    }

    /// <summary>
    /// This method gets the last line available to draw an element on the console from a placement.
    /// </summary>
    /// <param name="placement">The placement of the element.</param>
    /// <returns>The last line available to draw an element on the console from a placement.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the placement is invalid.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static int GetLineAvailable(Placement placement)
    {
        return placement switch
        {
            Placement.TopCenterFullWidth
                => s_elements
                    .Where(e => e.Placement == Placement.TopCenterFullWidth && e.Visibility)
                    .Sum(e => e.Height)
                    + s_elements
                        .Where(e => e.Placement == Placement.TopCenter && e.Visibility)
                        .Sum(e => e.Height)
                    + s_elements
                        .Where(e => e.Placement == Placement.TopLeft && e.Visibility)
                        .Sum(e => e.Height)
                    + s_elements
                        .Where(e => e.Placement == Placement.TopRight && e.Visibility)
                        .Sum(e => e.Height),
            Placement.TopCenter
                => s_elements
                    .Where(e => e.Placement == Placement.TopCenterFullWidth && e.Visibility)
                    .Sum(e => e.Height)
                    + s_elements
                        .Where(e => e.Placement == Placement.TopCenter && e.Visibility)
                        .Sum(e => e.Height),
            Placement.TopLeft
                => s_elements
                    .Where(e => e.Placement == Placement.TopCenterFullWidth && e.Visibility)
                    .Sum(e => e.Height)
                    + s_elements
                        .Where(e => e.Placement == Placement.TopLeft && e.Visibility)
                        .Sum(e => e.Height),

            Placement.TopRight
                => s_elements
                    .Where(e => e.Placement == Placement.TopCenterFullWidth && e.Visibility)
                    .Sum(e => e.Height)
                    + s_elements
                        .Where(e => e.Placement == Placement.TopRight && e.Visibility)
                        .Sum(e => e.Height),
            Placement.BottomCenterFullWidth
                => Console.WindowHeight
                    - s_elements
                        .Where(e => e.Placement == Placement.BottomCenterFullWidth && e.Visibility)
                        .Sum(e => e.Height),
            _ => throw new ArgumentOutOfRangeException(nameof(placement), "Invalid placement.")
        };
    }

    /// <summary>
    /// This method checks if the line is valid under the console constraints.
    /// </summary>
    /// <param name="line">The line to be checked.</param>
    /// <returns>The line if it is valid.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the line is out of range.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static int? CheckLine(int? line)
    {
        int minLine = 0;
        int maxLine = Console.WindowHeight == 0 ? 0 : Console.WindowHeight - 1;
        if (line is null)
        {
            return line;
        }
        if (line < minLine || line > maxLine)
        {
            throw new ArgumentOutOfRangeException(
                nameof(line),
                $"Invalid line. The line must be between 0 and {maxLine}."
            );
        }
        return line;
    }

    /// <summary>
    /// This method stops the execution of the program until a key is pressed.
    /// </summary>
    /// <param name="key">The key to be pressed to continue the execution.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    [Visual]
    public static void Freeze(ConsoleKey key = ConsoleKey.Enter)
    {
        while (Console.ReadKey(intercept: true).Key != key)
        {
            Thread.Sleep(10);
        }
    }

    /// <summary>
    /// This method draws all visible elements of the window on the console.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void Render()
    {
        Clear();
        Core.IsScreenUpdated();
        foreach (var element in s_elements)
        {
            element.RenderElement();
        }
    }

    /// <summary>
    /// This method draws all given visible elements of the window on the console.
    /// </summary>
    /// <param name="elements">The elements to be drawn.</param>
    /// <exception cref="ElementNotFoundException">Thrown when the element is not found in the window.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void Render(params Element[] elements)
    {
        if (Core.IsScreenUpdated())
        {
            Render();
            return;
        }

        foreach (var element in elements)
        {
            if (!s_elements.Contains(element))
            {
                throw new ElementNotFoundException($"Element {element} is not in the Window.");
            }
            element.RenderElement();
        }
    }

    /// <summary>
    /// This method draws all the space of the visible elements of the window on the console.
    /// </summary>
    /// <returns>True if the space of the elements is successfully drawn, false otherwise.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static bool RenderElementsSpace()
    {
        foreach (var element in s_elements)
        {
            element.RenderElementSpace();
        }
        return true;
    }

    /// <summary>
    /// This method clears the console.
    /// </summary>
    /// <param name="continuous">If true, the window will be cleared continuously.</param>
    /// <param name="startLine">The start line of the window to be cleared.</param>
    /// <param name="length">The number of lines to be cleared.</param>
    /// <param name="step">The step of the window to be cleared.</param>
    /// <returns>True if the window is successfully cleared, false otherwise.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static bool Clear(
        bool continuous = false,
        int? startLine = null,
        int? length = null,
        int step = 1
    )
    {
        int stepMax = Console.WindowHeight == 0 ? 1 : Console.WindowHeight;
        startLine = CheckLine(startLine) ?? 0;
        length = CheckLine(startLine + length) ?? Console.WindowHeight;
        if (step < 1 || step > stepMax)
        {
            throw new ArgumentOutOfRangeException(
                nameof(step),
                "Invalid step, less than 0 or greater than the window height."
            );
        }

        for (int i = (int)startLine; i < (int)length; i += step)
        {
            if (continuous)
            {
                Core.WriteContinuousString("".PadRight(Console.WindowWidth), i, false, 100, 10);
            }
            else
            {
                Core.WritePositionedString(
                    "".PadRight(Console.WindowWidth),
                    TextAlignment.Center,
                    false,
                    i
                );
            }
        }
        return true;
    }

    /// <summary>
    /// This method clears the window and exit the program.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    [ExcludeFromCodeCoverage]
    public static void Close()
    {
        Core.LoadTerminalColorPanel();
        Clear(true);
        Console.CursorVisible = true;
        Environment.Exit(0);
    }
    #endregion
}
