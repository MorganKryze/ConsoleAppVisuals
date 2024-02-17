/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

[TestClass]
public class UnitTestScrollingMenu
{
    #region Cleanup
    [TestCleanup]
    public void Cleanup()
    {
        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion

    #region Placement
    [TestMethod]
    [TestCategory("ScrollingMenu")]
    public void Placement_Getter()
    {
        // Arrange
        var scrollingMenu = new ScrollingMenu("Question",0, Placement.TopCenter, 0, "Choice1", "Choice2", "Choice3");

        // Act
        var placement = scrollingMenu.Placement;

        // Assert
        Assert.AreEqual(Placement.TopCenter, placement);
    }
    #endregion

    #region Line
    [TestMethod]
    [TestCategory("ScrollingMenu")]
    public void Line_Getter()
    {
        // Arrange
        var scrollingMenu = new ScrollingMenu("Question", 0, Placement.TopCenter, 0, "Choice1", "Choice2", "Choice3");

        // Act
        var line = scrollingMenu.Line;

        // Assert
        Assert.AreEqual(0, line);
    }

    [TestMethod]
    [TestCategory("ScrollingMenu")]
    public void Line_Getter_NoInput()
    {
        // Arrange
        var scrollingMenu = new ScrollingMenu("Question", 0, Placement.TopCenter, default, "Choice1", "Choice2", "Choice3");

        // Act
        var line = scrollingMenu.Line;

        // Assert
        Assert.AreEqual(0, line);
    }
    #endregion

    #region Height
    [TestMethod]
    [TestCategory("ScrollingMenu")]
    public void Height_Getter()
    {
        // Arrange
        var scrollingMenu = new ScrollingMenu("Question", 0, Placement.TopCenter, 0, "Choice1", "Choice2", "Choice3");

        // Act
        var height = scrollingMenu.Height;

        // Assert
        Assert.AreEqual(5, height);
    }
    #endregion

    #region Width
    [TestMethod]
    [TestCategory("ScrollingMenu")]
    public void Width_Getter()
    {
        // Arrange
        var scrollingMenu = new ScrollingMenu("Question", 0, Placement.TopCenter, 0, "Choice1", "Choice2", "Choice3");

        // Act
        var width = scrollingMenu.Width;

        // Assert
        Assert.AreEqual(11, width);
    }
    #endregion

    #region Question
    [TestMethod]
    [TestCategory("ScrollingMenu")]
    public void Question_Getter()
    {
        // Arrange
        var scrollingMenu = new ScrollingMenu("Question", 0, Placement.TopCenter, 0, "Choice1", "Choice2", "Choice3");

        // Act
        var question = scrollingMenu.Question;

        // Assert
        Assert.AreEqual("Question", question);
    }
    #endregion

    #region Choices
    [TestMethod]
    [TestCategory("ScrollingMenu")]
    public void Choices_Getter()
    {
        // Arrange
        var scrollingMenu = new ScrollingMenu("Question", 0, Placement.TopCenter, 0, "Choice1", "Choice2", "Choice3");

        // Act
        var choices = scrollingMenu.Choices;

        // Assert
        Assert.AreEqual(3, choices.Length);
        Assert.AreEqual("Choice1", choices[0]);
        Assert.AreEqual("Choice2", choices[1]);
        Assert.AreEqual("Choice3", choices[2]);
    }
    #endregion

    #region DefaultIndex
    [TestMethod]
    [TestCategory("ScrollingMenu")]
    public void DefaultIndex_Getter()
    {
        // Arrange
        var scrollingMenu = new ScrollingMenu("Question", 1, Placement.TopCenter, 0, "Choice1", "Choice2", "Choice3");

        // Act
        var defaultIndex = scrollingMenu.DefaultIndex;

        // Assert
        Assert.AreEqual(1, defaultIndex);
    }
    #endregion
}
