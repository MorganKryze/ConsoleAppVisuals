/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// Defines the basic properties of an console element.
/// </summary>
public interface IElement
{
    /// <summary>
    /// The id number of the element.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The visibility of the element.
    /// </summary>
    public bool Visibility { get; set; }

    /// <summary>
    /// The height of the element.
    /// </summary>
    public int Height { get; }

    /// <summary>
    /// The width of the element.
    /// </summary>
    public int Width { get; }

    /// <summary>
    /// This method is used to draw the element on the console.
    /// </summary>
    public void Render();
}
