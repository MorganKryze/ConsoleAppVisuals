/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace tests;

[TestClass]
public class UnitTestPosition
{
    [TestMethod]
    public void Constructor_PositionInitializedWithGivenValues()
    {
        // Arrange
        var position = new Position(1, 2);

        // Act & Assert
        Assert.AreEqual(1, position.X);
        Assert.AreEqual(2, position.Y);
    }

    [TestMethod]
    public void CopyConstructor_PositionCopiedCorrectly()
    {
        // Arrange
        var original = new Position(1, 2);

        // Act
        var copy = new Position(original);

        // Assert
        Assert.AreEqual(original, copy);
    }

    [TestMethod]
    public void ToString_ReturnsCorrectStringRepresentation()
    {
        // Arrange
        var position = new Position(1, 2);

        // Act & Assert
        Assert.AreEqual("Line : 1 ; Column : 2", position.ToString());
    }

    [TestMethod]
    public void Equals_TwoPositionsEqualWhenCoordinatesMatch()
    {
        // Arrange
        var position1 = new Position(1, 2);
        var position2 = new Position(1, 2);
        var position3 = new Position(2, 1);

        // Act & Assert
        Assert.IsTrue(position1.Equals(position2));
        Assert.IsFalse(position1.Equals(position3));
    }

    [TestMethod]
    public void GetHashCode_ReturnsSameHashCodeForEqualPositions()
    {
        // Arrange
        var position1 = new Position(1, 2);
        var position2 = new Position(1, 2);
        var position3 = new Position(2, 1);

        // Act & Assert
        Assert.AreEqual(position1.GetHashCode(), position2.GetHashCode());
        Assert.AreNotEqual(position1.GetHashCode(), position3.GetHashCode());
    }

    [TestMethod]
    public void OperatorEquals_ReturnsTrueWhenPositionsAreEqual()
    {
        // Arrange
        var position1 = new Position(1, 2);
        var position2 = new Position(1, 2);
        var position3 = new Position(2, 1);

        // Act & Assert
        Assert.IsTrue(position1 == position2);
        Assert.IsFalse(position1 == position3);
    }

    [TestMethod]
    public void OperatorNotEquals_ReturnsTrueWhenPositionsAreNotEqual()
    {
        // Arrange
        var position1 = new Position(1, 2);
        var position2 = new Position(1, 2);
        var position3 = new Position(2, 1);

        // Act & Assert
        Assert.IsFalse(position1 != position2);
        Assert.IsTrue(position1 != position3);
    }
}
