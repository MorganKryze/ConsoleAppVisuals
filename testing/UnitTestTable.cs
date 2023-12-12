/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing
{
    [TestClass]
    public class UnitTestTable
    {
        [TestMethod]
        public void TestNullBody()
        {
            Assert.ThrowsException<NullReferenceException>(() =>
            {
                Table<string> table = new (new List<string>(), null);
            });
        }

        [TestMethod]
        public void TestNullHeaderWrongBody()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Table<string> table = new (null, new List<List<string>>() {new List<string>() {"1", "2", "3"}, new List<string>() {"4", "5"}});
            });
        }

        [TestMethod]
        public void TestWrongHeaderWrongBody()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Table<string> table = new (new List<string>() {"header1", "header2", "header3"}, new List<List<string>>() {new List<string>() {"1", "2", "3"}, new List<string>() {"4", "5"}});
            });
        }

        [TestMethod]
        public void TestGetLine()
        {
            Table<string> table = new (new List<string>() {"header1", "header2", "header3"}, new List<List<string>>() {new List<string>() {"1", "2", "3"}, new List<string>() {"4", "5", "6"}});
            Assert.AreEqual("1", table.GetLine(0)[0]);
        }

        [TestMethod]
        public void TestGetWrongLine()
        {
            Table<string> table = new (new List<string>() {"header1", "header2", "header3"}, new List<List<string>>() {new List<string>() {"1", "2", "3"}, new List<string>() {"4", "5", "6"}});
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                table.GetLine(2);
            });
        }

        [TestMethod]
        public void TestAddLineOnEmptyBody()
        {
            Table<string> table = new (new List<string>() {"header1", "header2", "header3"}, new List<List<string>>());
            table.AddLine(new List<string>() {"1", "2", "3"});
            Assert.AreEqual(1, table.Count);
        }

        [TestMethod]
        public void TestAddWrongLine()
        {
            Table<string> table = new (new List<string>() {"header1", "header2", "header3"}, new List<List<string>>());
            table.AddLine(new List<string>() {"1", "2", "3"});
            Assert.ThrowsException<ArgumentException>(() =>
            {
                table.AddLine(new List<string>() {"1", "2"});
            });
        }

        [TestMethod]
        public void TestRemoveLine()
        {
            Table<string> table = new (new List<string>() {"header1", "header2", "header3"}, new List<List<string>>() {new List<string>() {"1", "2", "3"}, new List<string>() {"4", "5", "6"}});
            table.RemoveLine(0);
            Assert.AreEqual(1, table.Count);
        }
        
        [TestMethod]
        public void TestRemoveWrongLine()
        {
            Table<string> table = new (new List<string>() {"header1", "header2", "header3"}, new List<List<string>>() {new List<string>() {"1", "2", "3"}, new List<string>() {"4", "5", "6"}});
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                table.RemoveLine(2);
            });
        }

        [TestMethod]
        public void TestUpdateLine()
        {
            Table<string> table = new (new List<string>() {"header1", "header2", "header3"}, new List<List<string>>() {new List<string>() {"1", "2", "3"}, new List<string>() {"4", "5", "6"}});
            table.UpdateLine(0, new List<string>() {"7", "8", "9"});
            Assert.AreEqual("7", table.GetLine(0)[0]);
        }

        [TestMethod]
        public void TestUpdateWrongLine()
        {
            Table<string> table = new (new List<string>() {"header1", "header2", "header3"}, new List<List<string>>() {new List<string>() {"1", "2", "3"}, new List<string>() {"4", "5", "6"}});
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                table.UpdateLine(2, new List<string>() {"7", "8", "9"});
            });
        }

        [TestMethod]
        public void TestUpdateLineWrongIndex()
        {
            Table<string> table = new (new List<string>() {"header1", "header2", "header3"}, new List<List<string>>() {new List<string>() {"1", "2", "3"}, new List<string>() {"4", "5", "6"}});
            Assert.ThrowsException<ArgumentException>(() =>
            {
                table.UpdateLine(0, new List<string>() {"7", "8"});
            });
        }
    }
}