/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
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
    [ExcludeFromCodeCoverage]
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
    public static int CountElements => s_elements.Count;

    /// <summary>
    /// Gives the list of elements in the window.
    /// </summary>
    public static List<Element> GetElements => s_elements;
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
    /// This method adds elements to the window.
    /// </summary>
    /// <param name="elements">The elements to be added.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void AddElement(params Element[] elements)
    {
        foreach (var element in elements)
        {
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
    /// <exception cref="ElementNotFoundException">Thrown when the element is invalid.</exception>
    /// <returns>True if the element is successfully removed, false otherwise.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static bool RemoveElement(Element element)
    {
        if (!s_elements.Contains(element))
        {
            throw new ElementNotFoundException("Invalid element. Not found in the window.");
        }
        var state = s_elements.Remove(element);
        UpdateIDs();
        return state;
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
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
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
    /// This method removes the first element with the given type created by the library itself.
    /// </summary>
    /// <typeparam name="T">The type of the element.</typeparam>
    /// <exception cref="ElementNotFoundException">Thrown when the element is invalid.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the element is not created by the library.</exception>
    /// <returns>True if the element is successfully removed, false otherwise.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static bool RemoveLibraryElement<T>()
        where T : Element
    {
        var element =
            GetElement<T>()
            ?? throw new ElementNotFoundException("Invalid element. Not found in the window.");
        if (element.ElementSource == Source.Library)
        {
            var state = s_elements.Remove(element);
            UpdateIDs();
            return state;
        }
        throw new InvalidOperationException("Invalid element. Not created by the library.");
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
    /// <param name="render">If true, the element will be rendered.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the id is out of range.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
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
            s_elements[id].RenderElement();
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
            element.RenderElement();
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
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
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
            element.RenderElement();
        }
    }

    /// <summary>
    /// After activating the visibility of an interactive element, this method will return the response for the user.
    /// </summary>
    /// <param name="clear">If true, the element will be cleared.</param>
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
    [Visual]
    public static InteractionEventArgs<TResponse>? GetResponse<T, TResponse>(bool clear = true)
        where T : InteractiveElement<TResponse>
    {
        var element =
            GetVisibleElement<T>()
            ?? throw new ElementNotFoundException("Invalid element. Not found in the window.");
        DeactivateElement<T>(clear);
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
    /// <param name="clear">If true, the element will be cleared.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the id is out of range.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
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
        Render();
    }

    /// <summary>
    /// This method deactivate the visibility of the element with the given type.
    /// </summary>
    /// <param name="element">The element to be deactivated.</param>
    /// <param name="clear">If true, the element will be cleared.</param>
    /// <exception cref="ElementNotFoundException">Thrown when the element is invalid.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
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
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
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
        Render();
    }
    #endregion

    #region Utility Methods: AllowVisibilityToggle, GetLineAvailable, Clear, StopExecution, RenderOne, Refresh
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
    /// This method clears the window.
    /// </summary>
    /// <param name="continuous">If true, the window will be cleared continuously.</param>
    /// <returns>True if the window is successfully cleared, false otherwise.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static bool Clear(bool continuous = false)
    {
        if (continuous)
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Core.WriteContinuousString("".PadRight(Console.WindowWidth), i, false, 100, 10);
            }
        }
        else
        {
            for (int i = 0; i < Console.WindowHeight; i++)
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
    /// This method stops the execution of the program until a key is pressed.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    [Visual]
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
    /// <returns>True if the element is successfully drawn, false otherwise.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static bool RenderOneElement(int id)
    {
        if (id < 0 || id >= s_elements.Count)
        {
            throw new ElementNotFoundException("Invalid element ID.");
        }
        s_elements[id].RenderElement();
        return true;
    }

    /// <summary>
    /// This method draws the given element on the console.
    /// </summary>
    /// <param name="element">The element to be drawn.</param>
    /// <exception cref="ElementNotFoundException">Thrown when the element is invalid.</exception>
    /// <returns>True if the element is successfully drawn, false otherwise.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static bool RenderOneElement(Element element)
    {
        if (element == null || !s_elements.Contains(element))
        {
            throw new ElementNotFoundException("Invalid element. Not found in the window.");
        }

        element.RenderElement();
        return true;
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
    public static void Render()
    {
        Clear();
        foreach (var element in s_elements)
        {
            element.RenderElement();
        }
    }

    /// <summary>
    /// This method is called to refresh the window when the size of the console is changed.
    /// </summary>
    /// <returns>True if the window is refreshed, false otherwise.</returns>
    public static bool OnResize()
    {
        if (Core.IsScreenUpdated)
        {
            Core.SetConsoleDimensions();
            Render();
            return true;
        }
        return false;
    }

    /// <summary>
    /// This method draws all the space of the elements of the window on the console.
    /// </summary>
    /// <returns>True if the space of the elements is successfully drawn, false otherwise.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static bool RenderAllElementsSpace()
    {
        foreach (var element in s_elements)
        {
            element.RenderElementSpace();
        }
        return true;
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
    [ExcludeFromCodeCoverage]
    public static void Close()
    {
        Core.LoadTerminalColorPanel();
        Clear(true);
        Console.CursorVisible = true;
        Environment.Exit(0);
    }
    #endregion

    #region Info Methods: ListWindowElements, ListClassesInheritingElement, ListClassesInheritingInteractiveElement
    /// <summary>
    /// This method displays a list of all elements in the window and adds a table to the window.
    /// </summary>
    /// <param name="placement">The placement of the element.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void AddListWindowElements(Placement placement = Placement.TopCenter)
    {
        TableView<string> table =
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
                    "IsInteractive",
                    "Source"
                },
                null,
                true,
                placement
            )
            {
                ElementSource = Source.Library
            };
        AddElement(table);
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
                    element.IsInteractive.ToString(),
                    element.ElementSource.ToString()
                }
            );
        }
    }

    /// <summary>
    /// This method is used to get a list of all the types of the elements in the window.
    /// </summary>
    /// <returns>A list of all the types of the elements in the window.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static List<string>? GetListWindowElements()
    {
        TableView<string> table =
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
                    "IsInteractive",
                    "Source"
                }
            )
            {
                ElementSource = Source.Library
            };
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
                    element.IsInteractive.ToString(),
                    element.ElementSource.ToString()
                }
            );
        }
        return table.GetColumnData("Type");
    }

    /// <summary>
    /// This method gives a list of all classes inheriting from the Element (and so InteractiveElement as well) class and adds a table to the window.
    /// </summary>
    /// <param name="placement">The placement of the element.</param>
    /// <returns>The list of all classes inheriting from the Element class.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void AddListClassesInheritingElement(Placement placement = Placement.TopCenter)
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
        TableView<string> table =
            new(
                "Element Classes",
                new List<string> { "Id", "Type", "Project" },
                null,
                true,
                placement
            );
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
        table.ElementSource = Source.Library;
        AddElement(table);
    }

    /// <summary>
    /// This method is used to get a list of all the types of the classes inheriting from the Element class.
    /// </summary>
    /// <returns>A list of all the types of the classes inheriting from the Element class.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static List<string>? GetListClassesInheritingElement()
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
                        .Where(t =>
                            t.IsSubclassOf(typeof(Element)) && t != typeof(InteractiveElement<>)
                        )
                );
            }
        }
        TableView<string> table =
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
        return table.GetColumnData("Type");
    }

    /// <summary>
    /// This method gives a list of all classes inheriting from the InteractiveElement class and adds a table to the window.
    /// </summary>
    /// <param name="placement">The placement of the element.</param>
    /// <returns>The list of all classes inheriting from the InteractiveElement class.</returns>
    public static void AddListClassesInheritingInteractiveElement(
        Placement placement = Placement.TopCenter
    )
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
                        .Where(t =>
                            t.BaseType != null
                            && t.BaseType.IsGenericType
                            && t.BaseType.GetGenericTypeDefinition() == typeof(InteractiveElement<>)
                        )
                );
            }
        }
        TableView<string> table =
            new(
                "Interactive Element Classes",
                new List<string> { "Id", "Type", "Project" },
                null,
                true,
                placement
            );
        var id = 0;
        foreach (var type in types)
        {
            table.AddLine(
                new List<string> { $"{id}", type.Name, type.Assembly.GetName().Name ?? "Unknown" }
            );
            id += 1;
        }
        table.ElementSource = Source.Library;
        AddElement(table);
    }

    /// <summary>
    /// This method is used to get a list of all the types of the classes inheriting from the InteractiveElement class.
    /// </summary>
    /// <returns>A list of all the types of the classes inheriting from the InteractiveElement class.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static List<string>? GetListClassesInheritingInteractiveElement()
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
                        .Where(t =>
                            t.BaseType != null
                            && t.BaseType.IsGenericType
                            && t.BaseType.GetGenericTypeDefinition() == typeof(InteractiveElement<>)
                        )
                );
            }
        }
        TableView<string> table =
            new("Interactive Element Classes", new List<string> { "Id", "Type", "Project" });
        var id = 0;
        foreach (var type in types)
        {
            table.AddLine(
                new List<string> { $"{id}", type.Name, type.Assembly.GetName().Name ?? "Unknown" }
            );
            id += 1;
        }
        return table.GetColumnData("Type");
    }

    /// <summary>
    /// This method displays a list of all classes inheriting from the Element class and a list of all classes inheriting from the InteractiveElement class.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void AddClassesDashboard()
    {
        AddListClassesInheritingElement(Placement.TopLeft);
        AddListClassesInheritingInteractiveElement(Placement.TopRight);
    }

    /// <summary>
    /// This method removes the dashboard TableView from the window.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void RemoveClassesDashboard()
    {
        RemoveLibraryElement<TableView<string>>();
        RemoveLibraryElement<TableView<string>>();
    }

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
    public static void AddWindowElementsDashboard()
    {
        AddListWindowElements(Placement.TopCenter);
    }

    /// <summary>
    /// This method removes the dashboard TableView from the window.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void RemoveWindowElementsDashboard()
    {
        RemoveLibraryElement<TableView<string>>();
    }
    #endregion
}
