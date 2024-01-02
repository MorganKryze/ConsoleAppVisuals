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
    private static readonly List<Element> _elements = new();

    /// <summary>
    /// The default visibility of the elements.
    /// </summary>
    public static bool DefaultVisibility { get; set; } = false;
    #endregion

    #region Properties
    /// <summary>
    /// Gives the next id number.
    /// </summary>
    public static int NextId => _elements.Count;

    /// <summary>
    /// Gives the number of elements in the window.
    /// </summary>
    public static int NumberOfElements => _elements.Count;
    #endregion

    #region Manipulation Methods
    /// <summary>
    /// This method returns the element with the given type.
    /// </summary>
    /// <typeparam name="T">The type of the element.</typeparam>
    /// <returns>The element with the given type if it exists, null otherwise.</returns>
    public static T? GetElement<T>()
        where T : Element
    {
        return _elements.Find(element => element.GetType() == typeof(T)) as T;
    }

    /// <summary>
    /// This method returns the element with the given id.
    /// </summary>
    /// <param name="id">The id of the element.</param>
    /// <returns>The element with the given id if it exists, null otherwise.</returns>
    public static T? GetElement<T>(int id)
        where T : Element
    {
        if (id < 0 || id >= _elements.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Invalid element ID.");
        }
        return (T)_elements[id];
    }

    /// <summary>
    /// This method returns the visible element with the given type.
    /// </summary>
    /// <typeparam name="T">The type of the element.</typeparam>
    /// <returns>The visible element with the given type if it exists, null otherwise.</returns>
    public static T? GetVisibleElement<T>()
        where T : Element
    {
        return _elements.Find(element => element.GetType() == typeof(T) && element.Visibility) as T;
    }

    /// <summary>
    /// This method adds an element to the window.
    /// </summary>
    /// <param name="element">The element to be added.</param>
    public static void AddElement(Element element)
    {
        _elements.Add(element);
    }

    /// <summary>
    /// This method inserts an element to the window at the given id.
    /// </summary>
    /// <param name="element">The element to be inserted.</param>
    /// <param name="id">The id of the element.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the id is out of range.</exception>
    public static void InsertElement(Element element, int id)
    {
        if (id < 0 || id > _elements.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Invalid element ID.");
        }
        _elements.Insert(id, element);
    }

    /// <summary>
    /// This method removes the element with the given id.
    /// </summary>
    /// <param name="id">The id of the element.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the id is out of range.</exception>
    public static void RemoveElement(int id)
    {
        if (id < 0 || id >= _elements.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Invalid element ID.");
        }
        _elements.RemoveAt(id);
    }

    /// <summary>
    /// This method removes the given element.
    /// </summary>
    /// <param name="element">The element to be removed.</param>
    public static void RemoveElement(Element element)
    {
        if (element != null && _elements.Contains(element))
        {
            _elements.Remove(element);
        }
    }

    /// <summary>
    /// This method removes all elements from the window.
    /// </summary>
    public static void RemoveAllElements()
    {
        _elements.Clear();
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
            new(new List<string> { "Id", "Type", "Visibility", "Height", "Width", "Line" });
        foreach (var element in _elements)
        {
            table.AddLine(
                new List<string>
                {
                    element.Id.ToString(),
                    element.GetType().Name,
                    element.Visibility.ToString(),
                    element.Height.ToString(),
                    element.Width.ToString(),
                    element.Line.ToString()
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
        int numberOfVisibleElements = _elements.Count(
            element => element.GetType() == _elements[id].GetType() && element.Visibility
        );
        return numberOfVisibleElements < _elements[id].MaxNumberOfThisElement;
    }

    /// <summary>
    /// This method draws all the elements of the window on the console.
    /// </summary>
    public static void Render()
    {
        foreach (var element in _elements)
        {
            element.Render();
        }
    }
    #endregion
}
