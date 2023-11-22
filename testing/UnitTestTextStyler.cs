namespace testing
{
    [TestClass]
    public class UnitTestTextStyler
    {
        [TestMethod]
        public void TestConstructorWithNullFontPath()
        {
            var styler = new TextStyler();
            Assert.IsNotNull(styler.dictionary);
            var expected = @" █████╗  
██╔══██╗ 
███████║ 
██╔══██║ 
██║  ██║ 
╚═╝  ╚═╝ ";
            Assert.AreEqual(expected, styler.dictionary['a']);
        }

        [TestMethod]
        public void TestConstructorWithFontPath()
        {
            var styler = new TextStyler("../../../ressources/fonts/ANSI_Shadow/");
            var expected = @" █████╗  
██╔══██╗ 
███████║ 
██╔══██║ 
██║  ██║ 
╚═╝  ╚═╝ ";
            Assert.AreEqual(expected, styler.dictionary['a']);
            Assert.IsNotNull(styler.dictionary);
        }

        [TestMethod]
        public void TestConstructorWithFontPathAndDefault()
        {
            var stylerDefault = new TextStyler();
            var stylerCustom = new TextStyler("../../../ressources/fonts/ANSI_Shadow/");
            Assert.AreEqual(stylerDefault.dictionary['a'], stylerCustom.dictionary['a']);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void TestConstructorWithInvalidFontPath()
        {
            new TextStyler("invalid/path");
        }

        [TestMethod]
        public void TestStyleTextToString()
        {
            var styler = new TextStyler();
            string text = "Hello World";
            string styledText = styler.StyleTextToString(text);
            Assert.IsNotNull(styledText);
        }

        [TestMethod]
        public void TestStyleTextToStringArray()
        {
            var styler = new TextStyler();
            string text = "Hello World";
            string[] styledText = styler.StyleTextToStringArray(text);
            Assert.IsNotNull(styledText);
        }

        [TestMethod]
        public void TestToString()
        {
            var styler = new TextStyler();
            string result = styler.ToString();
            Assert.IsNotNull(result);
        }
    }
}