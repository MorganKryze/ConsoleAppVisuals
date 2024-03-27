/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace tests;

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
            TextAlignment.Left,
            placement
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
            TextAlignment.Left,
            Placement.TopCenter
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
        var EmbedText = new EmbedText(textToDisplay, TextAlignment.Left, Placement.TopCenter);

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
        var EmbedText = new EmbedText(textToDisplay, TextAlignment.Left, Placement.TopCenter);

        // Act
        var actual = EmbedText.Width;
        var finalTextToDisplay = EmbedText.TextToDisplay;

        // Assert
        Assert.AreEqual(finalTextToDisplay!.Max((string s) => s.Length), actual);
    }
    #endregion

    #region Text
    [TestMethod]
    [TestCategory("EmbedText")]
    public void Text_Getter()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var EmbedText = new EmbedText(textToDisplay, TextAlignment.Left, Placement.TopCenter);

        // Act
        var actual = EmbedText.Lines;

        // Assert
        Assert.AreEqual(textToDisplay, actual);
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
        var EmbedText = new EmbedText(textToDisplay, align, Placement.TopCenter);

        // Assert
        Assert.IsNotNull(EmbedText.TextToDisplay);
    }
    #endregion

    #region Constructor
    [TestMethod]
    [TestCategory("EmbedText")]
    public void Constructor_NoLineInputBuilds()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };

        // Act
        var EmbedText = new EmbedText(textToDisplay, TextAlignment.Left, Placement.TopCenter);

        // Assert
        Assert.IsNotNull(EmbedText);
    }

    [TestMethod]
    [TestCategory("EmbedText")]
    public void Constructor_LineInputBuilds()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };

        // Act
        var EmbedText = new EmbedText(textToDisplay, TextAlignment.Left, Placement.TopCenter);

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
        var EmbedText = new EmbedText(textToDisplay, TextAlignment.Left, Placement.TopCenter);

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
        var EmbedText = new EmbedText(textToDisplay, TextAlignment.Left, Placement.TopCenter);
        var marginValue = 2;

        // Act
        EmbedText.AddLine("New line");

        // Assert
        Assert.AreEqual(textToDisplay.Count + marginValue, EmbedText.TextToDisplay!.Count + 1);
    }
    #endregion

    #region InsertLine
    [TestMethod]
    [TestCategory("EmbedText")]
    public void InsertLine_InsertsLine()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var EmbedText = new EmbedText(textToDisplay, TextAlignment.Left, Placement.TopCenter);
        var marginValue = 2;

        // Act
        EmbedText.InsertLine(1, "New line");

        // Assert
        Assert.AreEqual(textToDisplay.Count + marginValue, EmbedText.TextToDisplay!.Count + 1);
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

        var EmbedText = new EmbedText(textToDisplay, TextAlignment.Left, Placement.TopCenter);

        // Act
        EmbedText.RemoveLine(0);

        // Assert
        Assert.AreEqual(textToDisplayUnchanged.Count - 1, EmbedText.Lines!.Count);
    }

    [TestMethod]
    [TestCategory("EmbedText")]
    public void RemoveLine_RemovesLineWithNegativeIndex()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var EmbedText = new EmbedText(textToDisplay, TextAlignment.Left, Placement.TopCenter);

        // Act
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => EmbedText.RemoveLine(-1));
    }

    [TestMethod]
    [TestCategory("EmbedText")]
    public void RemoveLine_RemovesLineWithIndexGreaterThanCount()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var EmbedText = new EmbedText(textToDisplay, TextAlignment.Left, Placement.TopCenter);

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
        var EmbedText = new EmbedText(textToDisplay, TextAlignment.Left, Placement.TopCenter);

        // Act
        EmbedText.RemoveLine("Test for the placement");

        // Assert
        Assert.AreEqual(textToDisplayUnchanged.Count - 1, EmbedText.Lines!.Count);
    }

    [TestMethod]
    [TestCategory("EmbedText")]
    public void RemoveLine_RemovesLineWithStringNotFound()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var EmbedText = new EmbedText(textToDisplay, TextAlignment.Left, Placement.TopCenter);

        // Act
        Assert.ThrowsException<ArgumentException>(
            () => EmbedText.RemoveLine("Test for the placement2")
        );
    }
    #endregion

    #region UpdateText
    [TestMethod]
    [TestCategory("EmbedText")]
    public void UpdateText_UpdatesTextCorrectly()
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var newTextToDisplay = new List<string>()
        {
            "Test for the placement",
            "123was tested",
            "New line"
        };
        var EmbedText = new EmbedText(textToDisplay, TextAlignment.Left, Placement.TopCenter);

        // Act
        EmbedText.UpdateLines(newTextToDisplay);

        // Assert
        Assert.AreEqual(newTextToDisplay, EmbedText.Lines);
    }
    #endregion

    #region UpdatePlacement
    [TestMethod]
    [TestCategory("EmbedText")]
    [DataRow(Placement.TopCenter)]
    [DataRow(Placement.TopLeft)]
    public void UpdatePlacement_UpdatesPlacementCorrectly(Placement newPlacement)
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var EmbedText = new EmbedText(textToDisplay, TextAlignment.Left, Placement.TopCenter);

        // Act
        EmbedText.UpdatePlacement(newPlacement);

        // Assert
        Assert.AreEqual(newPlacement, EmbedText.Placement);
    }
    #endregion

    #region UpdateTextAlignment
    [TestMethod]
    [TestCategory("EmbedText")]
    [DataRow(TextAlignment.Left)]
    [DataRow(TextAlignment.Center)]
    public void UpdateTextAlignment_UpdatesTextAlignmentCorrectly(TextAlignment newTextAlignment)
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var EmbedText = new EmbedText(textToDisplay, TextAlignment.Left, Placement.TopCenter);

        // Act
        EmbedText.UpdateTextAlignment(newTextAlignment);

        // Assert
        Assert.AreEqual(newTextAlignment, EmbedText.TextAlignment);
    }

    #endregion

    #region UpdateBorderType
    [TestMethod]
    [TestCategory("EmbedText")]
    [DataRow(BordersType.SingleBold)]
    [DataRow(BordersType.DoubleStraight)]
    public void UpdateBorderType_UpdatesBorderTypeCorrectly(BordersType newBorderType)
    {
        // Arrange
        var textToDisplay = new List<string>() { "Test for the placement", "123was tested" };
        var EmbedText = new EmbedText(textToDisplay, TextAlignment.Left, Placement.TopCenter);

        // Act
        EmbedText.UpdateBordersType(newBorderType);

        // Assert
        Assert.AreEqual(newBorderType, EmbedText.BordersType);
    }
    #endregion
}
