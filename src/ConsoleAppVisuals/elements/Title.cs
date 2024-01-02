/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// Defines the title of the console window.
/// </summary>
public class Title : Element
{
    #region Fields
    private string _text;
    private int _margin;
    private readonly int _width;
    private readonly Placement _placement;

    /// <summary>
    /// The height of the title.
    /// </summary>
    public override int Height => StyledText.Length + _margin * 2;

    /// <summary>
    /// The width of the title.
    /// </summary>
    public override int Width => _width;
    #endregion

    #region Properties
    private string[] StyledText => Core.StyleText(_text);
    #endregion

    #region Constructor
    /// <summary>
    /// The constructor of the title.
    /// </summary>
    /// <param name="text">The text of the title.</param>
    /// <param name="margin">The margin of the title.</param>
    /// <param name="width">The width of the title (by default the width of the console).</param>
    /// <param name="placement">The placement of the title.</param>
    public Title(
        string text,
        int margin = 1,
        int? width = null,
        Placement placement = Placement.Center
    )
    {
        _text = text;
        _margin = margin;
        _width = width ?? Console.WindowWidth;
        _placement = placement;
    }
    #endregion

    #region Methods
    /// <summary>
    /// This method updates the text of the title.
    /// </summary>
    /// <param name="text">The new text of the title.</param>
    public void UpdateText(string text)
    {
        _text = text;
    }

    /// <summary>
    /// This method updates the margin of the title.
    /// </summary>
    /// <param name="margin">The new margin of the title.</param>
    public void UpdateMargin(int margin)
    {
        _margin = margin;
    }

    /// <summary>
    /// This method is used to draw the title on the console.
    /// </summary>
    protected override void RenderActions()
    {
        Core.WritePositionedStyledText(StyledText, 0, _width, _margin, _placement, false);
    }
    #endregion
}
