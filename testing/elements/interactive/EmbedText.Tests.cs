/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

[TestClass]
public class UnitTestEmbedText
{
    #region Cleanup
    [TestCleanup]
    public void Cleanup()
    {
        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion

    #region Placement
    [TestMethod]
    [TestCategory("EmbedText")]
    [DataRow(Placement.TopCenter)]
    [DataRow(Placement.TopLeft)]
    [DataRow(Placement.TopRight)]
    public void Placement_Getter(Placement placement)
    {
        // Arrange
        var EmbedText = new EmbedText(
            new List<string>() { "Test for the placement", "123was tested" },
            "Button",
            TextAlignment.Left,
            placement,
            0
        );

        // Act
        var actual = EmbedText.Placement;

        // Assert
        Assert.AreEqual(placement, actual);
    }
    #endregion

    #region Line
    [TestMethod]
    [TestCategory("EmbedText")]
    public void Line_Getter()
    {
        // Arrange
        var EmbedText = new EmbedText(
            new List<string>() { "Test for the placement", "123was tested" },
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Act
        var actual = EmbedText.Line;

        // Assert
        Assert.AreEqual(0, actual);
    }
    #endregion

    #region Height
    [TestMethod]
    [TestCategory("EmbedText")]
    public void Height_Getter()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var EmbedText = new EmbedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Act
        var actual = EmbedText.Height;
        var finalTextToDisplay = EmbedText.TextToDisplay;

        // Assert
        Assert.AreEqual(finalTextToDisplay!.Count, actual);
    }
    #endregion

    #region Width
    [TestMethod]
    [TestCategory("EmbedText")]
    public void Width_Getter()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var EmbedText = new EmbedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Act
        var actual = EmbedText.Width;
        var finalTextToDisplay = EmbedText.TextToDisplay;

        // Assert
        Assert.AreEqual(finalTextToDisplay!.Max((string s) => s.Length) - 8, actual);
    }
    #endregion

    #region Text
    [TestMethod]
    [TestCategory("EmbedText")]
    public void Text_Getter()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var EmbedText = new EmbedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Act
        var actual = EmbedText.Text;

        // Assert
        Assert.AreEqual(textToDisplay, actual);
    }
    #endregion

    #region ButtonText
    [TestMethod]
    [TestCategory("EmbedText")]
    [DataRow("Button")]
    [DataRow("Button2")]
    public void ButtonText_Getter(string buttonText)
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var EmbedText = new EmbedText(
            textToDisplay,
            buttonText,
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Act
        var actual = EmbedText.ButtonText;

        // Assert
        Assert.AreEqual(buttonText, actual);
    }
    #endregion

    #region TextToDisplay
    [TestMethod]
    [TestCategory("EmbedText")]
    [DataRow(TextAlignment.Left)]
    [DataRow(TextAlignment.Center)]
    [DataRow(TextAlignment.Right)]
    public void TextToDisplay_WellCreatedWithDifferentAlignment(TextAlignment align)
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };

        // Act
        var EmbedText = new EmbedText(textToDisplay, "Button", align, Placement.TopCenter, 0);

        // Assert
        Assert.IsNotNull(EmbedText.TextToDisplay);
    }
    #endregion

    #region Constructor
    [TestMethod]
    [TestCategory("EmbedText")]
    public void Constructor_NoLineinputBuilds()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };

        // Act
        var EmbedText = new EmbedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter
        );

        // Assert
        Assert.IsNotNull(EmbedText);
    }

    [TestMethod]
    [TestCategory("EmbedText")]
    public void Constructor_LineinputBuilds()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };

        // Act
        var EmbedText = new EmbedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Assert
        Assert.IsNotNull(EmbedText);
    }

    [TestMethod]
    [TestCategory("EmbedText")]
    public void Constructor_EmptyTextToDisplayBuilds()
    {
        // Arrange
        var textToDisplay = new List<string>();

        // Act
        var EmbedText = new EmbedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Assert
        Assert.IsNotNull(EmbedText);
    }

    [TestMethod]
    [TestCategory("EmbedText")]
    public void Constructor_EmptyButtonTextBuilds()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };

        // Act
        var EmbedText = new EmbedText(
            textToDisplay,
            default,
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Assert
        Assert.IsNotNull(EmbedText);
    }
    #endregion

    #region AddLine
    [TestMethod]
    [TestCategory("EmbedText")]
    public void AddLine_AddsLine()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var EmbedText = new EmbedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );
        var marginValue = 2;

        // Act
        EmbedText.AddLine("New line");

        // Assert
        Assert.AreEqual(textToDisplay.Count + marginValue + 1, EmbedText.TextToDisplay!.Count);
    }
    #endregion

    #region InsertLine
    [TestMethod]
    [TestCategory("EmbedText")]
    public void InsertLine_InsertsLine()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var EmbedText = new EmbedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );
        var marginValue = 2;

        // Act
        EmbedText.InsertLine("New line", 1);

        // Assert
        Assert.AreEqual(textToDisplay.Count + marginValue + 1, EmbedText.TextToDisplay!.Count);
    }
    #endregion

    #region RemoveLine
    [TestMethod]
    [TestCategory("EmbedText")]
    public void RemoveLine_RemovesLine()
    {
        // Arrange
        var textToDisplay = new List<string>()
        {
            "Test for the placement",
            "123was tested",
            "3456 TEst"
        };
        var textToDisplayUnchanged = new List<string>()
        {
            "Test for the placement",
            "123was tested",
            "3456 TEst"
        };

        var EmbedText = new EmbedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Act
        EmbedText.RemoveLine(0);

        // Assert
        Assert.AreEqual(textToDisplayUnchanged.Count - 1, EmbedText.Text!.Count);
    }

    [TestMethod]
    [TestCategory("EmbedText")]
    public void RemoveLine_RemovesLineWithNegativeIndex()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var EmbedText = new EmbedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Act
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => EmbedText.RemoveLine(-1));
    }

    [TestMethod]
    [TestCategory("EmbedText")]
    public void RemoveLine_RemovesLineWithIndexGreaterThanCount()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var EmbedText = new EmbedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Act
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => EmbedText.RemoveLine(3));
    }

    [TestMethod]
    [TestCategory("EmbedText")]
    public void RemoveLine_RemovesLineWithString()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var textToDisplayUnchanged = new List<string>()
        {
            "Test for the placement",
            "123was tested"
        };
        var EmbedText = new EmbedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Act
        EmbedText.RemoveLine("Test for the placement");

        // Assert
        Assert.AreEqual(textToDisplayUnchanged.Count - 1, EmbedText.Text!.Count);
    }

    [TestMethod]
    [TestCategory("EmbedText")]
    public void RemoveLine_RemovesLineWithStringNotFound()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var EmbedText = new EmbedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Act
        Assert.ThrowsException<ArgumentException>(
            () => EmbedText.RemoveLine("Test for the placement2")
        );
    }
    #endregion
}
