/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/

using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace ConsoleAppVisuals;
[TestClass]
public class UnitTestFooter
{
    [TestMethod]
    [DataRow(" ", " ", " ")]
    [DataRow("l ", "m ", "r ")]
    public void Test_Text(string left, string mid, string right)
    {
        //Arrange
        var text = (left, mid, right);
        Footer footer = new Footer();
        //Act
        footer.Text = text;
        //Assert
        Assert.AreEqual(text, footer.Text);
    }


    [TestMethod]
    [DataRow(Placement.BottomCenterFullWidth)]
    [DataRow(Placement.TopLeft)]
    public void Test_Placement(Placement placement)
    {
        //Arrange
        Footer footer = new Footer();
        //Act
        footer.Placement = placement;
        //Assert 
        Assert.AreEqual(placement, footer.Placement);
    }

    [TestMethod]
    [ExpectedException(typeof(AssertFailedException))]
    [DataRow(Placement.TopLeft)]
    [DataRow(Placement.TopCenter)]
    [DataRow(Placement.TopRight)]

    public void Test_PlacementFalse(Placement placement){
        //Arrange
        Footer footer = new Footer();
        //Act
        footer.Placement = placement;
        //Assert
        Assert.AreEqual(Placement.BottomCenterFullWidth, footer.Placement);
    }

    [TestMethod]

    public void Test_Line(){
        //Arrange
        Footer footer = new Footer();

        //Assert 
        Assert.AreEqual(footer.Line, Window.GetLineAvailable(footer.Placement));
    }


    [TestMethod]

    public void Test_Height(){
        //Arrange
        Footer footer = new Footer();

        //Assert 
        Assert.AreEqual(footer.Height, 1);
    }

    [TestMethod]
    
    public void Test_Width(){
        //Arrange
        Footer footer = new Footer();

        //Assert 
        Assert.AreEqual(footer.Width, Console.WindowWidth);
    }   

    [TestMethod]
    [DataRow(" ", " ", " ")]
    [DataRow("l ", "m ", "r ")]
    public void Test_constructor(string left, string mid, string right){
        //Arrange
        //Act
        Footer footer = new Footer(left, mid, right);
        //Assert
        Assert.AreEqual((left, mid, right), footer.Text);
    }

    [TestMethod]
    [DataRow(" ", " ", " ")]
    [DataRow("l ", "m ", "r ")]
    public void Test_constructorPlacement(string left, string mid, string right){
        //Arrange
        //Act
        Footer footer = new Footer(left, mid, right);
        //Assert
        Assert.AreEqual(Placement.BottomCenterFullWidth, footer.Placement);
    }

    [TestMethod]
    [DataRow(" ")]
    [DataRow("hello world")]
    public void Test_UppdateLeftText(string left){
        //Arrange
        Footer footer = new Footer("hello", " ", " ");
        //Act
        footer.UpdateLeftText(left);
        //Assert
        Assert.AreEqual(left, footer.Text.Item1);
    }


    [TestMethod]
    [DataRow(" ")]
    [DataRow("hello world")]
    public void Test_UpdateCenterText(string mid){
        //Arrange
        Footer footer = new Footer(" ", " all", " ");
        //Act
        footer.UpdateCenterText(mid);
        //Assert
        Assert.AreEqual(mid, footer.Text.Item2);
    }

    [TestMethod]
    [DataRow(" ")]
    [DataRow("hello world")]
    public void Test_UpdateRightText(string right){
        //Arrange
        Footer footer = new Footer(" ", " ", "world");
        //Act
        footer.UpdateRightText(right);
        //Assert
        Assert.AreEqual(right, footer.Text.Item3);
    }


    



}
