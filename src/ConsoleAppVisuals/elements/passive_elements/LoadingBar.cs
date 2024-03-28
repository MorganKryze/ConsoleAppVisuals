/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.PassiveElements;

/// <summary>
/// The <see cref="LoadingBar"/> is a passive element that displays a loading bar using a reference to a progress variable.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class LoadingBar : PassiveElement
{
    #region Constants
    const char LOADING_BAR_CHAR = '█';
    const float MIN_PROGRESS = 0f;
    const float MAX_PROGRESS = 1f;
    const int DEFAULT_HEIGHT = 3;
    const Placement DEFAULT_PLACEMENT = Placement.TopCenter;
    const int DEFAULT_ADDITIONAL_DURATION = 1000;
    #endregion

    #region Fields
    private string _text;
    private Placement _placement;
    private float _progress;
    private int _additionalDuration;
    #endregion

    #region Default Properties
    /// <summary>
    /// Gets the height of the loading bar.
    /// </summary>
    /// <remarks>One line for the text,one line for the space between and one line for the progress.</remarks>
    public override int Height => DEFAULT_HEIGHT;

    /// <summary>
    /// Gets the width of the loading bar.
    /// </summary>
    public override int Width => _text.Length;

    /// <summary>
    /// Gets the placement of the loading bar.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// Gets the maximum number of this element.
    /// </summary>
    public override int MaxNumberOfThisElement => 1;
    #endregion

    #region Properties
    /// <summary>
    /// Gets the text of the loading bar.
    /// </summary>
    public string Text => _text;

    /// <summary>
    /// Gets the progress of the loading bar.
    /// </summary>
    public float Progress => _progress;

    /// <summary>
    /// Gets the additional duration of the loading bar at the end.
    /// </summary>
    public int AdditionalDuration => _additionalDuration;
    #endregion

    #region Constructor
    /// <summary>
    /// The <see cref="LoadingBar"/> is a passive element that displays a loading bar using a reference to a progress variable.
    /// </summary>
    /// <param name="text">The text of the loading bar.</param>
    /// <param name="progress">The reference of the progress of the loading bar (that means that you should put a reference to a variable that will contain the percentage of progress of your process).</param>
    /// <param name="placement">The placement of the loading bar.</param>
    /// <param name="additionalDuration">The duration of the loading bar after the process.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public LoadingBar(
        string text,
        ref float progress,
        Placement placement = DEFAULT_PLACEMENT,
        int additionalDuration = DEFAULT_ADDITIONAL_DURATION
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

    #region Update Methods
    /// <summary>
    /// Updates the text of the loading bar.
    /// </summary>
    /// <param name="text">The new text of the loading bar.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateText(string text)
    {
        _text = text;
    }

    /// <summary>
    /// Updates the placement of the loading bar.
    /// </summary>
    /// <param name="placement">The new placement of the loading bar.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdatePlacement(Placement placement)
    {
        _placement = placement;
    }

    /// <summary>
    /// Updates the additional duration of the loading bar.
    /// </summary>
    /// <param name="additionalDuration">The new additional duration of the loading bar.</param>
    /// <exception cref="ArgumentException">The additional duration of the loading bar cannot be negative.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// Updates the progress of the loading bar.
    /// </summary>
    /// <param name="progress">The new progress of the loading bar.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateProgress(float progress)
    {
        _progress = progress;
    }
    #endregion

    #region Rendering
    /// <summary>
    /// Defines the actions to perform when the element is called to be rendered on the console.
    /// </summary>
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
                _placement,
                false,
                line + 2,
                false
            );
        }

        Core.WritePositionedString(_text, _placement, false, Line, false);
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
