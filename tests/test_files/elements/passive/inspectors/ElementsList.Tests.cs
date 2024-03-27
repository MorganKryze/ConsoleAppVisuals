/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace tests;

[TestClass]
public class UnitTestElementsList
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
        var list = new ElementsList();

        // Act
        // No additional action needed

        // Assert
        Assert.IsNotNull(list);
    }

    [TestMethod]
    public void Constructor_WithLine()
    {
        // Arrange
        var list = new ElementsList(ElementType.Interactive, Placement.TopLeft);

        // Act
        // No additional action needed

        // Assert
        Assert.AreEqual(0, list.Line);
    }
    #endregion



    #region GeneralTests

    [TestMethod]
    public void GetHeaders_ReturnsHeaders()
    {
        // Arrange
        var headers = ElementsList.Headers;

        // Assert
        Assert.IsNotNull(headers);
    }

    [TestMethod]
    public void GetLines_ReturnsLines()
    {
        // Arrange
        var list = new ElementsList(ElementType.Default, Placement.TopLeft);

        // Act
        var lines = list.Lines;

        // Assert
        Assert.IsNotNull(lines);
    }

    [TestMethod]
    public void Placement_ReturnsPlacement()
    {
        // Arrange
        var list = new ElementsList(ElementType.Default, Placement.TopLeft);

        // Act
        var placement = list.Placement;

        // Assert
        Assert.IsNotNull(placement);
    }

    [TestMethod]
    public void Line_ReturnsLine()
    {
        // Arrange
        var list = new ElementsList(ElementType.Default, Placement.TopLeft);

        // Act
        var line = list.Line;

        // Assert
        Assert.AreEqual(0, line);
    }

    [TestMethod]
    public void Height_ReturnsHeight()
    {
        // Arrange
        var list = new ElementsList(ElementType.Default, Placement.TopLeft);

        // Act
        var height = list.Height;

        // Assert
        Assert.IsNotNull(height);
    }

    [TestMethod]
    public void Width_ReturnsWidth()
    {
        // Arrange
        var list = new ElementsList(ElementType.Default, Placement.TopLeft);

        // Act
        var width = list.Width;

        // Assert
        Assert.IsNotNull(width);
    }

    [TestMethod]
    public void Count_ReturnsCount()
    {
        // Arrange
        var list = new ElementsList(ElementType.Default, Placement.TopLeft);

        // Act
        var count = list.Count;

        // Assert
        Assert.IsNotNull(count);
    }

    #endregion

    #region UpdatePlacement
    [TestMethod]
    public void UpdatePlacement_HappyPath()
    {
        // Arrange
        var list = new ElementsList(ElementType.Passive, Placement.TopLeft);

        // Act
        list.UpdatePlacement(Placement.TopCenter);

        // Assert
        Assert.AreEqual(Placement.TopCenter, list.Placement);
    }
    #endregion

    #region UpdateElementsTypeExpected
    [TestMethod]
    public void UpdateElementsTypeExpected_HappyPath()
    {
        // Arrange
        var list = new ElementsList(ElementType.Default, Placement.TopLeft);

        // Act
        list.UpdateElementsTypeExpected(ElementType.Interactive);

        // Assert
        Assert.AreEqual(ElementType.Interactive, list.ElementsTypeExpected);
    }
    #endregion

    #region Get Title default
    [TestMethod]
    public void GetTitle_Default()
    {
        // Arrange
        var list = new ElementsList((ElementType)int.MaxValue, Placement.TopLeft);

        // Act
        var title = list.Title;

        // Assert
        Assert.AreEqual("Element types available", title);
    }
    #endregion

    #region UpdateBordersType
    [TestMethod]
    public void UpdateBordersType_HappyPath()
    {
        // Arrange
        var list = new ElementsList(ElementType.Default, Placement.TopLeft);

        // Act
        list.UpdateBordersType(BordersType.DoubleStraight);

        // Assert
        Assert.AreEqual(BordersType.DoubleStraight, list.BordersType);
        Assert.AreEqual(BordersType.DoubleStraight, list.Borders.Type);
    }
    #endregion
}
