/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals;

/// <summary>
/// The <see cref="Window"/> class is a collection of methods to manage visual elements stored in itself.
/// You may add, remove, or render elements in the console after adding them to the <see cref="Window"/> class.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public static class Window
{
    #region Constants
    /// <summary>
    /// Defines the interval of milliseconds between different read key of the console (used in the <see cref="Freeze"/> method).
    /// </summary>
    public const int INTERVAL_BETWEEN_READS = 10;
    #endregion

    #region Fields
    private static readonly List<Element> s_elements = new();
    #endregion

    #region Properties
    /// <summary>
    /// Gets the next id number each time a new element is added to the window.
    /// </summary>
    public static int NextId => s_elements.Count;

    /// <summary>
    /// Gets the number of elements currently stored in the window.
    /// </summary>
    public static int CountElements => s_elements.Count;

    /// <summary>
    /// Gets the list of elements stored in the window.
    /// </summary>
    public static List<Element> Elements => s_elements;
    #endregion

    #region Managing Methods
    /// <summary>
    /// Collects a range of <see cref="Element"/> given a start id and a count.
    /// </summary>
    /// <param name="index">The start id of the range.</param>
    /// <param name="count">The number of elements to be collected.</param>
    /// <returns>The list of <see cref="Element"/> given a range of ids.</returns>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public static List<Element> Range(int index, int count)
    {
        return s_elements.GetRange(index, count);
    }

    /// <summary>
    /// Gets the first <see cref="Element"/> of the given type present in the <see cref="Window"/>.
    /// </summary>
    /// <typeparam name="T">The type of the element.</typeparam>
    /// <returns>The element with the given type if it exists, null otherwise.</returns>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public static T? GetElement<T>()
        where T : Element
    {
        return s_elements.Find(element => element.GetType() == typeof(T)) as T;
    }

    /// <summary>
    /// Gets the <see cref="Element"/> with the given id in the <see cref="Window"/>.
    /// </summary>
    /// <param name="id">The id of the element.</param>
    /// <returns>The <see cref="Element"/> with the given id if it exists, null otherwise.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the id is out of the range of the <see cref="Window"/> elements.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// Gets the visible <see cref="Element"/> with the given type in the <see cref="Window"/>.
    /// </summary>
    /// <typeparam name="T">The type of the element.</typeparam>
    /// <returns>The visible <see cref="Element"/> with the given type if it exists, null otherwise.</returns>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public static T? GetVisibleElement<T>()
        where T : Element
    {
        return s_elements.Find(element => element.GetType() == typeof(T) && element.Visibility)
            as T;
    }

    /// <summary>
    /// Adds one or more <see cref="Element"/> to the window.
    /// If the element is passive, it will try to toggle its visibility to true.
    /// </summary>
    /// <param name="elements">The <see cref="Element"/> to be added.</param>
    /// <exception cref="ArgumentException">Thrown when no <see cref="Element"/> are provided.</exception>
    /// <exception cref="DuplicateElementException">Thrown when the <see cref="Element"/> is already present in the <see cref="Window"/>.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public static void AddElement(params Element[] elements)
    {
        if (elements == null || elements.Length == 0)
        {
            throw new ArgumentException("No elements provided");
        }

        foreach (var element in elements)
        {
            if (s_elements.Contains(element))
            {
                throw new DuplicateElementException(
                    $"Element with ID {element.Id} is already present in the window"
                );
            }

            element.Id = NextId;
            s_elements.Add(element);
            if (element.Type is ElementType.Passive && IsElementActivatable(element.Id))
            {
                element.ToggleVisibility();
            }
        }
    }

    /// <summary>
    /// Inserts an <see cref="Element"/> at the given id in the <see cref="Window"/>.
    /// </summary>
    /// <param name="element">The <see cref="Element"/> to be inserted.</param>
    /// <param name="id">The target id to insert the element.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the id is out of the range of the <see cref="Window"/> elements.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// Removes the first <see cref="Element"/> of the given type from the <see cref="Window"/>.
    /// </summary>
    /// <typeparam name="T">The type of the element.</typeparam>
    /// <exception cref="ElementNotFoundException">Thrown when the <see cref="Element"/> is not found in the <see cref="Window"/>.</exception>
    /// <returns>True if the element is successfully removed, false otherwise.</returns>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public static bool RemoveElement<T>()
        where T : Element
    {
        var element =
            GetElement<T>()
            ?? throw new ElementNotFoundException("Invalid element. Not found in the window.");
        var state = s_elements.Remove(element);
        UpdateIds();
        return state;
    }

    /// <summary>
    /// Removes the <see cref="Element"/> with the given id from the <see cref="Window"/>.
    /// </summary>
    /// <param name="id">The id of the element to be removed.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the id is out of the range of the <see cref="Window"/> elements.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public static void RemoveElement(int id)
    {
        if (id < 0 || id >= s_elements.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Invalid element ID.");
        }
        s_elements.RemoveAt(id);
        UpdateIds();
    }

    /// <summary>
    /// Removes one or more <see cref="Element"/> from the <see cref="Window"/>.
    /// </summary>
    /// <param name="elements">The <see cref="Element"/> to be removed.</param>
    /// <exception cref="ElementNotFoundException">Thrown when the <see cref="Element"/> is not found in the <see cref="Window"/>.</exception>
    /// <returns>True if the element is successfully removed, false otherwise.</returns>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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

        UpdateIds();
        return state;
    }

    /// <summary>
    /// Removes all <see cref="Element"/> from the window.
    /// </summary>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public static void RemoveAllElements()
    {
        s_elements.Clear();
    }
    #endregion

    #region Visibility Methods
    /// <summary>
    /// Attempts to toggle the visibility of the <see cref="Element"/> with the given id if the element fits the max number constraint.
    /// The element will be rendered if the render parameter is true.
    /// </summary>
    /// <param name="id">The id of the <see cref="Element"/> to activate.</param>
    /// <param name="render">If true, the <see cref="Element"/> will be rendered.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the id is out of the range of the <see cref="Window"/> elements.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// Attempts to toggle the visibility of the given <see cref="Element"/> if it fits the max number constraint.
    /// The element will be rendered if the render parameter is true.
    /// </summary>
    /// <param name="element">The <see cref="Element"/> to be activated.</param>
    /// <param name="render">If true, the <see cref="Element"/> will be rendered.</param>
    /// <exception cref="ElementNotFoundException">Thrown when the element is invalid.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
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
    /// Attempts to toggle the visibility of the first <see cref="Element"/> with the given type if the element fits the max number constraint.
    /// </summary>
    /// <param name="render">If true, the element will be rendered.</param>
    /// <typeparam name="T">The type of the element.</typeparam>
    /// <exception cref="ElementNotFoundException">Thrown when the element is invalid.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// Attempts to toggle the visibility of all <see cref="Element"/> in the window if the element fits the max number constraint.
    /// </summary>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// Deactivates the visibility of the <see cref="Element"/> with the given id.
    /// The console space taken by the element will be cleared if the clear parameter is true.
    /// </summary>
    /// <param name="id">The id of the <see cref="Element"/>.</param>
    /// <param name="clear">If true, the <see cref="Element"/> space will be cleared from the console.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the id is out of the range of the <see cref="Window"/> elements.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// Deactivates the visibility of the given <see cref="Element"/>.
    /// The console space taken by the element will be cleared if the clear parameter is true.
    /// </summary>
    /// <param name="element">The <see cref="Element"/> to be deactivated.</param>
    /// <param name="clear">If true, the <see cref="Element"/> space will be cleared from the console.</param>
    /// <exception cref="ElementNotFoundException">Thrown when the element is invalid.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// Deactivates the visibility of the first <see cref="Element"/> with the given type.
    /// The console space taken by the element will be cleared if the clear parameter is true.
    /// </summary>
    /// <param name="clear">If true, the element will be cleared.</param>
    /// <typeparam name="T">The type of the element.</typeparam>
    /// <exception cref="ElementNotFoundException">Thrown when the element is invalid.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// This method deactivate the visibility of all <see cref="Element"/>.
    /// </summary>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public static void DeactivateAllElements(bool clear = true)
    {
        foreach (var element in s_elements)
        {
            DeactivateElement(element, clear);
        }
    }
    #endregion

    #region Utility Methods
    private static void UpdateIds()
    {
        for (int i = 0; i < s_elements.Count; i++)
        {
            s_elements[i].Id = i;
        }
    }

    /// <summary>
    /// Tests if an <see cref="Element"/> given by an id can be activated
    /// </summary>
    /// <param name="id">The id of the <see cref="Element"/> to test.</param>
    /// <returns>True if the <see cref="Element"/> can be activated, false otherwise.</returns>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public static bool IsElementActivatable(int id)
    {
        if (s_elements[id].Type is ElementType.Interactive or ElementType.Animated)
        {
            int numberOfVisibleInteractiveElements = s_elements.Count(element =>
                element.Type is ElementType.Interactive or ElementType.Animated
                && element.Visibility
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
    /// Gets the last line available to render an <see cref="Element"/> on the console given a placement.
    /// </summary>
    /// <param name="placement">The placement to get the line.</param>
    /// <returns>The last line available to render an <see cref="Element"/> on the console.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the placement is invalid.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
                => (Console.WindowHeight == 0 ? 0 : Console.WindowHeight - 1)
                    - s_elements
                        .Where(e => e.Placement == Placement.BottomCenterFullWidth && e.Visibility)
                        .Sum(e => e.Height),
            _ => throw new ArgumentOutOfRangeException(nameof(Placement), "Invalid placement.")
        };
    }

    /// <summary>
    /// Checks if the line is not out of the console range.
    /// </summary>
    /// <param name="line">The line to be checked.</param>
    /// <returns>The line if it is valid.</returns>
    /// <exception cref="LineOutOfConsoleException">Thrown when the line is out of the console range.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
            throw new LineOutOfConsoleException(
                $"Invalid line. The line must be between 0 and {maxLine}."
            );
        }
        return line;
    }

    /// <summary>
    /// Freezes the execution of the program until the given key is pressed.
    /// </summary>
    /// <param name="key">The key to be pressed to continue the execution.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public static void Freeze(ConsoleKey key = ConsoleKey.Enter)
    {
        while (Console.ReadKey(intercept: true).Key != key)
        {
            Thread.Sleep(INTERVAL_BETWEEN_READS);
        }
    }

    /// <summary>
    /// Displays all the visible <see cref="Element"/> in the window.
    /// </summary>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
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
    /// Displays the given <see cref="Element"/> in the window.
    /// </summary>
    /// <param name="elements">The <see cref="Element"/> to be displayed.</param>
    /// <exception cref="ElementNotFoundException">Thrown when the element is not found in the <see cref="Window"/>.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
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
    /// Renders the space of all visible <see cref="Element"/> in the window.
    /// May ignore the visibility to display the hidden <see cref="Element"/> spaces.
    /// </summary>
    /// <param name="ignoreVisibility">If true, the space of the hidden <see cref="Element"/> will be drawn.</param>
    /// <returns>True if the space of the <see cref="Element"/> is successfully drawn, false otherwise.</returns>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public static bool RenderElementsSpace(bool ignoreVisibility = false)
    {
        foreach (var element in s_elements)
        {
            element.RenderElementSpace(ignoreVisibility);
        }
        return true;
    }

    /// <summary>
    /// Clears the console given a range of lines.
    /// </summary>
    /// <param name="continuous">If true, the window will be cleared continuously.</param>
    /// <param name="startLine">The start line of the window to be cleared.</param>
    /// <param name="length">The number of lines to be cleared.</param>
    /// <param name="step">The step of the window to be cleared.</param>
    /// <returns>True if the window is successfully cleared, false otherwise.</returns>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
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
                    Placement.TopCenter,
                    false,
                    i
                );
            }
        }
        return true;
    }

    /// <summary>
    /// Clears the console and hide the cursor.
    /// </summary>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public static void Open()
    {
        Clear();
        Console.CursorVisible = false;
    }

    /// <summary>
    /// Clears the console, show the cursor, and exit the program.
    /// </summary>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public static void Close()
    {
        Core.LoadTerminalColorPanel();
        Clear(true);
        Console.CursorVisible = true;
        Console.SetCursorPosition(0, 0);
        Environment.Exit(0);
    }
    #endregion
}
