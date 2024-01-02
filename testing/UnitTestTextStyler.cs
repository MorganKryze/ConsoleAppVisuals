/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing
{
    [TestClass]
    public class UnitTestTextStyler
    {
        private readonly TextStyler styler = new();
        [TestMethod]
        public void TestConstructorWithNullFontPath()
        {
            Assert.IsNotNull(styler.Dictionary);
            var expected = @" █████╗  
██╔══██╗ 
███████║ 
██╔══██║ 
██║  ██║ 
╚═╝  ╚═╝ ";
            Assert.AreEqual(expected, styler.Dictionary['a']);
        }

        [TestMethod]
        [DataRow("../../../resources/fonts/ANSI_Shadow/")]
        public void TestConstructorWithFontPath(string path)
        {
            var custom = new TextStyler(path);
            var expected = @" █████╗  
██╔══██╗ 
███████║ 
██╔══██║ 
██║  ██║ 
╚═╝  ╚═╝ ";
            Assert.AreEqual(expected, custom.Dictionary['a']);
            Assert.IsNotNull(custom.Dictionary);
        }

        [TestMethod]
        [DataRow("../../../resources/fonts/ANSI_Shadow/")]
        public void TestConstructorWithFontPathAndDefault(string path)
        {
            var stylerCustom = new TextStyler(path);
            Assert.AreEqual(styler.Dictionary['a'], stylerCustom.Dictionary['a']);
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