/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
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
        public void Constructor_NullFontPath_NotNullDictionary()
        {
            // Assert
            Assert.IsNotNull(styler.Dictionary);
            var expected =
                @" █████╗  
██╔══██╗ 
███████║ 
██╔══██║ 
██║  ██║ 
╚═╝  ╚═╝ ";
            Assert.AreEqual(expected, styler.Dictionary['a']);
        }

        [TestMethod]
        [DataRow("../../../resources/fonts/ANSI_Shadow/")]
        public void Constructor_WithFontPath_ValidDictionary(string path)
        {
            // Act
            var custom = new TextStyler(path);

            // Assert
            var expected =
                @" █████╗  
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
        public void Constructor_WithFontPathAndDefault_ValidDictionary(string path)
        {
            // Arrange
            var stylerCustom = new TextStyler(path);

            // Assert
            Assert.AreEqual(styler.Dictionary['a'], stylerCustom.Dictionary['a']);
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyFileException))]
        [DataRow("../../../resources/fonts/Throw_Error/")]
        public void Constructor_EmptyFileExceptionThrown(string path)
        {
            // Act
            TextStyler emptyStyler = new(path); // Exception should be thrown here
            emptyStyler.StyleTextToString("Hello World!");
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        [DataRow("invalid/path")]
        public void Constructor_InvalidFontPath_ExceptionThrown(string path)
        {
            // Act
            new TextStyler(path);
        }
        #endregion

        #region StyleTextToString
        [TestMethod]
        [DataRow("Hello World")]
        public void StyleTextToString_NotNull(string value)
        {
            // Act
            string styledText = styler.StyleTextToString(value);

            // Assert
            Assert.IsNotNull(styledText);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedCharException))]
        public void StyleTextToString_UnsupportedCharExceptionThrown()
        {
            // Assert
            styler.StyleTextToString("Hello World! +=è$%&/()=?^*[]{}@#|");
        }
        #endregion

        #region StyleTextToStringArray
        [TestMethod]
        [DataRow("Hello World")]
        public void StyleTextToStringArray_NotNull(string value)
        {
            // Act
            string[] styledText = styler.StyleTextToStringArray(value);

            // Assert
            Assert.IsNotNull(styledText);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedCharException))]
        public void StyleTextToStringArray_UnsupportedCharExceptionThrown()
        {
            // Assert
            styler.StyleTextToStringArray("Hello World! +=è$%&/()=?^*[]{}@#|");
        }
        #endregion

        #region General
        [TestMethod]
        public void ToString_NotNull()
        {
            // Act
            string result = styler.ToString();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Equals_ValidComparisons()
        {
            // Assert
            Assert.IsTrue(styler.Equals(styler));
            Assert.IsFalse(styler.Equals(null));
            Assert.IsFalse(styler.Equals(new TextStyler()));
        }

        [TestMethod]
        public void SetStyler_FontPathSet_StyleTextCorrect()
        {
            // Arrange
            Core.SetStyler("../../../resources/fonts/ANSI_Shadow/");

            // Act
            var result1 = styler.StyleTextToStringArray("a");
            var result2 = Core.StyleText("a");

            // Assert
            Assert.AreEqual(result1[0], result2[0]);
        }

        [TestMethod]
        public void GetRandomColor_ValidColorReturned()
        {
            // Arrange & Act
            var color = Core.GetRandomColor();

            // Assert
            Assert.IsTrue(Enum.IsDefined(typeof(ConsoleColor), color));
        }

        [TestMethod]
        public void RestoreColorPanel_ColorPanelRestored()
        {
            // Arrange
            var color = Core.GetColorPanel;

            // Act
            Core.RestoreColorPanel();

            // Assert
            Assert.AreNotEqual(color, Core.GetColorPanel);
        }

        [TestMethod]
        public void Constructor_FileNotFoundExceptionThrown_WhenStreamIsNull()
        {
            // Arrange
            var mockAssembly = new Mock<Assembly>();
            string resourceName = "nonexistentResource";
            mockAssembly
                .Setup(a => a.GetManifestResourceStream(It.IsAny<string>()))
                .Returns(default(Stream));

            // Act & Assert
            Assert.ThrowsException<FileNotFoundException>(
                () => new TextStyler(resourceName, mockAssembly.Object)
            );
        }
        #endregion
    }
}
