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
        BorderType actual = borders.Type;

        // Assert
        Assert.AreEqual(BorderType.SingleStraight, actual);
    }

    [TestMethod]
    [TestCategory("Borders")]
    public void Borders_Constructor_DoubleStraight()
    {
        // Arrange
        Borders borders = new Borders(BorderType.DoubleStraight);

        // Act
        BorderType actual = borders.Type;

        // Assert
        Assert.AreEqual(BorderType.DoubleStraight, actual);
    }

    [TestMethod]
    [TestCategory("Borders")]
    [ExpectedException(typeof(ArgumentException))]
    public void Borders_Constructor_InvalidType()
    {
        // Arrange
        new Borders((BorderType)99);
    }
    #endregion

    #region Properties

    [TestMethod]
    [TestCategory("Borders")]
    [DataRow(BorderType.SingleStraight, '┌')]
    [DataRow(BorderType.SingleRounded, '╭')]
    [DataRow(BorderType.SingleBold, '┏')]
    [DataRow(BorderType.DoubleStraight, '╔')]
    [DataRow(BorderType.ASCII, '+')]
    public void Borders_TopLeft(BorderType type, char expected)
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
    [DataRow(BorderType.SingleStraight, '┐')]
    [DataRow(BorderType.SingleRounded, '╮')]
    [DataRow(BorderType.SingleBold, '┓')]
    [DataRow(BorderType.DoubleStraight, '╗')]
    [DataRow(BorderType.ASCII, '+')]
    public void Borders_TopRight(BorderType type, char expected)
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
    [DataRow(BorderType.SingleStraight, '└')]
    [DataRow(BorderType.SingleRounded, '╰')]
    [DataRow(BorderType.SingleBold, '┗')]
    [DataRow(BorderType.DoubleStraight, '╚')]
    [DataRow(BorderType.ASCII, '+')]
    public void Borders_BottomLeft(BorderType type, char expected)
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
    [DataRow(BorderType.SingleStraight, '┘')]
    [DataRow(BorderType.SingleRounded, '╯')]
    [DataRow(BorderType.SingleBold, '┛')]
    [DataRow(BorderType.DoubleStraight, '╝')]
    [DataRow(BorderType.ASCII, '+')]
    public void Borders_BottomRight(BorderType type, char expected)
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
    [DataRow(BorderType.SingleStraight, '─')]
    [DataRow(BorderType.SingleRounded, '─')]
    [DataRow(BorderType.SingleBold, '━')]
    [DataRow(BorderType.DoubleStraight, '═')]
    [DataRow(BorderType.ASCII, '-')]
    public void Borders_Horizontal(BorderType type, char expected)
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
    [DataRow(BorderType.SingleStraight, '│')]
    [DataRow(BorderType.SingleRounded, '│')]
    [DataRow(BorderType.SingleBold, '┃')]
    [DataRow(BorderType.DoubleStraight, '║')]
    [DataRow(BorderType.ASCII, '|')]
    public void Borders_Vertical(BorderType type, char expected)
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
    [DataRow(BorderType.SingleStraight, '┬')]
    [DataRow(BorderType.SingleRounded, '┬')]
    [DataRow(BorderType.SingleBold, '┳')]
    [DataRow(BorderType.DoubleStraight, '╦')]
    [DataRow(BorderType.ASCII, '+')]
    public void Borders_Top(BorderType type, char expected)
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
    [DataRow(BorderType.SingleStraight, '┴')]
    [DataRow(BorderType.SingleRounded, '┴')]
    [DataRow(BorderType.SingleBold, '┻')]
    public void Borders_Bottom(BorderType type, char expected)
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
    [DataRow(BorderType.SingleStraight, '├')]
    [DataRow(BorderType.SingleRounded, '├')]
    public void Borders_Left(BorderType type, char expected)
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
    [DataRow(BorderType.SingleStraight, '┤')]
    [DataRow(BorderType.SingleRounded, '┤')]
    public void Borders_Right(BorderType type, char expected)
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
    [DataRow(BorderType.SingleStraight, '┼')]
    [DataRow(BorderType.SingleRounded, '┼')]
    public void Borders_Cross(BorderType type, char expected)
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
        borders.UpdateBorderType(BorderType.SingleRounded);
        BorderType actual = borders.Type;

        // Assert
        Assert.AreEqual(BorderType.SingleRounded, actual);
    }
    #endregion
}
