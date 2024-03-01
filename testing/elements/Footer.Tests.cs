/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

[TestClass]
public class UnitTestFooter
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
    [DataRow(Placement.BottomCenterFullWidth)]
    [DataRow(Placement.TopLeft)]
    public void Placement_Getter(Placement placement)
    {
        //Arrange
        Footer footer = new Footer();
        //Act
        footer.Placement = placement;
        //Assert
        Assert.AreEqual(placement, footer.Placement);
    }
    #endregion

    #region PlacementFalse
    [TestMethod]
    [ExpectedException(typeof(AssertFailedException))]
    [DataRow(Placement.TopLeft)]
    [DataRow(Placement.TopCenter)]
    [DataRow(Placement.TopRight)]
    public void PlacementFalse(Placement placement)
    {
        //Arrange
        Footer footer = new Footer();
        //Act
        footer.Placement = placement;
        //Assert
        Assert.AreEqual(Placement.BottomCenterFullWidth, footer.Placement);
    }
    #endregion

    #region Line
    [TestMethod]
    public void Line_Getter()
    {
        //Arrange
        Footer footer = new Footer();

        //Assert
        Assert.AreEqual(footer.Line, Window.GetLineAvailable(footer.Placement));
    }
    #endregion

    #region Height
    [TestMethod]
    public void Height_Getter()
    {
        //Arrange
        Footer footer = new Footer();

        //Assert
        Assert.AreEqual(footer.Height, 1);
    }
    #endregion

    #region Width
    [TestMethod]
    public void Width_Getter()
    {
        //Arrange
        Footer footer = new Footer();

        //Assert
        Assert.AreEqual(footer.Width, Console.WindowWidth);
    }
    #endregion

    #region Constructor
    [TestMethod]
    [DataRow(" ", " ", " ")]
    [DataRow("l ", "m ", "r ")]
    public void Constructor(string left, string mid, string right)
    {
        //Arrange
        //Act
        Footer footer = new Footer(left, mid, right);
        //Assert
        Assert.AreEqual((left, mid, right), footer.Text);
    }
    #endregion

    #region ConstructorPlacement
    [TestMethod]
    [DataRow(" ", " ", " ")]
    [DataRow("l ", "m ", "r ")]
    public void ConstructorPlacement(string left, string mid, string right)
    {
        //Arrange
        //Act
        Footer footer = new Footer(left, mid, right);
        //Assert
        Assert.AreEqual(Placement.BottomCenterFullWidth, footer.Placement);
    }
    #endregion

    #region UpdateLeftText
    [TestMethod]
    [DataRow(" ")]
    [DataRow("hello world")]
    public void UpdateLeftText(string left)
    {
        //Arrange
        Footer footer = new Footer("hello", " ", " ");
        //Act
        footer.UpdateLeftText(left);
        //Assert
        Assert.AreEqual(left, footer.Text.Item1);
    }
    #endregion

    #region UpdateCenterText
    [TestMethod]
    [DataRow(" ")]
    [DataRow("hello world")]
    public void UpdateCenterText(string mid)
    {
        //Arrange
        Footer footer = new Footer(" ", " all", " ");
        //Act
        footer.UpdateCenterText(mid);
        //Assert
        Assert.AreEqual(mid, footer.Text.Item2);
    }
    #endregion

    #region UpdateRightText
    [TestMethod]
    [DataRow(" ")]
    [DataRow("hello world")]
    public void UpdateRightText(string right)
    {
        //Arrange
        Footer footer = new Footer(" ", " ", "world");
        //Act
        footer.UpdateRightText(right);
        //Assert
        Assert.AreEqual(right, footer.Text.Item3);
    }
    #endregion
}
