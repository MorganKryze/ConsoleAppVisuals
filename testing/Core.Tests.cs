/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestCore
{
    #region SetSelector
    [TestMethod]
    public void SetSelector_NewChar()
    {
        // Arrange
        Core.SetSelector('>', '<');

        // Act
        var selector = Core.GetSelector;

        // Assert
        Assert.AreEqual('>', selector.Item1);
        Assert.AreEqual('<', selector.Item2);
    }
    #endregion

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
