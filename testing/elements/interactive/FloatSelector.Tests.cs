/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

[TestClass]
public class UnitTestFloatSelector
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
    [TestCategory("FloatSelector")]
    [DataRow(Placement.TopCenter)]
    [DataRow(Placement.TopLeft)]
    [DataRow(Placement.TopRight)]
    public void Placement_Getter(Placement placement)
    {
        // Arrange
        var floatSelector = new FloatSelector("Question", 0.0f, 10.0f, 5.0f, 1.0f, placement);

        // Act
        var actualPlacement = floatSelector.Placement;

        // Assert
        Assert.AreEqual(placement, actualPlacement);
    }

    #endregion

    #region Line
    [TestMethod]
    [TestCategory("FloatSelector")]
    public void Line_Getter()
    {
        // Arrange
        var line = 0;
        var floatSelector = new FloatSelector(
            "Question",
            0.0f,
            10.0f,
            5.0f,
            1.0f,
            Placement.TopCenter
        );

        // Act
        var actualLine = floatSelector.Line;

        // Assert
        Assert.AreEqual(line, actualLine);
    }

    [TestMethod]
    [TestCategory("FloatSelector")]
    public void Line_NoInput()
    {
        // Arrange
        var line = 0;
        var floatSelector = new FloatSelector(
            "Question",
            0.0f,
            10.0f,
            5.0f,
            1.0f,
            Placement.TopCenter
        );

        // Act
        var actualLine = floatSelector.Line;

        // Assert
        Assert.AreEqual(line, actualLine);
    }

    #endregion

    #region Height
    [TestMethod]
    [TestCategory("FloatSelector")]
    public void Height_Getter()
    {
        // Arrange
        var floatSelector = new FloatSelector(
            "Question",
            0.0f,
            10.0f,
            5.0f,
            1.0f,
            Placement.TopCenter
        );

        // Act
        var actualHeight = floatSelector.Height;

        // Assert
        Assert.AreEqual(7, actualHeight);
    }
    #endregion

    #region Width
    [TestMethod]
    [TestCategory("FloatSelector")]
    public void Width_Getter()
    {
        // Arrange
        var floatSelector = new FloatSelector(
            "Question",
            0.0f,
            10.0f,
            5.0f,
            1.0f,
            Placement.TopCenter
        );

        // Act
        var actualWidth = floatSelector.Width;

        // Assert
        Assert.AreEqual(12, actualWidth);
    }

    #endregion

    #region Constructor
    [TestMethod]
    [TestCategory("FloatSelector")]
    public void Constructor()
    {
        // Arrange
        var question = "Question";
        var min = 0.0f;
        var max = 10.0f;
        var start = 5.0f;
        var step = 1.0f;
        var placement = Placement.TopCenter;
        var line = 0;

        // Act
        var floatSelector = new FloatSelector(question, min, max, start, step, placement);

        // Assert
        Assert.AreEqual(question, floatSelector.Question);
        Assert.AreEqual(min, floatSelector.Min);
        Assert.AreEqual(max, floatSelector.Max);
        Assert.AreEqual(start, floatSelector.Start);
        Assert.AreEqual(step, floatSelector.Step);
        Assert.AreEqual(placement, floatSelector.Placement);
        Assert.AreEqual(line, floatSelector.Line);
        Assert.AreEqual(false, floatSelector.RoundedCorners);
    }

    [TestMethod]
    [TestCategory("FloatSelector")]
    [DataRow(50.0f, 10.0f)]
    [DataRow(100.0f, 0.0f)]
    public void Constructor_CheckMin(float min, float max)
    {
        // Arrange
        var question = "Question";
        var start = 5.0f;
        var step = 1.0f;
        var placement = Placement.TopCenter;

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(
            () => new FloatSelector(question, min, max, start, step, placement)
        );
    }

    [TestMethod]
    [TestCategory("FloatSelector")]
    [DataRow(0.0f, 10.0f, 100.0f)]
    [DataRow(50.0f, 1.0f, 25.0f)]
    public void Constructor_CheckStart(float start, float min, float max)
    {
        // Arrange
        var question = "Question";
        var step = 1.0f;
        var placement = Placement.TopCenter;

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(
            () => new FloatSelector(question, min, max, start, step, placement)
        );
    }

    [TestMethod]
    [TestCategory("FloatSelector")]
    [DataRow(10.0f, 0.0f, 50.0f, 60.0f)]
    [DataRow(0.0f, 10.0f, 100.0f, 1000.0f)]
    [DataRow(1.0f, 1.0f, 25.0f, 0.0f)]
    public void Constructor_CheckStep(float start, float min, float max, float step)
    {
        // Arrange
        var question = "Question";
        var placement = Placement.TopCenter;

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(
            () => new FloatSelector(question, min, max, start, step, placement)
        );
    }
    #endregion

    #region UpdateQuestion
    [TestMethod]
    [TestCategory("FloatSelector")]
    public void UpdateQuestion()
    {
        // Arrange
        var floatSelector = new FloatSelector(
            "Question",
            0.0f,
            10.0f,
            5.0f,
            1.0f,
            Placement.TopCenter
        );

        // Act
        floatSelector.UpdateQuestion("New question");

        // Assert
        Assert.AreEqual("New question", floatSelector.Question);
    }
    #endregion


    #region UpdateMin

    [TestMethod]
    [TestCategory("FloatSelector")]
    public void UpdateMin()
    {
        // Arrange
        var floatSelector = new FloatSelector(
            "Question",
            0.0f,
            10.0f,
            5.0f,
            1.0f,
            Placement.TopCenter
        );

        // Act
        floatSelector.UpdateMin(1.0f);

        // Assert
        Assert.AreEqual(1.0f, floatSelector.Min);
    }

    #endregion

    #region UpdateMax
    [TestMethod]
    [TestCategory("FloatSelector")]
    public void UpdateMax()
    {
        // Arrange
        var floatSelector = new FloatSelector(
            "Question",
            0.0f,
            10.0f,
            5.0f,
            1.0f,
            Placement.TopCenter
        );

        // Act
        floatSelector.UpdateMax(20.0f);

        // Assert
        Assert.AreEqual(20.0f, floatSelector.Max);
    }
    #endregion

    #region UpdateStart

    [TestMethod]
    [TestCategory("FloatSelector")]
    public void UpdateStart()
    {
        // Arrange
        var floatSelector = new FloatSelector(
            "Question",
            0.0f,
            10.0f,
            5.0f,
            1.0f,
            Placement.TopCenter
        );

        // Act
        floatSelector.UpdateStart(2.0f);

        // Assert
        Assert.AreEqual(2.0f, floatSelector.Start);
    }
    #endregion

    #region UpdateStep
    [TestMethod]
    [TestCategory("FloatSelector")]
    public void UpdateStep()
    {
        // Arrange
        var floatSelector = new FloatSelector(
            "Question",
            0.0f,
            10.0f,
            5.0f,
            1.0f,
            Placement.TopCenter
        );

        // Act
        floatSelector.UpdateStep(2.0f);

        // Assert
        Assert.AreEqual(2.0f, floatSelector.Step);
    }
    #endregion

    #region UpdatePlacement
    [TestMethod]
    [TestCategory("FloatSelector")]
    [DataRow(Placement.TopCenter)]
    [DataRow(Placement.TopLeft)]
    [DataRow(Placement.TopRight)]
    public void UpdatePlacement(Placement placement)
    {
        // Arrange
        var floatSelector = new FloatSelector(
            "Question",
            0.0f,
            10.0f,
            5.0f,
            1.0f,
            Placement.TopCenter
        );

        // Act
        floatSelector.UpdatePlacement(placement);

        // Assert
        Assert.AreEqual(placement, floatSelector.Placement);
    }
    #endregion

    #region SetRoundedCorners
    [TestMethod]
    [TestCategory("FloatSelector")]
    [DataRow(true)]
    [DataRow(false)]
    public void SetRoundedCorners(bool roundedCorners)
    {
        // Arrange
        var floatSelector = new FloatSelector(
            "Question",
            0.0f,
            10.0f,
            5.0f,
            1.0f,
            Placement.TopCenter
        );

        // Act
        floatSelector.SetRoundedCorners(roundedCorners);

        // Assert
        Assert.AreEqual(roundedCorners, floatSelector.RoundedCorners);
    }
    #endregion
}
