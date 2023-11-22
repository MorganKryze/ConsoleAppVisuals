namespace testing;

[TestClass]
public class UnitTestExtensions
{
    [TestMethod]
    public void TestResizeString()
    {
        string[] words = new string[] { "Hello", "World" };
        string[] expected = new string[] { "     Hello     ", "     World     " };
        foreach (string word in words)
        {
            string result = word.ResizeString(15);
            Assert.AreEqual(expected[Array.IndexOf(words, word)], result);
        }
    }

    [TestMethod]
    public void TestInsertStringLeft()
    {
        string[] words = new string[] { "Hello World", "Bonjour Le Monde" };

        string[] expectedLeft = new string[] {"testo World", "testour Le Monde"};
        
        foreach (string word in words)
        {
            string result = word.InsertString("test", Placement.Left);
            Assert.AreEqual(expectedLeft[Array.IndexOf(words, word)], result);
        }
    }
    [TestMethod]
    public void TestInsertStringCenter()
    {
        string[] words = new string[] { "Hello World", "Bonjour Le Monde" };

        string[] expectedRigth = new string[] {"Hello Wtest", "Bonjour Le Mtest"};
        
        foreach (string word in words)
        {
            string result = word.InsertString("test", Placement.Right);
            Assert.AreEqual(expectedRigth[Array.IndexOf(words, word)], result);
        }
    }
    [TestMethod]
    public void TestInsertStringRigth()
    {
        string[] words = new string[] { "Hello World", "Bonjour Le Monde" };

        string[] expectedCenter = new string[] {"Heltestorld", "Bonjoutest Monde"};

        foreach (string word in words)
        {
            string result = word.InsertString("test", Placement.Center);
            Assert.AreEqual(expectedCenter[Array.IndexOf(words, word)], result);
        }
    }
}