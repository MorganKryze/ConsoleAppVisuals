using YamlDotNet.Serialization;

namespace ConsoleAppVisuals;
/// <summary>
/// The <see cref="FontYamlFile"/> class defines the structure of a yaml file used to store the height of each character of a font.
/// </summary>
public class FontYamlFile
{
    /// <summary>
    /// The name of the font.
    /// </summary>
    // [YamlMember(Alias = "name", ApplyNamingConventions = false)]
    public required string Name { get; set; }
    /// <summary>
    /// The height of the elements of the font.
    /// </summary>
    public required Dictionary<string, int> Chars { get; set; }
    
}
