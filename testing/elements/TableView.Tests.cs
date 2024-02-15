/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestTableView
{
    #region Constructor

    [TestMethod]
    public void Test_HappyPath()
    {
        var table = new TableView<string>(
            "title",
            new List<string>() { "header1", "header2", "header3" },
            new List<List<string>>()
            {
                new() { "1", "2", "3" },
                new() { "4", "5", "6" }
            }
        );
        Assert.AreEqual(2, table.Count);
    }

    [TestMethod]
    public void Test_HappyPath_WithoutHeaders()
    {
        var table = new TableView<string>(
            null,
            null,
            new List<List<string>>()
            {
                new() { "1", "2", "3" },
                new() { "4", "5", "6" }
            }
        );
        Assert.AreEqual(2, table.Count);
    }

    [TestMethod]
    public void Test_WrongHeaderWrongBody()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            _ = new TableView<string>(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5" }
                }
            );
        });
    }

    [TestMethod]
    public void Test_NullHeaderWrongBody()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            _ = new TableView<string>(
                null,
                null,
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5" }
                }
            );
        });
    }

    [TestMethod]
    public void Test_NullHeaderNullBody()
    {
        var table = new TableView<string>(null, null, null);
        Assert.IsNull(table.GetRawLines);
        Assert.IsNull(table.GetRawHeaders);
    }
    #endregion

    #region GetLine
    [TestMethod]
    public void TestGetLine()
    {
        TableView<string> table =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );
        Assert.AreEqual("1", table.GetLine(0)[0]);
    }

    [TestMethod]
    public void TestGetWrongLine()
    {
        TableView<string> table =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            table.GetLine(2);
        });
    }
    #endregion

    #region Properties with null entry
    [TestMethod]
    public void TestGetRawHeaders()
    {
        TableView<string> table = new(null, null, null);

        Assert.AreEqual(0, table.Count);
        Assert.AreEqual(0, table.Height);
        Assert.AreEqual(0, table.Width);
    }

    #endregion

    #region Title
    [TestMethod]
    public void Test_AddTitle()
    {
        TableView<string> table1 =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
            );
        TableView<string> table2 =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
            );
        table1.AddTitle("title");
        Assert.AreNotEqual(table1.Height, table2.Height);

        table1.ClearTitle();
        table1.UpdateTitle("title");

        Assert.AreNotEqual(table1.Height, table2.Height);
    }
    #endregion

    #region Headers
    [TestMethod]
    public void Test_AddHeaders()
    {
        TableView<string> table1 =
            new(
                null,
                null,
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );
        TableView<string> table2 =
            new(
                null,
                null,
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );
        table1.AddHeaders(new List<string>() { "header1", "header2", "header3" });
        Assert.AreNotEqual(table1.Height, table2.Height);

        table1.ClearHeaders();
        table1.UpdateHeaders(new List<string>() { "header1", "header2", "header3" });

        Assert.AreNotEqual(table1.Height, table2.Height);
    }

    [TestMethod]
    public void Test_AddHeaders_NotConsistent()
    {
        TableView<string> table =
            new(
                null,
                null,
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );
        Assert.ThrowsException<ArgumentException>(() =>
        {
            table.AddHeaders(new List<string>() { "header1", "header2" });
        });
    }
    #endregion

    #region Line
    [TestMethod]
    public void TestAddLineOnEmptyBody()
    {
        TableView<string> table =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
            );
        table.AddLine(new List<string>() { "1", "2", "3" });
        Assert.AreEqual(1, table.Count);
    }

    [TestMethod]
    public void Test_AddWrongLine()
    {
        TableView<string> table =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
            );
        table.AddLine(new List<string>() { "1", "2", "3" });
        Assert.ThrowsException<ArgumentException>(() =>
        {
            table.AddLine(new List<string>() { "1", "2" });
        });
    }

    [TestMethod]
    public void Test_AddWrongLineWithHeaders()
    {
        TableView<string> table =
            new(null, new List<string>() { "header1", "header2", "header3" }, null);
        Assert.ThrowsException<ArgumentException>(() =>
        {
            table.AddLine(new List<string>() { "1", "2" });
        });
    }

    [TestMethod]
    public void TestRemoveLine()
    {
        TableView<string> table =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );
        table.RemoveLine(0);
        Assert.AreEqual(1, table.Count);
    }

    [TestMethod]
    public void TestRemoveWrongLine()
    {
        TableView<string> table =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            table.RemoveLine(2);
        });
    }

    [TestMethod]
    public void TestUpdateLine()
    {
        TableView<string> table =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );
        table.UpdateLine(0, new List<string>() { "7", "8", "9" });
        Assert.AreEqual("7", table.GetLine(0)[0]);
    }

    [TestMethod]
    public void TestUpdateWrongLine()
    {
        TableView<string> table =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            table.UpdateLine(2, new List<string>() { "7", "8", "9" });
        });
    }

    [TestMethod]
    public void TestUpdateLineWrongIndex()
    {
        TableView<string> table =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );
        Assert.ThrowsException<ArgumentException>(() =>
        {
            table.UpdateLine(0, new List<string>() { "7", "8" });
        });
    }
    #endregion

    #region General

    [TestMethod]
    public void Test_RoundedCorners()
    {
        // Arrange
        TableView<string> table1 =
            new(
                "title",
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" }
                }
            );
        TableView<string> table2 =
            new(
                "title",
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" }
                }
            );

        // Act
        table1.SetRoundedCorners(true);
        table2.SetRoundedCorners(false);

        // Assert
        Assert.AreNotEqual(table1.GetRawHeaders, table2.GetRawHeaders);
        Assert.AreNotEqual(table1.GetRawLines, table2.GetRawLines);
    }

    [TestMethod]
    public void Test_ClearEverything()
    {
        // Arrange
        TableView<string> table1 =
            new(
                "title",
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" }
                }
            );
        TableView<string> table2 =
            new(
                "title",
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" }
                }
            );

        // Act
        table1.ClearTitle();
        table1.ClearHeaders();
        table1.ClearLines();
        table2.ClearTitle();
        table2.ClearHeaders();
        table2.ClearLines();

        // Assert
        Assert.AreEqual(table1.Count, table2.Count);
        Assert.AreEqual(table1.GetRawHeaders, table2.GetRawHeaders);
        Assert.AreEqual(table1.GetRawLines, table2.GetRawLines);
    }

    [TestMethod]
    public void Test_Clear()
    {
        // Arrange
        TableView<string> table =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" }
                }
            );

        // Act
        table.Reset();

        // Assert
        Assert.AreEqual(0, table.Count);
    }

    [TestMethod]
    public void Test_Render()
    {
        // Arrange
        TableView<string> table =
            new(
                "title",
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );
        Window.AddElement(table);

        // Act
        Window.ActivateElement<TableView<string>>();

        // Assert
        Assert.IsNotNull(table.GetRawHeaders);

        // Cleanup
        Window.RemoveElement(table);
    }
    #endregion

    #region GetColumnData
    private readonly TableView<int> _tableView = new(
        null,
        new List<string> { "Column1", "Column2", "Column3" },
        new List<List<int>>
        {
            new List<int> { 1, 2, 3 },
            new List<int> { 4, 5, 6 }
        }
    );

    [TestMethod]
    public void GetColumnData_WithValidIndex_ReturnsCorrectData()
    {
        var result = _tableView.GetColumnData(1);
        CollectionAssert.AreEqual(new List<int> { 2, 5 }, result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void GetColumnData_WithInvalidIndex_ThrowsArgumentOutOfRangeException()
    {
        _tableView.GetColumnData(-1);
        _tableView.GetColumnData(3);
    }

    [TestMethod]
    public void GetColumnData_WithValidHeader_ReturnsCorrectData()
    {
        var result = _tableView.GetColumnData("Column2");
        CollectionAssert.AreEqual(new List<int> { 2, 5 }, result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void GetColumnData_WithInvalidHeader_ThrowsArgumentOutOfRangeException()
    {
        _tableView.GetColumnData("InvalidHeader");
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void GetColumnData_WithNullHeaders_ThrowsInvalidOperationException()
    {
        _tableView.ClearHeaders();
        _tableView.GetColumnData("Column1");
    }

    [TestMethod]
    public void GetColumnData_WithNullLines_ReturnsNull()
    {
        _tableView.ClearLines();
        Assert.IsNull(_tableView.GetColumnData(0));
        Assert.IsNull(_tableView.GetColumnData("Column1"));
    }
    #endregion
}
