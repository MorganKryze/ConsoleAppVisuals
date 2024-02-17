/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

[TestClass]
public class UnitTestIntSelector
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
    [TestCategory("IntSelector")]
    [DataRow(Placement.TopCenter)]
    [DataRow(Placement.TopLeft)]
    [DataRow(Placement.TopRight)]
    public void Placement_Getter(Placement placement)
    {
        // Arrange
        var intSelector = new IntSelector("Question", 0, 10, 5, 1, placement, 0);

        // Act
        var actualPlacement = intSelector.Placement;

        // Assert
        Assert.AreEqual(placement, actualPlacement);
    }

    #endregion

    #region Line
    [TestMethod]
    [TestCategory("IntSelector")]
    public void Line_Getter()
    {
        // Arrange
        var line = 0;
        var intSelector = new IntSelector("Question", 0, 10, 5, 1, Placement.TopCenter, line);

        // Act
        var actualLine = intSelector.Line;

        // Assert
        Assert.AreEqual(line, actualLine);
    }

    [TestMethod]
    [TestCategory("IntSelector")]
    public void Line_NoInput()
    {
        // Arrange
        var line = 0;
        var intSelector = new IntSelector("Question", 0, 10, 5, 1, Placement.TopCenter);

        // Act
        var actualLine = intSelector.Line;

        // Assert
        Assert.AreEqual(line, actualLine);
    }

    #endregion

    #region Height
    [TestMethod]
    [TestCategory("IntSelector")]
    public void Height_Getter()
    {
        // Arrange
        var intSelector = new IntSelector("Question", 0, 10, 5, 1, Placement.TopCenter, 0);

        // Act
        var actualHeight = intSelector.Height;

        // Assert
        Assert.AreEqual(7, actualHeight);
    }
    #endregion

    #region Width
    [TestMethod]
    [TestCategory("IntSelector")]
    public void Width_Getter()
    {
        // Arrange
        var intSelector = new IntSelector("Question", 0, 10, 5, 1, Placement.TopCenter, 0);

        // Act
        var actualWidth = intSelector.Width;

        // Assert
        Assert.AreEqual(12, actualWidth);
    }

    #endregion

    #region Constructor
    [TestMethod]
    [TestCategory("IntSelector")]
    public void Constructor()
    {
        // Arrange
        var question = "Question";
        var min = 0;
        var max = 10;
        var start = 5;
        var step = 1;
        var placement = Placement.TopCenter;
        var line = 0;

        // Act
        var intSelector = new IntSelector(question, min, max, start, step, placement, line);

        // Assert
        Assert.AreEqual(question, intSelector.Question);
        Assert.AreEqual(min, intSelector.Min);
        Assert.AreEqual(max, intSelector.Max);
        Assert.AreEqual(start, intSelector.Start);
        Assert.AreEqual(step, intSelector.Step);
        Assert.AreEqual(placement, intSelector.Placement);
        Assert.AreEqual(line, intSelector.Line);
        Assert.AreEqual(false, intSelector.RoundedCorners);
    }

    [TestMethod]
    [TestCategory("IntSelector")]
    [DataRow(50, 10)]
    [DataRow(100, 0)]
    public void Constructor_CheckMin(int min, int max)
    {
        // Arrange
        var question = "Question";
        var start = 5;
        var step = 1;
        var placement = Placement.TopCenter;
        var line = 0;

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(
            () => new IntSelector(question, min, max, start, step, placement, line)
        );
    }

    [TestMethod]
    [TestCategory("IntSelector")]
    [DataRow(0, 10, 100)]
    [DataRow(50, 1, 25)]
    public void Constructor_CheckStart(int start, int min, int max)
    {
        // Arrange
        var question = "Question";
        var step = 1;
        var placement = Placement.TopCenter;
        var line = 0;

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(
            () => new IntSelector(question, min, max, start, step, placement, line)
        );
    }

    [TestMethod]
    [TestCategory("IntSelector")]
    [DataRow(10, 0, 50, 60)]
    [DataRow(0, 10, 100, 1000)]
    [DataRow(1, 1, 25, 0)]
    public void Constructor_CheckStep(int start, int min, int max, int step)
    {
        // Arrange
        var question = "Question";
        var placement = Placement.TopCenter;
        var line = 0;

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(
            () => new IntSelector(question, min, max, start, step, placement, line)
        );
    }
    #endregion
}
