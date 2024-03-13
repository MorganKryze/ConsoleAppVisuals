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
        var intSelector = new IntSelector("Question", 0, 10, 5, 1, placement);

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
        var intSelector = new IntSelector("Question", 0, 10, 5, 1, Placement.TopCenter);

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
        var intSelector = new IntSelector("Question", 0, 10, 5, 1, Placement.TopCenter);

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
        var intSelector = new IntSelector("Question", 0, 10, 5, 1, Placement.TopCenter);

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
        var intSelector = new IntSelector(question, min, max, start, step, placement);

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

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(
            () => new IntSelector(question, min, max, start, step, placement)
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

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(
            () => new IntSelector(question, min, max, start, step, placement)
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

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(
            () => new IntSelector(question, min, max, start, step, placement)
        );
    }
    #endregion

    #region UpdateQuestion

    [TestMethod]
    [TestCategory("IntSelector")]
    public void UpdateQuestion()
    {
        // Arrange
        var intSelector = new IntSelector("Question", 0, 10, 5, 1, Placement.TopCenter);
        var newQuestion = "New question";

        // Act
        intSelector.UpdateQuestion(newQuestion);

        // Assert
        Assert.AreEqual(newQuestion, intSelector.Question);
    }
    #endregion

    #region UpdateMin
    [TestMethod]
    [TestCategory("IntSelector")]
    public void UpdateMin()
    {
        // Arrange
        var intSelector = new IntSelector("Question", 0, 10, 5, 1, Placement.TopCenter);
        var newMin = 5;

        // Act
        intSelector.UpdateMin(newMin);

        // Assert
        Assert.AreEqual(newMin, intSelector.Min);
    }
    #endregion

    #region UpdateMax
    [TestMethod]
    [TestCategory("IntSelector")]
    public void UpdateMax()
    {
        // Arrange
        var intSelector = new IntSelector("Question", 0, 10, 5, 1, Placement.TopCenter);
        var newMax = 15;

        // Act
        intSelector.UpdateMax(newMax);

        // Assert
        Assert.AreEqual(newMax, intSelector.Max);
    }
    #endregion

    #region UpdateStart
    [TestMethod]
    [TestCategory("IntSelector")]
    public void UpdateStart()
    {
        // Arrange
        var intSelector = new IntSelector("Question", 0, 10, 5, 1, Placement.TopCenter);
        var newStart = 7;

        // Act
        intSelector.UpdateStart(newStart);

        // Assert
        Assert.AreEqual(newStart, intSelector.Start);
    }
    #endregion

    #region UpdateStep
    [TestMethod]
    [TestCategory("IntSelector")]
    public void UpdateStep()
    {
        // Arrange
        var intSelector = new IntSelector("Question", 0, 10, 5, 1, Placement.TopCenter);
        var newStep = 2;

        // Act
        intSelector.UpdateStep(newStep);

        // Assert
        Assert.AreEqual(newStep, intSelector.Step);
    }
    #endregion

    #region UpdatePlacement
    [TestMethod]
    [TestCategory("IntSelector")]
    [DataRow(Placement.TopCenter)]
    [DataRow(Placement.TopLeft)]
    [DataRow(Placement.TopRight)]
    public void UpdatePlacement(Placement placement)
    {
        // Arrange
        var intSelector = new IntSelector("Question", 0, 10, 5, 1, Placement.TopCenter);

        // Act
        intSelector.UpdatePlacement(placement);

        // Assert
        Assert.AreEqual(placement, intSelector.Placement);
    }
    #endregion

    #region UpdateRoundedCorners
    [TestMethod]
    [TestCategory("IntSelector")]
    [DataRow(true)]
    [DataRow(false)]
    public void UpdateRoundedCorners(bool roundedCorners)
    {
        // Arrange
        var intSelector = new IntSelector("Question", 0, 10, 5, 1, Placement.TopCenter);

        // Act
        intSelector.SetRoundedCorners(roundedCorners);

        // Assert
        Assert.AreEqual(roundedCorners, intSelector.RoundedCorners);
    }
    #endregion

    #region UpdateLeftSelector
    [TestMethod]
    [TestCategory("IntSelector")]
    [DataRow('X')]
    [DataRow('Y')]
    public void UpdateLeftSelector(char leftSelector)
    {
        // Arrange
        var intSelector = new IntSelector("Question", 0, 10, 5, 1, Placement.TopCenter);

        // Act
        intSelector.UpdateLeftSelector(leftSelector);

        // Assert
        Assert.AreEqual(leftSelector, intSelector.LeftSelector);
    }
    #endregion

    #region UpdateRightSelector
    [TestMethod]
    [TestCategory("IntSelector")]
    [DataRow('X')]
    [DataRow('Y')]
    public void UpdateRightSelector(char rightSelector)
    {
        // Arrange
        var intSelector = new IntSelector("Question", 0, 10, 5, 1, Placement.TopCenter);

        // Act
        intSelector.UpdateRightSelector(rightSelector);

        // Assert
        Assert.AreEqual(rightSelector, intSelector.RightSelector);
    }
    #endregion
}
