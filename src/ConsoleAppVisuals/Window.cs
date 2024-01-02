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
    /// <param name="visibility">If true, will try to toggle the visibility of the element.</param>
    public static void AddElement(Element element, bool visibility = false)
    {
        _elements.Add(element);
        if (visibility && AllowVisibilityToggle(element.Id))
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
        UpdateIDs();
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
            UpdateIDs();
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(element), "Invalid element. Not found in the window.");
        }
    }

    private static void UpdateIDs()
    {
        for (int i = 0; i < _elements.Count; i++)
        {
            _elements[i].Id = i;
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
    /// This method checks if the element can be toggled to visible.
    /// </summary>
    /// <param name="id">The id of the element.</param>
    /// <returns>True if the element can be toggled to visible, false otherwise.</returns>
    public static bool AllowVisibilityToggle(int id)
    {
        int numberOfVisibleElements = _elements.Count(
            element => element.GetType() == _elements[id].GetType() && element.Visibility
        );
        return numberOfVisibleElements < _elements[id].MaxNumberOfThisElement;
    }

    /// <summary>
    /// This method attempts to activate the visibility of the element with the given id.
    /// </summary>
    /// <param name="id">The id of the element.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the id is out of range.</exception>
    public static void ActivateElement(int id)
    {
        if (id < 0 || id >= _elements.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Invalid element ID.");
        }
        if (!_elements[id].Visibility)
        {
            _elements[id].ToggleVisibility();
        }
    }

    /// <summary>
    /// This method attempts to activate the visibility of all elements.
    /// </summary>
    public static void ActivateAllElements()
    {
        foreach (var element in _elements)
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
    public static void DeactivateElement(int id)
    {
        if (id < 0 || id >= _elements.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Invalid element ID.");
        }
        if (_elements[id].Visibility)
        {
            _elements[id].ToggleVisibility();
        }
    }

    /// <summary>
    /// This method deactivate the visibility of all elements.
    /// </summary>
    public static void DeactivateAllElements()
    {
        foreach (var element in _elements)
        {
            if (element.Visibility)
            {
                element.ToggleVisibility();
            }
        }
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
    /// This method gives a list of all classes inheriting from the Element class.
    /// </summary>
    /// <returns></returns>
    public static void ListClassesInheritingElement()
    {
        var types = new List<Type>();
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            // Exclude default C# assemblies
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
        Table<string> table = new(new List<string> { "Id", "Type", "Project" });
        var id = 0;
        foreach (var type in types)
        {
            table.AddLine(
                new List<string> { $"{id}", type.Name, type.Assembly.GetName().Name ?? "Unknown" }
            );
            id += 1;
        }
        table.Render();
    }
    #endregion
}
