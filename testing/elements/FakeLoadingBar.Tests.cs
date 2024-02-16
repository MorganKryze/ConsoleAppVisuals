/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

[TestClass]
public class UnitTestFakeLoadingBar
{
    #region Constructor
    [TestMethod]
    [DataRow("Test", Placement.TopCenterFullWidth, 0, 1000, 1000)]
    [DataRow("Test", Placement.TopCenterFullWidth, null, 1000, 1000)]
    public void Constructor_Initialization(
        string text,
        Placement placement,
        int line,
        int processDuration,
        int additionalDuration
    )
    {
        // Arrange

        // Act
        var loadingBar = new FakeLoadingBar(
            text,
            placement,
            line,
            processDuration,
            additionalDuration
        );

        // Assert
        Assert.IsNotNull(loadingBar);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    [DataRow(30000)]
    [DataRow(-1)]
    public void Constructor_InvalidLine_ExceptionThrown(int line)
    {
        // Arrange

        // Act
        new FakeLoadingBar("Test", Placement.TopCenterFullWidth, line, 1000, 1000);
        // Assert
    }
    #endregion

    #region UpdateText
    [TestMethod]
    [DataRow("hello world")]
    [DataRow("")]
    public void UpdateText_ModifyText_TextUpdated(string text)
    {
        // Arrange
        var fakeLoadingBar = new FakeLoadingBar(
            "Test",
            Placement.TopCenterFullWidth,
            0,
            1000,
            1000
        );

        // Act
        fakeLoadingBar.UpdateText(text);

        // Assert
        Assert.AreEqual(fakeLoadingBar.Text, text);
    }
    #endregion

    #region Text
    [TestMethod]
    [DataRow("hello world")]
    [DataRow("")]
    public void Text_SetText_TextSet(string text)
    {
        // Arrange
        var fakeLoadingBar = new FakeLoadingBar(
            "Test",
            Placement.TopCenterFullWidth,
            0,
            1000,
            1000
        );

        // Act
        fakeLoadingBar.Text = text;

        // Assert
        Assert.AreEqual(fakeLoadingBar.Text, text);
    }
    #endregion

    #region Placement
    [TestMethod]
    public void Placement_GetPlacement_PlacementReturned()
    {
        // Arrange
        var fakeLoadingBar = new FakeLoadingBar(
            "Test",
            Placement.TopCenterFullWidth,
            0,
            1000,
            1000
        );

        // Act
        var placement = fakeLoadingBar.Placement;

        // Assert
        Assert.AreEqual(Placement.TopCenterFullWidth, placement);
    }
    #endregion

    #region Line
    [TestMethod]
    public void Line_GetLine_LineReturned()
    {
        // Arrange
        var fakeLoadingBar = new FakeLoadingBar(
            "Test",
            Placement.TopCenterFullWidth,
            0,
            1000,
            1000
        );

        // Act
        var line = fakeLoadingBar.Line;

        // Assert
        Assert.AreEqual(0, line);
    }
    #endregion

    #region ProcessDuration
    [TestMethod]
    public void ProcessDuration_GetProcessDuration_ProcessDurationReturned()
    {
        // Arrange
        var fakeLoadingBar = new FakeLoadingBar(
            "Test",
            Placement.TopCenterFullWidth,
            0,
            1000,
            1000
        );

        // Act
        var processDuration = fakeLoadingBar.ProcessDuration;

        // Assert
        Assert.AreEqual(1000, processDuration);
    }
    #endregion

    #region AdditionalDuration
    [TestMethod]
    public void AdditionalDuration_GetAdditionalDuration_AdditionalDurationReturned()
    {
        // Arrange
        var fakeLoadingBar = new FakeLoadingBar(
            "Test",
            Placement.TopCenterFullWidth,
            0,
            1000,
            1000
        );

        // Act
        var additionalDuration = fakeLoadingBar.AdditionalDuration;

        // Assert
        Assert.AreEqual(1000, additionalDuration);
    }
    #endregion

    #region Height
    [TestMethod]
    public void Height_GetHeight_HeightReturned()
    {
        // Arrange
        var fakeLoadingBar = new FakeLoadingBar(
            "Test",
            Placement.TopCenterFullWidth,
            0,
            1000,
            1000
        );

        // Act
        var height = fakeLoadingBar.Height;

        // Assert
        // No assertion provided as height is not settable
    }
    #endregion

    #region Width
    [TestMethod]
    public void Width_GetWidth_WidthReturned()
    {
        // Arrange
        var fakeLoadingBar = new FakeLoadingBar(
            "Test",
            Placement.TopCenterFullWidth,
            0,
            1000,
            1000
        );

        // Act
        var width = fakeLoadingBar.Width;

        // Assert
        // No assertion provided as width is not settable
    }
    #endregion
}
