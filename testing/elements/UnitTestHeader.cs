/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;
[TestClass]
public class UnitTestHeader
{
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