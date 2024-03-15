/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals.PassiveElements;

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
public class LoadingBar : PassiveElement
{
    #region Fields
    private string _text;
    private Placement _placement;
    private float _progress;
    private int _additionalDuration;
    #endregion

    #region Constants
    private const char LOADING_BAR_CHAR = '█';
    private const float MIN_PROGRESS = 0f;
    private const float MAX_PROGRESS = 1f;

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
    /// The placement of the loading bar.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// The maximum number of this element.
    /// </summary>
    public override int MaxNumberOfThisElement => 1;

    /// <summary>
    /// Getters and setters of the text of the loading bar.
    /// </summary>
    public string Text => _text;

    /// <summary>
    /// Getters and setters of the progress of the loading bar.
    /// </summary>
    public float Progress => _progress;

    /// <summary>
    /// Getters of the additional duration of the loading bar at the end.
    /// </summary>
    public int AdditionalDuration => _additionalDuration;
    #endregion

    #region Constructor
    /// <summary>
    /// The natural constructor of the loading bar.
    /// </summary>
    /// <param name="text">The text of the loading bar.</param>
    /// <param name="progress">The reference of the progress of the loading bar (that means that you should put a reference to a variable that will contain the percentage of progress of your process).</param>
    /// <param name="placement">The placement of the loading bar.</param>
    /// <param name="additionalDuration">The duration of the loading bar after the process.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public LoadingBar(
        string text,
        ref float progress,
        Placement placement = Placement.TopCenter,
        int additionalDuration = 1000
    )
    {
        if (Console.WindowWidth - 1 < 0)
        {
            _text = text[..Math.Min(text.Length, 0)];
        }
        else
        {
            _text = text[..Math.Min(text.Length, Console.WindowWidth - 1)];
        }
        _progress = progress;
        _placement = placement;
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
    /// <exception cref="ArgumentException">The additional duration of the loading bar cannot be negative.</exception>
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
            throw new ArgumentException(
                "The additional duration of the loading bar cannot be negative."
            );
        }
        _additionalDuration = additionalDuration;
    }

    /// <summary>
    /// This method is used to update the progress of the loading bar.
    /// </summary>
    /// <param name="progress">The new progress of the loading bar.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateProgress(float progress)
    {
        _progress = progress;
    }

    /// <summary>
    /// This method is used to draw the loading bar on the console.
    /// </summary>
    ///
    [Visual]
    protected override void RenderElementActions()
    {
        [Visual]
        void BuildBar(string text, float progress, int line)
        {
            StringBuilder loadingBar = new();
            for (int j = 0; j <= (int)(text.Length * progress); j++)
            {
                loadingBar.Append(LOADING_BAR_CHAR);
            }
            Core.WritePositionedString(
                loadingBar.ToString().ResizeString(text.Length, TextAlignment.Left),
                _placement.ToTextAlignment(),
                false,
                line + 2,
                false
            );
        }

        Core.WritePositionedString(_text, _placement.ToTextAlignment(), false, Line, false);
        while (_progress < MAX_PROGRESS)
        {
            BuildBar(_text, _progress, Line);
        }
        BuildBar(_text, MAX_PROGRESS, Line);
        Thread.Sleep(_additionalDuration);
        _progress = MIN_PROGRESS;
        Window.DeactivateElement(this);
    }
    #endregion
}
