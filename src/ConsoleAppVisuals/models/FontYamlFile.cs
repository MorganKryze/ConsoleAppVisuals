/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Models;

/// <summary>
/// The <see cref="FontYamlFile"/> class defines the structure of a yaml file used to store the height of each character of a font.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class FontYamlFile
{
    /// <summary>
    /// The name of the font.
    /// </summary>
    [YamlMember(Alias = "name", ApplyNamingConventions = false)]
    public string? Name { get; set; }

    /// <summary>
    /// The author of the font.
    /// </summary>
    [YamlMember(Alias = "author", ApplyNamingConventions = false)]
    public string? Author { get; set; }

    /// <summary>
    /// The height of each font element.
    /// </summary>
    [YamlMember(Alias = "height", ApplyNamingConventions = false)]
    public int? Height { get; set; }

    /// <summary>
    /// The height of the elements of the font.
    /// </summary>
    public Dictionary<string, string>? Chars { get; set; }
}
