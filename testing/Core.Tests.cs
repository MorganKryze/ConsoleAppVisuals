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

    #region SetBackgroundColor
    [TestMethod]
    public void SetBackgroundColor_ForConsole()
    {
        // Arrange
        ConsoleColor color = ConsoleColor.Blue;

        // Act
        Core.SetBackgroundColor(color);
        var colorPanel = Core.GetColorPanel;

        // Assert
        Assert.AreEqual(color, colorPanel.Item2);
    }
    #endregion

    #region SaveColorPanel & LoadSavedColorPanel
    // The class can save the current color panel as a tuple.
    [TestMethod]
    public void SaveColorPanel()
    {
        // Arrange
        var initialColorPanel = Core.GetColorPanel;

        // Act
        Core.SaveColorPanel();
        Core.SetForegroundColor(ConsoleColor.Red);
        Core.SetBackgroundColor(ConsoleColor.Blue);

        // Assert
        Core.LoadSavedColorPanel();
        Assert.AreEqual(initialColorPanel, Core.GetColorPanel);
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

    #region ApplyNegative
    // The class can apply negative colors to the console.
    [TestMethod]
    public void ApplyNegative()
    {
        // Arrange
        Core.SetForegroundColor(ConsoleColor.Red);
        Core.SetBackgroundColor(ConsoleColor.Blue);

        // Act
        Core.ApplyNegative(true);

        // Assert
        Assert.AreEqual(ConsoleColor.Blue, Console.ForegroundColor);
        Assert.AreEqual(ConsoleColor.Red, Console.BackgroundColor);

        // Cleanup
        Core.ApplyNegative(false);
    }
    #endregion
}
