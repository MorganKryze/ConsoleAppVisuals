/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals.Models;

/// <summary>
/// The <see cref="FontYamlFile"/> class defines the structure of a yaml file used to store the height of each character of a font.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
/// </list>
/// </remarks>
public class FontYamlFile
{
    /// <summary>
    /// The name of the font.
    /// </summary>
    // [YamlMember(Alias = "name", ApplyNamingConventions = false)]
    public string? Name { get; set; }

    /// <summary>
    /// The height of the elements of the font.
    /// </summary>
    public Dictionary<string, int>? Chars { get; set; }
}
