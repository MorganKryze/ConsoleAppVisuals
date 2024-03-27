/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Enums;

/// <summary>
/// The <see cref="DialogOption"/> enum defines the outputs of a dialog.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public enum DialogOption
{
    /// <summary>
    /// No options are set or escape pressed.
    /// </summary>
    None,

    /// <summary>
    /// Left option selected.
    /// </summary>
    Left,

    /// <summary>
    /// Right option selected.
    /// </summary>
    Right,
}
