/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestInteractionEventArgs
{
    #region ConstructorTests

    [TestMethod]
    public void Constructor_StateAndInfo_SetCorrectly()
    {
        // Arrange
        var state = Output.Exit;
        var info = "Test info";

        // Act
        var args = new InteractionEventArgs<string>(state, info);

        // Assert
        Assert.AreEqual(state, args.State);
        Assert.AreEqual(info, args.Info);
    }

    #endregion

    #region StatePropertyTests

    [TestMethod]
    public void StateProperty_ReturnsCorrectState()
    {
        // Arrange
        var args = new InteractionEventArgs<string>(Output.Delete, "Test info");

        // Act & Assert
        Assert.AreEqual(Output.Delete, args.State);
    }

    #endregion

    #region InfoPropertyTests

    [TestMethod]
    public void InfoProperty_ReturnsCorrectInfo()
    {
        // Arrange
        var args = new InteractionEventArgs<string>(Output.Delete, "Test info");

        // Act & Assert
        Assert.AreEqual("Test info", args.Info);
    }

    #endregion
}
