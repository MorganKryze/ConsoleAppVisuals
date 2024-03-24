/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestTableView
{
    #region Cleanup
    [TestCleanup]
    public void Cleanup()
    {
        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion

    #region ConstructorTests
    [TestMethod]
    public void Constructor_CreatesTableViewWithHeadersAndBody()
    {
        // Arrange
        var table = new TableView(
            "title",
            new List<string>() { "header1", "header2", "header3" },
            new List<List<string>>()
            {
                new() { "1", "2", "3" },
                new() { "4", "5", "6" }
            }
        );

        // Act
        // No additional action needed

        // Assert
        Assert.AreEqual(2, table.Count);
    }

    [TestMethod]
    public void Constructor_CreatesTableViewWithoutHeaders()
    {
        // Arrange
        var table = new TableView(
            null,
            null,
            new List<List<string>>()
            {
                new() { "1", "2", "3" },
                new() { "4", "5", "6" }
            }
        );

        // Act
        // No additional action needed

        // Assert
        Assert.AreEqual(2, table.Count);
    }

    [TestMethod]
    public void Constructor_ThrowsExceptionOnInconsistentHeadersAndBody()
    {
        // Assert
        Assert.ThrowsException<ArgumentException>(() =>
        {
            // Act
            _ = new TableView(
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
    public void Constructor_ThrowsExceptionOnNullHeadersAndInconsistentBody()
    {
        // Assert
        Assert.ThrowsException<ArgumentException>(() =>
        {
            // Act
            _ = new TableView(
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
    public void Constructor_CreatesTableViewWithNullParameters()
    {
        // Arrange
        var table = new TableView(null, null, null);

        // Act
        // No additional action needed

        // Assert
        Assert.IsNull(table.GetRawLines);
        Assert.IsNull(table.GetRawHeaders);
    }
    #endregion

    #region GetLineTests
    [TestMethod]
    public void GetLine_ReturnsCorrectLine()
    {
        // Arrange
        TableView table =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );

        // Act
        var line = table.GetLine(0);

        // Assert
        Assert.AreEqual("1", line[0]);
    }

    [TestMethod]
    public void GetLine_ThrowsExceptionOnWrongIndex()
    {
        // Arrange
        TableView table =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );

        // Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            // Act
            table.GetLine(2);
        });
    }
    #endregion

    #region PropertiesWithNullEntryTests
    [TestMethod]
    public void PropertiesWithNullEntry_ReturnsZeroCountHeightAndWidth()
    {
        // Arrange
        TableView table = new(null, null, null);

        // Act
        // No additional action needed

        // Assert
        Assert.AreEqual(0, table.Count);
        Assert.AreEqual(0, table.Height);
        Assert.AreEqual(0, table.Width);
    }
    #endregion

    #region TitleTests
    [TestMethod]
    public void AddTitle_AddsTitleCorrectly()
    {
        // Arrange
        TableView table1 =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
            );
        TableView table2 =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
            );

        // Act
        table1.AddTitle("title");

        // Assert
        Assert.AreNotEqual(table1.Height, table2.Height);

        // Act
        table1.ClearTitle();
        table1.UpdateTitle("title");

        // Assert
        Assert.AreNotEqual(table1.Height, table2.Height);
    }
    #endregion

    #region HeadersTests
    [TestMethod]
    public void AddHeaders_AddsHeadersCorrectly()
    {
        // Arrange
        TableView table1 =
            new(
                null,
                null,
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );
        TableView table2 =
            new(
                null,
                null,
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );

        // Act
        table1.AddHeaders(new List<string>() { "header1", "header2", "header3" });

        // Assert
        Assert.AreNotEqual(table1.Height, table2.Height);

        // Act
        table1.ClearHeaders();
        table1.UpdateHeaders(new List<string>() { "header1", "header2", "header3" });

        // Assert
        Assert.AreNotEqual(table1.Height, table2.Height);
    }

    [TestMethod]
    public void AddHeaders_ThrowsExceptionOnInconsistentHeaders()
    {
        // Arrange
        TableView table =
            new(
                null,
                null,
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );

        // Assert
        Assert.ThrowsException<ArgumentException>(() =>
        {
            // Act
            table.AddHeaders(new List<string>() { "header1", "header2" });
        });
    }
    #endregion

    #region LineTests
    [TestMethod]
    public void AddLine_AddsLineOnEmptyBody()
    {
        // Arrange
        TableView table =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
            );

        // Act
        table.AddLine(new List<string>() { "1", "2", "3" });

        // Assert
        Assert.AreEqual(1, table.Count);
    }

    [TestMethod]
    public void AddLine_ThrowsExceptionOnWrongLine()
    {
        // Arrange
        TableView table =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
            );
        table.AddLine(new List<string>() { "1", "2", "3" });

        // Assert
        Assert.ThrowsException<ArgumentException>(() =>
        {
            // Act
            table.AddLine(new List<string>() { "1", "2" });
        });
    }

    [TestMethod]
    public void AddLine_ThrowsExceptionOnWrongLineWithHeaders()
    {
        // Arrange
        TableView table = new(null, new List<string>() { "header1", "header2", "header3" }, null);

        // Assert
        Assert.ThrowsException<ArgumentException>(() =>
        {
            // Act
            table.AddLine(new List<string>() { "1", "2" });
        });
    }

    [TestMethod]
    public void RemoveLine_RemovesLineCorrectly()
    {
        // Arrange
        TableView table =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );

        // Act
        table.RemoveLine(0);

        // Assert
        Assert.AreEqual(1, table.Count);
    }

    [TestMethod]
    public void RemoveLine_ThrowsExceptionOnWrongIndex()
    {
        // Arrange
        TableView table =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );

        // Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            // Act
            table.RemoveLine(2);
        });
    }

    [TestMethod]
    public void UpdateLine_UpdatesLineCorrectly()
    {
        // Arrange
        TableView table =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );

        // Act
        table.UpdateLine(0, new List<string>() { "7", "8", "9" });

        // Assert
        Assert.AreEqual("7", table.GetLine(0)[0]);
    }

    [TestMethod]
    public void UpdateLine_ThrowsExceptionOnWrongIndex()
    {
        // Arrange
        TableView table =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );

        // Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            // Act
            table.UpdateLine(2, new List<string>() { "7", "8", "9" });
        });
    }

    [TestMethod]
    public void UpdateLine_ThrowsExceptionOnWrongLineIndex()
    {
        // Arrange
        TableView table =
            new(
                null,
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );

        // Assert
        Assert.ThrowsException<ArgumentException>(() =>
        {
            // Act
            table.UpdateLine(0, new List<string>() { "7", "8" });
        });
    }
    #endregion


    #region GeneralTests
    [TestMethod]
    public void UpdatePlacement_UpdatesPlacementCorrectly()
    {
        // Arrange
        TableView table =
            new(
                "title",
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" }
                }
            );

        // Act
        table.UpdatePlacement(Placement.TopLeft);

        // Assert
        Assert.AreEqual(Placement.TopLeft, table.Placement);
    }

    [TestMethod]
    public void UpdateBorderType_UpdatesBorderTypeCorrectly()
    {
        // Arrange
        TableView table =
            new(
                "title",
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" }
                }
            );

        // Act
        table.UpdateBordersType(BordersType.SingleRound);

        // Assert
        Assert.AreEqual(BordersType.SingleRound, table.BordersType);
    }

    [TestMethod]
    public void ClearEverything_ClearsAllElements()
    {
        // Arrange
        TableView table1 =
            new(
                "title",
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" }
                }
            );
        TableView table2 =
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
    public void Clear_ResetsTable()
    {
        // Arrange
        TableView table =
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
    public void Render_AddsTableToWindowAndActivates()
    {
        // Arrange
        TableView table =
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
        Window.ActivateElement<TableView>(false);

        // Assert
        Assert.IsNotNull(table.GetRawHeaders);

        // Cleanup
        Window.RemoveElement(table);
    }
    #endregion

    #region GetColumnDataTests
    private readonly TableView _tableView =
        new(
            null,
            new List<string> { "Column1", "Column2", "Column3" },
            new List<List<string>>
            {
                new() { "1", "2", "3" },
                new() { "4", "5", "6" }
            }
        );

    [TestMethod]
    public void GetColumnData_WithValidIndex_ReturnsCorrectData()
    {
        // Act
        var result = _tableView.GetColumnData(1);

        // Assert
        CollectionAssert.AreEqual(new List<string> { "2", "5" }, result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void GetColumnData_WithInvalidIndex_ThrowsArgumentOutOfRangeException()
    {
        // Act
        _tableView.GetColumnData(-1);
        _tableView.GetColumnData(3);
    }

    [TestMethod]
    public void GetColumnData_WithValidHeader_ReturnsCorrectData()
    {
        // Act
        var result = _tableView.GetColumnData("Column2");

        // Assert
        CollectionAssert.AreEqual(new List<string> { "2", "5" }, result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void GetColumnData_WithInvalidHeader_ThrowsArgumentOutOfRangeException()
    {
        // Act
        _tableView.GetColumnData("InvalidHeader");
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void GetColumnData_WithNullHeaders_ThrowsInvalidOperationException()
    {
        // Arrange
        _tableView.ClearHeaders();

        // Act
        _tableView.GetColumnData("Column1");
    }

    [TestMethod]
    public void GetColumnData_WithNullLines_ReturnsNull()
    {
        // Arrange
        _tableView.ClearLines();

        // Act & Assert
        Assert.IsNull(_tableView.GetColumnData(0));
        Assert.IsNull(_tableView.GetColumnData("Column1"));
    }
    #endregion

    #region GetPLacement
    [TestMethod]
    public void GetPlacement_ReturnsCorrectPlacement()
    {
        // Arrange
        TableView table =
            new(
                "title",
                new List<string>() { "header1", "header2", "header3" },
                new List<List<string>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );

        // Act
        var placement = table.Placement;

        // Assert
        Assert.AreEqual(Placement.TopCenter, placement);
    }
    #endregion
}
