/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestElement
{
    [TestMethod]
    public void Test_Dimensions()
    {
        var element = new TestElement();
        Assert.AreEqual(0, element.Height);
        Assert.AreEqual(0, element.Width);
        Assert.AreEqual(0, element.Line);
        Assert.AreEqual(Placement.TopCenter, element.Placement);
    }

    [TestMethod]
    public void Test_Line()
    {
        var element = new TestElement();
        Assert.AreEqual(0, element.Line);
        Assert.AreEqual(Placement.TopCenter, element.Placement);
    }

    [TestMethod]
    public void Test_Placement()
    {
        var element = new TestElement();
        Assert.AreEqual(Placement.TopCenter, element.Placement);
    }

    [TestMethod]
    public void Test_ToggleVisibility()
    {
        // Arrange
        var element1 = new TestElement();
        Window.AddElement(element1);
        var element2 = new TestElement();
        Window.AddElement(element2);

        Assert.ThrowsException<InvalidOperationException>(() => element2.ToggleVisibility());
    }
}

public class TestElement : Element { }
