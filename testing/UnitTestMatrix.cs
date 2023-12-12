/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing
{
    [TestClass]
    public class UnitTestMatrix
    {
        [TestMethod]
        public void TestNoLines()
        {
            Matrix<string> matrix = new Matrix<string>();
            Assert.AreEqual(0, matrix.Count);
        }

        [TestMethod]
        public void TestWrongLinesLengths()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Matrix<string> matrix = new (new List<List<string?>>() { new () { "1", "2", "3" }, new () { "4", "5" } });
            });
        }

        [TestMethod]
        public void TestGetElement()
        {
            Matrix<string> matrix = new (new List<List<string?>>() { new () { "1", "2", "3" }, new () { "4", "5", "6" } });
            Assert.AreEqual("1", matrix.GetElement(new Position(0, 0)));
        }

        [TestMethod]
        public void TestGetWrongElement()
        {
            Matrix<string> matrix = new (new List<List<string?>>() { new () { "1", "2", "3" }, new () { "4", "5", "6" } });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                matrix.GetElement(new Position(2, 0));
            });
        }

        [TestMethod]
        public void TestUpdateElement()
        {
            Matrix<string> matrix = new (new List<List<string?>>() { new () { "1", "2", "3" }, new () { "4", "5", "6" } });
            matrix.UpdateElement(new Position(0, 0), "7");
            Assert.AreEqual("7", matrix.GetElement(new Position(0, 0)));
        }

        [TestMethod]
        public void TestUpdateWrongElement()
        {
            Matrix<string> matrix = new (new List<List<string?>>() { new () { "1", "2", "3" }, new () { "4", "5", "6" } });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                matrix.UpdateElement(new Position(2, 0), "7");
            });
        }

        [TestMethod]
        public void TestUpdateElementWrongIndex()
        {
            Matrix<string> matrix = new (new List<List<string?>>() { new () { "1", "2", "3" }, new () { "4", "5", "6" } });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {       
                matrix.UpdateElement(new Position(0, 3), "7");
            });
        }
    }
}