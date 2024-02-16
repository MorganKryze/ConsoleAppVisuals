/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestTitle
{
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
        Title title2 = new("Bonjour Monde !", 2);

        // Act
        title1.UpdateMargin(3);

        // Assert
        Assert.AreNotEqual(title1.Height, title2.Height);
    }
    #endregion
}
