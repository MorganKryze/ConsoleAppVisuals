/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
using Microsoft.VisualBasic;

namespace ConsoleAppVisuals;

[TestClass]
public class UnitTestEmbeddedText
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
    [TestCategory("EmbeddedText")]
    [DataRow(Placement.TopCenter)]
    [DataRow(Placement.TopLeft)]
    [DataRow(Placement.TopRight)]
    public void Placement_Getter(Placement placement)
    {
        // Arrange
        var embeddedText = new EmbeddedText(
            new List<string>() { "Test for the placement", "123was tested" },
            "Button",
            TextAlignment.Left,
            placement,
            1
        );

        // Act
        var actual = embeddedText.Placement;

        // Assert
        Assert.AreEqual(placement, actual);
    }
    #endregion

    #region Line
    [TestMethod]
    [TestCategory("EmbeddedText")]
    public void Line_Getter()
    {
        // Arrange
        var embeddedText = new EmbeddedText(
            new List<string>() { "Test for the placement", "123was tested" },
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Act
        var actual = embeddedText.Line;

        // Assert
        Assert.AreEqual(0, actual);
    }
    #endregion

    #region Height
    [TestMethod]
    [TestCategory("EmbeddedText")]
    public void Height_Getter()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var embeddedText = new EmbeddedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Act
        var actual = embeddedText.Height;
        var finalTextToDisplay = embeddedText.TextToDisplay;

        // Assert
        Assert.AreEqual(finalTextToDisplay!.Count, actual);
    }
    #endregion

    #region Width
    [TestMethod]
    [TestCategory("EmbeddedText")]
    public void Width_Getter()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var embeddedText = new EmbeddedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Act
        var actual = embeddedText.Width;
        var finalTextToDisplay = embeddedText.TextToDisplay;

        // Assert
        Assert.AreEqual(finalTextToDisplay!.Max((string s) => s.Length) - 8, actual);
    }
    #endregion

    #region Text
    [TestMethod]
    [TestCategory("EmbeddedText")]
    public void Text_Getter()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var embeddedText = new EmbeddedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Act
        var actual = embeddedText.Text;

        // Assert
        Assert.AreEqual(textToDisplay, actual);
    }
    #endregion

    #region ButtonText
    [TestMethod]
    [TestCategory("EmbeddedText")]
    [DataRow("Button")]
    [DataRow("Button2")]
    public void ButtonText_Getter(string buttonText)
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var embeddedText = new EmbeddedText(
            textToDisplay,
            buttonText,
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Act
        var actual = embeddedText.ButtonText;

        // Assert
        Assert.AreEqual(buttonText, actual);
    }
    #endregion

    #region TextToDisplay
    [TestMethod]
    [TestCategory("EmbeddedText")]
    [DataRow(TextAlignment.Left)]
    [DataRow(TextAlignment.Center)]
    [DataRow(TextAlignment.Right)]
    public void TextToDisplay_WellCreatedWithDifferentAlignment(TextAlignment align)
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };

        // Act
        var embeddedText = new EmbeddedText(textToDisplay, "Button", align, Placement.TopCenter, 1);

        // Assert
        Assert.IsNotNull(embeddedText.TextToDisplay);
    }
    #endregion

    #region Constructor
    [TestMethod]
    [TestCategory("EmbeddedText")]
    public void Constructor_NoLineinputBuilds()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };

        // Act
        var embeddedText = new EmbeddedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter
        );

        // Assert
        Assert.IsNotNull(embeddedText);
    }

    [TestMethod]
    [TestCategory("EmbeddedText")]
    public void Constructor_LineinputBuilds()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };

        // Act
        var embeddedText = new EmbeddedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Assert
        Assert.IsNotNull(embeddedText);
    }

    [TestMethod]
    [TestCategory("EmbeddedText")]
    public void Constructor_EmptyTextToDisplayBuilds()
    {
        // Arrange
        var textToDisplay = new List<string>();

        // Act
        var embeddedText = new EmbeddedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Assert
        Assert.IsNotNull(embeddedText);
    }

    [TestMethod]
    [TestCategory("EmbeddedText")]
    public void Constructor_EmptyButtonTextBuilds()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };

        // Act
        var embeddedText = new EmbeddedText(
            textToDisplay,
            default,
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Assert
        Assert.IsNotNull(embeddedText);
    }
    #endregion

    #region AddLine
    [TestMethod]
    [TestCategory("EmbeddedText")]
    public void AddLine_AddsLine()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var embeddedText = new EmbeddedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );
        var marginValue = 2;

        // Act
        embeddedText.AddLine("New line");

        // Assert
        Assert.AreEqual(textToDisplay.Count + marginValue + 1, embeddedText.TextToDisplay!.Count);
    }
    #endregion

    #region InsertLine
    [TestMethod]
    [TestCategory("EmbeddedText")]
    public void InsertLine_InsertsLine()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var embeddedText = new EmbeddedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );
        var marginValue = 2;

        // Act
        embeddedText.InsertLine("New line", 1);

        // Assert
        Assert.AreEqual(textToDisplay.Count + marginValue + 1, embeddedText.TextToDisplay!.Count);
    }
    #endregion

    #region RemoveLine
    [TestMethod]
    [TestCategory("EmbeddedText")]
    public void RemoveLine_RemovesLine()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested", "3456 TEst" };
        var textToDisplayUnchanged = new List<string>() { "Test for the placement", "123was tested", "3456 TEst" };

        var embeddedText = new EmbeddedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Act
        embeddedText.RemoveLine(0);


        // Assert
        Assert.AreEqual(textToDisplayUnchanged.Count - 1, embeddedText.Text!.Count);
    }

    [TestMethod]
    [TestCategory("EmbeddedText")]
    public void RemoveLine_RemovesLineWithNegativeIndex()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var embeddedText = new EmbeddedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Act
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => embeddedText.RemoveLine(-1));
    }

    [TestMethod]
    [TestCategory("EmbeddedText")]
    public void RemoveLine_RemovesLineWithIndexGreaterThanCount()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var embeddedText = new EmbeddedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Act
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => embeddedText.RemoveLine(3));
       
    }

    [TestMethod]
    [TestCategory("EmbeddedText")]
    public void RemoveLine_RemovesLineWithString()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var textToDisplayUnchanged = new List<string>() { "Test for the placement", "123was tested" };
        var embeddedText = new EmbeddedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Act
        embeddedText.RemoveLine("Test for the placement");

        // Assert
        Assert.AreEqual(textToDisplayUnchanged.Count - 1, embeddedText.Text!.Count);
    }

    [TestMethod]
    [TestCategory("EmbeddedText")]
    public void RemoveLine_RemovesLineWithStringNotFound()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var embeddedText = new EmbeddedText(
            textToDisplay,
            "Button",
            TextAlignment.Left,
            Placement.TopCenter,
            0
        );

        // Act
        Assert.ThrowsException<ArgumentException>(() => embeddedText.RemoveLine("Test for the placement2"));
    }
    #endregion
}
