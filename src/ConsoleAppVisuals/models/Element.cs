/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Models;

/// <summary>
/// The <see cref="Element"/> class is an abstract class that represents an element that can be rendered on the console.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public abstract class Element
{
    #region Constants
    /// <summary>
    /// The default visibility of the elements when they are added to the window.
    /// </summary>
    /// <remarks>
    /// This value should not be changed.
    /// Each time the user adds an element to the window, it will try to toggle the visibility of the element.
    /// </remarks>
    private const bool DEFAULT_VISIBILITY = false;

    private const int DEFAULT_HEIGHT = 0;

    private const int DEFAULT_WIDTH = 0;

    private const int DEFAULT_MAX_NUMBER_OF_THIS_ELEMENT = int.MaxValue;
    #endregion

    #region Sealed Properties
    /// <summary>
    /// Gets the id number of the element.
    /// </summary>
    /// <remarks>This property is sealed. The ID of an element is automatically generated and managed by the <see cref="Window"/> class.</remarks>
    public int Id { get; set; }

    /// <summary>
    /// Gets the visibility of the element.
    /// </summary>
    /// <remarks>This property is sealed. The visibility of an element is managed by the <see cref="ToggleVisibility"/> method.</remarks>
    public bool Visibility { get; private set; } = DEFAULT_VISIBILITY;
    #endregion

    #region Properties
    /// <summary>
    /// Gets the type of the element.
    /// </summary>
    [Visual]
    public virtual ElementType Type { get; }

    /// <summary>
    /// Gets the height of the element, the vertical number of lines taken in the console.
    /// </summary>
    /// <remarks>This property is marked as virtual. It is recommended to override this property in derived classes to make it more specific.</remarks>
    public virtual int Height { get; } = DEFAULT_HEIGHT;

    /// <summary>
    /// Gets the width of the element, the horizontal number of lines taken in the console.
    /// </summary>
    /// <remarks>This property is marked as virtual. It is recommended to override this property in derived classes to make it more specific.</remarks>
    public virtual int Width { get; } = DEFAULT_WIDTH;

    /// <summary>
    /// Gets the placement of the element int the console. See the <see cref="Placement"/> enum to know the possible values.
    /// </summary>
    /// <remarks>This property is marked as virtual. It is recommended to override this property in derived classes to make it more specific.</remarks>
    public virtual Placement Placement { get; set; }

    /// <summary>
    ///Gets the text alignment of the text of the element. See the <see cref="TextAlignment"/> enum to know the possible values.
    /// </summary>
    /// <remarks>This property is marked as virtual. It is recommended to override this property in derived classes to make it more specific.</remarks>
    public virtual TextAlignment TextAlignment { get; set; }

    /// <summary>
    /// Gets the maximum number of this element that can be drawn on the console.
    /// </summary>
    /// <remarks>This property is marked as virtual. It is recommended to override this property in derived classes to make it more specific.</remarks>
    public virtual int MaxNumberOfThisElement { get; } = DEFAULT_MAX_NUMBER_OF_THIS_ELEMENT;

    /// <summary>
    /// Gets a line to place the element in the console.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the placement of the element is invalid.</exception>
    /// <remarks>ATTENTION: This property is not marked as virtual. Override this property only to give it a constant value.</remarks>
    public virtual int Line
    {
        get
        {
            var elements = Window.Range(0, Id);
            return Placement switch
            {
                Placement.TopCenterFullWidth
                    => elements
                        .Where(e => e.Placement == Placement.TopCenterFullWidth && e.Visibility)
                        .Sum(e => e.Height)
                        + elements
                            .Where(e => e.Placement == Placement.TopCenter && e.Visibility)
                            .Sum(e => e.Height)
                        + elements
                            .Where(e => e.Placement == Placement.TopLeft && e.Visibility)
                            .Sum(e => e.Height)
                        + elements
                            .Where(e => e.Placement == Placement.TopRight && e.Visibility)
                            .Sum(e => e.Height),
                Placement.TopCenter
                    => elements
                        .Where(e => e.Placement == Placement.TopCenterFullWidth && e.Visibility)
                        .Sum(e => e.Height)
                        + elements
                            .Where(e => e.Placement == Placement.TopCenter && e.Visibility)
                            .Sum(e => e.Height),
                Placement.TopLeft
                    => elements
                        .Where(e => e.Placement == Placement.TopCenterFullWidth && e.Visibility)
                        .Sum(e => e.Height)
                        + elements
                            .Where(e => e.Placement == Placement.TopLeft && e.Visibility)
                            .Sum(e => e.Height),

                Placement.TopRight
                    => elements
                        .Where(e => e.Placement == Placement.TopCenterFullWidth && e.Visibility)
                        .Sum(e => e.Height)
                        + elements
                            .Where(e => e.Placement == Placement.TopRight && e.Visibility)
                            .Sum(e => e.Height),
                Placement.BottomCenterFullWidth
                    => (Console.WindowHeight == 0 ? 0 : Console.WindowHeight - 1)
                        - (Height - 1)
                        - elements
                            .Where(e =>
                                e.Placement == Placement.BottomCenterFullWidth && e.Visibility
                            )
                            .Sum(e => e.Height),
                _ => throw new ArgumentOutOfRangeException(nameof(Placement), "Invalid placement.")
            };
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Toggles the visibility of the element. If the maximum number of this element is reached, an exception is thrown.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the maximum number of this element is reached.</exception>
    /// <remarks>This method is effectively sealed. The only way to change the visibility of an element is to use this method.</remarks>
    public void ToggleVisibility()
    {
        if (Visibility)
        {
            Visibility = false;
        }
        else if (Window.IsElementActivatable(Id))
        {
            Visibility = true;
        }
        else
        {
            throw new InvalidOperationException(
                $"Operation not allowed, too many elements of {GetType()} already toggled from the maximum of {MaxNumberOfThisElement}. Consider turning off one element of this type."
            );
        }
    }
    #endregion

    #region Rendering
    /// <summary>
    /// Renders the element on the console.
    /// </summary>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public void RenderElement()
    {
        if (Visibility)
        {
            RenderOptionsBeforeHand();
            RenderElementActions();
            RenderOptionsAfterHand();
        }
    }

    /// <summary>
    /// Defines the actions to perform when the element is called to be rendered on the console.
    /// </summary>
    /// <remarks>This method is marked as virtual. It is recommended to override this method in derived classes to make it more specific.</remarks>
    [Visual]
    protected virtual void RenderElementActions()
    {
        throw new NotImplementedException("Consider overriding this method in the derived class.");
    }

    /// <summary>
    /// Defines actions to perform before rendering the element on the console.
    /// </summary>
    [Visual]
    protected virtual void RenderOptionsBeforeHand() { }

    /// <summary>
    /// Defines actions to perform after rendering the element on the console.
    /// </summary>
    [Visual]
    protected virtual void RenderOptionsAfterHand() { }

    /// <summary>
    /// Renders the space taken by the element on the console.
    /// </summary>
    /// <param name="ignoreVisibility">Whether to ignore the visibility of the element or not.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public void RenderElementSpace(bool ignoreVisibility = false)
    {
        if (Visibility || ignoreVisibility)
        {
            Core.SaveColorPanel();
            Core.SetForegroundColor(Core.GetRandomColor());
            Core.WriteMultiplePositionedLines(
                false,
                TextAlignment.Center,
                Placement,
                true,
                Line,
                GetRenderSpace()
            );
            Core.LoadSavedColorPanel();
        }
    }

    /// <summary>
    /// Gets the space taken by the element on the console.
    /// </summary>
    /// <returns>The space taken by the element.</returns>
    /// <remarks>This method is marked as virtual. It is recommended to override this method in derived classes to make it more specific.</remarks>
    [Visual]
    protected virtual string[] GetRenderSpace()
    {
        var space = new string[Height];
        for (int i = 0; i < space.Length; i++)
        {
            space[i] = new string(' ', Width);
        }
        return space;
    }

    /// <summary>
    /// Clears the space taken by the element on the console.
    /// </summary>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public void Clear()
    {
        Core.ClearMultiplePositionedLines(Placement, Line, GetRenderSpace());
    }
    #endregion
}
