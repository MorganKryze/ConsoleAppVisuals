/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;
/// <summary>
/// The class that styles any text with specified font files.
/// </summary> 
public class TextStyler
{
    #region Constants
    private const string DEFAULT_FONT_PATH = "ConsoleAppVisuals.fonts.ANSI_Shadow";
    private const string DEFAULT_CONFIG_PATH = ".config.yml";
    private const string DEFAULT_ALPHABET_PATH = ".data.alphabet.txt";
    private const string DEFAULT_NUMBERS_PATH = ".data.numbers.txt";
    private const string DEFAULT_SYMBOLS_PATH = ".data.symbols.txt";
    private const string CONFIG_PATH = "config.yml";
    private const string ALPHABET_PATH = "data/alphabet.txt";
    private const string NUMBERS_PATH = "data/numbers.txt";
    private const string SYMBOLS_PATH = "data/symbols.txt";
    private const string SUPPORTED_ALPHABET = "abcdefghijklmnopqrstuvwxyz";
    private const string SUPPORTED_NUMBERS = "0123456789";
    private const string SUPPORTED_SYMBOLS = "?!:.,;/-_()[]%$^*@ ";
    #endregion

    #region Attributes
    /// <summary>
    /// The path to the font files.
    /// </summary>
    private readonly string? fontPath;
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
    /// <exception cref="NullReferenceException">Thrown when the config.yml file is empty.</exception>
    public TextStyler(string? fontPath = null)
    {
        this.fontPath = fontPath;
        dictionary = new Dictionary<char, string>();

        string yamlContent;
        if (fontPath is null)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream(DEFAULT_FONT_PATH + DEFAULT_CONFIG_PATH);
            using var reader = new StreamReader(stream ?? throw new InvalidOperationException());
            yamlContent = reader.ReadToEnd();
        }
        else 
        {
            yamlContent = File.ReadAllText(this.fontPath + CONFIG_PATH);
        }

        var deserializer = new DeserializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
        config = deserializer.Deserialize<FontYamlFile>(yamlContent);

        DictionaryBuilder();
    }
    private void DictionaryBuilder()
    {
        List<string> alphabetStyled;
        List<string> numbersStyled;
        List<string> symbolsStyled;

        if (fontPath is null)
        {
            alphabetStyled = ReadResourceLines(DEFAULT_ALPHABET_PATH);
            numbersStyled = ReadResourceLines(DEFAULT_NUMBERS_PATH);
            symbolsStyled = ReadResourceLines(DEFAULT_SYMBOLS_PATH);
        }
        else 
        {
            alphabetStyled = ReadResourceLines(ALPHABET_PATH);
            numbersStyled = ReadResourceLines(NUMBERS_PATH);
            symbolsStyled = ReadResourceLines(SYMBOLS_PATH);
        }
        if (config.Chars is null)
            throw new NullReferenceException("The config.yml file is empty.");

        var alphabetStyledGrouped = alphabetStyled
            .Select((line, index) => new { line, index })
            .GroupBy(x => x.index / config.Chars["alphabet"])
            .Select(g => string.Join(Environment.NewLine, g.Select(x => x.line)))
            .ToList();
        var numbersStyledGrouped = numbersStyled
            .Select((line, index) => new { line, index })
            .GroupBy(x => x.index / config.Chars["numbers"])
            .Select(g => string.Join(Environment.NewLine, g.Select(x => x.line)))
            .ToList();
        var symbolsStyledGrouped = symbolsStyled
            .Select((line, index) => new { line, index })
            .GroupBy(x => x.index / config.Chars["symbols"])
            .Select(g => string.Join(Environment.NewLine, g.Select(x => x.line)))
            .ToList();

        for (int i = 0; i < SUPPORTED_ALPHABET.Length; i++)
            dictionary.Add(SUPPORTED_ALPHABET[i], alphabetStyledGrouped[i]);
        for (int i = 0; i < SUPPORTED_NUMBERS.Length; i++)
            dictionary.Add(SUPPORTED_NUMBERS[i], numbersStyledGrouped[i]);
        for (int i = 0; i < SUPPORTED_SYMBOLS.Length; i++)
            dictionary.Add(SUPPORTED_SYMBOLS[i], symbolsStyledGrouped[i]);
    }
    private List<string> ReadResourceLines(string path)
    {
        if (fontPath is null)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream(DEFAULT_FONT_PATH + path);
            using var reader = new StreamReader(stream ?? throw new InvalidOperationException());
            return reader.ReadToEnd().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();
        }
        else 
            return File.ReadLines(fontPath + path).ToList();
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
    /// Get the info of the actual style (from the config.yml file).
    /// </summary>
    /// <returns>A string compiling these pieces of information.</returns>
    /// <exception cref="NullReferenceException">Thrown when the config.yml file is empty.</exception>
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Name: {config.Name}");
        if(config.Chars is null)
            throw new NullReferenceException("The config.yml file is empty.");
        foreach (KeyValuePair<string, int> pair in config.Chars)
        {
            sb.AppendLine($"File: {pair.Key}, Height: {pair.Value}");
        }
        return sb.ToString();
    }
    #endregion
}