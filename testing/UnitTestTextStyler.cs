namespace testing
{
    [TestClass]
    public class UnitTestTextStyler
    {
        private readonly TextStyler styler = new();
        [TestMethod]
        public void TestConstructorWithNullFontPath()
        {
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
        [DataRow("../../../ressources/fonts/ANSI_Shadow/")]
        public void TestConstructorWithFontPath(string path)
        {
            var custom = new TextStyler(path);
            var expected = @" █████╗  
██╔══██╗ 
███████║ 
██╔══██║ 
██║  ██║ 
╚═╝  ╚═╝ ";
            Assert.AreEqual(expected, custom.dictionary['a']);
            Assert.IsNotNull(custom.dictionary);
        }

        [TestMethod]
        [DataRow("../../../ressources/fonts/ANSI_Shadow/")]
        public void TestConstructorWithFontPathAndDefault(string path)
        {
            var stylerCustom = new TextStyler(path);
            Assert.AreEqual(styler.dictionary['a'], stylerCustom.dictionary['a']);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        [DataRow("invalid/path")]
        public void TestConstructorWithInvalidFontPath(string path)
        {
            new TextStyler(path);
        }

        [TestMethod]
        [DataRow("Hello World")]
        public void TestStyleTextToString(string value)
        {
            string styledText = styler.StyleTextToString(value);
            Assert.IsNotNull(styledText);
        }

        [TestMethod]
        [DataRow("Hello World")]
        public void TestStyleTextToStringArray(string value)
        {
            string[] styledText = styler.StyleTextToStringArray(value);
            Assert.IsNotNull(styledText);
        }

        [TestMethod]
        public void TestToString()
        {
            string result = styler.ToString();
            Assert.IsNotNull(result);
        }
    }
}