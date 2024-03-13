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
        var scrollingMenu = new ScrollingMenu(
            "Question",
            0,
            Placement.TopCenter,
            "Choice1",
            "Choice2",
            "Choice3"
        );

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
        var scrollingMenu = new ScrollingMenu(
            "Question",
            0,
            Placement.TopCenter,
            "Choice1",
            "Choice2",
            "Choice3"
        );

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
        var scrollingMenu = new ScrollingMenu(
            "Question",
            0,
            Placement.TopCenter,
            "Choice1",
            "Choice2",
            "Choice3"
        );

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
        var scrollingMenu = new ScrollingMenu(
            "Question",
            0,
            Placement.TopCenter,
            "Choice1",
            "Choice2",
            "Choice3"
        );

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
        var scrollingMenu = new ScrollingMenu(
            "Question",
            0,
            Placement.TopCenter,
            "Choice1",
            "Choice2",
            "Choice3"
        );

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
        var scrollingMenu = new ScrollingMenu(
            "Question",
            0,
            Placement.TopCenter,
            "Choice1",
            "Choice2",
            "Choice3"
        );

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
        var scrollingMenu = new ScrollingMenu(
            "Question",
            0,
            Placement.TopCenter,
            "Choice1",
            "Choice2",
            "Choice3"
        );

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
        var scrollingMenu = new ScrollingMenu(
            "Question",
            1,
            Placement.TopCenter,
            "Choice1",
            "Choice2",
            "Choice3"
        );

        // Act
        var defaultIndex = scrollingMenu.DefaultIndex;

        // Assert
        Assert.AreEqual(1, defaultIndex);
    }
    #endregion

    #region UpdateQuestion
    [TestMethod]
    [TestCategory("ScrollingMenu")]
    public void UpdateQuestion()
    {
        // Arrange
        var scrollingMenu = new ScrollingMenu(
            "Question",
            1,
            Placement.TopCenter,
            "Choice1",
            "Choice2",
            "Choice3"
        );

        // Act
        scrollingMenu.UpdateQuestion("New Question");

        // Assert
        Assert.AreEqual("New Question", scrollingMenu.Question);
    }
    #endregion

    #region UpdateChoices
    [TestMethod]
    [TestCategory("ScrollingMenu")]
    public void UpdateChoices()
    {
        // Arrange
        var scrollingMenu = new ScrollingMenu(
            "Question",
            1,
            Placement.TopCenter,
            "Choice1",
            "Choice2",
            "Choice3"
        );

        // Act
        scrollingMenu.UpdateChoices("NewChoice1", "NewChoice2");

        // Assert
        var choices = scrollingMenu.Choices;
        Assert.AreEqual(2, choices.Length);
        Assert.AreEqual("NewChoice1", choices[0]);
        Assert.AreEqual("NewChoice2", choices[1]);
    }
    #endregion

    #region UpdateDefaultIndex
    [TestMethod]
    [TestCategory("ScrollingMenu")]
    public void UpdateDefaultIndex()
    {
        // Arrange
        var scrollingMenu = new ScrollingMenu(
            "Question",
            1,
            Placement.TopCenter,
            "Choice1",
            "Choice2",
            "Choice3"
        );

        // Act
        scrollingMenu.UpdateDefaultIndex(2);

        // Assert
        Assert.AreEqual(2, scrollingMenu.DefaultIndex);
    }
    #endregion

    #region UpdatePlacement
    [TestMethod]
    [TestCategory("ScrollingMenu")]
    [DataRow(Placement.TopCenter)]
    [DataRow(Placement.TopLeft)]
    public void UpdatePlacement(Placement placement)
    {
        // Arrange
        var scrollingMenu = new ScrollingMenu(
            "Question",
            1,
            Placement.TopCenter,
            "Choice1",
            "Choice2",
            "Choice3"
        );

        // Act
        scrollingMenu.UpdatePlacement(placement);

        // Assert
        Assert.AreEqual(placement, scrollingMenu.Placement);
    }
    #endregion

    #region UpdateSelector
    [TestMethod]
    [TestCategory("ScrollingMenu")]
    public void UpdateSelector()
    {
        // Arrange
        var scrollingMenu = new ScrollingMenu(
            "Question",
            1,
            Placement.TopCenter,
            "Choice1",
            "Choice2",
            "Choice3"
        );

        // Act
        scrollingMenu.UpdateSelector('X');

        // Assert
        Assert.AreEqual('X', scrollingMenu.Selector);
    }
    #endregion
}
