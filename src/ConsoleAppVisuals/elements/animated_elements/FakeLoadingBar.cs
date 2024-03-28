/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.AnimatedElements;

/// <summary>
/// A <see cref="FakeLoadingBar"/> is an animated element that simulates a loading bar with a fixed duration.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class FakeLoadingBar : AnimatedElement
{
    #region Constants
    private const char LOADING_BAR_CHAR = '█';
    private const int DEFAULT_HEIGHT = 3;
    private const string DEFAULT_TEXT = "[ Loading ...]";
    private const Placement DEFAULT_PLACEMENT = Placement.TopCenter;
    private const int DEFAULT_PROCESS_DURATION = 2000;
    private const int DEFAULT_ADDITIONAL_DURATION = 1000;
    #endregion

    #region Fields
    private string _text;
    private Placement _placement;
    private int _processDuration;
    private int _additionalDuration;
    #endregion

    #region Default Properties
    /// <summary>
    /// The height of the loading bar.
    /// </summary>
    public override int Height => DEFAULT_HEIGHT;

    /// <summary>
    /// The width of the loading bar.
    /// </summary>
    public override int Width => _text.Length;

    /// <summary>
    /// The placement of the loading bar.
    /// </summary>
    public override Placement Placement => _placement;
    #endregion

    #region Properties
    /// <summary>
    /// The text of the loading bar.
    /// </summary>
    public string Text => _text;

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
    /// A <see cref="FakeLoadingBar"/> is an animated element that simulates a loading bar with a fixed duration.
    /// </summary>
    /// <param name="text">The text of the loading bar.</param>
    /// <param name="placement">The placement of the loading bar.</param>
    /// <param name="processDuration">The duration of the loading bar.</param>
    /// <param name="additionalDuration">The additional duration of the loading bar at the end.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public FakeLoadingBar(
        string text = DEFAULT_TEXT,
        Placement placement = DEFAULT_PLACEMENT,
        int processDuration = DEFAULT_PROCESS_DURATION,
        int additionalDuration = DEFAULT_ADDITIONAL_DURATION
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

    #region Update Methods
    /// <summary>
    /// This method is used to update the text of the loading bar.
    /// </summary>
    /// <param name="text">The new text of the loading bar.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateText(string text)
    {
        if (text.Length == 0)
        {
            throw new ArgumentException("The text cannot be empty.", nameof(text));
        }
        _text = text;
    }

    /// <summary>
    /// This method is used to update the placement of the loading bar.
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
    /// This method is used to update the duration of the loading bar.
    /// </summary>
    /// <param name="processDuration">The new duration of the loading bar.</param>
    /// <exception cref="ArgumentOutOfRangeException">Throw when the process duration is negative.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateProcessDuration(int processDuration)
    {
        if (processDuration < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(processDuration),
                "The process duration must be greater than or equal to 0."
            );
        }
        _processDuration = processDuration;
    }

    /// <summary>
    /// This method is used to update the additional duration of the loading bar.
    /// </summary>
    /// <param name="additionalDuration">The new additional duration of the loading bar.</param>
    /// <exception cref="ArgumentOutOfRangeException">The additional duration of the loading bar cannot be negative.</exception>

    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    #endregion

    #region Rendering
    /// <summary>
    /// This method is used to draw the loading bar on the console.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        Core.WritePositionedString(_text, _placement, false, Line, false);
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
            _placement.ToTextAlignment()
        );
    }
    #endregion
}
