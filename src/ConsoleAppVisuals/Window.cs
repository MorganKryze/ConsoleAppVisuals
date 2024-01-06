/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// The major class of the library. The window is used to collect the elements of the console and draw them.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
/// </list>
/// </remarks>
public static class Window
{
    #region Setup
    /// <summary>
    /// This method sets up the window without the need to call it.
    /// </summary>
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
    public const bool DEFAULT_VISIBILITY = false;
    #endregion

    #region Properties: NextId, NumberOfElements
    /// <summary>
    /// Gives the next id number each time a new element is added to the window.
    /// </summary>
    public static int NextId => s_elements.Count;

    /// <summary>
    /// Gives the number of elements in the window.
    /// </summary>
    public static int NumberOfElements => s_elements.Count;
    #endregion

    #region Basic Methods: Get, Add, Insert, Remove, RemoveAll
    /// <summary>
    /// This method returns the first element of the given type.
    /// </summary>
    /// <typeparam name="T">The type of the element.</typeparam>
    /// <returns>The element with the given type if it exists, null otherwise.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static T? GetElement<T>()
        where T : Element
    {
        return s_elements.Find(element => element.GetType() == typeof(T)) as T;
    }

    /// <summary>
    /// This method returns the element with the given id.
    /// </summary>
    /// <param name="id">The id of the element.</param>
    /// <returns>The element with the given id if it exists, null otherwise.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the id is out of range.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
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
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static T? GetVisibleElement<T>()
        where T : Element
    {
        return s_elements.Find(element => element.GetType() == typeof(T) && element.Visibility)
            as T;
    }

