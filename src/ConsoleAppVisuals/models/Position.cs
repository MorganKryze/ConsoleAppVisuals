/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Models;

/// <summary>
/// The <c>Position</c> struct represents a position in the console with a line and a column.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public struct Position : IEquatable<Position>
{
    #region Fields
    /// <summary>
    /// Gets the x coordinate of the position.
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Gets the y coordinate of the position.
    /// </summary>
    public int Y { get; set; }
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="Position"/> class with 2 coordinates.
    /// </summary>
    /// <param name="x">The x coordinate of the position.</param>
    /// <param name="y">The y coordinate of the position.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Position"/> class with another instance of the <see cref="Position"/> class.
    /// </summary>
    /// <param name="pos">The position to copy.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public Position(Position pos)
    {
        X = pos.X;
        Y = pos.Y;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Converts the position to a string.
    /// </summary>
    /// <returns>The position as a string.</returns>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public override readonly string ToString() => $"Line : {X} ; Column : {Y}";

    /// <summary>
    /// Compares the position to another position.
    /// </summary>
    /// <param name="obj">The position to compare to.</param>
    /// <returns>True if the positions are equal, false otherwise.</returns>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public override readonly bool Equals(object? obj) =>
        obj is Position position && X == position.X && Y == position.Y;

    /// <summary>
    /// Gets the hash code of the position.
    /// </summary>
    /// <returns>An integer representing the hash code of the position.</returns>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public override readonly int GetHashCode() => HashCode.Combine(X, Y);

    /// <summary>
    /// Compares the position to another position.
    /// </summary>
    /// <param name="other">The position to compare to.</param>
    /// <returns>True if the positions are equal, false otherwise.</returns>
    readonly bool IEquatable<Position>.Equals(Position other) => Equals(other);

    /// <summary>
    /// Implements the operator to check if the position is equal to another position.
    /// </summary>
    /// <param name="left">The first position to compare.</param>
    /// <param name="right">The second position to compare.</param>
    /// <returns>True if the positions are equal, false otherwise.</returns>
    public static bool operator ==(Position left, Position right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Implements the operator to check if the position is not equal to another position.
    /// </summary>
    /// <param name="left">The first position to compare.</param>
    /// <param name="right">The second position to compare.</param>
    /// <returns>True if the positions are not equal, false otherwise.</returns>
    public static bool operator !=(Position left, Position right)
    {
        return !(left == right);
    }
    #endregion
}
