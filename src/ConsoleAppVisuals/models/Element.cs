/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// Defines the basic properties of an console element.
/// </summary>
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
    public void Render()
    {
        if (Visibility)
        {
            RenderActions();
        }
    }

    /// <summary>
    /// This method is used to define the actions to perform when the element is drawn on the console.
    /// </summary>
    /// <remarks>This method is marked as virtual. It is recommended to override this method in derived classes to make it more specific.</remarks>
    protected virtual void RenderActions()
    {
        Console.WriteLine($"Element {Id} of type {GetType()} is visible.");
    }
    #endregion
}
