/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// The <see cref="Placement"/> enum defines the placement of a string in some space.
/// It could be another string or a console line.
/// </summary>
/// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
public enum Placement
{
    /// <summary>
    /// The object is placed in the top center of the space.
    /// </summary>
    TopCenter,
    /// <summary>
    /// The object is placed in the top left of the space.
    /// </summary>
    TopLeft,
    /// <summary>
    /// The object is placed in the top right of the space.
    /// </summary>
    TopRight,
    /// <summary>
    /// The object is placed in the bottom of the space.
    /// </summary>
    BottomCenter,
    /// <summary>
    /// The object is placed in the bottom left of the space.
    /// </summary>
    BottomLeft,
    /// <summary>
    /// The object is placed in the bottom right of the space.
    /// </summary>
    BottomRight
}
