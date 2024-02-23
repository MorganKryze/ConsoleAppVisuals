/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestInteractiveList
{
    #region Cleanup
    [TestCleanup]
    public void Cleanup()
    {
        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion

    #region ConstructorTests
    [TestMethod]
    public void Constructor_HappyPath()
    {
        // Arrange
        var list = new InteractiveList();

        // Act
        // No additional action needed

        // Assert
        Assert.IsNotNull(list);
    }

    [TestMethod]
    public void Constructor_WithLine()
    {
        // Arrange
        var list = new InteractiveList(Placement.TopLeft, true, 1);

        // Act
        // No additional action needed

        // Assert
        Assert.AreEqual(1, list.Line);
    }
    #endregion



    #region GeneralTests
    [TestMethod]
    public void RoundedCorners_SetsRoundedCornersCorrectly()
    {
        // Arrange
        var list = new InteractiveList(Placement.TopLeft, true);
        var list2 = new InteractiveList(Placement.TopLeft, false);

        // Act
        list.SetRoundedCorners(false);
        list2.SetRoundedCorners(true);

        // Assert
        Assert.AreNotEqual(list.RoundedCorners, list2.RoundedCorners);
    }

    [TestMethod]
    public void GetHeaders_ReturnsHeaders()
    {
        // Arrange
        var list = new InteractiveList(Placement.TopLeft, true);

        // Act
        var headers = list.GetHeaders;

        // Assert
        Assert.IsNotNull(headers);
    }

    [TestMethod]
    public void GetLines_ReturnsLines()
    {
        // Arrange
        var list = new InteractiveList(Placement.TopLeft, true);

        // Act
        var lines = list.GetLines;

        // Assert
        Assert.IsNotNull(lines);
    }

    [TestMethod]
    public void Placement_ReturnsPlacement()
    {
        // Arrange
        var list = new InteractiveList(Placement.TopLeft, true);

        // Act
        var placement = list.Placement;

        // Assert
        Assert.IsNotNull(placement);
    }

    [TestMethod]
    public void Line_ReturnsLine()
    {
        // Arrange
        var list = new InteractiveList(Placement.TopLeft, true, 1);

        // Act
        var line = list.Line;

        // Assert
        Assert.AreEqual(1, line);
    }

    [TestMethod]
    public void Height_ReturnsHeight()
    {
        // Arrange
        var list = new InteractiveList(Placement.TopLeft, true);

        // Act
        var height = list.Height;

        // Assert
        Assert.IsNotNull(height);
    }

    [TestMethod]
    public void Width_ReturnsWidth()
    {
        // Arrange
        var list = new InteractiveList(Placement.TopLeft, true);

        // Act
        var width = list.Width;

        // Assert
        Assert.IsNotNull(width);
    }

    [TestMethod]
    public void Count_ReturnsCount()
    {
        // Arrange
        var list = new InteractiveList(Placement.TopLeft, true);

        // Act
        var count = list.Count;

        // Assert
        Assert.IsNotNull(count);
    }


    #endregion
}
