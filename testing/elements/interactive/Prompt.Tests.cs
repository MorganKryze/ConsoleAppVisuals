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

    [TestMethod]
    [TestCategory("Prompt")]
    public void Placement_Getter()
    {
        // Arrange
        var prompt = new Prompt("What is your name?", "John Doe", Placement.TopCenter, 20);

        // Act
        var actual = prompt.Placement;
        var expected = Placement.TopCenter;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("Prompt")]
    public void Height_Getter()
    {
        // Arrange
        var prompt = new Prompt("What is your name?", "John Doe");

        // Act
        var actual = prompt.Height;
        var expected = 3;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("Prompt")]
    public void Width_Getter()
    {
        // Arrange
        var prompt = new Prompt("What is your name?", "John Doe");

        // Act
        var actual = prompt.Width;
        var expected = 19;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("Prompt")]
    public void DefaultValue_Getter()
    {
        // Arrange
        var prompt = new Prompt("What is your name?", "John Doe");

        // Act
        var actual = prompt.DefaultValue;
        var expected = "John Doe";

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("Prompt")]
    public void MaxLength_Getter()
    {
        // Arrange
        var prompt = new Prompt("What is your name?", "John Doe", Placement.TopCenter, 20);
 
        // Act
        var actual = prompt.MaxLength;
        var expected = 20;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("Prompt")]
    public void MaxLength_Getter_DefaultValue()
    {
        // Arrange
        var prompt = new Prompt("What is your name?", "John Doe");

        // Act
        var actual = prompt.MaxLength;
        var expected = 10;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region UpdateQuestion

    [TestMethod]
    [TestCategory("Prompt")]
    public void UpdateQuestion()
    {
        // Arrange
        var prompt = new Prompt("What is your name?", "John Doe");

        // Act
        prompt.UpdateQuestion("What is your age?");
        var actual = prompt.Question;
        var expected = "What is your age?";

        // Assert
        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region UpdateDefaultValue

    [TestMethod]
    [TestCategory("Prompt")]
    public void UpdateDefaultValue()
    {
        // Arrange
        var prompt = new Prompt("What is your name?", "John Doe");

        // Act
        prompt.UpdateDefaultValue("Jane Doe");
        var actual = prompt.DefaultValue;
        var expected = "Jane Doe";

        // Assert
        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region UpdateMaxLength

    [TestMethod]
    [TestCategory("Prompt")]
    public void UpdateMaxLength()
    {
        // Arrange
        var prompt = new Prompt("What is your name?", "John Doe");

        // Act
        prompt.UpdateMaxLength(20);
        var actual = prompt.MaxLength;
        var expected = 20;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("Prompt")]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    [DataRow(-1)]
    public void UpdateMaxLength_OutsideRange(int maxLength)
    {
        // Arrange
        var prompt = new Prompt("What is your name?", "John Doe");

        // Act
        prompt.UpdateMaxLength(maxLength);
        
    }

    #endregion

    #region UpdatePlacement

    [TestMethod]
    [TestCategory("Prompt")]
    public void UpdatePlacement()
    {
        // Arrange
        var prompt = new Prompt("What is your name?", "John Doe");

        // Act
        prompt.UpdatePlacement(Placement.TopRight);
        var actual = prompt.Placement;
        var expected = Placement.TopRight;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    #endregion

}
