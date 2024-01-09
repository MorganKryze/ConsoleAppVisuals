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

        #region Constructor
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
        [ExpectedException(typeof(EmptyFileException))]
        [DataRow("../../../resources/fonts/Throw_Error/")]
        public void Test_ConfigFileEmpty(string path)
        {
            
            TextStyler emptyStyler = new(path); // Here should the error be thrown
            emptyStyler.StyleTextToString("Hello World!");
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        [DataRow("invalid/path")]
        public void TestConstructorWithInvalidFontPath(string path)
        {
            new TextStyler(path);
        }
        #endregion

        #region StyleTextToString
        [TestMethod]
        [DataRow("Hello World")]
        public void TestStyleTextToString(string value)
        {
            string styledText = styler.StyleTextToString(value);
            Assert.IsNotNull(styledText);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedCharException))]
        public void Test_UnsupportedCharString()
        {
            styler.StyleTextToString("Hello World! +=è$%&/()=?^*[]{}@#|");
        }
        #endregion

        #region StyleTextToStringArray
        [TestMethod]
        [DataRow("Hello World")]
        public void TestStyleTextToStringArray(string value)
        {
            string[] styledText = styler.StyleTextToStringArray(value);
            Assert.IsNotNull(styledText);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedCharException))]
        public void Test_UnsupportedCharArray()
        {
            styler.StyleTextToStringArray("Hello World! +=è$%&/()=?^*[]{}@#|");
        }
        #endregion

        #region General
        [TestMethod]
        public void TestToString()
        {
            string result = styler.ToString();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestEquals()
        {
            Assert.IsTrue(styler.Equals(styler));
            Assert.IsFalse(styler.Equals(null));
            Assert.IsFalse(styler.Equals(new TextStyler()));
        }
        #endregion
    }
}