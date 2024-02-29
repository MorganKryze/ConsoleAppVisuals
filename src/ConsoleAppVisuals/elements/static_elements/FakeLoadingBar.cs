/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals.Elements;

/// <summary>
/// Defines the loading bar of the console window.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
/// </list>
/// </remarks>
public class FakeLoadingBar : Element
{
    #region Fields
    private string _text;
    private readonly Placement _placement;
    private readonly int _processDuration;
    private readonly int _additionalDuration;
    private readonly int _line;
    #endregion

    #region Constants
    private const char LOADING_BAR_CHAR = '█';
    #endregion

    #region Properties
    /// <summary>
    /// The line of the loading bar in the console.
    /// </summary>
    /// <remarks>We add 2 because so the loading bar does not overlap with the title.</remarks>
    [Visual]
    public override int Line => _line;

    /// <summary>
    /// The height of the loading bar.
    /// </summary>
    /// <remarks>One line for the text,one line for the space between and one line for the progress.</remarks>
    public override int Height => 3;

    /// <summary>
    /// The width of the loading bar.
    /// </summary>
    public override int Width => _text.Length;
    #endregion

    #region Getters and Setters
    
    /// <summary>
    /// Getter and setter of the text of the loading bar.
    /// </summary>
    public string Text { get => _text; set => _text = value; }

    /// <summary>
    /// Getter of the placement of the loading bar.
    /// </summary>
    public override Placement Placement {get => _placement;}

    /// <summary>
    /// Getter of the duration of the loading bar.
    /// </summary>
    public int ProcessDuration {get => _processDuration;}

    /// <summary>
    /// Getter of the additional duration of the loading bar at the end.
    /// </summary>
    public int AdditionalDuration {get => _additionalDuration;}

    #endregion

    #region Constructor
    /// <summary>
    /// The natural constructor of the loading bar.
    /// </summary>
    /// <param name="text">The text of the loading bar.</param>
    /// <param name="placement">The placement of the loading bar.</param>
    /// <param name="line">The line of the loading bar.</param>
    /// <param name="processDuration">The duration of the loading bar.</param>
    /// <param name="additionalDuration">The additional duration of the loading bar at the end.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public FakeLoadingBar(
        string text = "[ Loading ...]",
        Placement placement = Placement.TopCenter,
        int? line = null,
        int processDuration = 2000,
        int additionalDuration = 1000
    )
    {
        if(Console.WindowWidth-1 >= 0){
            _text = text[..Math.Min(text.Length, Console.WindowWidth - 1)];
        }
        else{
            _text = text[..Math.Min(text.Length, 0)];
        }
        _placement = placement;
        _line = Window.CheckLine(line) ?? Window.GetLineAvailable(placement);
        _processDuration = processDuration;
        _additionalDuration = additionalDuration;
    }
    #endregion

    #region Methods
    /// <summary>
    /// This method is used to update the text of the loading bar.
    /// </summary>
    /// <param name="text">The new text of the loading bar.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateText(string text)
    {
        _text = text;
    }

    /// <summary>
    /// This method is used to draw the loading bar on the console.
    /// </summary>
    
    [Visual]
    protected override void RenderElementActions()
    {
        Core.WritePositionedString(_text, _placement.ToTextAlignment(), false, _line, false);
        StringBuilder loadingBar = new();
        for (int j = 0; j < _text.Length; j++)
        {
            loadingBar.Append(LOADING_BAR_CHAR);
        }
        Core.WriteContinuousString(
            loadingBar.ToString(),
            _line + 2,
            false,
            _processDuration,
            _additionalDuration,
            Width,
            default,
            false
        );
        Window.DeactivateElement(this);
    }
    #endregion
}
