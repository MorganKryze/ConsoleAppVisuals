/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.Models;

/// <summary>
/// The <see cref="Borders"/> class defines the border characters to use for embed elements.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public class Borders
{
    #region Constants
    private const string SINGLE_STRAIGHT = "┌┐└┘─│┬┴├┤┼";
    private const string SINGLE_ROUNDED = "╭╮╰╯─│┬┴├┤┼";
    private const string SINGLE_BOLD = "┏┓┗┛━┃┳┻┣┫╋";
    private const string DOUBLE_STRAIGHT = "╔╗╚╝═║╦╩╠╣╬";
    private const string ASCII = "++++-|+++++";
    private const int DEFAULT_MINIMUM_INDEX = 0;
    private const int DEFAULT_MAXIMUM_INDEX = 11;
    #endregion

    #region Fields
    private BordersType _type;
    #endregion

    #region Properties
    /// <summary>
    /// Gets the type of border to use for the element.
    /// </summary>
    public BordersType Type => _type;

    /// <summary>
    /// Gets the top-left corner of the border. (┌)
    /// </summary>
    public char TopLeft => GetBorderChar(0);

    /// <summary>
    /// Gets the top-right corner of the border. (┐)
    /// </summary>
    public char TopRight => GetBorderChar(1);

    /// <summary>
    /// Gets the bottom-left corner of the border. (└)
    /// </summary>
    public char BottomLeft => GetBorderChar(2);

    /// <summary>
    /// Gets the bottom-right corner of the border. (┘)
    /// </summary>
    public char BottomRight => GetBorderChar(3);

    /// <summary>
    /// Gets the horizontal line of the border. (─)
    /// </summary>
    public char Horizontal => GetBorderChar(4);

    /// <summary>
    /// Gets the vertical line of the border. (│)
    /// </summary>
    public char Vertical => GetBorderChar(5);

    /// <summary>
    /// Gets the top line of the border. (┬)
    /// </summary>
    public char Top => GetBorderChar(6);

    /// <summary>
    /// Gets the bottom line of the border. (┴)
    /// </summary>
    public char Bottom => GetBorderChar(7);

    /// <summary>
    /// Gets the left line of the border. (├)
    /// </summary>
    public char Left => GetBorderChar(8);

    /// <summary>
    /// Gets the right line of the border. (┤)
    /// </summary>
    public char Right => GetBorderChar(9);

    /// <summary>
    /// Gets the cross of the border. (┼)
    /// </summary>
    public char Cross => GetBorderChar(10);
    #endregion

    #region Constructor
    /// <summary>
    /// The <see cref="Borders"/> class defines the border characters to use for embed elements.
    /// </summary>
    /// <param name="type">The type of border to use for the element.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public Borders(BordersType type = BordersType.SingleStraight)
    {
        _type = CheckType(type);
    }

    private static BordersType CheckType(BordersType type)
    {
        if (
            type
            is BordersType.SingleStraight
                or BordersType.SingleRound
                or BordersType.SingleBold
                or BordersType.DoubleStraight
                or BordersType.ASCII
        )
        {
            return type;
        }
        throw new ArgumentException("Invalid border type.");
    }
    #endregion

    #region Methods
    /// <summary>
    /// Gets the border character at the specified index.
    /// </summary>
    /// <param name="index">The index of the border character to get.</param>
    /// <returns>The border character at the specified index.</returns>
    /// <exception cref="ArgumentException">Thrown when the border type is invalid.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is out of range.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public char GetBorderChar(int index)
    {
        if (index < DEFAULT_MINIMUM_INDEX || index >= DEFAULT_MAXIMUM_INDEX)
        {
            throw new ArgumentOutOfRangeException(
                $"Invalid border index. Index must be between 0 and 10. (actual: {index})"
            );
        }
        string border = SINGLE_STRAIGHT;
        switch (_type)
        {
            case BordersType.SingleRound:
                border = SINGLE_ROUNDED;
                break;
            case BordersType.SingleBold:
                border = SINGLE_BOLD;
                break;
            case BordersType.DoubleStraight:

                border = DOUBLE_STRAIGHT;
                break;
            case BordersType.ASCII:
                border = ASCII;
                break;
        }

        return border[index];
    }

    /// <summary>
    /// Updates the border type of the element.
    /// </summary>
    /// <param name="newType">The new border type to use.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateBordersType(BordersType newType)
    {
        _type = CheckType(newType);
    }
    #endregion
}
