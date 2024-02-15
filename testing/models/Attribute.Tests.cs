/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestAttribute
{
    [TestMethod]
    public void TestConstructor()
    {
        var attribute = new VisualAttribute();
        Assert.IsNull(attribute.Message);
        Assert.IsFalse(attribute.IsError);
    }

    [TestMethod]
    public void TestConstructorWithMessage()
    {
        var attribute = new VisualAttribute("Test message");
        Assert.AreEqual("Test message", attribute.Message);
        Assert.IsFalse(attribute.IsError);
    }

    [TestMethod]
    public void TestConstructorWithMessageAndError()
    {
        var attribute = new VisualAttribute("Test message", true);
        Assert.AreEqual("Test message", attribute.Message);
        Assert.IsTrue(attribute.IsError);
    }

    [TestMethod]
    public void TestDiagnosticIdProperty()
    {
        var attribute = new VisualAttribute
        {
            DiagnosticId = "Test diagnostic ID"
        };
        Assert.AreEqual("Test diagnostic ID", attribute.DiagnosticId);
    }

    [TestMethod]
    public void TestUrlFormatProperty()
    {
        var attribute = new VisualAttribute
        {
            UrlFormat = "Test URL format"
        };
        Assert.AreEqual("Test URL format", attribute.UrlFormat);
    }
}
