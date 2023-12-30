/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// Enum for the output of the scrolling menus.
/// </summary>
/// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
public enum Output
{
    /// <summary>
    /// Chose to validate the input.
    /// </summary>
    Select,

    /// <summary>
    /// Chose to delete an item.
    /// </summary>
    Delete,

    /// <summary>
    /// Chose to exit the menu.
    /// </summary>
    Exit
}
