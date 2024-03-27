/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals.Models;

/// <summary>
/// Defines the basic properties of an console element.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public abstract class InteractiveElement<TResponse> : Element
{
    #region Sealed Properties
    /// <summary>
    /// Whether the element is interactive or not.
    /// </summary>
    public sealed override bool IsInteractive { get; } = true;

    /// <summary>
    /// The maximum number of this element that can be drawn on the console. As an interactive element, the value is 1.
    /// </summary>
    public sealed override int MaxNumberOfThisElement { get; } = 1;

    /// <summary>
    /// The event that is triggered when the user has interacted with the element.
    /// </summary>
    public event EventHandler<InteractionEventArgs<TResponse>>? EndOfInteractionEvent;

    /// <summary>
    /// The response of the user.
    /// </summary>
    protected List<InteractionEventArgs<TResponse>?> _interactionResponse = new();
    #endregion

    #region Methods
    /// <summary>
    /// Sets the response of the user in the attribute field.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The response of the user.</param>
    [Visual]
    protected void SetInteractionResponse(object? sender, InteractionEventArgs<TResponse> e)
    {
        _interactionResponse.Add(e);
    }

    /// <summary>
    /// Triggers the EndOfInteractionEvent event.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The response of the user.</param>
    [Visual]
    protected void SendResponse(object? sender, InteractionEventArgs<TResponse> e)
    {
        EndOfInteractionEvent?.Invoke(sender, e);
    }

    /// <summary>
    /// Returns the response of the user after an interaction.
    /// </summary>
    /// <returns>Null if the user has not interacted with the element, otherwise the response of the user.</returns>
    /// <remarks>
    /// This sample shows how to use the <see cref="GetResponse"/> method using the var keyword:
    /// <code>
    /// var response = element.GetResponse();
    /// </code>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    [Visual]
    public InteractionEventArgs<TResponse>? GetResponse()
    {
        return _interactionResponse.LastOrDefault();
    }

    /// <summary>
    /// Returns the history of the responses of the user after interactions.
    /// </summary>
    /// <returns>The history of the responses of the user after interactions.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    [Visual]
    public List<InteractionEventArgs<TResponse>?> GetResponseHistory()
    {
        return _interactionResponse;
    }

    /// <summary>
    /// This method is used to set options before drawing the element on the console.
    /// </summary>
    [Visual]
    protected sealed override void RenderOptionsBeforeHand()
    {
        EndOfInteractionEvent += SetInteractionResponse;
    }

    /// <summary>
    /// This method is used to set options after drawing the element on the console.
    /// </summary>
    [Visual]
    protected sealed override void RenderOptionsAfterHand()
    {
        EndOfInteractionEvent -= SetInteractionResponse;
        Window.DeactivateElement(this);
    }
    #endregion
}
