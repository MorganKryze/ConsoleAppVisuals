/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace tests;

[TestClass]
public class UnitTestInteractionEventArgs
{
    #region ConstructorTests

    [TestMethod]
    public void Constructor_StateAndInfo_SetCorrectly()
    {
        // Arrange
        var state = Status.Escaped;
        var info = "Test info";

        // Act
        var args = new InteractionEventArgs<string>(state, info);

        // Assert
        Assert.AreEqual(state, args.Status);
        Assert.AreEqual(info, args.Value);
    }

    #endregion

    #region StatePropertyTests

    [TestMethod]
    public void StateProperty_ReturnsCorrectState()
    {
        // Arrange
        var args = new InteractionEventArgs<string>(Status.Deleted, "Test info");

        // Act & Assert
        Assert.AreEqual(Status.Deleted, args.Status);
    }

    #endregion

    #region InfoPropertyTests

    [TestMethod]
    public void InfoProperty_ReturnsCorrectInfo()
    {
        // Arrange
        var args = new InteractionEventArgs<string>(Status.Deleted, "Test info");

        // Act & Assert
        Assert.AreEqual("Test info", args.Value);
    }

    #endregion
}
