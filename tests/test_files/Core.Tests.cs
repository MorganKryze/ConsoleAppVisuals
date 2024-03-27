/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace tests;

[TestClass]
public class UnitTestCore
{

    #region SetForegroundColor
    [TestMethod]
    public void SetForegroundColor_ForConsole()
    {
        // Arrange
        ConsoleColor color = ConsoleColor.Red;

        // Act
        Core.SetForegroundColor(color);
        var colorPanel = Core.GetColorPanel;

        // Assert
        Assert.AreEqual(color, colorPanel.Item1);
    }
    #endregion

    #region LoadTerminalColorPanel
    [TestMethod]
    public void LoadTerminalColorPanel()
    {
        // Arrange
        var initialColorPanel = Core.GetColorPanel;

        // Act
        Core.LoadTerminalColorPanel();

        // Assert
        Assert.AreNotEqual(initialColorPanel, Core.GetColorPanel);
    }
    #endregion

    #region GetInitialColorPanel
    [TestMethod]
    public void GetInitialColorPanel()
    {
        // Assert
        Assert.AreEqual((ConsoleColor.White, ConsoleColor.Black), Core.GetInitialColorPanel);
    }

    #endregion

    #region GetRandom color
    [TestMethod]
    public void GetRandomColor()
    {
        // Act
        var color = Core.GetRandomColor();

        // Assert
        Assert.IsTrue(Enum.IsDefined(typeof(ConsoleColor), color));
    }
    #endregion
}
