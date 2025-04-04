/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.PassiveElements;

/// <summary>
/// The <see cref="ASCIIArt"/> is a passive element that displays ASCII art from a file or string content.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class ASCIIArt : PassiveElement
{
    #region Constants
    const Placement DEFAULT_PLACEMENT = Placement.TopCenter;
    #endregion

    #region Fields
    private List<string> _artLines;
    private Placement _placement;
    #endregion

    #region Default Properties
    /// <summary>
    /// Gets the position of the ASCIIArt element on the screen.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// Gets the alignment of the ASCIIArt element.
    /// </summary>
    public override TextAlignment TextAlignment => TextAlignment.Left; // ASCII art should always be left-aligned to preserve structure

    /// <summary>
    /// Gets the height of the ASCIIArt element.
    /// </summary>
    public override int Height => _artLines.Count;

    /// <summary>
    /// Gets the width of the ASCIIArt element.
    /// </summary>
    public override int Width => _artLines.Count > 0 ? _artLines.Max(s => s.Length) : 0;
    #endregion

    #region Properties
    /// <summary>
    /// Gets the art lines of the ASCIIArt element.
    /// </summary>
    public List<string> ArtLines => _artLines;
    #endregion

    #region Constructor
    /// <summary>
    /// The <see cref="ASCIIArt"/> is a passive element that displays ASCII art from a file.
    /// </summary>
    /// <param name="filePath">The path to the file containing the ASCII art.</param>
    /// <param name="placement">The placement of the ASCIIArt element on the screen.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public ASCIIArt(string filePath, Placement placement = DEFAULT_PLACEMENT)
    {
        _artLines = new List<string>();
        LoadFromFile(filePath);
        _placement = placement;
        CheckIntegrity();
    }

    /// <summary>
    /// The <see cref="ASCIIArt"/> is a passive element that displays ASCII art from a list of strings.
    /// </summary>
    /// <param name="artLines">The lines of ASCII art to display.</param>
    /// <param name="placement">The placement of the ASCIIArt element on the screen.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public ASCIIArt(List<string> artLines, Placement placement = DEFAULT_PLACEMENT)
    {
        _artLines = artLines;
        _placement = placement;
        CheckIntegrity();
    }

    #endregion

    #region Update Methods
    private void CheckIntegrity()
    {
        if (_artLines.Count == 0)
        {
            throw new ArgumentException("The ASCII art is empty.");
        }
    }

    /// <summary>
    /// Loads ASCII art from a file.
    /// </summary>
    /// <param name="filePath">The path to the file containing the ASCII art.</param>
    /// <exception cref="FileNotFoundException">Thrown when the file is not found.</exception>
    private void LoadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"ASCII art file not found: {filePath}");
        }

        _artLines = File.ReadAllLines(filePath).ToList();
    }

    /// <summary>
    /// Updates the ASCII art from a file.
    /// </summary>
    /// <param name="filePath">The path to the file containing the new ASCII art.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateFromFile(string filePath)
    {
        _artLines.Clear();
        LoadFromFile(filePath);
        CheckIntegrity();
    }

    /// <summary>
    /// Updates the ASCII art lines.
    /// </summary>
    /// <param name="artLines">The new ASCII art lines.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateArtLines(List<string> artLines)
    {
        _artLines = artLines;
        CheckIntegrity();
    }

    /// <summary>
    /// Updates the ASCII art from a multiline string.
    /// </summary>
    /// <param name="art">The new ASCII art as a multiline string.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateArt(string art)
    {
        _artLines = art.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None).ToList();
        CheckIntegrity();
    }

    /// <summary>
    /// Updates the placement of the ASCIIArt element on the screen.
    /// </summary>
    /// <param name="newPlacement">The new placement of the ASCIIArt element.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdatePlacement(Placement newPlacement)
    {
        _placement = newPlacement;
    }
    #endregion

    #region Rendering
    /// <summary>
    /// Defines the actions to perform when the element is called to be rendered on the console.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        Core.WriteMultiplePositionedLines(
            false,
            TextAlignment.Left,
            Placement,
            false,
            Line,
            _artLines.ToArray()
        );
    }
    #endregion
}
