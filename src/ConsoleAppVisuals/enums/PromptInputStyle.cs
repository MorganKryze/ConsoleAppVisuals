/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Enums;

/// <summary>
/// The <see cref="PromptInputStyle"/> enum defines the style of the prompt input.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public enum PromptInputStyle
{
    /// <summary>
    /// The default prompt style.
    /// </summary>
    Default,

    /// <summary>
    /// The form style. (the default text will be "----" for 4 characters)
    /// </summary>
    Fill,

    /// <summary>
    /// The secret style. (the input will be hidden with "*" characters)
    /// </summary>
    Secret
}
