/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// The major class of the library. The window is used to collect the elements of the console and draw them.
/// </summary>
public static class Window
{
    #region Fields
    private static readonly List<IElement> elements = new();

    /// <summary>
    /// The default visibility of the elements.
    /// </summary>
    public static bool DefaultVisibility { get; set; } = false;
    #endregion

    #region Properties
    /// <summary>
    /// Gives the next id number.
    /// </summary>
    public static int NextId => elements.Count;
    #endregion

    #region Manipulation Methods
    /// <summary>
    /// This method returns the element with the given id.
    /// </summary>
    /// <param name="id">The id of the element.</param>
    /// <returns>The element with the given id if it exists, null otherwise.</returns>
    public static IElement? GetElement(int id)
    {
        if (id < 0 || id >= elements.Count)
        {
            return null;
        }
        return elements[id];
    }

    /// <summary>
    /// This method adds an element to the window.
    /// </summary>
    /// <param name="element">The element to be added.</param>
    public static void AddElement(IElement element)
    {
        elements.Add(element);
    }

    /// <summary>
    /// This method inserts an element to the window at the given id.
    /// </summary>
    /// <param name="element">The element to be inserted.</param>
    /// <param name="id">The id of the element.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the id is out of range.</exception>
    public static void InsertElement(IElement element, int id)
    {
        if (id < 0 || id > elements.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Invalid element ID.");
        }
        elements.Insert(id, element);
    }

    /// <summary>
    /// This method removes the element with the given id.
    /// </summary>
    /// <param name="id">The id of the element.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the id is out of range.</exception>
    public static void RemoveElement(int id)
    {
        if (id < 0 || id >= elements.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Invalid element ID.");
        }
        elements.RemoveAt(id);
    }

    /// <summary>
    /// This method removes the given element.
    /// </summary>
    /// <param name="element">The element to be removed.</param>
    public static void RemoveElement(IElement element)
    {
        if (element != null && elements.Contains(element))
        {
            elements.Remove(element);
        }
    }

    /// <summary>
    /// This method removes all elements from the window.
    /// </summary>
    public static void RemoveAllElements()
    {
        elements.Clear();
    }
    #endregion

    #region Utility Methods
    /// <summary>
    /// This method clears the window.
    /// </summary>
    public static void Clear()
    {
        Console.Clear();
    }

    /// <summary>
    /// This method displays a list of all elements in the window.
    /// </summary>
    public static void ListElements()
    {
        Table<string> table =
            new(new List<string> { "Id", "Type", "Visibility", "Height", "Width" });
        foreach (var element in elements)
        {
            table.AddLine(
                new List<string>
                {
                    element.Id.ToString(),
                    element.GetType().Name,
                    element.Visibility.ToString(),
                    element.Height.ToString(),
                    element.Width.ToString()
                }
            );
        }
        table.Render();
    }

    /// <summary>
    /// This method checks if the element can be toggled to visible.
    /// </summary>
    /// <param name="id">The id of the element.</param>
    /// <returns>True if the element can be toggled to visible, false otherwise.</returns>
    public static bool AllowVisibilityChange(int id)
    {
        int numberOfVisibleElements = elements.Count(
            element => element.GetType() == elements[id].GetType() && element.Visibility
        );
        return numberOfVisibleElements < elements[id].MaxNumberOfThisElement;
    }

    /// <summary>
    /// This method draws all the elements of the window on the console.
    /// </summary>
    public static void Render()
    {
        foreach (var element in elements)
        {
            element.Render();
        }
    }
    #endregion
}
