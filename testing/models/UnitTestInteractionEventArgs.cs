/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestInteractionEventArgs
{
    [TestMethod]
    public void TestConstructor()
    {
        var state = Output.Exit;
        var info = "Test info";
        var args = new InteractionEventArgs<string>(state, info);
        Assert.AreEqual(state, args.State);
        Assert.AreEqual(info, args.Info);
    }

    [TestMethod]
    public void TestStateProperty()
    {
        var args = new InteractionEventArgs<string>(Output.Delete, "Test info");
        Assert.AreEqual(Output.Delete, args.State);
    }

    [TestMethod]
    public void TestInfoProperty()
    {
        var args = new InteractionEventArgs<string>(Output.Delete, "Test info");
        Assert.AreEqual("Test info", args.Info);
    }
}
