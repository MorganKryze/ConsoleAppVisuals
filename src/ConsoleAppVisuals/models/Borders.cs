/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals.Models;

/// <summary>
/// The <see cref="Borders"/> class defines the border characters to use for embed elements.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public class Borders
{
    #region Fields
    private BorderType _type;
    #endregion

    #region Constants
    private const string SINGLE_STRAIGHT = "┌┐└┘─│┬┴├┤┼";
    private const string SINGLE_ROUNDED = "╭╮╰╯─│┬┴├┤┼";
    private const string SINGLE_BOLD = "┏┓┗┛━┃┳┻┣┫╋";
    private const string DOUBLE_STRAIGHT = "╔╗╚╝═║╦╩╠╣╬";
    private const string ASCII = "++++-|--+++";
    #endregion

    #region Properties
    /// <summary>
    /// The type of border to use for the element.
    /// </summary>
    public BorderType Type => _type;

    /// <summary>
    /// The top-left corner of the border. (┌)
    /// </summary>
    public char TopLeft => GetBorderChar(0);

    /// <summary>
    /// The top-right corner of the border. (┐)
    /// </summary>
    public char TopRight => GetBorderChar(1);

    /// <summary>
    /// The bottom-left corner of the border. (└)
    /// </summary>
    public char BottomLeft => GetBorderChar(2);

    /// <summary>
    /// The bottom-right corner of the border. (┘)
    /// </summary>
    public char BottomRight => GetBorderChar(3);

    /// <summary>
    /// The horizontal line of the border. (─)
    /// </summary>
    public char Horizontal => GetBorderChar(4);

    /// <summary>
    /// The vertical line of the border. (│)
    /// </summary>
    public char Vertical => GetBorderChar(5);

    /// <summary>
    /// The top line of the border. (┬)
    /// </summary>
    public char Top => GetBorderChar(6);

    /// <summary>
    /// The bottom line of the border. (┴)
    /// </summary>
    public char Bottom => GetBorderChar(7);

    /// <summary>
    /// The left line of the border. (├)
    /// </summary>
    public char Left => GetBorderChar(8);

    /// <summary>
    /// The right line of the border. (┤)
    /// </summary>
    public char Right => GetBorderChar(9);

    /// <summary>
    /// The cross of the border. (┼)
    /// </summary>
    public char Cross => GetBorderChar(10);
    #endregion

    #region Constructor
    /// <summary>
    /// The <see cref="Borders"/> class defines the border characters to use for embed elements.
    /// </summary>
    /// <param name="type">The type of border to use for the element.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public Borders(BorderType type = BorderType.SingleStraight)
    {
        _type = CheckType(type);
    }

    private static BorderType CheckType(BorderType type)
    {
        if (
            type
            is BorderType.SingleStraight
                or BorderType.SingleRounded
                or BorderType.SingleBold
                or BorderType.DoubleStraight
                or BorderType.ASCII
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
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public char GetBorderChar(int index)
    {
        if (index < 0 || index >= 12)
        {
            throw new ArgumentOutOfRangeException(
                $"Invalid border index. Index must be between 0 and 11. (actual: {index})"
            );
        }
        string border = _type switch
        {
            BorderType.SingleStraight => SINGLE_STRAIGHT,
            BorderType.SingleRounded => SINGLE_ROUNDED,
            BorderType.SingleBold => SINGLE_BOLD,
            BorderType.DoubleStraight => DOUBLE_STRAIGHT,
            BorderType.ASCII => ASCII,
            _ => throw new ArgumentException($"Invalid border type. (actual: {_type})")
        };
        return border[index];
    }

    /// <summary>
    /// Updates the border type of the element.
    /// </summary>
    /// <param name="newType">The new border type to use.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateBorderType(BorderType newType)
    {
        _type = CheckType(newType);
    }
    #endregion
}
