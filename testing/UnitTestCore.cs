/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestCore
{
    #region SetSelector
    [TestMethod]
    public void Test_SetSelectorNewChar()
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
    public void Test_SetForegroundColorForConsole()
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
    public void Test_SetBackgroundColorForConsole()
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
    public void Test_SaveColorPanel()
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
    public void Test_LoadTerminalColorPanel()
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
    public void Test_GetInitialColorPanel()
    {
        Assert.AreEqual((ConsoleColor.White, ConsoleColor.Black), Core.GetInitialColorPanel);
    }

    #endregion

    #region ApplyNegative
    // The class can apply negative colors to the console.
    [TestMethod]
    public void Test_ApplyNegative()
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
