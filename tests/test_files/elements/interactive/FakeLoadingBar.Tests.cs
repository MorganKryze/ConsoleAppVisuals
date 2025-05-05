/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace tests;

[TestClass]
public class UnitTestFakeLoadingBar
{
    #region Cleanup
    [TestCleanup]
    public void Cleanup()
    {
        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion

    #region Constructor
    [TestMethod]
    [DataRow("Test", 10, Placement.TopCenterFullWidth, 1000, 1000)]
    [DataRow("Test", 10, Placement.TopCenterFullWidth, 1000, 1000)]
    public void Constructor_Initialization(
        string text,
        int width,
        Placement placement,
        int processDuration,
        int additionalDuration
    )
    {
        // Arrange

        // Act
        var loadingBar = new FakeLoadingBar(
            text,
            width,
            placement,
            processDuration,
            additionalDuration
        );

        // Assert
        Assert.IsNotNull(loadingBar);
    }

    [TestMethod]
    public void Constructor_GetLineAvailable()
    {
        // Arrange
        var line = 0;
        var loadingBar = new FakeLoadingBar("Test", 10, Placement.TopCenterFullWidth, 1000, 1000);

        // Act
        var lineAvailable = loadingBar.Line;

        // Assert
        Assert.AreEqual(line, lineAvailable);
    }
    #endregion

    #region UpdateText
    [TestMethod]
    [DataRow("hello world")]
    [DataRow("h")]
    public void UpdateText_ModifyText_TextUpdated(string text)
    {
        // Arrange
        var fakeLoadingBar = new FakeLoadingBar(
            "Test",
            10,
            Placement.TopCenterFullWidth,
            1000,
            1000
        );

        // Act
        fakeLoadingBar.UpdateText(text);

        // Assert
        Assert.AreEqual(fakeLoadingBar.Text, text);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void UpdateText_ModifyTextWithEmptyString_TextNotUpdated()
    {
        // Arrange
        var fakeLoadingBar = new FakeLoadingBar(
            "Test",
            10,
            Placement.TopCenterFullWidth,
            1000,
            1000
        );

        // Act
        fakeLoadingBar.UpdateText("");
    }
    #endregion

    #region Text
    [TestMethod]
    [DataRow("hello world")]
    [DataRow("h")]
    public void Text_SetText_TextSet(string text)
    {
        // Arrange
        var fakeLoadingBar = new FakeLoadingBar(
            "Test",
            10,
            Placement.TopCenterFullWidth,
            1000,
            1000
        );

        // Act
        fakeLoadingBar.UpdateText(text);

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
            10,
            Placement.TopCenterFullWidth,
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
            10,
            Placement.TopCenterFullWidth,
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
            10,
            Placement.TopCenterFullWidth,
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
            10,
            Placement.TopCenterFullWidth,
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
            10,
            Placement.TopCenterFullWidth,
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
            10,
            Placement.TopCenterFullWidth,
            1000,
            1000
        );

        // Act
        var width = fakeLoadingBar.Width;

        // Assert
        Assert.AreEqual(10, width);
    }

    [TestMethod]
    public void UpdateBarWidth_UpdateBarWidth_BarWidthUpdated()
    {
        // Arrange
        var fakeLoadingBar = new FakeLoadingBar(
            "Test",
            10,
            Placement.TopCenterFullWidth,
            1000,
            1000
        );

        // Act
        fakeLoadingBar.UpdateBarWidth(20);

        // Assert
        Assert.AreEqual(20, fakeLoadingBar.Width);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void UpdateBarWidth_UpdateBarWidthWithNegativeValue_BarWidthNotUpdated()
    {
        // Arrange
        var fakeLoadingBar = new FakeLoadingBar(
            "Test",
            10,
            Placement.TopCenterFullWidth,
            1000,
            1000
        );

        // Act
        fakeLoadingBar.UpdateBarWidth(-20);
    }
    #endregion

    #region UpdatePlacement
    [TestMethod]
    public void UpdatePlacement_UpdatePlacement_PlacementUpdated()
    {
        // Arrange
        var fakeLoadingBar = new FakeLoadingBar(
            "Test",
            10,
            Placement.TopCenterFullWidth,
            1000,
            1000
        );

        // Act
        fakeLoadingBar.UpdatePlacement(Placement.BottomCenterFullWidth);

        // Assert
        Assert.AreEqual(Placement.BottomCenterFullWidth, fakeLoadingBar.Placement);
    }
    #endregion

    #region UpdateAdditionalDuration
    [TestMethod]
    public void UpdateAdditionalDuration_UpdateAdditionalDuration_AdditionalDurationUpdated()
    {
        // Arrange
        var fakeLoadingBar = new FakeLoadingBar(
            "Test",
            10,
            Placement.TopCenterFullWidth,
            1000,
            1000
        );

        // Act
        fakeLoadingBar.UpdateAdditionalDuration(2000);

        // Assert
        Assert.AreEqual(2000, fakeLoadingBar.AdditionalDuration);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void UpdateAdditionalDuration_UpdateAdditionalDurationWithNegativeValue_AdditionalDurationNotUpdated()
    {
        // Arrange
        var fakeLoadingBar = new FakeLoadingBar(
            "Test",
            10,
            Placement.TopCenterFullWidth,
            1000,
            1000
        );

        // Act
        fakeLoadingBar.UpdateAdditionalDuration(-2000);
    }
    #endregion

    #region UpdateProcessDuration
    [TestMethod]
    public void UpdateProcessDuration_UpdateProcessDuration_ProcessDurationUpdated()
    {
        // Arrange
        var fakeLoadingBar = new FakeLoadingBar(
            "Test",
            10,
            Placement.TopCenterFullWidth,
            1000,
            1000
        );

        // Act
        fakeLoadingBar.UpdateProcessDuration(2000);

        // Assert
        Assert.AreEqual(2000, fakeLoadingBar.ProcessDuration);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void UpdateProcessDuration_UpdateProcessDurationWithNegativeValue_ProcessDurationNotUpdated()
    {
        // Arrange
        var fakeLoadingBar = new FakeLoadingBar(
            "Test",
            10,
            Placement.TopCenterFullWidth,
            1000,
            1000
        );

        // Act
        fakeLoadingBar.UpdateProcessDuration(-2000);
    }
    #endregion
}
