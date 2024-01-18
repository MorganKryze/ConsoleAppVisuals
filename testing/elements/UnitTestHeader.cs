/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;
[TestClass]
public class UnitTestHeader
{
    [TestMethod]
    public void Test_Placement(){
        
        //Arrange
        var header = new Header();

        //Act
        var placement = header.Placement;
        
        //Assert
        Assert.AreEqual(Placement.TopCenterFullWidth,placement);
    }


    [TestMethod]
    public void Test_Line(){
        
        //Arrange 
        var header = new Header();

        //Act 
        var line = header.Line;

        //Assert
        Assert.AreEqual(line, Window.GetVisibleElement<Title>()?.Height ?? default);
    }

    [TestMethod]
    public void Test_Height(){
        
        //Arrange
        var header = new Header();

        //Act
        var height = header.Height;

        //Assert
        Assert.AreEqual(height, 1 + header.Margin);
    }

    [TestMethod]
    public void Test_Width(){
        
        //Arrange
        var header = new Header();

        //Act
        var width = header.Width;

        //Assert
        Assert.AreEqual(width, Console.WindowWidth);
    }

    [TestMethod]
    public void Test_Text(){
        
        //Arrange
        var header = new Header();

        //Act
        var text = header.Text;

        //Assert
        Assert.AreEqual(text, ("Header Left", "Header Center", "Header Right"));
    }

    [TestMethod]
    public void Test_Margin(){
        
        //Arrange
        var header = new Header();

        //Act
        var margin = header.Margin;

        //Assert
        Assert.AreEqual(margin, 1);
    }




    [TestMethod]
    [DataRow("left", "center", "right", 1)]
    public void Test_Constructor(string leftText, string centerText, string rightText, int margin) 
    {
        //Arrange

        //Act
        var header = new Header(leftText, centerText, rightText, margin);

        //Assert
        Assert.AreEqual(header.Text, (leftText, centerText, rightText));
        Assert.AreEqual(header.Margin, margin);
    }



    [TestMethod]
    [DataRow("hello world")]
    [DataRow(null)]
    public void Test_UpdateLeftText(string newText)
    {
        //Arrange
        var leftText = "left";
        var centerText = "center";
        var rightText = "right";
        var margin = 1;
        var header = new Header(leftText, centerText, rightText, margin);

        //Act
        header.UpdateLeftText(newText);
        
        //Assert
        Assert.AreEqual(newText, header.Text.Item1);
    }

    [TestMethod]
    [DataRow("hello world")]
    [DataRow(null)]
    public void Test_UpdateCenterText(string newText)
    {
        //Arrange
        var leftText = "left";
        var centerText = "center";
        var rightText = "right";
        var margin = 1;

        //Act
        var header = new Header(leftText, centerText, rightText, margin);
        header.UpdateCenterText(newText);
        //Assert
        Assert.AreEqual(header.Text.Item2, newText);
    }


    [TestMethod]
    [DataRow("hello world")]
    [DataRow(null)]
    public void Test_UpdateRightText(string newText){
        //Arrange
        var leftText = "left";
        var centerText = "center";
        var rightText = "right";
        var margin = 1;

        //Act
        var header = new Header(leftText, centerText, rightText, margin);
        header.UpdateRightText(newText);
        //Assert
        Assert.AreEqual(header.Text.Item3, newText);
    }

}