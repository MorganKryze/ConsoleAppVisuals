/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Models;

/// <summary>
/// The <see cref="TextStyler"/> class is a class that styles text with the font files.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class TextStyler
{
    #region Constants
    private const string DEFAULT_FONT_PATH = "ConsoleAppVisuals.fonts.";
    private const string DEFAULT_CONFIG_PATH = ".config.yml";
    private const string DEFAULT_ALPHABET_PATH = ".data.alphabet.txt";
    private const string DEFAULT_NUMBERS_PATH = ".data.numbers.txt";
    private const string DEFAULT_SYMBOLS_PATH = ".data.symbols.txt";
    private const string CONFIG_PATH = "config.yml";
    private const string ALPHABET_PATH = "data/alphabet.txt";
    private const string NUMBERS_PATH = "data/numbers.txt";
    private const string SYMBOLS_PATH = "data/symbols.txt";
    private const int DEFAULT_MAX_DISPLAY_LENGTH_ERRORS = 10;
    #endregion

    #region Fields
    private readonly Font _font;
    private readonly string? _fontPath;
    private readonly FontYamlFile _config;
    private readonly Dictionary<char, string> _dictionary;
    private readonly string _supportedAlphabet;
    private readonly string _supportedNumbers;
    private readonly string _supportedSymbols;
    #endregion

    #region Properties
    /// <summary>
    /// Gets the dictionary that stores the characters and their styled equivalent.
    /// </summary>
    public Dictionary<char, string> Dictionary => _dictionary;

    /// <summary>
    /// Gets the font to use. Font.Custom if you want to use your own font.
    /// </summary>
    public Font Font => _font;

    /// <summary>
    /// Gets the path to the font files. Null if the font is not custom.
    /// </summary>
    public string? FontPath => _fontPath;

    /// <summary>
    /// Gets the supported alphabet by the font.
    /// </summary>
    public string SupportedAlphabet => _supportedAlphabet;

    /// <summary>
    /// Gets the supported numbers by the font.
    /// </summary>
    public string SupportedNumbers => _supportedNumbers;

    /// <summary>
    /// Gets the supported symbols by the font.
    /// </summary>
    public string SupportedSymbols => _supportedSymbols;

    /// <summary>
    /// Gets all the supported characters by the font.
    /// </summary>
    public string SupportedChars => _supportedAlphabet + _supportedNumbers + _supportedSymbols;
    #endregion

    #region Constructor
    /// <summary>
    /// The <see cref="TextStyler"/> class is a class that styles text with the font files.
    /// </summary>
    /// <param name="source">The font to use. Font.Custom if you want to use your own font.</param>
    /// <param name="fontPath">ATTENTION: only use the path to the font files for custom fonts.</param>
    /// <param name="assembly">ATTENTION: Debug purposes only. Do not update it.</param>
    /// <exception cref="EmptyFileException">Thrown when the config.yml file is empty.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
                "A Custom font path implies a non-null value for fontPath."
            );
        }
        else if (source is not Font.Custom && fontPath is not null)
        {
            throw new ArgumentException(
                "A non-Custom font implies a null value for fontPath.",
                nameof(fontPath)
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
                "Font not recognized. Use Font.Custom for custom fonts.",
                nameof(source)
            );
        }

        (_config, _supportedAlphabet, _supportedNumbers, _supportedSymbols) = ParseYaml(
            yamlContent
        );

        BuildDictionary();
    }
    #endregion

    #region Parsing
    private (FontYamlFile, string, string, string) ParseYaml(string yamlContent)
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

        return (config, alphabet, numbers, symbols);
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
                    var endOfLine =
                        line.Length > DEFAULT_MAX_DISPLAY_LENGTH_ERRORS
                            ? line.Substring(line.Length - DEFAULT_MAX_DISPLAY_LENGTH_ERRORS)
                            : line;
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
                    var endOfLine =
                        line.Length > DEFAULT_MAX_DISPLAY_LENGTH_ERRORS
                            ? line.Substring(line.Length - DEFAULT_MAX_DISPLAY_LENGTH_ERRORS)
                            : line;
                    throw new FormatException(
                        $"Character line not ending with @. Error in file: {filePath}, Line: {index}, End of line: {endOfLine}"
                    );
                }
            }
        }
    }
    #endregion

    #region Build
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

    #region Methods
    /// <summary>
    /// Styles the given text with the font files.
    /// </summary>
    /// <param name="text">The text to style.</param>
    /// <returns>The styled text as a string array.</returns>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public string[] Style(string text)
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
    /// Gets the info of the actual style (from the config.yml file).
    /// </summary>
    /// <returns>A string compiling these pieces of information.</returns>
    /// <exception cref="EmptyFileException">Thrown when the config.yml file is empty.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
