/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace tests;

[TestClass]
public class UnitTestASCIIArt
{
    #region Test Setup and Cleanup

    private readonly string _validAsciiArtFilePath = Path.Combine("TestFiles", "ascii_art.txt");
    private readonly string _nonExistentFilePath = "non_existent_file.txt";
    private readonly List<string> _validArtLines = new()
    {
        @"  _____  ",
        @" / ____| ",
        @"| |      ",
        @"| |      ",
        @"| |____  ",
        @" \_____| ",
    };
    private readonly string _validArtString =
        "  _____  \n"
        + " / ____| \n"
        + "| |      \n"
        + "| |      \n"
        + "| |____  \n"
        + " \\_____| ";

    [TestInitialize]
    public void Initialize()
    {
        // Create test directory if it doesn't exist
        Directory.CreateDirectory("TestFiles");

        // Create a test ASCII art file
        File.WriteAllLines(_validAsciiArtFilePath, _validArtLines);
    }

    [TestCleanup]
    public void Cleanup()
    {
        // Remove test files
        if (File.Exists(_validAsciiArtFilePath))
            File.Delete(_validAsciiArtFilePath);

        // Cleanup Window
        Window.RemoveAllElements();
    }
    #endregion

    #region Placement
    [TestMethod]
    [TestCategory("ASCIIArt")]
    [DataRow(Placement.TopCenter)]
    [DataRow(Placement.TopLeft)]
    [DataRow(Placement.TopRight)]
    public void Placement_Getter_ReturnsCorrectPlacement(Placement placement)
    {
        // Arrange
        var asciiArt = new ASCIIArt(_validArtLines, placement);

        // Act
        var result = asciiArt.Placement;

        // Assert
        Assert.AreEqual(placement, result);
    }
    #endregion

    #region TextAlignment
    [TestMethod]
    [TestCategory("ASCIIArt")]
    public void TextAlignment_Getter_AlwaysReturnsLeft()
    {
        // Arrange
        var asciiArt = new ASCIIArt(_validArtLines);

        // Act
        var result = asciiArt.TextAlignment;

        // Assert
        Assert.AreEqual(TextAlignment.Left, result);
    }
    #endregion

    #region Height
    [TestMethod]
    [TestCategory("ASCIIArt")]
    public void Height_Getter_ReturnsLineCount()
    {
        // Arrange
        var asciiArt = new ASCIIArt(_validArtLines);

        // Act
        var result = asciiArt.Height;

        // Assert
        Assert.AreEqual(_validArtLines.Count, result);
    }
    #endregion

    #region Width
    [TestMethod]
    [TestCategory("ASCIIArt")]
    public void Width_Getter_ReturnsMaxLineLength()
    {
        // Arrange
        var asciiArt = new ASCIIArt(_validArtLines);
        int expectedWidth = _validArtLines.Max(s => s.Length);

        // Act
        var result = asciiArt.Width;

        // Assert
        Assert.AreEqual(expectedWidth, result);
    }

    [TestMethod]
    [TestCategory("ASCIIArt")]
    public void Width_EmptyArtLines_ReturnsZero()
    {
        // This test should throw an exception in the constructor
        // because empty art lines are not allowed
        Assert.ThrowsException<ArgumentException>(() => new ASCIIArt(new List<string>()));
    }
    #endregion

    #region ArtLines
    [TestMethod]
    [TestCategory("ASCIIArt")]
    public void ArtLines_Getter_ReturnsCorrectLines()
    {
        // Arrange
        var asciiArt = new ASCIIArt(_validArtLines);

        // Act
        var result = asciiArt.ArtLines;

        // Assert
        CollectionAssert.AreEqual(_validArtLines, result);
    }
    #endregion

    #region Constructors
    [TestMethod]
    [TestCategory("ASCIIArt")]
    public void Constructor_WithValidFilePath_CreatesInstance()
    {
        // Arrange & Act
        var asciiArt = new ASCIIArt(_validAsciiArtFilePath);

        // Assert
        Assert.IsNotNull(asciiArt);
        Assert.AreEqual(_validArtLines.Count, asciiArt.ArtLines.Count);
    }

    [TestMethod]
    [TestCategory("ASCIIArt")]
    public void Constructor_WithInvalidFilePath_ThrowsException()
    {
        // Arrange & Act & Assert
        Assert.ThrowsException<FileNotFoundException>(() => new ASCIIArt(_nonExistentFilePath));
    }

    [TestMethod]
    [TestCategory("ASCIIArt")]
    public void Constructor_WithArtLines_CreatesInstance()
    {
        // Arrange & Act
        var asciiArt = new ASCIIArt(_validArtLines);

        // Assert
        Assert.IsNotNull(asciiArt);
        CollectionAssert.AreEqual(_validArtLines, asciiArt.ArtLines);
    }

