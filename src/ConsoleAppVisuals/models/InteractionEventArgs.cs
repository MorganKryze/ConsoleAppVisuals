/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Models;

/// <summary>
/// This class contains the arguments of the ScrollingMenuSelected event.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public class InteractionEventArgs<T> : EventArgs
{
    #region Fields
    /// <summary>
    /// The status after exiting the interactive element.
    /// </summary>
    /// <value>Output.Escaped : pressed escape, Output.Deleted : pressed backspace, Output.Selected : pressed enter, Output.None : default value</value>
    public Status Status { get; set; }

    /// <summary>
    /// The value of the response after exiting the interactive element.
    /// </summary>
    public T Value { get; set; }
    #endregion

    #region Constructor
    /// <summary>
    /// This constructor initializes the InteractionEventArgs class.
    /// </summary>
    /// <param name="status">The status of the exit from the menu.</param>
    /// <param name="value">The value of the response after exiting the interactive element.</param>
    public InteractionEventArgs(Status status, T value)
    {
        Status = status;
        Value = value;
    }
    #endregion
}
