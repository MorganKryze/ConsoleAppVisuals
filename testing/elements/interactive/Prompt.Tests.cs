/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

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
        var prompt = new Prompt("What is your name?", "John Doe", Placement.TopCenter, 10);

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
        var expected = 5;

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
        var expected = 22;

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
        var prompt = new Prompt("What is your name?", "John Doe", Placement.TopCenter, 10);

        // Act
        var actual = prompt.MaxInputLength;
        var expected = 10;

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
        var actual = prompt.MaxInputLength;
        var expected = 12;

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

    [TestMethod]
    [TestCategory("Prompt")]
    public void UpdateDefaultValue_Empty()
    {
        // Arrange
        var prompt = new Prompt("What is your name?", "John Doe");

        // Act
        prompt.UpdateDefaultValue(null);
        var actual = prompt.DefaultValue;
        var expected = "";

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("Prompt")]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void UpdateDefaultValue_OutOfRange()
    {
        // Arrange
        var prompt = new Prompt("What is your name?", "John Doe");

        // Act
        prompt.UpdateDefaultValue("John Doe, John Doe");
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
        prompt.UpdateMaxLength(10);
        var actual = prompt.MaxInputLength;
        var expected = 10;

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


    #region UpdateSelector
    [TestMethod]
    [TestCategory("Prompt")]
    public void UpdateSelector()
    {
        // Arrange
        var prompt = new Prompt("What is your name?", "John Doe");

        // Act
        prompt.UpdateSelector('>');
        char actual = prompt.Selector;
        char expected = '>';

        // Assert
        Assert.AreEqual(expected, actual);
    }
    #endregion

    #region MaxLengthOutOfRange
    [TestMethod]
    [TestCategory("Prompt")]
    [DataRow(-1)]
    [DataRow(0)]
    [DataRow(int.MaxValue)]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void MaxLengthOutOfRange(int max)
    {
        // Act
        new Prompt("What is your name?", "John Doe", Placement.TopCenter, max);
    }
    #endregion

    #region PromptInputStyle
    [TestMethod]
    [TestCategory("Prompt")]
    public void PromptInputStyle()
    {
        // Arrange
        var prompt = new Prompt(
            "What is your name?",
            "John Doe",
            Placement.TopCenter,
            10,
            ConsoleAppVisuals.Enums.PromptInputStyle.Fill
        );

        // Act
        prompt.UpdateStyle(ConsoleAppVisuals.Enums.PromptInputStyle.Secret);
        var actual = prompt.Style;
        var expected = ConsoleAppVisuals.Enums.PromptInputStyle.Secret;

        // Assert
        Assert.AreEqual(expected, actual);
    }
    #endregion

    #region UpdateBorderType

    [TestMethod]
    [TestCategory("Prompt")]
    public void UpdateBorderType()
    {
        // Arrange
        var prompt = new Prompt("What is your name?", "John Doe");

        // Act
        prompt.UpdateBordersType(BordersType.SingleRounded);
        var actual = prompt.BordersType;
        var expected = BordersType.SingleRounded;

        // Assert
        Assert.AreEqual(expected, actual);
        Assert.AreEqual(expected, prompt.Borders.Type);
    }
    #endregion
}
