/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestElement
{
    #region DimensionsTests

    [TestMethod]
    public void Dimensions_DefaultValues_ReturnsZero()
    {
        // Arrange
        var element = new TestElement();

        // Assert
        Assert.AreEqual(0, element.Height);
        Assert.AreEqual(0, element.Width);
        Assert.AreEqual(0, element.Line);
        Assert.AreEqual(Placement.TopCenter, element.Placement);
    }

    #endregion

    #region LineTests

    [TestMethod]
    public void Line_DefaultValue_ReturnsZero()
    {
        // Arrange
        var element = new TestElement();

        // Assert
        Assert.AreEqual(0, element.Line);
        Assert.AreEqual(Placement.TopCenter, element.Placement);
    }

    #endregion

    #region PlacementTests

    [TestMethod]
    public void Placement_DefaultValue_ReturnsTopCenter()
    {
        // Arrange
        var element = new TestElement();

        // Assert
        Assert.AreEqual(Placement.TopCenter, element.Placement);
    }

    #endregion

    #region ToggleVisibilityTests

    [TestMethod]
    public void ToggleVisibility_WhenAddedToWindow_ThrowsInvalidOperationException()
    {
        // Arrange
        var element1 = new TestElement();
        Window.AddElement(element1);
        var element2 = new TestElement();
        Window.AddElement(element2);

        // Act & Assert
        Assert.ThrowsException<InvalidOperationException>(() => element2.ToggleVisibility());
    }

    #endregion

    #region Line
    [TestMethod]
    public void Line_MinimalApp()
    {
        // Arrange
        var title = new Title("Title");
        var header = new Header();
        var footer = new Footer();
        var loadingBarLeft = new FakeLoadingBar("LoadingBarLeft", Placement.TopLeft);
        var loadingBarRight = new FakeLoadingBar("LoadingBarRight", Placement.TopRight);
        var loadingBarCenter = new FakeLoadingBar("LoadingBarCenter", Placement.TopCenter);

        // Act
        Window.AddElement(title, header, footer, loadingBarLeft, loadingBarRight, loadingBarCenter);

        // Assert
        Assert.IsNotNull(title.Line);
        Assert.IsNotNull(header.Line);
        Assert.IsNotNull(footer.Line);
        Assert.IsNotNull(loadingBarLeft.Line);
        Assert.IsNotNull(loadingBarRight.Line);
        Assert.IsNotNull(loadingBarCenter.Line);
    }
    #endregion
}

public class TestElement : Element { }
