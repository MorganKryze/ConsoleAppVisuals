/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

[TestClass]
public class UnitTestBanner
{
    #region BannerConstructor
    [TestMethod]
    [DataRow("left", "center", "right", 1, 1)]
    [DataRow("left", "center", "right", 1, 1)]
    public void BannerConstructor(
        string leftText,
        string centerText,
        string rightText,
        int upperMargin,
        int lowerMargin
    )
    {
        //Arrange
        //Act
        var banner = new Banner(
            leftText,
            centerText,
            rightText,
            upperMargin,
            lowerMargin,
            Placement.TopCenterFullWidth
        );

        //Assert
        Assert.AreEqual(banner.Text, (leftText, centerText, rightText));
        Assert.AreEqual(banner.UpperMargin, upperMargin);
        Assert.AreEqual(banner.LowerMargin, lowerMargin);
    }
    #endregion

    #region BannerConstructorWrongPlacement
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    [DataRow("left", "center", "right", 1, 1, Placement.TopLeft)]
    [DataRow("left", "center", "right", 1, 1, Placement.TopRight)]
    public void BannerConstructorWrongPlacement(
        string leftText,
        string centerText,
        string rightText,
        int upperMargin,
        int lowerMargin,
        Placement placement
    )
    {
        //Act
        new Banner(leftText, centerText, rightText, upperMargin, lowerMargin, placement);
    }
    #endregion

    #region CheckPlacement
    [TestMethod]
    [DataRow(Placement.TopCenterFullWidth)]
    [DataRow(Placement.BottomCenterFullWidth)]
    public void CheckPlacement(Placement placement)
    {
        //Arrange
        //Act
        var banner = new Banner("left", "center", "right", 1, 1, placement);

        //Assert
        Assert.AreEqual(banner.Placement, placement);
    }
    #endregion

    #region UpdateLeftText
    [TestMethod]
    [DataRow("hello world")]
    [DataRow(null)]
    public void UpdateLeftText(string leftText)
    {
        //Arrange
        var banner = new Banner("left", "center", "right", 1, 1, Placement.TopCenterFullWidth);
        //Act
        banner.UpdateLeftText(leftText);

        //Assert
        Assert.AreEqual(banner.Text.Item1, leftText);
    }
    #endregion

    #region UpdateCenterText
    [TestMethod]
    [DataRow("hello world")]
    [DataRow(null)]
    public void UpdateCenterText(string leftText)
    {
        //Arrange
        var banner = new Banner("left", "center", "right", 1, 1, Placement.TopCenterFullWidth);
        //Act
        banner.UpdateCenterText(leftText);

        //Assert
        Assert.AreEqual(banner.Text.Item2, leftText);
    }
    #endregion

    #region UpdateLRightText
    [TestMethod]
    [DataRow("hello world")]
    [DataRow(null)]
    public void UpdateRightText(string leftText)
    {
        //Arrange
        var banner = new Banner("left", "center", "right", 1, 1, Placement.TopCenterFullWidth);
        
        //Act
        banner.UpdateRightText(leftText);

        //Assert
        Assert.AreEqual(banner.Text.Item3, leftText);
    }
    #endregion

    #region Text
    [TestMethod]
    public void Text()
    {
        //Arrange
        var banner = new Banner();

        //Act
        var text = banner.Text;

        //Assert
        Assert.AreEqual(text, ("Banner Left", "Banner Center", "Banner Right"));
    }
    #endregion

    #region UpperMargin
    [TestMethod]
    public void UpperMargin()
    {
        //Arrange
        var banner = new Banner();

        //Act
        var margin = banner.UpperMargin;

        //Assert
        Assert.AreEqual(margin, banner.UpperMargin);
    }
    #endregion

    #region LowerMargin
    [TestMethod]
    public void LowerMargin()
    {
        //Arrange
        var banner = new Banner();

        //Act
        var margin = banner.LowerMargin;

        //Assert
        Assert.AreEqual(margin, banner.LowerMargin);
    }
    #endregion

    #region Placement
    [TestMethod]
    public void Placement_Getter()
    {
        //Arrange
        var banner = new Banner();

        //Act
        var placement = banner.Placement;

        //Assert
        Assert.AreEqual(placement, banner.Placement);
    }
    #endregion

    #region Line
    [TestMethod]
    public void Line()
    {
        //Arrange
        var banner = new Banner();

        //Act
        var line = banner.Line;

        //Assert
        Assert.AreEqual(line, banner.Line);
    }
    #endregion
}
