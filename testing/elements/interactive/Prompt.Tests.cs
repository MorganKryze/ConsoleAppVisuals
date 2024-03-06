/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

[TestClass]
public class UnitTestPrompt
{
    #region Cleanup
    [TestCleanup]
    public void Cleanup()
    {
        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion

    #region Properties
    [TestMethod]
    [TestCategory("Prompt")]
    public void Question_Getter()
    {
        // Arrange
        var prompt = new Prompt("What is your name?", "John Doe");

        // Act
        var actual = prompt.Question;
        var expected = "What is your name?";

        // Assert
        Assert.AreEqual(expected, actual);
    }

    #endregion

}
