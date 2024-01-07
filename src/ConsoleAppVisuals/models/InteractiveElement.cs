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
public abstract class InteractiveElement<TResponse> : Element
{
    #region Properties
    /// <summary>
    /// Whether the element is interactive or not.
    /// </summary>
    public sealed override bool IsInteractive { get; } = true;

    /// <summary>
    /// The maximum number of this element that can be drawn on the console. As an interactive element, the value is 1.
    /// </summary>
    public sealed override int MaxNumberOfThisElement { get; } = 1;

    /// <summary>
    ///
    /// </summary>
    public event EventHandler<InteractionEventArgs<TResponse>>? EndOfInteractionEvent;

    /// <summary>
    /// The response of the user.
    /// </summary>
    protected InteractionEventArgs<TResponse>? _interactionResponse;

    /// <summary>
    /// Returns the response of the user.
    /// </summary>
    public InteractionEventArgs<TResponse>? GetInteractionResponse => _interactionResponse;
    #endregion

    #region Methods
    /// <summary>
    /// Sets the response of the user in the attribute field.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The response of the user.</param>
    protected void SetInteractionResponse(object? sender, InteractionEventArgs<TResponse> e)
    {
        _interactionResponse = e;
    }

    /// <summary>
    /// Triggers the EndOfInteractionEvent event.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The response of the user.</param>
    protected void SendResponse(object? sender, InteractionEventArgs<TResponse> e)
    {
        EndOfInteractionEvent?.Invoke(sender, e);
    }

    /// <summary>
    /// This method is used to set options before drawing the element on the console.
    /// </summary>
    protected sealed override void RenderOptionsBeforeHand()
    {
        EndOfInteractionEvent += SetInteractionResponse;
    }

    /// <summary>
    /// This method is used to set options after drawing the element on the console.
    /// </summary>
    protected sealed override void RenderOptionsAfterHand()
    {
        EndOfInteractionEvent -= SetInteractionResponse;
    }
    #endregion
}
