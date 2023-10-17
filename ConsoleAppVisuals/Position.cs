namespace ConsoleAppVisuals;
/// <summary>
/// A class that stores the position into X and Y parameters.
/// </summary>
public struct Position : IEquatable<Position>
{
    #region Attributes
    /// <summary>
    /// The x coordinate of the position.
    /// </summary>
    public int X;
    /// <summary>
    /// The y coordinate of the position.
    /// </summary>
    public int Y;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="Position"/> class with 2 coordinates.
    /// </summary>
    /// <param name="x">The x coordinate of the position.</param>
    /// <param name="y">The y coordinate of the position.</param>
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="Position"/> class with another instance of the <see cref="Position"/> class.
    /// </summary>
    /// <param name="pos">The position to copy.</param>
    public Position(Position pos)
    {
        X = pos.X;
        Y = pos.Y;
    }
    #endregion
    
    #region Methods
    /// <summary>
    /// This method is used to convert the position to a string.
    /// </summary>
    /// <returns>The position as a string.</returns>
    public override readonly string ToString() => $"Line : {X} ; Column : {Y}";
    /// <summary>
    /// This method is used to check if the position is equal to another position.
    /// </summary>
    /// <param name="obj">The position to compare to.</param>
    /// <returns>True if the positions are equal, false otherwise.</returns>
    public override readonly bool Equals(object? obj) => obj is Position position && X == position.X && Y == position.Y;
    /// <summary>
    /// Implementation of the IEquatable interface.
    /// </summary>
    /// <returns>An integer representing the hash code of the position.</returns>
    public override readonly int GetHashCode() => HashCode.Combine(X, Y);
    /// <summary>
    /// Implementation of the IEquatable interface.
    /// </summary>
    /// <param name="other">The position to compare to.</param>
    /// <returns>True if the positions are equal, false otherwise.</returns>
    readonly bool IEquatable<Position>.Equals(Position other) => Equals(other);

    /// <summary>
    /// This operator is used to check if the position is equal to another position.
    /// </summary>
    /// <param name="left">The first position to compare.</param>
    /// <param name="right">The second position to compare.</param>
    /// <returns>True if the positions are equal, false otherwise.</returns>
    public static bool operator ==(Position left, Position right)
    {
        return left.Equals(right);
    }
    /// <summary>
    /// This operator is used to check if the position is not equal to another position.
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