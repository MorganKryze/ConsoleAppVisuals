/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// Enum for the output of the scrolling menus.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
/// </list>
/// </remarks>
public enum Output
{
    /// <summary>
    /// Default value.
    /// </summary>
    None,

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
