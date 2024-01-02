/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// Defines the loading bar of the console window.
/// </summary>
public class LoadingBar : Element
{
    #region Fields
    private string _text;
    private readonly Placement _placement;
    private float _progress;
    private readonly int _line;
    private readonly int _additionalDuration;
    #endregion

    #region Constants
    private const char LOADING_BAR_CHAR = '█';
    private const float MIN_PROGRESS = 0f;
    private const float MAX_PROGRESS = 1f;

    #endregion

    #region Properties
    /// <summary>
    /// The line of the loading bar in the console.
    /// </summary>
    /// <remarks>We add 2 because so the loading bar does not overlap with the title.</remarks>
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

    #region Constructor
    /// <summary>
    /// The natural constructor of the loading bar.
    /// </summary>
    /// <param name="text">The text of the loading bar.</param>
    /// <param name="progress">The reference of the progress of the loading bar (that means that you should put a reference to a variable that will contain the percentage of progress of your process).</param>
    /// <param name="placement">The placement of the loading bar.</param>
    /// <param name="line">The line of the loading bar.</param>
    /// <param name="additionalDuration">The duration of the loading bar after the process.</param>
    public LoadingBar(
        string text,
        ref float progress,
        Placement placement = Placement.TopCenter,
        int? line = null,
        int additionalDuration = 1000
    )
    {
        _text = text[..Math.Min(text.Length, Console.WindowWidth - 1)];
        _progress = progress;
        _placement = placement;
        _line = line ?? Window.LastTopLineAvailable;
        _additionalDuration = additionalDuration;
    }
    #endregion

    #region Methods
    /// <summary>
    /// This method is used to update the text of the loading bar.
    /// </summary>
    /// <param name="text">The new text of the loading bar.</param>
    public void UpdateText(string text)
    {
        _text = text;
    }

    /// <summary>
    /// This method is used to update the progress of the loading bar.
    /// </summary>
    /// <param name="progress">The new progress of the loading bar.</param>
    public void UpdateProgress(float progress)
    {
        _progress = progress;
    }

    /// <summary>
    /// This method is used to draw the loading bar on the console.
    /// </summary>
    protected override void RenderActions()
    {
        void BuildBar(string text, float progress, int line)
        {
            StringBuilder loadingBar = new();
            for (int j = 0; j <= (int)(text.Length * progress); j++)
            {
                loadingBar.Append(LOADING_BAR_CHAR);
            }
            Core.WritePositionedString(
                loadingBar.ToString().ResizeString(text.Length, Placement.TopLeft),
                _placement,
                false,
                line + 2,
                false
            );
        }

        Core.WritePositionedString(_text, _placement, false, _line, false);
        while (_progress <= MAX_PROGRESS)
        {
            BuildBar(_text, _progress, _line);
        }
        BuildBar(_text, MAX_PROGRESS, _line);
        Thread.Sleep(_additionalDuration);
        _progress = MIN_PROGRESS;
    }
    #endregion
}
