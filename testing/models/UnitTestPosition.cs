/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestPosition
{
    [TestMethod]
    public void TestConstructor()
    {
        var position = new Position(1, 2);
        Assert.AreEqual(1, position.X);
        Assert.AreEqual(2, position.Y);
    }

    [TestMethod]
    public void TestCopyConstructor()
    {
        var original = new Position(1, 2);
        var copy = new Position(original);
        Assert.AreEqual(original, copy);
    }

    [TestMethod]
    public void TestToString()
    {
        var position = new Position(1, 2);
        Assert.AreEqual("Line : 1 ; Column : 2", position.ToString());
    }

    [TestMethod]
    public void TestEquals()
    {
        var position1 = new Position(1, 2);
        var position2 = new Position(1, 2);
        var position3 = new Position(2, 1);
        Assert.IsTrue(position1.Equals(position2));
        Assert.IsFalse(position1.Equals(position3));
    }

    [TestMethod]
    public void TestGetHashCode()
    {
        var position1 = new Position(1, 2);
        var position2 = new Position(1, 2);
        var position3 = new Position(2, 1);
        Assert.AreEqual(position1.GetHashCode(), position2.GetHashCode());
        Assert.AreNotEqual(position1.GetHashCode(), position3.GetHashCode());
    }

    [TestMethod]
    public void TestOperatorEquals()
    {
        var position1 = new Position(1, 2);
        var position2 = new Position(1, 2);
        var position3 = new Position(2, 1);
        Assert.IsTrue(position1 == position2);
        Assert.IsFalse(position1 == position3);
    }

    [TestMethod]
    public void TestOperatorNotEquals()
    {
        var position1 = new Position(1, 2);
        var position2 = new Position(1, 2);
        var position3 = new Position(2, 1);
        Assert.IsFalse(position1 != position2);
        Assert.IsTrue(position1 != position3);
    }
}
