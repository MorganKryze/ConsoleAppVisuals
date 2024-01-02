/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// Defines the title of the console window.
/// </summary>
public class Title : IElement
{
    #region Fields
    private string _text;
    private int _margin;
    private readonly int _width;
    private readonly Placement _placement;

    /// <summary>
    /// The id number of the title.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The visibility of the title.
    /// </summary>
    public bool Visibility { get; private set; }

    /// <summary>
    /// The height of the title.
    /// </summary>
    public int Height
    {
        get { return StyledText.Length + _margin * 2; }
    }

    /// <summary>
    /// The width of the title.
    /// </summary>
    public int Width
    {
        get { return _width; }
    }
    /// <summary>
    /// The maximum number of this element that can be drawn on the console.
    /// </summary>
    public int MaxNumberOfThisElement => 1;
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
    public Title(string text, int margin = 1, int? width = null, Placement placement = Placement.Center)
    {
        _text = text;
        _margin = margin;
        _width = width ?? Console.WindowWidth;
        _placement = placement;
        Id = Window.NextId;
        Visibility = Window.DefaultVisibility;
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
    /// This method is used to toggle the visibility of the title.
    /// </summary>
    public void ToggleVisibility()
    {
        if (Visibility)
        {
            Visibility = false;
        }
        else if (Window.AllowVisibilityChange(Id))
        {
            Visibility = true;
        }
        else 
        {
            throw new InvalidOperationException($"Operation not allowed, too many elements of {GetType()} already toggled from the maximum of {MaxNumberOfThisElement}.");
        }
    }
    /// <summary>
    /// This method is used to draw the title on the console.
    /// </summary>
    public void Render()
    {
        if (Visibility)
        {
            Core.WritePositionedStyledText(
                StyledText,
                0,
                _width,
                _margin,
                _placement,
                false
            );
        }
    }
    #endregion
}
