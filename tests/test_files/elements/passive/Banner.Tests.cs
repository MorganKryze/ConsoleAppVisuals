/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace tests;

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

    #region Height
    [TestMethod]
    public void Height()
    {
        //Arrange
        var banner = new Banner();

        //Act
        var height = banner.Height;

        //Assert
        Assert.AreEqual(height, banner.Height);
    }

    #endregion

    #region Width

    [TestMethod]
    public void Width()
    {
        //Arrange
        var banner = new Banner();

        //Act
        var width = banner.Width;

        //Assert
        Assert.AreEqual(width, banner.Width);
    }
    #endregion

    #region UpdatePlacement
    [TestMethod]
    [DataRow(Placement.TopCenterFullWidth)]
    [DataRow(Placement.BottomCenterFullWidth)]
    public void UpdatePlacement(Placement placement)
    {
        //Arrange
        var banner = new Banner();

        //Act
        banner.UpdatePlacement(placement);

        //Assert
        Assert.AreEqual(banner.Placement, placement);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    [DataRow(Placement.TopLeft)]
    [DataRow(Placement.TopRight)]
    public void UpdatePlacementWrongPlacement(Placement placement)
    {
        //Arrange
        var banner = new Banner();

        //Act
        banner.UpdatePlacement(placement);
    }
    #endregion

    #region UpdateUpperMargin
    [TestMethod]
    [DataRow(0)]
    public void UpdateUpperMargin(int margin)
    {
        //Arrange
        var banner = new Banner();

        //Act
        banner.UpdateUpperMargin(margin);

        //Assert
        Assert.AreEqual(banner.UpperMargin, margin);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    [DataRow(-1)]
    [DataRow(200)]
    public void UpdateUpperMarginNegative(int margin)
    {
        //Arrange
        var banner = new Banner();

        //Act
        banner.UpdateUpperMargin(margin);
    }
    #endregion

    #region UpdateLowerMargin

    [TestMethod]
    [DataRow(0)]
    public void UpdateLowerMargin(int margin)
    {
        //Arrange
        var banner = new Banner();

        //Act
        banner.UpdateLowerMargin(margin);

        //Assert
        Assert.AreEqual(banner.LowerMargin, margin);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    [DataRow(-1)]
    [DataRow(200)]
    public void UpdateLowerMarginNegative(int margin)
    {
        //Arrange
        var banner = new Banner();

        //Act
        banner.UpdateLowerMargin(margin);
    }
    #endregion
}
