/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestsBorders
{
    #region Constructor
    [TestMethod]
    [TestCategory("Borders")]
    public void Borders_Constructor_Default()
    {
        // Arrange
        Borders borders = new Borders();

        // Act
        BordersType actual = borders.Type;

        // Assert
        Assert.AreEqual(BordersType.SingleStraight, actual);
    }

    [TestMethod]
    [TestCategory("Borders")]
    public void Borders_Constructor_DoubleStraight()
    {
        // Arrange
        Borders borders = new Borders(BordersType.DoubleStraight);

        // Act
        BordersType actual = borders.Type;

        // Assert
        Assert.AreEqual(BordersType.DoubleStraight, actual);
    }

    [TestMethod]
    [TestCategory("Borders")]
    [ExpectedException(typeof(ArgumentException))]
    public void Borders_Constructor_InvalidType()
    {
        // Arrange
        new Borders((BordersType)99);
    }
    #endregion

    #region Properties

    [TestMethod]
    [TestCategory("Borders")]
    [DataRow(BordersType.SingleStraight, '┌')]
    [DataRow(BordersType.SingleRound, '╭')]
    [DataRow(BordersType.SingleBold, '┏')]
    [DataRow(BordersType.DoubleStraight, '╔')]
    [DataRow(BordersType.ASCII, '+')]
    public void Borders_TopLeft(BordersType type, char expected)
    {
        // Arrange
        Borders borders = new Borders(type);

        // Act
        char actual = borders.TopLeft;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("Borders")]
    [DataRow(BordersType.SingleStraight, '┐')]
    [DataRow(BordersType.SingleRound, '╮')]
    [DataRow(BordersType.SingleBold, '┓')]
    [DataRow(BordersType.DoubleStraight, '╗')]
    [DataRow(BordersType.ASCII, '+')]
    public void Borders_TopRight(BordersType type, char expected)
    {
        // Arrange
        Borders borders = new Borders(type);

        // Act
        char actual = borders.TopRight;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("Borders")]
    [DataRow(BordersType.SingleStraight, '└')]
    [DataRow(BordersType.SingleRound, '╰')]
    [DataRow(BordersType.SingleBold, '┗')]
    [DataRow(BordersType.DoubleStraight, '╚')]
    [DataRow(BordersType.ASCII, '+')]
    public void Borders_BottomLeft(BordersType type, char expected)
    {
        // Arrange
        Borders borders = new Borders(type);

        // Act
        char actual = borders.BottomLeft;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("Borders")]
    [DataRow(BordersType.SingleStraight, '┘')]
    [DataRow(BordersType.SingleRound, '╯')]
    [DataRow(BordersType.SingleBold, '┛')]
    [DataRow(BordersType.DoubleStraight, '╝')]
    [DataRow(BordersType.ASCII, '+')]
    public void Borders_BottomRight(BordersType type, char expected)
    {
        // Arrange
        Borders borders = new Borders(type);

        // Act
        char actual = borders.BottomRight;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("Borders")]
    [DataRow(BordersType.SingleStraight, '─')]
    [DataRow(BordersType.SingleRound, '─')]
    [DataRow(BordersType.SingleBold, '━')]
    [DataRow(BordersType.DoubleStraight, '═')]
    [DataRow(BordersType.ASCII, '-')]
    public void Borders_Horizontal(BordersType type, char expected)
    {
        // Arrange
        Borders borders = new Borders(type);

        // Act
        char actual = borders.Horizontal;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("Borders")]
    [DataRow(BordersType.SingleStraight, '│')]
    [DataRow(BordersType.SingleRound, '│')]
    [DataRow(BordersType.SingleBold, '┃')]
    [DataRow(BordersType.DoubleStraight, '║')]
    [DataRow(BordersType.ASCII, '|')]
    public void Borders_Vertical(BordersType type, char expected)
    {
        // Arrange
        Borders borders = new Borders(type);

        // Act
        char actual = borders.Vertical;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("Borders")]
    [DataRow(BordersType.SingleStraight, '┬')]
    [DataRow(BordersType.SingleRound, '┬')]
    [DataRow(BordersType.SingleBold, '┳')]
    [DataRow(BordersType.DoubleStraight, '╦')]
    [DataRow(BordersType.ASCII, '+')]
    public void Borders_Top(BordersType type, char expected)
    {
        // Arrange
        Borders borders = new Borders(type);

        // Act
        char actual = borders.Top;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("Borders")]
    [DataRow(BordersType.SingleStraight, '┴')]
    [DataRow(BordersType.SingleRound, '┴')]
    [DataRow(BordersType.SingleBold, '┻')]
    public void Borders_Bottom(BordersType type, char expected)
    {
        // Arrange
        Borders borders = new Borders(type);

        // Act
        char actual = borders.Bottom;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("Borders")]
    [DataRow(BordersType.SingleStraight, '├')]
    [DataRow(BordersType.SingleRound, '├')]
    public void Borders_Left(BordersType type, char expected)
    {
        // Arrange
        Borders borders = new Borders(type);

        // Act
        char actual = borders.Left;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("Borders")]
    [DataRow(BordersType.SingleStraight, '┤')]
    [DataRow(BordersType.SingleRound, '┤')]
    public void Borders_Right(BordersType type, char expected)
    {
        // Arrange
        Borders borders = new Borders(type);

        // Act
        char actual = borders.Right;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("Borders")]
    [DataRow(BordersType.SingleStraight, '┼')]
    [DataRow(BordersType.SingleRound, '┼')]
    public void Borders_Cross(BordersType type, char expected)
    {
        // Arrange
        Borders borders = new Borders(type);

        // Act
        char actual = borders.Cross;

        // Assert
        Assert.AreEqual(expected, actual);
    }
    #endregion

    #region GetBorderChar
    [TestMethod]
    [TestCategory("Borders")]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    [DataRow(-1)]
    [DataRow(int.MaxValue)]
    public void Borders_GetBorderChar_OutOfRange(int index)
    {
        // Arrange
        Borders borders = new Borders();

        // Act
        borders.GetBorderChar(index);
    }
    #endregion

    #region UpdateBorderType
    [TestMethod]
    [TestCategory("Borders")]
    public void Borders_UpdateBorderType_SingleRounded()
    {
        // Arrange
        Borders borders = new Borders();

        // Act
        borders.UpdateBordersType(BordersType.SingleRound);
        BordersType actual = borders.Type;

        // Assert
        Assert.AreEqual(BordersType.SingleRound, actual);
    }
    #endregion
}
