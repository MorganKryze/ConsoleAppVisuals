/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

[TestClass]
public class UnitTestLoadingBar
{
    #region Cleanup
    [TestCleanup]
    public void Cleanup()
    {
        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion

    [TestMethod]
    public void Line_Getter()
    {
        //Arrange
        float valuee = 0.3f;
        var loadingBar = new LoadingBar("test", ref valuee, Placement.TopCenter, 0);

        //Act
        var line = loadingBar.Line;

        //Assert
        Assert.AreEqual(0, line);
    }

    [TestMethod]
    public void Line_NoLineInput()
    {
        //Arrange
        float valuee = 0.3f;
        var loadingBar = new LoadingBar("test", ref valuee, Placement.TopCenter);

        //Act
        var line = loadingBar.Line;

        //Assert
        Assert.AreEqual(0, line);
    }

    [TestMethod]
    public void Height_Getter()
    {
        //Arrange
        float valuee = 0.3f;
        var loadingBar = new LoadingBar("test", ref valuee, Placement.TopCenter, 0);

        //Act
        var height = loadingBar.Height;

        //Assert
        Assert.AreEqual(3, height);
    }

    [TestMethod]
    [DataRow("test")]
    [DataRow("hello world")]
    [DataRow("")]
    public void Width_Getter(string text)
    {
        //Arrange
        float valuee = 0.3f;
        var loadingBar = new LoadingBar(text, ref valuee, Placement.TopCenter, 0);

        //Act
        var width = loadingBar.Width;

        //Assert
        Assert.AreEqual(loadingBar.Text.Length, width);
    }

    [TestMethod]
    [DataRow("test")]
    [DataRow("")]
    public void Text_Getter(string text)
    {
        //Arrange
        float valuee = 0.3f;
        var loadingBar = new LoadingBar(text, ref valuee, Placement.TopCenter, 0);
        //Act
        var newText = loadingBar.Text;
        //Assert
        Assert.AreEqual(newText, loadingBar.Text);
    }

    [TestMethod]
    [DataRow(0.5f)]
    [DataRow(0.3f)]
    public void Progress_Getter(float progress)
    {
        //Arrange
        var loadingBar = new LoadingBar("test", ref progress, Placement.TopCenter, 0);
        //Act
        var newProgress = loadingBar.Progress;
        //Assert
        Assert.AreEqual(newProgress, loadingBar.Progress);
    }

    [TestMethod]
    [DataRow(Placement.TopCenter)]
    [DataRow(Placement.BottomCenterFullWidth)]
    public void Placement_Getter(Placement placement)
    {
        //Arrange
        float valuee = 0.3f;
        var loadingBar = new LoadingBar("test", ref valuee, placement, 0);
        //Act
        var newPlacement = loadingBar.Placement;
        //Assert
        Assert.AreEqual(newPlacement, loadingBar.Placement);
    }

    [TestMethod]
    public void AdditionalDuration_Getter()
    {
        //Arrange
        float valuee = 0.3f;
        var loadingBar = new LoadingBar("test", ref valuee, Placement.TopCenter, 1000);
        //Act
        var newAdditionalDuration = loadingBar.AdditionalDuration;
        //Assert
        Assert.AreEqual(newAdditionalDuration, loadingBar.AdditionalDuration);
    }

    [TestMethod]
    [DataRow("test", 0.3f, Placement.TopCenter, 0)]
    [DataRow("test", 0.3f, Placement.BottomCenterFullWidth, 0)]
    public void Test_Constructor(string text, ref float progress, Placement placement, int line)
    {
        //Act
        new LoadingBar(text, ref progress, placement, line);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    [DataRow(-1)]
    [DataRow(300000)]
    public void Test_ConstructorFalseLine(int line)
    {
        //Arrange
        float valuee = 0.3f;
        string text = "test";
        Placement placement = Placement.TopCenter;
        //Act
        new LoadingBar(text, ref valuee, placement, line);
    }

    [TestMethod]
    [DataRow("test")]
    [DataRow("hello world")]
    [DataRow("")]
    public void UpdateText_DifferentValues(string text)
    {
        //Arrange
        float valuee = 0.3f;
        Placement placement = Placement.TopCenter;
        var loadingBar = new LoadingBar("test", ref valuee, placement, 0);
        //Act
        loadingBar.UpdateText(text);
        //Assert
        Assert.AreEqual(text, loadingBar.Text);
    }

    [TestMethod]
    [DataRow(0.5f)]
    [DataRow(0.3f)]
    [DataRow(null)]
    public void UpdateProgress_SimulateProcess(float progress)
    {
        //Arrange
        float p = 0.3f;
        string text = "test";
        Placement placement = Placement.TopCenter;
        var loadingBar = new LoadingBar(text, ref p, placement, 0);
        //Act
        loadingBar.UpdateProgress(progress);
        //Assert
        Assert.AreEqual(progress, loadingBar.Progress);
    }
}
