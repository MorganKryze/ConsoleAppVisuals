/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// This class contains the arguments of the ScrollingMenuSelected event.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
/// </list>
/// </remarks>
public class InteractionEventArgs<T> : EventArgs
{
    /// <summary>
    /// The state of the exit from the menu.
    /// </summary>
    /// <value>Status.Exit : pressed escape, Status.Delete : pressed backspace, Status.Select : pressed enter</value>
    public Status State { get; set; }

    /// <summary>
    /// The index of the choice of the user among the different choices.
    /// </summary>
    public T Info { get; set; }

    /// <summary>
    /// This constructor initializes the ScrollingMenuEventArgs class.
    /// </summary>
    /// <param name="state">The state of the exit from the menu.</param>
    /// <param name="info">The index of the choice of the user among the different choices.</param>
    public InteractionEventArgs(Status state, T info)
    {
        State = state;
        Info = info;
    }
}
