/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;
[TestClass]

public class UnitTestBanner{
    [TestMethod]
    [DataRow("left", "center", "right", 1, 1)]
    [DataRow("left", "center", "right", 1, 1)]
    public void Test_BannerConstructor(string leftText, string centerText, string rightText, int upperMargin, int lowerMargin){

        //Arrange
        //Act

        var banner = new Banner(leftText, centerText, rightText, upperMargin, lowerMargin,Placement.TopCenterFullWidth);

        //Assert

        Assert.AreEqual(banner.Text, (leftText, centerText, rightText));
        Assert.AreEqual(banner.UpperMargin, upperMargin);
        Assert.AreEqual(banner.LowerMargin, lowerMargin);
 
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    [DataRow("left", "center", "right", 1, 1,Placement.TopLeft)]
    [DataRow("left", "center", "right", 1, 1,Placement.TopRight)]
    public void Test_BannerConstructorWrongPlacement(string leftText, string centerText, string rightText, int upperMargin, int lowerMargin, Placement placement){

        //Arrange
        //Act
        var banner = new Banner(leftText, centerText, rightText, upperMargin, lowerMargin,placement);
    }

    [TestMethod]
    [DataRow(Placement.TopCenterFullWidth)]
    [DataRow(Placement.BottomCenterFullWidth)]
    public void Test_checkPlacement(Placement placement){
            
            //Arrange
            //Act
            var banner = new Banner("left", "center", "right", 1, 1,placement);
    
            //Assert
            Assert.AreEqual(banner.Placement, placement);
    }


    [TestMethod]
    [DataRow("hello world")]
    [DataRow(null)]
    public void Test_UpdateLeftText(string leftText){
            
            //Arrange
            var banner = new Banner("left", "center", "right", 1, 1,Placement.TopCenterFullWidth);
            //Act
            banner.UpdateLeftText(leftText);
    
            //Assert
            Assert.AreEqual(banner.Text.Item1, leftText);
    }  

    [TestMethod]
    [DataRow("hello world")]
    [DataRow(null)]
    public void Test_UpdateCenterText(string leftText){
            
            //Arrange
            var banner = new Banner("left", "center", "right", 1, 1,Placement.TopCenterFullWidth);
            //Act
            banner.UpdateCenterText(leftText);
    
            //Assert
            Assert.AreEqual(banner.Text.Item2, leftText);
    }  

    [TestMethod]
    [DataRow("hello world")]
    [DataRow(null)]
    public void Test_UpdateLRightText(string leftText){
            
            //Arrange
            var banner = new Banner("left", "center", "right", 1, 1,Placement.TopCenterFullWidth);
            //Act
            banner.UpdateRightText(leftText);
    
            //Assert
            Assert.AreEqual(banner.Text.Item3, leftText);
    }  

    [TestMethod]
    public void Test_Text(){
        
        //Arrange
        var banner = new Banner();

        //Act
        var text = banner.Text;

        //Assert
        Assert.AreEqual(text, ("Banner Left", "Banner Center", "Banner Right"));
    }

    [TestMethod]
    public void Test_UpperMargin(){
        
        //Arrange
        var banner = new Banner();

        //Act
        var margin = banner.UpperMargin;

        //Assert
        Assert.AreEqual(margin, banner.UpperMargin);
    }

    [TestMethod]
    public void Test_LowerMargin(){
        
        //Arrange
        var banner = new Banner();

        //Act
        var margin = banner.LowerMargin;

        //Assert
        Assert.AreEqual(margin, banner.LowerMargin);
    }

    [TestMethod]
    public void Test_Placement(){
        
        //Arrange
        var banner = new Banner();

        //Act
        var placement = banner.Placement;

        //Assert
        Assert.AreEqual(placement, banner.Placement);
    }

    [TestMethod]
    public void Test_Line(){
        
        //Arrange
        var banner = new Banner();

        //Act
        var line = banner.Line;

        //Assert
        Assert.AreEqual(line, banner.Line);
    }




}


