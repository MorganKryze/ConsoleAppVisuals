/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

[TestClass]
public class UnitTestIntSelector
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
    [TestCategory("IntSelector")]
    [DataRow(Placement.TopCenter)]
    [DataRow(Placement.TopLeft)]
    [DataRow(Placement.TopRight)]
    public void Placement_Getter(Placement placement)
    {
        // Arrange
        var intSelector = new IntSelector("Question", 0, 10, 5, 1, placement, 0);

        // Act
        var actualPlacement = intSelector.Placement;

        // Assert
        Assert.AreEqual(placement, actualPlacement);
    }

    #endregion

    #region Line

    #endregion

    #region Height

    #endregion

    #region Width

    #endregion

    #region Constructor

    #endregion

    #region Build

    #endregion
}
