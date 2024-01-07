/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// Defines the basic properties of an console element.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
/// </list>
/// </remarks>
public abstract class Element
{
    #region Fields
    /// <summary>
    /// The id number of the element.
    /// </summary>
    /// <remarks>This property is sealed. The ID of an element is automatically generated and managed by the <see cref="Window"/> class.</remarks>
    public int Id { get; set; } = Window.NextId;

    /// <summary>
    /// The visibility of the element.
    /// </summary>
    /// <remarks>This property is sealed. The visibility of an element is managed by the <see cref="ToggleVisibility"/> method.</remarks>
    public bool Visibility { get; private set; } = Window.DEFAULT_VISIBILITY;

    /// <summary>
    /// The placement of the element.
    /// </summary>
    public virtual Placement Placement { get; set; } = Placement.TopCenter;

    /// <summary>
    /// The text alignment of the text of the element.
    /// </summary>
    public virtual TextAlignment TextAlignment { get; set; } = TextAlignment.Center;

    /// <summary>
    /// Whether the element is executable or not.
    /// </summary>
    public virtual bool IsInteractive { get; } = false;

    /// <summary>
    /// The line of the element in the console.
    /// </summary>
    /// <remarks>This property is marked as virtual. It is recommended to override this property in derived classes to make it more specific.</remarks>
    public virtual int Line { get; } = 0;

    /// <summary>
    /// The height of the element.
    /// </summary>
    /// <remarks>This property is marked as virtual. It is recommended to override this property in derived classes to make it more specific.</remarks>
    public virtual int Height { get; } = 0;

    /// <summary>
    /// The width of the element.
    /// </summary>
    /// <remarks>This property is marked as virtual. It is recommended to override this property in derived classes to make it more specific.</remarks>
    public virtual int Width { get; } = 0;

    /// <summary>
    /// The maximum number of this element that can be drawn on the console.
    /// </summary>
    /// <remarks>This property is marked as virtual. It is recommended to override this property in derived classes to make it more specific.</remarks>
    public virtual int MaxNumberOfThisElement { get; } = 1;

    /// <summary>
    /// The source of the element. This property is used to determine whether the element is a user element or a library element for internal use.
    /// </summary>
    /// <remarks><c>[ DANGEROUS ]</c> Please do not change this property unless you know what you are doing.</remarks>
    public Source ElementSource { get; set; } = Source.User;
    #endregion

    #region Methods
    /// <summary>
    /// This method is used to toggle the visibility of the element.This method is used to toggle the visibility of the element. If the maximum number of this element is reached, an exception is thrown.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the maximum number of this element is reached.</exception>
    /// <remarks>This method is effectively sealed. The only way to change the visibility of an element is to use this method.</remarks>
    public void ToggleVisibility()
    {
        if (Visibility)
        {
            Visibility = false;
        }
        else if (Window.AllowVisibilityToggle(Id))
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

    /// <summary>
    /// This method is used to draw the element on the console.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
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
    /// This method is used to define the actions to perform when the element is drawn on the console.
    /// </summary>
    /// <remarks>This method is marked as virtual. It is recommended to override this method in derived classes to make it more specific.</remarks>
    protected virtual void RenderElementActions()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// This method is used to set options before drawing the element on the console.
    /// </summary>
    protected virtual void RenderOptionsBeforeHand() { }

    /// <summary>
    /// This method is used to set options after drawing the element on the console.
    /// </summary>
    protected virtual void RenderOptionsAfterHand() { }

    /// <summary>
    /// This method is used to draw the space taken by the element on the console.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void RenderElementSpace()
    {
        if (Visibility)
        {
            Core.SaveColorPanel();
            Core.SetForegroundColor(Core.GetRandomColor());
            Core.WriteMultiplePositionedLines(
                false,
                Placement.ToTextAlignment(),
                true,
                Line,
                GetRenderSpace()
            );
            Core.LoadSavedColorPanel();
        }
    }

    /// <summary>
    /// This method is used to simulate the drawing space of the element on the console.
    /// </summary>
    /// <returns>The space taken by the element.</returns>
    /// <remarks>This method is marked as virtual. It is recommended to override this method in derived classes to make it more specific.</remarks>
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
    /// This method is used to clear the space taken by the element on the console.
    /// </summary>
    public void Clear()
    {
        Core.WriteMultiplePositionedLines(false, TextAlignment, false, Line, GetRenderSpace());
    }
    #endregion
}
