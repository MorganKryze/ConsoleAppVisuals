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
            var defaultLetterHeigth = 6;
            Core.SetTitle(title, margin);
            Assert.AreEqual(Core.TitleHeight, defaultLetterHeigth + 2 * margin);
        }
    }
}