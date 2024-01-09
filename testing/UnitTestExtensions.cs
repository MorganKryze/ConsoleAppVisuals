/*
    MIT License 2023 MorganKryze
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
    public void Test_ResizeString(string value)
    {
        if (value == "Hello")
        {
            Assert.AreEqual("     Hello     ", value.ResizeString(15, TextAlignment.Center, true));
        }
        else if (value == "World")
        {
            Assert.AreEqual("World          ", value.ResizeString(15, TextAlignment.Left, true));
        }
        else if (value == "!")
        {
            Assert.AreEqual("              !", value.ResizeString(15, TextAlignment.Right, true));
        }
    }
    #endregion

    #region InsertString
    [TestMethod]
    [DataRow("Hello World")]
    [DataRow("Bonjour Le Monde")]
    public void Test_InsertStringLeft(string value)
    {
        if (value == "Hello World")
        {
            Assert.AreEqual("testo World", value.InsertString("test", Placement.TopLeft));
        }
        else if (value == "Bonjour Le Monde")
        {
            Assert.AreEqual("testour Le Monde", value.InsertString("test", Placement.TopLeft));
        }
    }

    [TestMethod]
    [DataRow("Hello World")]
    [DataRow("Bonjour Le Monde")]
    public void Test_InsertStringRight(string value)
    {
        if (value == "Hello World")
        {
            Assert.AreEqual("Hello Wtest", value.InsertString("test", Placement.TopRight));
        }
        else if (value == "Bonjour Le Monde")
        {
            Assert.AreEqual("Bonjour Le Mtest", value.InsertString("test", Placement.TopRight));
        }
    }

    [TestMethod]
    [DataRow("Hello World")]
    [DataRow("Bonjour Le Monde")]
    public void Test_InsertStringCenter(string value)
    {
        if (value == "Hello World")
        {
            Assert.AreEqual("Heltestorld", value.InsertString("test", Placement.TopCenter));
        }
        else if (value == "Bonjour Le Monde")
        {
            Assert.AreEqual("Bonjoutest Monde", value.InsertString("test", Placement.TopCenter));
        }
    }
    #endregion

    #region GetRangeAndRemoveNegativeAnchors
    [TestMethod]
    [DataRow("This is a /neg test /neg string")]
    [DataRow("This is another /neg test /neg string but with str/ange anch/ors")]
    public void Test_GetRangeAndRemoveNegativeAnchors(string value)
    {
        if (value == "This is a /neg test /neg string")
        {
            Assert.AreEqual(
                "This is a  test  string",
                value.GetRangeAndRemoveNegativeAnchors().Item1
            );
        }
        else if (value == "This is another /neg test /neg string but with str/ange anch/ors")
        {
            Assert.AreEqual(
                "This is another  test  string but with str/ange anch/ors",
                value.GetRangeAndRemoveNegativeAnchors().Item1
            );
        }
    }
    #endregion

    #region ToTextAlignment
    [TestMethod]
    [DataRow(Placement.TopCenter, TextAlignment.Center)]
    [DataRow(Placement.TopLeft, TextAlignment.Left)]
    [DataRow(Placement.TopRight, TextAlignment.Right)]
    [DataRow(Placement.BottomCenterFullWidth, TextAlignment.Center)]
    [DataRow(Placement.TopCenterFullWidth, TextAlignment.Center)]
    public void Test_ToTextAlignment(Placement placement, TextAlignment expectedAlignment)
    {
        Assert.AreEqual(expectedAlignment, placement.ToTextAlignment());
    }

    [TestMethod]
    [DataRow((Placement)999)] // Invalid Placement
    public void Test_ToTextAlignment_ThrowsException(Placement placement)
    {
        Assert.ThrowsException<ArgumentException>(() => placement.ToTextAlignment());
    }
    #endregion

    #region ToPlacement
    [TestMethod]
    [DataRow(TextAlignment.Center, Placement.TopCenter)]
    [DataRow(TextAlignment.Left, Placement.TopLeft)]
    [DataRow(TextAlignment.Right, Placement.TopRight)]
    public void Test_ToPlacement(TextAlignment alignment, Placement expectedPlacement)
    {
        Assert.AreEqual(expectedPlacement, alignment.ToPlacement());
    }

    [TestMethod]
    [DataRow((TextAlignment)999)] // Invalid TextAlignment
    public void Test_ToPlacement_ThrowsException(TextAlignment alignment)
    {
        Assert.ThrowsException<ArgumentException>(() => alignment.ToPlacement());
    }
    #endregion
}
