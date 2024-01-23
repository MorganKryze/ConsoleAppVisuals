/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/

namespace ConsoleAppVisuals;
[TestClass]
public class UnitTestFakeLoadingBar{

    [TestMethod]
    [DataRow("Test", Placement.TopCenterFullWidth, 0, 1000, 1000)]
    [DataRow("Test", Placement.TopCenterFullWidth, null, 1000, 1000)]
    public void Test_Constructor(string text, Placement placement, int line, int processDuration, int additionalDuration){
        
        new FakeLoadingBar(text, placement, line, processDuration, additionalDuration);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    [DataRow(30000)]
    [DataRow(-1)]
    public void Test_ConstructorFalseLine(int line){

        //Act
        new FakeLoadingBar("Test", Placement.TopCenterFullWidth, line, 1000, 1000);
    }


    [TestMethod]
    [DataRow("hello world")]
    [DataRow("")]
    public void Test_UpdateText(string text){
            
            //Arrange
            var fakeLoadingBar = new FakeLoadingBar(text, Placement.TopCenterFullWidth, 0, 1000, 1000);
    
            //Act
            fakeLoadingBar.UpdateText(text);
    
            //Assert
            Assert.AreEqual(fakeLoadingBar.Text, text);
    }

    [TestMethod]
    [DataRow("hello world")]
    [DataRow("")]
    public void TestText(string text){
        
        //Arrange
        var fakeLoadingBar = new FakeLoadingBar("Test", Placement.TopCenterFullWidth, 0, 1000, 1000);

        //Act
        fakeLoadingBar.Text = text;

        //Assert
        Assert.AreEqual(fakeLoadingBar.Text, text);
    }

    [TestMethod]
    public void Test_Placement(){
        
        //Arrange
        var fakeLoadingBar = new FakeLoadingBar("Test", Placement.TopCenterFullWidth, 0, 1000, 1000);

        //Act
        var placement = fakeLoadingBar.Placement;

        //Assert
        Assert.AreEqual(Placement.TopCenterFullWidth, placement);
    }

    [TestMethod]
    public void Test_Line(){
        
        //Arrange
        var fakeLoadingBar = new FakeLoadingBar("Test", Placement.TopCenterFullWidth, 0, 1000, 1000);

        //Act
        var line = fakeLoadingBar.Line;

        //Assert
        Assert.AreEqual(0,line);
    }   

    [TestMethod]
    public void Test_processDuration(){
        
        //Arrange
        var fakeLoadingBar = new FakeLoadingBar("Test", Placement.TopCenterFullWidth, 0, 1000, 1000);

        //Act
        var processDuration = fakeLoadingBar.processDuration;

        //Assert
        Assert.AreEqual(1000,processDuration);
    }

    [TestMethod]
    public void Test_AdditionalDuration(){
        
        //Arrange
        var fakeLoadingBar = new FakeLoadingBar("Test", Placement.TopCenterFullWidth, 0, 1000, 1000);

        //Act
        var additionalDuration = fakeLoadingBar.AdditionalDuration;

        //Assert
        Assert.AreEqual(1000,additionalDuration);
    }

    [TestMethod]
    public void Test_Height(){
        
        //Arrange
        var fakeLoadingBar = new FakeLoadingBar("Test", Placement.TopCenterFullWidth, 0, 1000, 1000);

        //Act
        var height = fakeLoadingBar.Height;
    }

    [TestMethod]
    public void Test_Width(){
        
        //Arrange
        var fakeLoadingBar = new FakeLoadingBar("Test", Placement.TopCenterFullWidth, 0, 1000, 1000);

        //Act
        var width = fakeLoadingBar.Width;
    }



}