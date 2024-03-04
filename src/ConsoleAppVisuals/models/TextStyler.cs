/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals.Models;

/// <summary>
/// The class that styles any text with specified font files.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public class TextStyler
{
    #region Constants: Paths, supported characters
    private const string DEFAULT_FONT_PATH = "ConsoleAppVisuals.fonts.";
    private const string DEFAULT_CONFIG_PATH = ".config.yml";
    private const string DEFAULT_ALPHABET_PATH = ".data.alphabet.txt";
    private const string DEFAULT_NUMBERS_PATH = ".data.numbers.txt";
    private const string DEFAULT_SYMBOLS_PATH = ".data.symbols.txt";
    private const string CONFIG_PATH = "config.yml";
    private const string ALPHABET_PATH = "data/alphabet.txt";
    private const string NUMBERS_PATH = "data/numbers.txt";
    private const string SYMBOLS_PATH = "data/symbols.txt";
    #endregion

    #region Fields: Font path, config, dictionary
    private readonly Font _font;
    private readonly string? _fontPath;
    private readonly FontYamlFile _config;
    private readonly Dictionary<char, string> _dictionary;
    private readonly string _supportedAlphabet;
    private readonly string _supportedNumbers;
    private readonly string _supportedSymbols;
    private readonly string _author;
    #endregion

    #region Properties: Dictionary
    /// <summary>
    /// The dictionary that stores the characters and their styled equivalent.
    /// </summary>
    public Dictionary<char, string> Dictionary => _dictionary;

    /// <summary>
    /// The font to use. Font.Custom if you want to use your own font.
    /// </summary>
    public Font Font => _font;

    /// <summary>
    /// The path to the font files. Null if the font is not custom.
    /// </summary>
    public string? FontPath => _fontPath;

    /// <summary>
    /// The supported alphabet by the font.
    /// </summary>
    public string SupportedAlphabet => _supportedAlphabet;

    /// <summary>
    /// The supported numbers by the font.
    /// </summary>
    public string SupportedNumbers => _supportedNumbers;

    /// <summary>
    /// The supported symbols by the font.
    /// </summary>
    public string SupportedSymbols => _supportedSymbols;
    #endregion

    #region Constructor
    /// <summary>
    /// The constructor of the TextStyler class.
    /// </summary>
    /// <param name="source">The font to use. Font.Custom if you want to use your own font.</param>
    /// <param name="fontPath">ATTENTION: only use the path to the font files for custom fonts.</param>
    /// <param name="assembly">ATTENTION: Debug purposes only. Do not update it.</param>
    /// <exception cref="EmptyFileException">Thrown when the config.yml file is empty.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public TextStyler(
        Font source = Font.ANSI_Shadow,
        string? fontPath = null,
        Assembly? assembly = null
    )
    {
        if (source is Font.Custom && fontPath is null)
        {
            throw new ArgumentNullException(
                nameof(fontPath),
                "No font path provided for a custom font."
            );
        }
        _font = source;
        _fontPath = fontPath;
        _dictionary = new Dictionary<char, string>();

        string yamlContent;
        if (source is Font.Custom)
        {
            yamlContent = File.ReadAllText(_fontPath + CONFIG_PATH);
        }
        else if (Enum.IsDefined(typeof(Font), source))
        {
            assembly ??= Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream(
                DEFAULT_FONT_PATH + source.ToString() + DEFAULT_CONFIG_PATH
            );
            using var reader = new StreamReader(stream ?? throw new FileNotFoundException());
            yamlContent = reader.ReadToEnd();
        }
        else
        {
            throw new ArgumentException(
                nameof(source),
                "Font not recognized. Use Font.Custom for custom fonts."
            );
        }

        (_config, _supportedAlphabet, _supportedNumbers, _supportedSymbols, _author) = ParseYaml(
            yamlContent
        );

        BuildDictionary();
    }

    private (FontYamlFile, string, string, string, string) ParseYaml(string yamlContent)
    {
        FontYamlFile config;
        string alphabet;
        string numbers;
        string symbols;

        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        config = deserializer.Deserialize<FontYamlFile>(yamlContent);

        if (config.Name is null)
        {
            throw new FormatException("Name is not defined in the config.yml file.");
        }

        if (config.Author is null)
        {
            throw new FormatException(
                "Author is not defined in the config.yml file. If Unknown, use 'Unknown'."
            );
        }

        if (config.Height is null)
        {
            throw new FormatException("Height is not defined in the config.yml file.");
        }
        if (config.Height < 1)
        {
            throw new InvalidCastException("Height must be greater than 0.");
        }

        if (config.Chars is null)
        {
            throw new FormatException("Chars is not defined in the config.yml file.");
        }

        if (config.Chars["alphabet"] is null or "")
        {
            alphabet = "";
        }
        else
        {
            ValidateTextFile(
                _font is Font.Custom
                    ? _fontPath + ALPHABET_PATH
                    : DEFAULT_FONT_PATH + _font.ToString() + DEFAULT_ALPHABET_PATH,
                (int)config.Height
            );
            alphabet = config.Chars["alphabet"];
        }

        if (config.Chars["numbers"] is null or "")
        {
            numbers = "";
        }
        else
        {
            ValidateTextFile(
                _font is Font.Custom
                    ? _fontPath + NUMBERS_PATH
                    : DEFAULT_FONT_PATH + _font.ToString() + DEFAULT_NUMBERS_PATH,
                (int)config.Height
            );
            numbers = config.Chars["numbers"];
        }

        if (config.Chars["symbols"] is null or "")
        {
            symbols = "";
        }
        else
        {
            ValidateTextFile(
                _font is Font.Custom
                    ? _fontPath + SYMBOLS_PATH
                    : DEFAULT_FONT_PATH + _font.ToString() + DEFAULT_SYMBOLS_PATH,
                (int)config.Height
            );
            symbols = config.Chars["symbols"];
        }

        return (config, alphabet, numbers, symbols, config.Author);
    }

    private void ValidateTextFile(string filePath, int expectedHeight)
    {
        string[] lines;
        if (_font is Font.Custom)
        {
            lines = File.ReadAllLines(filePath);
        }
        else
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream(filePath);
            using var reader = new StreamReader(stream ?? throw new EmptyFileException());
            lines = reader.ReadToEnd().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        }

        if (lines.Length % expectedHeight != 0)
        {
            throw new FormatException(
                $"Invalid number of lines in file: {filePath}. "
                    + $"Number of lines: {lines.Length}, "
                    + $"Expected multiple of: {expectedHeight}"
            );
        }

        for (int i = 0; i < lines.Length; i++)
        {
            var index = i + 1;
            if (index % expectedHeight == 0 && index != 1)
            {
                var line = lines[i].TrimEnd('\r', '\n');
                if (!line.EndsWith("@@"))
                {
                    var endOfLine = line.Length > 10 ? line.Substring(line.Length - 10) : line;
                    throw new FormatException(
                        $"Character end line not ending with @@. Error in file: {filePath}, Line: {index}, End of line: {endOfLine}"
                    );
                }
            }
            else
            {
                var line = lines[i].TrimEnd('\r', '\n');
                if (!line.EndsWith("@"))
                {
                    var endOfLine = line.Length > 10 ? line.Substring(line.Length - 10) : line;
                    throw new FormatException(
                        $"Character line not ending with @. Error in file: {filePath}, Line: {index}, End of line: {endOfLine}"
                    );
                }
            }
        }
    }

    private void BuildDictionary()
    {
        if (_supportedAlphabet != "")
        {
            AddAlphabetToDictionary();
        }

        if (_supportedNumbers != "")
        {
            AddNumbersToDictionary();
        }

        if (_supportedSymbols != "")
        {
            AddSymbolsToDictionary();
        }
    }

    private void AddAlphabetToDictionary()
    {
        List<string> alphabetStyled;
        alphabetStyled = ReadResourceLines(
            _font is Font.Custom ? ALPHABET_PATH : DEFAULT_ALPHABET_PATH
        );

        var alphabetStyledGrouped = alphabetStyled
            .Select((line, index) => new { line, index })
            .GroupBy(x => x.index / _config.Height)
            .Select(g => string.Join(Environment.NewLine, g.Select(x => x.line)))
            .ToList();

        for (int i = 0; i < SupportedAlphabet.Length; i++)
        {
            _dictionary.Add(SupportedAlphabet[i], alphabetStyledGrouped[i]);
        }
    }

    private void AddNumbersToDictionary()
    {
        List<string> numbersStyled;

        numbersStyled = ReadResourceLines(
            _font is Font.Custom ? NUMBERS_PATH : DEFAULT_NUMBERS_PATH
        );

        var numbersStyledGrouped = numbersStyled
            .Select((line, index) => new { line, index })
            .GroupBy(x => x.index / _config.Height)
            .Select(g => string.Join(Environment.NewLine, g.Select(x => x.line)))
            .ToList();

        for (int i = 0; i < SupportedNumbers.Length; i++)
        {
            _dictionary.Add(SupportedNumbers[i], numbersStyledGrouped[i]);
        }
    }

    private void AddSymbolsToDictionary()
    {
        List<string> symbolsStyled;

        symbolsStyled = ReadResourceLines(
            _font is Font.Custom ? SYMBOLS_PATH : DEFAULT_SYMBOLS_PATH
        );

        var symbolsStyledGrouped = symbolsStyled
            .Select((line, index) => new { line, index })
            .GroupBy(x => x.index / _config.Height)
            .Select(g => string.Join(Environment.NewLine, g.Select(x => x.line)))
            .ToList();

        for (int i = 0; i < SupportedSymbols.Length; i++)
        {
            _dictionary.Add(SupportedSymbols[i], symbolsStyledGrouped[i]);
        }
    }

    private List<string> ReadResourceLines(string path)
    {
        List<string> lines;

        if (_font is Font.Custom)
        {
            lines = File.ReadLines(_fontPath + path).ToList();
        }
        else
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream(
                DEFAULT_FONT_PATH + _font.ToString() + path
            );
            using var reader = new StreamReader(
                stream
                    ?? throw new EmptyFileException(
                        "Font file not found or empty. No data extracted."
                    )
            );
            lines = reader
                .ReadToEnd()
                .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                .ToList();
        }

        return CleanupLines(lines);
    }

    private static List<string> CleanupLines(List<string> lines)
    {
        for (int i = 0; i < lines.Count; i++)
        {
            lines[i] = lines[i].Replace("@", "");
        }

        return lines;
    }
    #endregion

    #region Methods: Style text
    /// <summary>
    /// Styles the given text with the font files.
    /// </summary>
    /// <param name="text">The text to style.</param>
    /// <returns>The styled text.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public string StyleTextToString(string text)
    {
        var lines = new List<string[]>();
        foreach (char c in text)
        {
            if (_dictionary.ContainsKey(c))
                lines.Add(
                    _dictionary[c].Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                );
            else
                throw new NotSupportedCharException($"The character '{c}' is not supported.");
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
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public string[] StyleTextToStringArray(string text)
    {
        var lines = new List<string[]>();
        foreach (char c in text)
        {
            if (_dictionary.ContainsKey(c))
                lines.Add(
                    _dictionary[c].Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                );
            else
                throw new NotSupportedCharException($"The character '{c}' is not supported.");
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
    /// <exception cref="EmptyFileException">Thrown when the config.yml file is empty.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Name: {_config.Name}");
        sb.AppendLine($"Author: {_config.Author}");
        sb.AppendLine($"Height: {_config.Height}");
        if (_config.Chars != null)
        {
            sb.AppendLine($"List of supported chars:\n");

            foreach (KeyValuePair<string, string> pair in _config.Chars)
            {
                sb.AppendLine($"File: {pair.Key}, supported chars: {pair.Value}");
            }
        }
        return sb.ToString();
    }
    #endregion
}
