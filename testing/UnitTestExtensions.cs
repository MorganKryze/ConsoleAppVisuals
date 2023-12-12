/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestExtensions
{
    [TestMethod]
    [DataRow("Hello")]
    [DataRow("World")]
    public void TestResizeString(string value)
    {
        if(value == "Hello")
        {
            Assert.AreEqual("     Hello     ", value.ResizeString(15));
        }
        else if (value == "World")
        {
            Assert.AreEqual("     World     ", value.ResizeString(15));
        }
    }

    [TestMethod]
    [DataRow("Hello World")]
    [DataRow("Bonjour Le Monde")]
    public void TestInsertStringLeft(string value)
    {
        if(value == "Hello World")
        {
            Assert.AreEqual("testo World", value.InsertString("test", Placement.Left));
        }
        else if (value == "Bonjour Le Monde")
        {
            Assert.AreEqual("testour Le Monde", value.InsertString("test", Placement.Left));
        }
    }

    [TestMethod]
    [DataRow("Hello World")]
    [DataRow("Bonjour Le Monde")]
    public void TestInsertStringRight(string value)
    {
        if(value == "Hello World")
        {
            Assert.AreEqual("Hello Wtest", value.InsertString("test", Placement.Right));
        }
        else if (value == "Bonjour Le Monde")
        {
            Assert.AreEqual("Bonjour Le Mtest", value.InsertString("test", Placement.Right));
        }
    }
    
    [TestMethod]
    [DataRow("Hello World")]
    [DataRow("Bonjour Le Monde")]
    public void TestInsertStringCenter(string value)
    {
        if(value == "Hello World")
        {
            Assert.AreEqual("Heltestorld", value.InsertString("test", Placement.Center));
        }
        else if (value == "Bonjour Le Monde")
        {
            Assert.AreEqual("Bonjoutest Monde", value.InsertString("test", Placement.Center));
        }
    }
}