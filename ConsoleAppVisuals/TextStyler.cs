using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ConsoleAppVisuals;
/// <summary>
/// The class that styles any text with specified font files.
/// </summary> 
public class TextStyler
{
    #region Constants
    private const string DEFAULT_FONT_PATH = "fonts/ANSI_Shadow/";
    private const string DEFAULT_CONFIG_PATH = "config.yml";
    private const string DEFAULT_ALPHABET_PATH = "/data/alphabet.txt";
    private const string DEFAULT_NUMBERS_PATH = "/data/numbers.txt";
    private const string DEFAULT_SYMBOLS_PATH = "/data/symbols.txt";
    private const string DEFAULT_SUPPORTED_ALPHABET = "abcdefghijklmnopqrstuvwxyz";
    private const string DEFAULT_SUPPORTED_NUMBERS = "0123456789";
    private const string DEFAULT_SUPPORTED_SYMBOLS = "?!:.,;/-_()[]%$^*@ ";
    #endregion

    #region Attributes
    /// <summary>
    /// The path to the font files.
    /// </summary>
    private readonly string fontPath;
    /// <summary>
    /// The config.yml file deserialized.
    /// </summary>
    private readonly FontYamlFile config;
    /// <summary>
    /// A dictionary that stores the characters and their styled equivalent.
    /// </summary>
    public Dictionary<char, string> dictionary;
    #endregion
    
    #region Constructor
    /// <summary>
    /// The constructor of the TextStyler class.
    /// </summary>
    /// <param name="fontPath">The path to the font files.</param>
    /// <exception cref="FileNotFoundException">If the given path is incorrect or the config.yml file is absent.</exception>
    public TextStyler(string fontPath = DEFAULT_FONT_PATH)
    {
        this.fontPath = fontPath;
        dictionary = new Dictionary<char, string>();

        string yamlContent;
        try 
        {
            yamlContent = File.ReadAllText(this.fontPath + DEFAULT_CONFIG_PATH);
        }
        catch (FileNotFoundException)
        {
            yamlContent = File.ReadAllText(DEFAULT_FONT_PATH + DEFAULT_CONFIG_PATH);
        }
        
        var deserializer = new DeserializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
        config = deserializer.Deserialize<FontYamlFile>(yamlContent);
        
        DictionaryBuilder();
    }
    private void DictionaryBuilder()
    {
        var alphabetStyled = File.ReadLines(fontPath + DEFAULT_ALPHABET_PATH).ToList();
        var alphabetStyledGrouped = alphabetStyled
            .Select((line, index) => new { line, index })
            .GroupBy(x => x.index / config.Chars["alphabet"])
            .Select(g => string.Join(Environment.NewLine, g.Select(x => x.line)))
            .ToList();

        var numbersStyled = File.ReadLines(fontPath + DEFAULT_NUMBERS_PATH).ToList();
        var numbersStyledGrouped = numbersStyled
            .Select((line, index) => new { line, index })
            .GroupBy(x => x.index / config.Chars["numbers"])
            .Select(g => string.Join(Environment.NewLine, g.Select(x => x.line)))
            .ToList();

        var symbolsStyled = File.ReadLines(fontPath + DEFAULT_SYMBOLS_PATH).ToList();
        var symbolsStyledGrouped = symbolsStyled
            .Select((line, index) => new { line, index })
            .GroupBy(x => x.index / config.Chars["symbols"])
            .Select(g => string.Join(Environment.NewLine, g.Select(x => x.line)))
            .ToList();
        
        for (int i = 0; i < DEFAULT_SUPPORTED_ALPHABET.Length; i++)
            dictionary.Add(DEFAULT_SUPPORTED_ALPHABET[i], alphabetStyledGrouped[i]);
        for (int i = 0; i < DEFAULT_SUPPORTED_NUMBERS.Length; i++)
            dictionary.Add(DEFAULT_SUPPORTED_NUMBERS[i], numbersStyledGrouped[i]);
        for (int i = 0; i < DEFAULT_SUPPORTED_SYMBOLS.Length; i++)
            dictionary.Add(DEFAULT_SUPPORTED_SYMBOLS[i], symbolsStyledGrouped[i]);
    }
    #endregion

    #region Methods
    /// <summary>
    /// Styles the given text with the font files.
    /// </summary>
    /// <param name="text">The text to style.</param>
    /// <returns>The styled text.</returns>
    public string StyleTextToString(string text)
    {
        text = text.ToLower();
        var lines = new List<string[]>();
        foreach (char c in text)
        {
            if (dictionary.ContainsKey(c))
                lines.Add(dictionary[c].Split(new[] { Environment.NewLine }, StringSplitOptions.None));
            else
                lines.Add(dictionary[' '].Split(new[] { Environment.NewLine }, StringSplitOptions.None));
        }

        var sb = new StringBuilder();
        for (int i = 0; i < lines[0].Length; i++)
        {
            foreach (var line in lines)
            {
                sb.Append(line[i]);
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }
    /// <summary>
    /// Styles the given text with the font files.
    /// </summary>
    /// <param name="text">The text to style.</param>
    /// <returns>The styled text as a string array.</returns>
    public string[] StyleTextToStringArray(string text)
    {
        text = text.ToLower();
        var lines = new List<string[]>();
        foreach (char c in text)
        {
            if (dictionary.ContainsKey(c))
                lines.Add(dictionary[c].Split(new[] { Environment.NewLine }, StringSplitOptions.None));
            else
                lines.Add(dictionary[' '].Split(new[] { Environment.NewLine }, StringSplitOptions.None));
        }
    
        var result = new List<string>();
        for (int i = 0; i < lines[0].Length; i++)
        {
            var sb = new StringBuilder();
            foreach (var line in lines)
            {
                sb.Append(line[i]);
            }
            result.Add(sb.ToString());
        }
    
        return result.ToArray();
    }
    /// <summary>
    /// Gives the caracteristics of the actual style (from the config.yml file).
    /// </summary>
    /// <returns>A string compiling these pieces of information.</returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Name: {config.Name}");
        foreach (KeyValuePair<string, int> pair in config.Chars)
        {
            sb.AppendLine($"File: {pair.Key}, Height: {pair.Value}");
        }
        return sb.ToString();
    }
    #endregion
}