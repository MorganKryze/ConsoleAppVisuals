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
    private string Text { get; set; }
    private int Margin { get; set; }

    /// <summary>
    /// The id number of the title.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The visibility of the title.
    /// </summary>
    public bool Visibility { get; set; }

    /// <summary>
    /// The height of the title.
    /// </summary>
    public int Height
    {
        get { return StyledText.Length + Margin * 2; }
    }

    /// <summary>
    /// The width of the title.
    /// </summary>
    public int Width
    {
        get { return Console.WindowWidth; }
    }
    #endregion

    #region Properties
    private string[] StyledText => Core.StyleText(Text);
    #endregion

    #region Constructor
    /// <summary>
    /// The constructor of the title.
    /// </summary>
    /// <param name="text">The text of the title.</param>
    /// <param name="margin">The margin of the title.</param>
    /// <param name="id">The id number of the title.</param>
    /// <param name="visible">The visibility of the title.</param>
    public Title(string text, int margin = 1, int? id = null, bool? visible = null)
    {
        Text = text;
        Margin = margin;
        Id = id ?? Window.NextId;
        Visibility = visible ?? Window.DefaultVisibility;
    }
    #endregion

    #region Methods
    /// <summary>
    /// This method updates the text of the title.
    /// </summary>
    /// <param name="text">The new text of the title.</param>
    public void UpdateText(string text)
    {
        Text = text;
    }

    /// <summary>
    /// This method updates the margin of the title.
    /// </summary>
    /// <param name="margin">The new margin of the title.</param>
    public void UpdateMargin(int margin)
    {
        Margin = margin;
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
                Console.WindowWidth,
                Margin,
                Placement.Center,
                false
            );
        }
    }
    #endregion
}