    /// <summary>
    /// This method adds an element to the window.
    /// </summary>
    /// <param name="element">The element to be added.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void AddElement(Element element)
    {
        s_elements.Add(element);
        if (!element.IsInteractive && AllowVisibilityToggle(element.Id))
        {
            element.ToggleVisibility();
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
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
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
    /// This method removes the element with the given id.
    /// </summary>
    /// <param name="id">The id of the element.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the id is out of range.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
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
    /// <param name="element">The element to be removed.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void RemoveElement(Element element)
    {
        if (element is null || s_elements.Contains(element))
        {
            throw new ArgumentOutOfRangeException(
                nameof(element),
                "Invalid element. Not found in the window."
            );
        }
        s_elements.Remove(element);
        UpdateIDs();
    }

    /// <summary>
    /// This method removes the first element with the given type.
    /// </summary>
    /// <typeparam name="T">The type of the element.</typeparam>
    /// <exception cref="InvalidOperationException">Thrown when the element is invalid.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void RemoveElement<T>()
        where T : Element
    {
        var element =
            GetElement<T>()
            ?? throw new InvalidOperationException("Invalid element. Not found in the window.");
        s_elements.Remove(element);
        UpdateIDs();
    }

    /// <summary>
    /// This method removes all elements from the window.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void RemoveAllElements()
    {
        s_elements.Clear();
    }
    #endregion

    #region Manipulation Methods: ActivateElement, ActivateAllElements, DeactivateElement, DeactivateAllElements
    /// <summary>
    /// This method attempts to activate the visibility of the element with the given id.
    /// </summary>
    /// <param name="id">The id of the element.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the id is out of range.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void ActivateElement(int id)
    {
        if (id < 0 || id >= s_elements.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Invalid element ID.");
        }
        if (!s_elements[id].Visibility)
        {
            s_elements[id].ToggleVisibility();
        }
    }

    /// <summary>
    /// This method attempts to activate the visibility of the first element of the given type.
    /// </summary>
    /// <typeparam name="T">The type of the element.</typeparam>
    /// <exception cref="ElementNotFoundException">Thrown when the element is invalid.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void ActivateElement<T>()
        where T : Element
    {
        var element =
            GetElement<T>()
            ?? throw new ElementNotFoundException("Invalid element. Not found in the window.");
        if (!element.Visibility)
        {
            element.ToggleVisibility();
        }
    }

    /// <summary>
    /// After activating the visibility of an interactive element, this method will return the response for the user.
    /// </summary>
    /// <typeparam name="T">The type of interactive element.</typeparam>
    /// <typeparam name="TResponse">The type of the response (int, string, float...).</typeparam>
    /// <returns>The response of the user.</returns>
    /// <exception cref="ElementNotFoundException">Thrown when the element is invalid.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static InteractionEventArgs<TResponse>? GetResponse<T, TResponse>()
        where T : InteractiveElement<TResponse>
    {
        var element =
            GetVisibleElement<T>()
            ?? throw new ElementNotFoundException("Invalid element. Not found in the window.");
        DeactivateElement<T>();
        return element.GetInteractionResponse;
    }

    /// <summary>
    /// This method attempts to activate the visibility of all elements.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
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
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the id is out of range.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void DeactivateElement(int id)
    {
        if (id < 0 || id >= s_elements.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Invalid element ID.");
        }
        if (s_elements[id].Visibility)
        {
            s_elements[id].ToggleVisibility();
        }
        Refresh();
    }

    /// <summary>
    /// This method deactivate the visibility of the element with the given type.
    /// </summary>
    /// <param name="element">The element to be deactivated.</param>
    /// <exception cref="ElementNotFoundException">Thrown when the element is invalid.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void DeactivateElement(Element element)
    {
        if (element is null || !s_elements.Contains(element))
        {
            throw new ElementNotFoundException("Invalid element. Not found in the window.");
        }

        if (element.Visibility)
        {
            element.ToggleVisibility();
        }

        Refresh();
    }

    /// <summary>
    /// This method deactivate the visibility of the first element with the given type.
    /// </summary>
    /// <typeparam name="T">The type of the element.</typeparam>
    /// <exception cref="ElementNotFoundException">Thrown when the element is invalid.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void DeactivateElement<T>()
        where T : Element
    {
        var element =
            GetVisibleElement<T>()
            ?? throw new ElementNotFoundException("Invalid element. Not found in the window.");
        if (element.Visibility)
        {
            element.ToggleVisibility();
        }
        Refresh();
    }

    /// <summary>
    /// This method deactivate the visibility of all elements.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
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
        Refresh();
    }
    #endregion

    #region Utility Methods: AllowVisibilityToggle, GetLineAvailable, Clear, StopExecution, RenderOne, Refresh
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
            int numberOfVisibleInteractiveElements = s_elements.Count(
                element => element.IsInteractive && element.Visibility
            );
            return numberOfVisibleInteractiveElements == 0;
        }
        else
        {
            int numberOfVisibleElements = s_elements.Count(
                element => element.GetType() == s_elements[id].GetType() && element.Visibility
            );
            return numberOfVisibleElements < s_elements[id].MaxNumberOfThisElement;
        }
    }

    /// <summary>
    /// Gives the last line available to draw an element on the console from a placement.
    /// </summary>
    /// <param name="placement">The placement of the element.</param>
    /// <returns>The last line available to draw an element on the console from a placement.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the placement is invalid.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
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
    /// This method checks if the line is valid.
    /// </summary>
    /// <param name="line">The line to be checked.</param>
    /// <returns>The line if it is valid.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the line is out of range.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static int? CheckLine(int? line)
    {
        if (line is null)
        {
            return line;
        }
        if (line < 0 || line >= Console.WindowHeight)
        {
            throw new ArgumentOutOfRangeException(
                nameof(line),
                $"Invalid line. The line must be between 0 and {Console.WindowHeight - 1}."
            );
        }
        return line;
    }

    /// <summary>
    /// This method clears the window.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void Clear()
    {
        Core.ClearWindow(false, false);
    }

    /// <summary>
    /// This method stops the execution of the program until a key is pressed.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void StopExecution(ConsoleKey key = ConsoleKey.Enter)
    {
        // wait until the user presses a key
        while (Console.ReadKey(intercept: true).Key != key)
        {
            Thread.Sleep(10);
        }
    }

    /// <summary>
    /// This method draws the element with the given id on the console.
    /// </summary>
    /// <param name="id">The id of the element.</param>
    /// <exception cref="ElementNotFoundException">Thrown when the id is out of range.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void RenderOneElement(int id)
    {
        if (id < 0 || id >= s_elements.Count)
        {
            throw new ElementNotFoundException("Invalid element ID.");
        }
        s_elements[id].RenderElement();
    }

    /// <summary>
    /// This method draws the given element on the console.
    /// </summary>
    /// <param name="element">The element to be drawn.</param>
    /// <exception cref="ElementNotFoundException">Thrown when the element is invalid.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void RenderOneElement(Element element)
    {
        if (element == null || !s_elements.Contains(element))
        {
            throw new ElementNotFoundException("Invalid element. Not found in the window.");
        }

        element.RenderElement();
    }

    /// <summary>
    /// This method draws all the non interactive elements of the window on the console.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void Refresh()
    {
        Clear();
        foreach (var element in s_elements)
        {
            element.RenderElement();
        }
    }

    /// <summary>
    /// This method closes the window and exit the program.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void Close()
    {
        Core.ClearWindow();
        Console.CursorVisible = true;
        Environment.Exit(0);
    }
    #endregion

    #region Info Methods: ListWindowElements, ListClassesInheritingElement, ListClassesInheritingInteractiveElement
    /// <summary>
    /// This method displays a list of all elements in the window.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static List<string>? ListWindowElements()
    {
        Table<string> table =
            new(
                "Window Elements",
                new List<string>
                {
                    "Id",
                    "Type",
                    "Visibility",
                    "Height",
                    "Width",
                    "Line",
                    "Placement",
                    "IsInteractive"
                }
            );
        foreach (var element in s_elements)
        {
            table.AddLine(
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
        table.Render(GetLineAvailable(Placement.TopCenter));
        return table.GetColumnData("Type");
    }

    /// <summary>
    /// This method gives a list of all classes inheriting from the Element class.
    /// </summary>
    /// <returns>The list of all classes inheriting from the Element class.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static List<string>? ListClassesInheritingElement()
    {
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
                types.AddRange(assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Element))));
            }
        }
        Table<string> table =
            new("Element Classes", new List<string> { "Id", "Type", "Project" });
        var id = 0;
        foreach (var type in types)
        {
            if (type.IsAbstract)
            {
                continue;
            }
            table.AddLine(
                new List<string> { $"{id}", type.Name, type.Assembly.GetName().Name ?? "Unknown" }
            );
            id += 1;
        }
        table.Render(GetLineAvailable(Placement.TopCenter));
        return table.GetColumnData("Type");
    }

    /// <summary>
    /// This method gives a list of all classes inheriting from the InteractiveElement class.
    /// </summary>
    /// <returns>The list of all classes inheriting from the InteractiveElement class.</returns>
    public static List<string>? ListClassesInheritingInteractiveElement()
    {
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
                        .Where(
                            t =>
                                t.BaseType != null
                                && t.BaseType.IsGenericType
                                && t.BaseType.GetGenericTypeDefinition()
                                    == typeof(InteractiveElement<>)
                        )
                );
            }
        }
        Table<string> table =
            new("Interactive Element Classes", new List<string> { "Id", "Type", "Project" });
        var id = 0;
        foreach (var type in types)
        {
            table.AddLine(
                new List<string> { $"{id}", type.Name, type.Assembly.GetName().Name ?? "Unknown" }
            );
            id += 1;
        }
        table.Render(GetLineAvailable(Placement.TopCenter));
        return table.GetColumnData("Type");
    }

    /// <summary>
    /// This method displays a list of all elements in the window, a list of all classes inheriting from the Element class and a list of all classes inheriting from the InteractiveElement class.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void GetFullInfo()
    {
        ListWindowElements();
        ListClassesInheritingElement();
        ListClassesInheritingInteractiveElement();
    }
    #endregion
}
