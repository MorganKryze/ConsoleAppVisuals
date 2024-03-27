/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace tests;

[TestClass]
public class UnitTestSpacer
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
    [TestCategory("Spacer")]
    public void Placement_Getter()
    {
        // Arrange
        var spacer = new HeightSpacer(0);

        // Act
        var placement = spacer.Placement;

        // Assert
        Assert.AreEqual(Placement.TopCenter, placement);
    }

    [TestMethod]
    [TestCategory("Spacer")]
    public void UpdatePlacement()
    {
        // Arrange
        var spacer = new HeightSpacer(0);

        // Act
        spacer.UpdatePlacement(Placement.TopLeft);

        // Assert
        Assert.AreEqual(Placement.TopLeft, spacer.Placement);
    }
    #endregion

    #region Height
    [TestMethod]
    [TestCategory("Spacer")]
    public void Height_Getter()
    {
        // Arrange
        var spacer = new HeightSpacer(0);

        // Act
        var height = spacer.Height;

        // Assert
        Assert.AreEqual(0, height);
    }

    [TestMethod]
    [TestCategory("Spacer")]
    public void Constructor_ThrowsException()
    {
        // Act & Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new HeightSpacer(-1));
    }

    [TestMethod]
    [TestCategory("Spacer")]
    public void Constructor_ThrowsException2()
    {
        // Act & Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new HeightSpacer(int.MaxValue));
    }

    [TestMethod]
    [TestCategory("Spacer")]
    public void UpdateHeight()
    {
        // Arrange
        var spacer = new HeightSpacer(0);

        // Act
        spacer.UpdateHeight(0);

        // Assert
        Assert.AreEqual(0, spacer.Height);
    }

    [TestMethod]
    [TestCategory("Spacer")]
    public void UpdateHeight_ThrowsException()
    {
        // Arrange
        var spacer = new HeightSpacer(0);

        // Act & Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => spacer.UpdateHeight(-1));
    }

    [TestMethod]
    [TestCategory("Spacer")]
    public void UpdateHeight_ThrowsException2()
    {
        // Arrange
        var spacer = new HeightSpacer(0);

        // Act & Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => spacer.UpdateHeight(int.MaxValue));
    }
    #endregion
}