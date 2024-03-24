/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestTitle
{
    #region Cleanup
    [TestCleanup]
    public void Cleanup()
    {
        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion

    #region UpdateTextTests
    [TestMethod]
    public void UpdateText_UpdatesTextCorrectly()
    {
        // Arrange
        Title title1 = new("Hello World!", 2);
        Title title2 = new("Bonjour Monde !", 2);

        // Act
        title1.UpdateText("Bonjour Monde !");

        // Assert
        Assert.AreEqual(title1.StyledText[0], title2.StyledText[0]);
    }
    #endregion

    #region UpdateMarginTests
    [TestMethod]
    public void UpdateMargin_UpdatesMarginCorrectly()
    {
        // Arrange
        Title title1 = new("Hello World!", 2);
        Title title2 = new("Bonjour Monde !", 0);

        // Act
        title1.UpdateMargin(0);

        // Assert
        Assert.AreEqual(title1.Height, title2.Height);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void UpdateMargin_UpdatesMarginOutOfWindowHeight()
    {
        // Arrange
        Title title1 = new("Hello World!", 2);

        // Act
        title1.UpdateMargin(100);
    }
    #endregion

    #region UpdateAlignmentTests

    [TestMethod]
    public void UpdateAlignment_UpdatesAlignmentCorrectly()
    {
        // Arrange
        Title title1 = new("Hello World!", 2);

        // Act
        title1.UpdateAlignment(TextAlignment.Center);

        // Assert
        Assert.AreEqual(TextAlignment.Center, title1.TextAlignment);
    }
    #endregion

    #region UpdateFont
    [TestMethod]
    public void UpdateFont_UpdatesFontCorrectly()
    {
        // Arrange
        Title title1 = new("Hello World!", 2);

        // Act
        title1.UpdateFont(Font.Ghost);

        // Assert
        Assert.AreEqual(Font.Ghost, title1.Font);
        Assert.AreEqual(Font.Ghost, title1.Styler.Font);
    }
    #endregion
}
