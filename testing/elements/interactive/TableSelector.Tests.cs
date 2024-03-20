/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestTableSelector
{
    #region Cleanup
    [TestCleanup]
    public void Cleanup()
    {
        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion

    #region Properties
    [TestMethod]
    [TestCategory("TableSelector")]
    [DataRow(Placement.TopRight)]
    [DataRow(Placement.TopLeft)]
    [DataRow(Placement.TopCenter)]
    public void Placement_Getter(Placement placement)
    {
        // Arrange
        var tableSelector = new TableSelector(
            default,
            default,
            default,
            default,
            default,
            default,
            placement
        );

        // Act
        var actualPlacement = tableSelector.Placement;

        // Assert
        Assert.AreEqual(placement, actualPlacement);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void Line_Getter()
    {
        // Arrange
        var tableSelector = new TableSelector(
            default,
            default,
            default,
            default,
            default,
            default,
            default
        );

        // Act
        var actualLine = tableSelector.Line;

        // Assert
        Assert.AreEqual(0, actualLine);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void Line_Getter_NoInput()
    {
        // Arrange
        var tableSelector = new TableSelector(
            default,
            default,
            default,
            default,
            default,
            default,
            default
        );

        // Act
        var actualLine = tableSelector.Line;

        // Assert
        Assert.AreEqual(0, actualLine);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void Height_Getter()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "nationality", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };
        List<string> player4 = new() { "04", "Rafael", "Nadal", "Spain", "23" };
        List<string> player5 = new() { "05", "Andy", "Murray", "England", "3" };
        List<string> player6 = new() { "06", "Daniil", "Medvedev", "Russia", "1" };
        List<string> player7 = new() { "07", "Stan", "Wawrinka", "Switzerland", "2" };
        List<List<string>> playersData =
            new() { player1, player2, player3, player4, player5, player6, player7 };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            playersData
        );

        // Act
        var actualHeight = tableSelector.Height;

        // Assert
        Assert.AreEqual(13, actualHeight);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void Height_Getter_NullArray()
    {
        // Arrange
        var tableSelector = new TableSelector(
            default,
            default,
            default,
            default,
            default,
            default,
            default
        );

        // Act
        var actualHeight = tableSelector.Height;

        // Assert
        Assert.AreEqual(0, actualHeight);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void Width_Getter()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "nationality", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };
        List<string> player4 = new() { "04", "Rafael", "Nadal", "Spain", "23" };
        List<string> player5 = new() { "05", "Andy", "Murray", "England", "3" };
        List<string> player6 = new() { "06", "Daniil", "Medvedev", "Russia", "1" };
        List<string> player7 = new() { "07", "Stan", "Wawrinka", "Switzerland", "2" };
        List<List<string>> playersData =
            new() { player1, player2, player3, player4, player5, player6, player7 };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            playersData
        );

        // Act
        var actualWidth = tableSelector.Width;

        // Assert
        Assert.AreEqual(53, actualWidth);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void Width_Getter_NullArray()
    {
        // Arrange
        var tableSelector = new TableSelector(
            default,
            default,
            default,
            default,
            default,
            default,
            default
        );

        // Act
        var actualWidth = tableSelector.Width;

        // Assert
        Assert.AreEqual(0, actualWidth);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void Title_Getter()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "nationality", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };
        List<string> player4 = new() { "04", "Rafael", "Nadal", "Spain", "23" };
        List<string> player5 = new() { "05", "Andy", "Murray", "England", "3" };
        List<string> player6 = new() { "06", "Daniil", "Medvedev", "Russia", "1" };
        List<string> player7 = new() { "07", "Stan", "Wawrinka", "Switzerland", "2" };
        List<List<string>> playersData =
            new() { player1, player2, player3, player4, player5, player6, player7 };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            playersData
        );

        // Act
        var actualTitle = tableSelector.Title;

        // Assert
        Assert.AreEqual("Great tennis players", actualTitle);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void Title_Getter_NullArray()
    {
        // Arrange
        var tableSelector = new TableSelector(
            default,
            default,
            default,
            default,
            default,
            default,
            default
        );

        // Act
        var actualTitle = tableSelector.Title;

        // Assert
        Assert.AreEqual(string.Empty, actualTitle);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    [DataRow(true)]
    [DataRow(false)]
    public void ExcludeHeader_Getter(bool exclude)
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "nationality", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>> { player1, player2, player3 },
            exclude
        );

        // Act
        var actualExcludeHeader = tableSelector.ExcludeHeader;

        // Assert
        Assert.AreEqual(exclude, actualExcludeHeader);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    [DataRow(true)]
    [DataRow(false)]
    public void ExcludeFooter_Getter(bool exclude)
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "nationality", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>> { player1, player2, player3 },
            default,
            exclude
        );

        // Act
        var actualExcludeFooter = tableSelector.ExcludeFooter;

        // Assert
        Assert.AreEqual(exclude, actualExcludeFooter);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void RoundedCorners_Getter()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "nationality", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act
        var actualRoundedCorners = tableSelector.RoundedCorners;

        // Assert
        Assert.AreEqual(false, actualRoundedCorners);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void RoundedCorners_Getter_RoundedCorners()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "nationality", "slams" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>>()
        );

        // Act
        var actualRoundedCorners = tableSelector.RoundedCorners;

        // Assert
        Assert.AreEqual(false, actualRoundedCorners);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void RoundedCorners_Getter_NullArray()
    {
        // Arrange
        var tableSelector = new TableSelector(
            default,
            default,
            default,
            default,
            default,
            default,
            default
        );

        // Act
        var actualRoundedCorners = tableSelector.RoundedCorners;

        // Assert
        Assert.AreEqual(false, actualRoundedCorners);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void GetCorners_Getter()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "nationality", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act
        var actualCorners = tableSelector.GetCorners;

        // Assert
        Assert.AreEqual("┌┐└┘", actualCorners);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void GetCorners_Getter_False()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "nationality", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act
        tableSelector.SetRoundedCorners(false);
        var actualCorners = tableSelector.GetCorners;

        // Assert
        Assert.AreEqual("┌┐└┘", actualCorners);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void FooterText_Getter()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "nationality", "slams" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>>(),
            default,
            default,
            "This is the footer"
        );

        // Act
        var actualFooterText = tableSelector.FooterText;

        // Assert
        Assert.AreEqual("This is the footer", actualFooterText);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void FooterText_Getter_NullArray()
    {
        // Arrange
        var tableSelector = new TableSelector(
            default,
            default,
            default,
            default,
            default,
            default,
            default
        );

        // Act
        var actualFooterText = tableSelector.FooterText;

        // Assert
        Assert.AreEqual("New", actualFooterText);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void GetRawHeaders_Getter()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "nationality", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act
        var actualRawHeaders = tableSelector.GetRawHeaders;

        // Assert
        Assert.AreEqual(playersHeaders, actualRawHeaders);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void GetRawHeaders_Getter_NullArray()
    {
        // Arrange
        var tableSelector = new TableSelector(
            default,
            default,
            default,
            default,
            default,
            default,
            default
        );

        // Act
        var actualRawHeaders = tableSelector.GetRawHeaders;

        // Assert
        Assert.AreEqual(default, actualRawHeaders);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void GetRawLines_Getter()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "nationality", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act
        var actualRawLines = tableSelector.GetRawLines;

        // Assert
        Assert.AreEqual(3, actualRawLines?.Count);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void Count_Getter()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "nationality", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act
        var actualCount = tableSelector.Count;

        // Assert
        Assert.AreEqual(3, actualCount);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void Count_Getter_NullArray()
    {
        // Arrange
        var tableSelector = new TableSelector(
            default,
            default,
            default,
            default,
            default,
            default,
            default
        );

        // Act
        var actualCount = tableSelector.Count;

        // Assert
        Assert.AreEqual(0, actualCount);
    }
    #endregion

    #region Check Methods
    [TestMethod]
    [TestCategory("TableSelector")]
    public void CompatibilityCheck_HeadersNotNullLinesNull()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            default
        );

        // Assert
        Assert.IsNull(tableSelector.GetRawLines);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void CheckRawLines_HeadersNullLinesNotNull_NumberNonConsistent()
    {
        // Arrange
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer" };

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() =>
        {
            var tableSelector = new TableSelector(
                "Great tennis players",
                default,
                new List<List<string>> { player1, player2, player3 }
            );
        });
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void CheckRawLines_HeadersNullLinesNotNull_NumberConsistent()
    {
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            null,
            null,
            new List<List<string>> { player1, player2, player3 }
        );

        // Assert
        Assert.AreEqual(3, tableSelector.Count);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void CheckRawHeadersAndLines_HeadersNotNullLinesNotNull_NumberNonConsistent()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer" };

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() =>
        {
            var tableSelector = new TableSelector(
                "Great tennis players",
                playersHeaders,
                new List<List<string>> { player1, player2, player3 }
            );
        });
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void CheckRawHeadersAndLines_HeadersNotNullLinesNotNull_NumberConsistent()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Assert
        Assert.AreEqual(3, tableSelector.Count);
    }
    #endregion

    #region Build Methods
    [TestMethod]
    [TestCategory("TableSelector")]
    public void BuildHeadersAndLines_HeadersNotNullLinesNotNull()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act
        var array = tableSelector.DisplayArray;

        // Assert
        Assert.IsNotNull(array);
    }
    #endregion

    #region Manipulation Methods
    [TestMethod]
    [TestCategory("TableSelector")]
    public void AddHeaders_HeadersUpdated()
    {
        // Arrange
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            default,
            default,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        tableSelector.AddHeaders(playersHeaders);
        var actualHeaders = tableSelector.GetRawHeaders;

        // Assert
        Assert.AreEqual(5, actualHeaders?.Count);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void AddHeaders_HeadersNotUpdated()
    {
        // Arrange
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            default,
            default,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act & Assert
        List<string> playersHeaders = new() { "id", "first name", "last name", "national" };
        Assert.ThrowsException<ArgumentException>(() =>
        {
            tableSelector.AddHeaders(playersHeaders);
        });
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void UpdateHeaders_HeadersUpdated()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            default,
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act
        List<string> playersHeaders2 =
            new() { "id", "last name", "first name", "nationality", "slams" };
        tableSelector.UpdateHeaders(playersHeaders2);
        var actualHeaders = tableSelector.GetRawHeaders;

        // Assert
        Assert.AreEqual("last name", actualHeaders?[1]);
        Assert.AreEqual("first name", actualHeaders?[2]);
        Assert.AreEqual("nationality", actualHeaders?[3]);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void AddTitle_TitleUpdated()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            default,
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act
        tableSelector.AddTitle("Great tennis players");
        var actualTitle = tableSelector.Title;

        // Assert
        Assert.AreEqual("Great tennis players", actualTitle);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void UpdateTitle_TitleUpdated()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act
        tableSelector.UpdateTitle("Great tennis players updated");
        var actualTitle = tableSelector.Title;

        // Assert
        Assert.AreEqual("Great tennis players updated", actualTitle);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void GetLine_CorrectIndex()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            default,
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act
        var line = tableSelector.GetLine(1);

        // Assert
        Assert.AreEqual(player2, line);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    [DataRow(-1)]
    [DataRow(8)]
    [DataRow(50)]
    public void GetLine_WrongIndex(int index)
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            default,
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act & Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            var line = tableSelector.GetLine(index);
        });
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void GetColumnData_CorrectIndex()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };
        List<List<string>> playersData = new() { player1, player2, player3 };

        var tableSelector = new TableSelector(default, playersHeaders, playersData);

        // Act
        var columnData = tableSelector.GetColumnData(2);

        // Assert
        Assert.AreEqual("Djokovic", columnData?[0]);
        Assert.AreEqual("Alkaraz", columnData?[1]);
        Assert.AreEqual("Federer", columnData?[2]);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    [DataRow(-1)]
    [DataRow(5)]
    [DataRow(50)]
    public void GetColumnData_WrongIndex(int index)
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };
        List<List<string>> playersData = new() { player1, player2, player3 };

        var tableSelector = new TableSelector(default, playersHeaders, playersData);

        // Act & Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            var columnData = tableSelector.GetColumnData(index);
        });
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void GetColumnData_NullLines()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };

        var tableSelector = new TableSelector(default, playersHeaders, default);

        // Act & Assert
        Assert.IsNull(tableSelector.GetColumnData(2));
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void GetColumnData_RawHeadersNull()
    {
        // Arrange
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };
        List<List<string>> playersData = new() { player1, player2, player3 };

        var tableSelector = new TableSelector(default, default, playersData);

        // Act & Assert
        Assert.IsNull(tableSelector.GetColumnData("first name"));
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void GetColumnData_RawLinesNull()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };

        var tableSelector = new TableSelector(default, playersHeaders, default);

        // Act & Assert
        Assert.IsNull(tableSelector.GetColumnData("first name"));
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void GetColumnData_DoesNotContain()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };
        List<List<string>> playersData = new() { player1, player2, player3 };

        var tableSelector = new TableSelector(default, playersHeaders, playersData);

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() =>
        {
            var columnData = tableSelector.GetColumnData("age");
        });
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void GetColumnData_CorrectHeader()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };
        List<List<string>> playersData = new() { player1, player2, player3 };

        var tableSelector = new TableSelector(default, playersHeaders, playersData);

        // Act
        var columnData = tableSelector.GetColumnData("last name");

        // Assert
        Assert.AreEqual("Djokovic", columnData?[0]);
        Assert.AreEqual("Alkaraz", columnData?[1]);
        Assert.AreEqual("Federer", columnData?[2]);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void AddLine_LineAdded()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };

        var tableSelector = new TableSelector(
            default,
            playersHeaders,
            new List<List<string>>()
        );

        // Act
        List<string> player4 = new() { "04", "Rafael", "Nadal", "Spain", "23" };
        tableSelector.AddLine(player4);
        var actualLines = tableSelector.GetRawLines;

        // Assert
        Assert.AreEqual(1, actualLines?.Count);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void AddLine_LineNotAdded()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };

        var tableSelector = new TableSelector(
            default,
            playersHeaders,
            new List<List<string>>()
        );

        // Act & Assert
        List<string> player4 = new() { "04", "Rafael", "Nadal", "Spain" };
        Assert.ThrowsException<ArgumentException>(() =>
        {
            tableSelector.AddLine(player4);
        });
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void AddLines_ColumnsNotConsistentWithLines()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };
        List<List<string>> playersData = new() { player1, player2, player3 };

        var tableSelector = new TableSelector(default, playersHeaders, playersData);

        // Act & Assert
        List<string> player4 = new() { "04", "Rafael", "Nadal", "Spain" };
        Assert.ThrowsException<ArgumentException>(() =>
        {
            tableSelector.AddLine(player4);
        });
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void RemoveLine_LineRemoved()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player4 = new() { "04", "Rafael", "Nadal", "Spain", "23" };

        var tableSelector = new TableSelector(
            default,
            playersHeaders,
            new List<List<string>> { player4 }
        );

        // Act
        tableSelector.RemoveLine(0);
        var actualLines = tableSelector.GetRawLines;

        // Assert
        Assert.AreEqual(0, actualLines?.Count);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void RemoveLine_LineNotRemoved()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };

        var tableSelector = new TableSelector(
            default,
            playersHeaders,
            new List<List<string>>()
        );

        // Act & Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            tableSelector.RemoveLine(0);
        });
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    [DataRow(-1)]
    [DataRow(5)]
    public void RemoveLine_WrongIndex(int index)
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };
        List<List<string>> playersData = new() { player1, player2, player3 };

        var tableSelector = new TableSelector(default, playersHeaders, playersData);

        // Act & Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            tableSelector.RemoveLine(index);
        });
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void UpdateLine_LineUpdated()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player4 = new() { "04", "Rafael", "Nadal", "Spain", "23" };

        var tableSelector = new TableSelector(
            default,
            playersHeaders,
            new List<List<string>> { player4 }
        );

        // Act
        List<string> player5 = new() { "05", "Stefanos", "Tsitsipas", "Greece", "0" };
        tableSelector.UpdateLine(0, player5);
        var actualLines = tableSelector.GetRawLines;

        // Assert
        Assert.AreEqual("05", actualLines?[0][0]);
        Assert.AreEqual("Stefanos", actualLines?[0][1]);
        Assert.AreEqual("Tsitsipas", actualLines?[0][2]);
        Assert.AreEqual("Greece", actualLines?[0][3]);
        Assert.AreEqual("0", actualLines?[0][4]);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void UpdateLine_LineNotUpdated()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };

        var tableSelector = new TableSelector(
            default,
            playersHeaders,
            new List<List<string>>()
        );

        // Act & Assert
        List<string> player5 = new() { "05", "Stefanos", "Tsitsipas", "Greece", "0" };
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            tableSelector.UpdateLine(0, player5);
        });
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    [DataRow(-1)]
    [DataRow(5)]
    public void UpdateLine_WrongIndex(int index)
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player4 = new() { "04", "Rafael", "Nadal", "Spain", "23" };

        var tableSelector = new TableSelector(
            default,
            playersHeaders,
            new List<List<string>> { player4 }
        );

        // Act & Assert
        List<string> player5 = new() { "05", "Stefanos", "Tsitsipas", "Greece", "0" };
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            tableSelector.UpdateLine(index, player5);
        });
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void UpdateLine_ColumnsNotConsistentWithLines()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player4 = new() { "04", "Rafael", "Nadal", "Spain", "23" };

        var tableSelector = new TableSelector(
            default,
            playersHeaders,
            new List<List<string>> { player4 }
        );

        // Act & Assert
        List<string> player5 = new() { "05", "Stefanos", "Tsitsipas", "Greece" };
        Assert.ThrowsException<ArgumentException>(() =>
        {
            tableSelector.UpdateLine(0, player5);
        });
    }

    #endregion

    #region Reset Methods

    [TestMethod]
    [TestCategory("TableSelector")]
    public void ClearHeaders_HeadersErased()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            default,
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act
        tableSelector.ClearHeaders();
        var actualHeaders = tableSelector.GetRawHeaders;

        // Assert
        Assert.IsNull(actualHeaders);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void ClearLines_LinesErased()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act
        tableSelector.ClearLines();
        var actualLines = tableSelector.GetRawLines;

        // Assert
        Assert.IsNull(actualLines);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void Reset_ElementsErased()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act
        tableSelector.Reset();
        var actualTitle = tableSelector.Title;
        var actualHeaders = tableSelector.GetRawHeaders;
        var actualLines = tableSelector.GetRawLines;

        // Assert
        Assert.AreEqual(string.Empty, actualTitle);
        Assert.AreEqual(0, actualHeaders?.Count);
        Assert.AreEqual(0, actualLines?.Count);
        Assert.IsNull(tableSelector.DisplayArray);
    }
    #endregion

    #region UpdatePlacement
    [TestMethod]
    [TestCategory("TableSelector")]
    [DataRow(Placement.TopRight)]
    [DataRow(Placement.TopLeft)]
    public void UpdatePlacement(Placement placement)
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act
        tableSelector.UpdatePlacement(placement);
        var actualPlacement = tableSelector.Placement;

        // Assert
        Assert.AreEqual(placement, actualPlacement);
    }
    #endregion

    #region UpdateFooter
    [TestMethod]
    [TestCategory("TableSelector")]
    public void UpdateFooter_FooterUpdated()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>>()
        );

        // Act
        tableSelector.UpdateFooterText("This is the footer");
        var actualFooter = tableSelector.FooterText;

        // Assert
        Assert.AreEqual("This is the footer", actualFooter);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void UpdateFooter_FooterUpdatedAndBuild()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act
        tableSelector.UpdateFooterText("This is the footer");
        var actualFooter = tableSelector.FooterText;

        // Assert
        Assert.AreEqual("This is the footer", actualFooter);
    }
    #endregion

    #region SetExcludeHeader
    [TestMethod]
    [TestCategory("TableSelector")]
    public void SetExcludeHeader_ExcludeHeaderUpdated()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>>()
        );

        // Act
        tableSelector.SetExcludeHeader(true);
        var actualExcludeHeader = tableSelector.ExcludeHeader;

        // Assert
        Assert.IsTrue(actualExcludeHeader);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void SetExcludeHeader_ExcludeHeaderUpdatedAndBuild()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act
        tableSelector.SetExcludeHeader(true);
        var actualExcludeHeader = tableSelector.ExcludeHeader;

        // Assert
        Assert.IsTrue(actualExcludeHeader);
    }
    #endregion

    #region SetExcludeFooter
    [TestMethod]
    [TestCategory("TableSelector")]
    public void SetExcludeFooter_ExcludeFooterUpdated()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>>()
        );

        // Act
        tableSelector.SetExcludeFooter(true);
        var actualExcludeFooter = tableSelector.ExcludeFooter;

        // Assert
        Assert.IsTrue(actualExcludeFooter);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void SetExcludeFooter_ExcludeFooterUpdatedAndBuild()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "national", "slams" };
        List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
        List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
        List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };

        var tableSelector = new TableSelector(
            "Great tennis players",
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act
        tableSelector.SetExcludeFooter(true);
        var actualExcludeFooter = tableSelector.ExcludeFooter;

        // Assert
        Assert.IsTrue(actualExcludeFooter);
    }
    #endregion

}