    [TestMethod]
    [TestCategory("ASCIIArt")]
    public void Constructor_WithEmptyArtLines_ThrowsException()
    {
        // Arrange & Act & Assert
        Assert.ThrowsException<ArgumentException>(() => new ASCIIArt(new List<string>()));
    }
    #endregion

    #region UpdateFromFile
    [TestMethod]
    [TestCategory("ASCIIArt")]
    public void UpdateFromFile_WithValidFilePath_UpdatesArtLines()
    {
        // Arrange
        var initialLines = new List<string> { "Initial ASCII Art" };
        var asciiArt = new ASCIIArt(initialLines);

        // Act
        asciiArt.UpdateFromFile(_validAsciiArtFilePath);

        // Assert
        CollectionAssert.AreEqual(_validArtLines, asciiArt.ArtLines);
    }

    [TestMethod]
    [TestCategory("ASCIIArt")]
    public void UpdateFromFile_WithInvalidFilePath_ThrowsException()
    {
        // Arrange
        var asciiArt = new ASCIIArt(_validArtLines);

        // Act & Assert
        Assert.ThrowsException<FileNotFoundException>(
            () => asciiArt.UpdateFromFile(_nonExistentFilePath)
        );
    }
    #endregion

    #region UpdateArtLines
    [TestMethod]
    [TestCategory("ASCIIArt")]
    public void UpdateArtLines_WithValidArtLines_UpdatesArtLines()
    {
        // Arrange
        var initialLines = new List<string> { "Initial ASCII Art" };
        var asciiArt = new ASCIIArt(initialLines);
        var newArtLines = new List<string> { "New", "ASCII", "Art" };

        // Act
        asciiArt.UpdateArtLines(newArtLines);

        // Assert
        CollectionAssert.AreEqual(newArtLines, asciiArt.ArtLines);
    }

    [TestMethod]
    [TestCategory("ASCIIArt")]
    public void UpdateArtLines_WithEmptyArtLines_ThrowsException()
    {
        // Arrange
        var asciiArt = new ASCIIArt(_validArtLines);

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(
            () => asciiArt.UpdateArtLines(new List<string>())
        );
    }
    #endregion

    #region UpdateArt
    [TestMethod]
    [TestCategory("ASCIIArt")]
    public void UpdateArt_WithValidArtString_UpdatesArtLines()
    {
        // Arrange
        var asciiArt = new ASCIIArt(new List<string> { "Initial ASCII Art" });
        var newArtString = "Line 1\nLine 2\nLine 3";
        var expectedLines = new List<string> { "Line 1", "Line 2", "Line 3" };

        // Act
        asciiArt.UpdateArt(newArtString);

        // Assert
        CollectionAssert.AreEqual(expectedLines, asciiArt.ArtLines);
    }

    [TestMethod]
    [TestCategory("ASCIIArt")]
    public void UpdateArt_WithEmptyArtString_ThrowsException()
    {
        // Arrange
        var asciiArt = new ASCIIArt(_validArtLines);

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => asciiArt.UpdateArt(""));
    }

    [TestMethod]
    [TestCategory("ASCIIArt")]
    public void UpdateArt_HandlesWindowsLineEndings()
    {
        // Arrange
        var asciiArt = new ASCIIArt(_validArtLines);
        var winNewlines = "Line 1\r\nLine 2\r\nLine 3";
        var expectedLines = new List<string> { "Line 1", "Line 2", "Line 3" };

        // Act
        asciiArt.UpdateArt(winNewlines);

        // Assert
        CollectionAssert.AreEqual(expectedLines, asciiArt.ArtLines);
    }
    #endregion

    #region UpdatePlacement
    [TestMethod]
    [TestCategory("ASCIIArt")]
    [DataRow(Placement.TopLeft)]
    [DataRow(Placement.TopCenter)]
    [DataRow(Placement.TopRight)]
    public void UpdatePlacement_WithValidPlacement_UpdatesPlacement(Placement newPlacement)
    {
        // Arrange
        var asciiArt = new ASCIIArt(_validArtLines, Placement.TopCenter);

        // Act
        asciiArt.UpdatePlacement(newPlacement);

        // Assert
        Assert.AreEqual(newPlacement, asciiArt.Placement);
    }
    #endregion

    #region Rendering
    [TestMethod]
    [TestCategory("ASCIIArt")]
    public void RenderElementActions_DoesNotThrowException()
    {
        // Arrange
        var asciiArt = new ASCIIArt(_validArtLines);
        Window.AddElement(asciiArt);

        // Act & Assert
        try
        {
            Window.Render();
            // If we reach this point, no exception was thrown
            Assert.IsTrue(true);
        }
        catch
        {
            Assert.Fail("RenderElementActions threw an exception");
        }
    }
    #endregion
}
