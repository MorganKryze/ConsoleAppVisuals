/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestText
{
    #region Cleanup
    [TestCleanup]
    public void Cleanup()
    {
        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion

    #region Constructor
    [TestMethod]
    public void Constructor_HappyPath()
    {
        // Arrange
        Text text = new(["Hello, World!"], TextAlignment.Center, Placement.TopCenter);

        // Act
        var actual = text;

        // Assert
        Assert.IsNotNull(actual);
    }

    [TestMethod]
    public void Constructor_NullLines()
    {
        // Arrange
        Text text = new([], TextAlignment.Center, Placement.TopCenter);

        // Act
        var textAfterBuild = text.TextToDisplay;

        // Assert
        Assert.IsNull(textAfterBuild);
    }
    #endregion

    #region Properties
    [TestMethod]
    public void Properties_Height()
    {
        // Arrange
        Text text = new(["Hello, World!"], TextAlignment.Center, Placement.TopCenter);

        // Act
        var actual = text.Height;

        // Assert
        Assert.AreEqual(1, actual);
    }

    [TestMethod]
    public void Properties_Width()
    {
        // Arrange
        string textToDisplay = "Hello, World!";
        Text text = new([textToDisplay], TextAlignment.Center, Placement.TopCenter);

        // Act
        var actual = text.Width;

        // Assert
        Assert.AreEqual(textToDisplay.Length, actual);
    }

    [TestMethod]
    public void Properties_Lines()
    {
        // Arrange
        List<string> lines = new() { "Hello, World!" };
        Text text = new(lines, TextAlignment.Center, Placement.TopCenter);

        // Act
        var actual = text.Lines;

        // Assert
        CollectionAssert.AreEqual(lines, actual);
    }

    [TestMethod]
    public void Properties_Placement()
    {
        // Arrange
        Text text = new(["Hello, World!"], TextAlignment.Center, Placement.TopCenter);

        // Act
        var actual = text.Placement;

        // Assert
        Assert.AreEqual(Placement.TopCenter, actual);
    }

    [TestMethod]
    public void Properties_TextAlignment()
    {
        // Arrange
        Text text = new(["Hello, World!"], TextAlignment.Center, Placement.TopCenter);

        // Act
        var actual = text.TextAlignment;

        // Assert
        Assert.AreEqual(TextAlignment.Center, actual);
    }

    [TestMethod]
    public void Properties_TextToDisplay()
    {
        // Arrange
        List<string> lines = new() { "Hello, World!" };
        Text text = new(lines, TextAlignment.Center, Placement.TopCenter);

        // Act
        var actual = text.TextToDisplay;

        // Assert
        CollectionAssert.AreEqual(lines, actual);
    }
    #endregion

    #region UpdateLines
    [TestMethod]
    public void UpdateLines_HappyPath()
    {
        // Arrange
        Text text = new(["Hello, World!"], TextAlignment.Center, Placement.TopCenter);
        List<string> newLines = new() { "Goodbye, World!" };

        // Act
        text.UpdateLines(newLines);
        var actual = text.TextToDisplay;

        // Assert
        CollectionAssert.AreEqual(newLines, actual);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void UpdateLines_NullLines()
    {
        // Arrange
        Text text = new(["Hello, World!"], TextAlignment.Center, Placement.TopCenter);
        List<string> newLines = new();

        // Act
        text.UpdateLines(newLines);
    }
    #endregion

    #region UpdatePlacement
    [TestMethod]
    public void UpdatePlacement_HappyPath()
    {
        // Arrange
        Text text = new(["Hello, World!"], TextAlignment.Center, Placement.TopCenter);
        Placement newPlacement = Placement.TopLeft;

        // Act
        text.UpdatePlacement(newPlacement);
        var actual = text.Placement;

        // Assert
        Assert.AreEqual(newPlacement, actual);
    }
    #endregion

    #region UpdateTextAlignment
    [TestMethod]
    public void UpdateTextAlignment_HappyPath()
    {
        // Arrange
        Text text = new(["Hello, World!"], TextAlignment.Center, Placement.TopCenter);
        TextAlignment newTextAlignment = TextAlignment.Left;

        // Act
        text.UpdateTextAlignment(newTextAlignment);
        var actual = text.TextAlignment;

        // Assert
        Assert.AreEqual(newTextAlignment, actual);
    }
    #endregion

    #region AddLine
    [TestMethod]
    public void AddLine_HappyPath()
    {
        // Arrange
        Text text = new(["Hello, World!"], TextAlignment.Center, Placement.TopCenter);
        string newLine = "Goodbye, World!";

        // Act
        text.AddLine(newLine);
        var actual = text.TextToDisplay;

        // Assert
        CollectionAssert.Contains(actual, newLine);
    }
    #endregion

    #region InsertLine
    [TestMethod]
    public void InsertLine_HappyPath()
    {
        // Arrange
        Text text = new(["Hello, World!"], TextAlignment.Center, Placement.TopCenter);
        string newLine = "Goodbye, World!";

        // Act
        text.InsertLine(newLine, 0);
        var actual = text.TextToDisplay;

        // Assert
        CollectionAssert.Contains(actual, newLine);
    }
    #endregion

    #region RemoveLine
    [TestMethod]
    public void RemoveLine_HappyPath()
    {
        // Arrange
        Text text = new(["Hello, World!"], TextAlignment.Center, Placement.TopCenter);
        string lineToRemove = "Hello, World!";

        // Act
        text.RemoveLine(lineToRemove);

        // Assert
        Assert.AreEqual(0, text.Lines.Count);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RemoveLine_EmptyText()
    {
        // Arrange
        Text text = new([], TextAlignment.Center, Placement.TopCenter);

        // Act
        text.RemoveLine("Hello, World!");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RemoveLine_LineNotFound()
    {
        // Arrange
        Text text = new(["Hello, World!"], TextAlignment.Center, Placement.TopCenter);

        // Act
        text.RemoveLine("Goodbye, World!");
    }

    [TestMethod]
    public void RemoveLine_Index_HappyPath()
    {
        // Arrange
        Text text = new(["Hello, World!"], TextAlignment.Center, Placement.TopCenter);

        // Act
        text.RemoveLine(0);

        // Assert
        Assert.AreEqual(0, text.Lines.Count);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void RemoveLine_Index_OutOfRange()
    {
        // Arrange
        Text text = new(["Hello, World!"], TextAlignment.Center, Placement.TopCenter);

        // Act
        text.RemoveLine(1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void RemoveLine_Index_Negative()
    {
        // Arrange
        Text text = new(["Hello, World!"], TextAlignment.Center, Placement.TopCenter);

        // Act
        text.RemoveLine(-1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void RemoveLine_Index_EmptyText()
    {
        // Arrange
        Text text = new([], TextAlignment.Center, Placement.TopCenter);

        // Act
        text.RemoveLine(0);
    }
    #endregion
}
