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
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public class FakeLoadingBar : InteractiveElement<string>
{
    #region Fields
    private string _text;
    private Placement _placement;
    private readonly int _processDuration;
    private int _additionalDuration;
    #endregion

    #region Constants
    private const char LOADING_BAR_CHAR = '█';
    #endregion

    #region Properties
    /// <summary>
    /// The height of the loading bar.
    /// </summary>
    /// <remarks>One line for the text,one line for the space between and one line for the progress.</remarks>
    public override int Height => 3;

    /// <summary>
    /// The width of the loading bar.
    /// </summary>
    public override int Width => _text.Length;

    /// <summary>
    /// The text of the loading bar.
    /// </summary>
    public string Text => _text;

    /// <summary>
    /// The placement of the loading bar.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// Getter of the duration of the loading bar.
    /// </summary>
    public int ProcessDuration => _processDuration;

    /// <summary>
    /// Getter of the additional duration of the loading bar at the end.
    /// </summary>
    public int AdditionalDuration => _additionalDuration;

    #endregion

    #region Constructor
    /// <summary>
    /// The natural constructor of the loading bar.
    /// </summary>
    /// <param name="text">The text of the loading bar.</param>
    /// <param name="placement">The placement of the loading bar.</param>
    /// <param name="processDuration">The duration of the loading bar.</param>
    /// <param name="additionalDuration">The additional duration of the loading bar at the end.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public FakeLoadingBar(
        string text = "[ Loading ...]",
        Placement placement = Placement.TopCenter,
        int processDuration = 2000,
        int additionalDuration = 1000
    )
    {
        if (Console.WindowWidth - 1 >= 0)
        {
            _text = text[..Math.Min(text.Length, Console.WindowWidth - 1)];
        }
        else
        {
            _text = text[..Math.Min(text.Length, 0)];
        }
        _placement = placement;
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
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateText(string text)
    {
        _text = text;
    }

    /// <summary>
    /// This method is used to update the placement of the loading bar.
    /// </summary>
    /// <param name="placement">The new placement of the loading bar.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdatePlacement(Placement placement)
    {
        _placement = placement;
    }

    /// <summary>
    /// This method is used to update the additional duration of the loading bar.
    /// </summary>
    /// <param name="additionalDuration">The new additional duration of the loading bar.</param>
    /// <exception cref="ArgumentOutOfRangeException">The additional duration of the loading bar cannot be negative.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateAdditionalDuration(int additionalDuration)
    {
        if (additionalDuration < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(additionalDuration),
                "The additional duration must be greater than or equal to 0."
            );
        }
        _additionalDuration = additionalDuration;
    }

    /// <summary>
    /// This method is used to draw the loading bar on the console.
    /// </summary>

    [Visual]
    protected override void RenderElementActions()
    {
        Core.WritePositionedString(_text, _placement.ToTextAlignment(), false, Line, false);
        StringBuilder loadingBar = new();
        for (int j = 0; j < _text.Length; j++)
        {
            loadingBar.Append(LOADING_BAR_CHAR);
        }
        Core.WriteContinuousString(
            loadingBar.ToString(),
            Line + 2,
            false,
            _processDuration,
            _additionalDuration,
            Width,
            _placement.ToTextAlignment(),
            false
        );
        Window.DeactivateElement(this);
    }
    #endregion
}
