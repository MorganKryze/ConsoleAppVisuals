/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

public class UnitTestCore
{
    #region SetSelector
    [TestMethod]
    public void Test_SetSelectorCharactersForMenu()
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

    #region ApplyNegative
    // The class can apply negative colors to the console.
    [TestMethod]
    public void Test_ApplyNegative()
    {
        // Arrange
        ConsoleColor initialForegroundColor = Console.ForegroundColor;
        ConsoleColor initialBackgroundColor = Console.BackgroundColor;
        ConsoleColor expectedForegroundColor = initialBackgroundColor;
        ConsoleColor expectedBackgroundColor = initialForegroundColor;

        // Act
        Core.ApplyNegative(true);
        ConsoleColor actualForegroundColor = Console.ForegroundColor;
        ConsoleColor actualBackgroundColor = Console.BackgroundColor;

        // Assert
        Assert.AreEqual(expectedForegroundColor, actualForegroundColor);
        Assert.AreEqual(expectedBackgroundColor, actualBackgroundColor);

        // Cleanup
        Core.ApplyNegative(false);
        Console.ForegroundColor = initialForegroundColor;
        Console.BackgroundColor = initialBackgroundColor;
    }
    #endregion
}
