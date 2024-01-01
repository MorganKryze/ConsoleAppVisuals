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
    public static bool DefaultVisibility { get; set; } = true;
    #endregion

    #region Properties
    /// <summary>
    /// Gives the next id number.
    /// </summary>
    public static int NextId => elements.Count;

    #endregion

    #region Methods
    /// <summary>
    /// This method adds an element to the window.
    /// </summary>
    /// <param name="element">The element to be added.</param>
    public static void AddElement(IElement element)
    {
        elements.Add(element);
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
