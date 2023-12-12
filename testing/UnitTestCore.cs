/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing
{
    [TestClass]
    public class UnitTestCore
    {
        [TestMethod]
        [DataRow("Test Title", 2)]
        [DataRow("New Test", 4)]
        public void SetTitle_WithTitle_SetsTitleCorrectly(string title, int margin)
        {
            var defaultLetterHeight = 6;
            Core.SetTitle(title, margin);
            Assert.AreEqual(Core.TitleHeight, defaultLetterHeight + 2 * margin);
        }
    }
}