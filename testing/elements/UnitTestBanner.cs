/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE

namespace ConsoleAppVisuals;
[TestClass]

public class UnitTestBanner{
    [TestMethod]
    [DataRow("left", "center", "right", 1, 1, Placement.TopCenter, 1)]
    [DataRow("left", "center", "right", 1, 1, Placement.TopLeft, 1)]
    [DataRow("left", "center", "right", 1, 1, Placement.TopRight, 1)]
    [DataRow(null,null,null,0,0,null,0)]
    public void Test_BannerConstructor(string leftText, string centerText, string rightText, int upperMargin, int lowerMargin, Placement placement, int line){

        //Arrange

        //Act

        var banner = new Banner(leftText, centerText, rightText, upperMargin, lowerMargin, placement, line);

        //Assert

        Assert.AreEqual(banner.Text, (leftText, centerText, rightText));
        Assert.AreEqual(banner.UpperMargin, upperMargin);
        Assert.AreEqual(banner.LowerMargin, lowerMargin);
        Assert.AreEqual(banner.Placement, placement);
        Assert.AreEqual(banner.Line, line);     
    }

}


*/