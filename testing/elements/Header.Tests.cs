/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

[TestClass]
public class UnitTestHeader
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
    public void Placement_GetPlacement_PlacementReturned()
    {
        // Arrange
        var header = new Header();

        // Act
        var placement = header.Placement;

        // Assert
        Assert.AreEqual(Placement.TopCenterFullWidth, placement);
    }
    #endregion

    #region Line
    [TestMethod]
    public void Line_GetLine_LineReturned()
    {
        // Arrange
        var header = new Header();

        // Act
        var line = header.Line;

        // Assert
        Assert.AreEqual(line, Window.GetVisibleElement<Title>()?.Height ?? default);
    }

    [TestMethod]
    public void Line_GetLine_TitleMakesHeaderMove()
    {
        // Arrange
        var header = new Header();
        var title = new Title("Example Title");

        // Act
        Window.AddElement(title);
        Window.AddElement(header);
        Window.Refresh();
        var line = header.Line;

        // Assert
        Assert.AreEqual(line, title.Height);

        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion

    #region Height
    [TestMethod]
    public void Height_GetHeight_HeightReturned()
    {
        // Arrange
        var header = new Header();

        // Act
        var height = header.Height;

        // Assert
        Assert.AreEqual(height, 1 + header.Margin);
    }
    #endregion

    #region Width
    [TestMethod]
    public void Width_GetWidth_WidthReturned()
    {
        // Arrange
        var header = new Header();

        // Act
        var width = header.Width;

        // Assert
        Assert.AreEqual(width, Console.WindowWidth);
    }
    #endregion

    #region Text
    [TestMethod]
    public void Text_GetText_TextReturned()
    {
        // Arrange
        var header = new Header();

        // Act
        var text = header.Text;

        // Assert
        Assert.AreEqual(text, ("Header Left", "Header Center", "Header Right"));
    }
    #endregion

    #region Margin
    [TestMethod]
    public void Margin_GetMargin_MarginReturned()
    {
        // Arrange
        var header = new Header();

        // Act
        var margin = header.Margin;

        // Assert
        Assert.AreEqual(margin, 1);
    }

    [TestMethod]
    public void Margin_SetMargin_MarginUpdated()
    {
        // Arrange
        var header = new Header();

        // Act
        header.UpdateMargin(2);

        // Assert
        Assert.AreEqual(header.Margin, 2);
    }
    #endregion

    #region Constructor
    [TestMethod]
    [DataRow("left", "center", "right", 1)]
    public void Constructor_Initialization(
        string leftText,
        string centerText,
        string rightText,
        int margin
    )
    {
        // Arrange

        // Act
        var header = new Header(leftText, centerText, rightText, margin);

        // Assert
        Assert.AreEqual(header.Text, (leftText, centerText, rightText));
        Assert.AreEqual(header.Margin, margin);
    }
    #endregion

    #region UpdateLeftText
    [TestMethod]
    [DataRow("hello world")]
    [DataRow(null)]
    public void UpdateLeftText_ModifyLeftText_LeftTextUpdated(string newText)
    {
        // Arrange
        var leftText = "left";
        var centerText = "center";
        var rightText = "right";
        var margin = 1;
        var header = new Header(leftText, centerText, rightText, margin);

        // Act
        header.UpdateLeftText(newText);

        // Assert
        Assert.AreEqual(newText, header.Text.Item1);
    }
    #endregion

    #region UpdateCenterText
    [TestMethod]
    [DataRow("hello world")]
    [DataRow(null)]
    public void UpdateCenterText_ModifyCenterText_CenterTextUpdated(string newText)
    {
        // Arrange
        var leftText = "left";
        var centerText = "center";
        var rightText = "right";
        var margin = 1;

        // Act
        var header = new Header(leftText, centerText, rightText, margin);
        header.UpdateCenterText(newText);
        // Assert
        Assert.AreEqual(header.Text.Item2, newText);
    }
    #endregion

    #region UpdateRightText
    [TestMethod]
    [DataRow("hello world")]
    [DataRow(null)]
    public void UpdateRightText_ModifyRightText_RightTextUpdated(string newText)
    {
        // Arrange
        var leftText = "left";
        var centerText = "center";
        var rightText = "right";
        var margin = 1;

        // Act
        var header = new Header(leftText, centerText, rightText, margin);
        header.UpdateRightText(newText);
        // Assert
        Assert.AreEqual(header.Text.Item3, newText);
    }
    #endregion
}
