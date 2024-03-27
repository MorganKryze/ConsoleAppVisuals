/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Enums;

/// <summary>
/// The <see cref="Placement"/> enum defines the placement of a string in some space.
/// It could be another string or a console line.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public enum Placement
{
    /// <summary>
    /// The object is placed in the top center of the space.
    /// </summary>
    TopCenter,

    /// <summary>
    /// The object is placed in the top left of the space.
    /// </summary>
    TopLeft,

    /// <summary>
    /// The object is placed in the top right of the space.
    /// </summary>
    TopRight,

    /// <summary>
    /// The object is placed in the top center of the space and takes all the width.
    /// </summary>
    TopCenterFullWidth,

    /// <summary>
    /// The object is placed in the bottom center of the space and takes all the width.
    /// </summary>
    BottomCenterFullWidth,
}
