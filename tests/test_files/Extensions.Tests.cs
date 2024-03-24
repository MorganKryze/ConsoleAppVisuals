/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestExtensions
{
    #region ResizeString
    [TestMethod]
    [DataRow("Hello")]
    [DataRow("World")]
    [DataRow("!")]
    public void ResizeString_CenterAlignment_TrueTruncate(string value)
    {
        // Arrange, Act & Assert
        if (value == "Hello")
            Assert.AreEqual("     Hello     ", value.ResizeString(15, TextAlignment.Center, true));
        else if (value == "World")
            Assert.AreEqual("World          ", value.ResizeString(15, TextAlignment.Left, true));
        else if (value == "!")
            Assert.AreEqual("              !", value.ResizeString(15, TextAlignment.Right, true));
    }

    [TestMethod]
    public void ResizeString_Truncate_LeftAlignment()
    {
        // Arrange
        string str = "Hello, world!";

        // Act
        string result = str.ResizeString(5, TextAlignment.Left, true);

        // Assert
        Assert.AreEqual("Hello", result);
    }

    [TestMethod]
    public void ResizeString_Truncate_CenterAlignment()
    {
        // Arrange
        string str = "Hello, world!";

        // Act
        string result = str.ResizeString(5, TextAlignment.Center, true);

        // Assert
        Assert.AreEqual("o, wo", result);
    }

    [TestMethod]
    public void ResizeString_Truncate_RightAlignment()
    {
        // Arrange
        string str = "Hello, world!";

        // Act
        string result = str.ResizeString(5, TextAlignment.Right, true);

        // Assert
        Assert.AreEqual("orld!", result);
    }

    [TestMethod]
    public void ResizeString_NoTruncate()
    {
        // Arrange
        string str = "Hello, world!";

        // Act
        string result = str.ResizeString(13, TextAlignment.Left, false);

        // Assert
        Assert.AreEqual(str, result);
    }
    #endregion

    #region InsertString
    [TestMethod]
    [DataRow("Hello World")]
    [DataRow("Bonjour Le Monde")]
    public void InsertString_LeftPlacement(string value)
    {
        // Arrange, Act & Assert
        if (value == "Hello World")
            Assert.AreEqual("testo World", value.InsertString("test", TextAlignment.Left));
        else if (value == "Bonjour Le Monde")
            Assert.AreEqual("testour Le Monde", value.InsertString("test", TextAlignment.Left));
    }

    [TestMethod]
    [DataRow("Hello World")]
    [DataRow("Bonjour Le Monde")]
    public void InsertString_RightPlacement(string value)
    {
        // Arrange, Act & Assert
        if (value == "Hello World")
            Assert.AreEqual("Hello Wtest", value.InsertString("test", TextAlignment.Right));
        else if (value == "Bonjour Le Monde")
            Assert.AreEqual("Bonjour Le Mtest", value.InsertString("test", TextAlignment.Right));
    }

    [TestMethod]
    [DataRow("Hello World")]
    [DataRow("Bonjour Le Monde")]
    public void InsertString_CenterPlacement(string value)
    {
        // Arrange, Act & Assert
        if (value == "Hello World")
            Assert.AreEqual("Heltestorld", value.InsertString("test", TextAlignment.Center));
        else if (value == "Bonjour Le Monde")
            Assert.AreEqual("Bonjoutest Monde", value.InsertString("test", TextAlignment.Center));
    }

    [TestMethod]
    [DataRow((TextAlignment)999)]
    [ExpectedException(typeof(ArgumentException))]
    public void InsertString_InvalidPlacement(TextAlignment value)
    {
        // Act & Assert
        "Hello World".InsertString("test", value);
    }

    [TestMethod]
    [DataRow("Hello")]
    [DataRow("World")]
    [ExpectedException(typeof(ArgumentException))]
    public void InsertString_ThrowsException(string value)
    {
        // Act & Assert
        value.InsertString("teststring");
    }
    #endregion

    #region GetRangeAndRemoveNegativeAnchors
    [TestMethod]
    [DataRow("This is a /neg test /neg string")]
    [DataRow("This is another /neg test /neg string but with str/ange anch/ors")]
    [DataRow("This is another test string but with no anchors")]
    public void GetRangeAndRemoveNegativeAnchors_ValidAnchors(string value)
    {
        // Arrange, Act & Assert
        if (value == "This is a /neg test /neg string")
            Assert.AreEqual(
                "This is a  test  string",
                value.GetRangeAndRemoveNegativeAnchors().Item1
            );
        else if (value == "This is another /neg test /neg string but with str/ange anch/ors")
            Assert.AreEqual(
                "This is another  test  string but with str/ange anch/ors",
                value.GetRangeAndRemoveNegativeAnchors().Item1
            );
        else if (value == "This is another test string but with no anchors")
            Assert.AreEqual(
                "This is another test string but with no anchors",
                value.GetRangeAndRemoveNegativeAnchors().Item1
            );
    }
    #endregion

    #region ToTextAlignment
    [TestMethod]
    [DataRow(Placement.TopCenter, TextAlignment.Center)]
    [DataRow(Placement.TopLeft, TextAlignment.Left)]
    [DataRow(Placement.TopRight, TextAlignment.Right)]
    [DataRow(Placement.BottomCenterFullWidth, TextAlignment.Center)]
    [DataRow(Placement.TopCenterFullWidth, TextAlignment.Center)]
    public void ToTextAlignment_ValidPlacements_ReturnsExpectedAlignment(
        Placement placement,
        TextAlignment expectedAlignment
    )
    {
        // Act & Assert
        Assert.AreEqual(expectedAlignment, placement.ToTextAlignment());
    }

    [TestMethod]
    [DataRow((Placement)999)] // Invalid Placement
    public void ToTextAlignment_InvalidPlacement_ThrowsException(Placement placement)
    {
        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => placement.ToTextAlignment());
    }
    #endregion

    #region ToPlacement
    [TestMethod]
    [DataRow(TextAlignment.Center, Placement.TopCenter)]
    [DataRow(TextAlignment.Left, Placement.TopLeft)]
    [DataRow(TextAlignment.Right, Placement.TopRight)]
    public void ToPlacement_ValidAlignments_ReturnsExpectedPlacement(
        TextAlignment alignment,
        Placement expectedPlacement
    )
    {
        // Act & Assert
        Assert.AreEqual(expectedPlacement, alignment.ToPlacement());
    }

    [TestMethod]
    [DataRow((TextAlignment)999)] // Invalid TextAlignment
    public void ToPlacement_InvalidAlignment_ThrowsException(TextAlignment alignment)
    {
        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => alignment.ToPlacement());
    }
    #endregion
}
