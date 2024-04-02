/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Models;

/// <summary>
/// The <c>InteractionEventArgs</c> class is a generic class that represents the event arguments for the interactive elements.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class InteractionEventArgs<T> : EventArgs
{
    #region Fields
    /// <summary>
    /// Gets the status after exiting the interactive element. See the <see cref="Status"/> enumeration to know the possible values.
    /// </summary>
    /// <value>Status.Escaped : pressed escape, Status.Deleted : pressed backspace, Status.Selected : pressed enter</value>
    public Status Status { get; set; }

    /// <summary>
    /// Gets the <typeparamref name="T"/> value of the response after exiting the interactive element.
    /// </summary>
    public T Value { get; set; }
    #endregion

    #region Constructor
    /// <summary>
    /// The <c>InteractionEventArgs</c> class is a generic class that represents the event arguments for the interactive elements.
    /// </summary>
    /// <param name="status">The status of the exit from the menu.</param>
    /// <param name="value">The value of the response after exiting the interactive element.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public InteractionEventArgs(Status status, T value)
    {
        Status = status;
        Value = value;
    }
    #endregion
}
