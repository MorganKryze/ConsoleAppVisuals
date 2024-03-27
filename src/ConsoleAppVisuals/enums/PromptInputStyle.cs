/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Enums;

/// <summary>
/// The <see cref="PromptInputStyle"/> enum defines the style of the prompt input.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
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
