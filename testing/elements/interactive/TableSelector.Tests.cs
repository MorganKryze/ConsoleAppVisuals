/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

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
        var tableSelector = new TableSelector<int>(
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
        var tableSelector = new TableSelector<int>(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            0
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
        var tableSelector = new TableSelector<int>(
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

        var tableSelector = new TableSelector<string>(
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
        var tableSelector = new TableSelector<int>(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            0
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

        var tableSelector = new TableSelector<string>(
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
        var tableSelector = new TableSelector<int>(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            0
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

        var tableSelector = new TableSelector<string>(
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
        var tableSelector = new TableSelector<int>(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            0
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

        var tableSelector = new TableSelector<string>(
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

        var tableSelector = new TableSelector<string>(
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

        var tableSelector = new TableSelector<string>(
            "Great tennis players",
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act
        var actualRoundedCorners = tableSelector.RoundedCorners;

        // Assert
        Assert.AreEqual(true, actualRoundedCorners);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void RoundedCorners_Getter_RoundedCorners()
    {
        // Arrange
        List<string> playersHeaders =
            new() { "id", "first name", "last name", "nationality", "slams" };

        var tableSelector = new TableSelector<string>(
            "Great tennis players",
            playersHeaders,
            new List<List<string>>()
        );

        // Act
        var actualRoundedCorners = tableSelector.RoundedCorners;

        // Assert
        Assert.AreEqual(true, actualRoundedCorners);
    }

    [TestMethod]
    [TestCategory("TableSelector")]
    public void RoundedCorners_Getter_NullArray()
    {
        // Arrange
        var tableSelector = new TableSelector<int>(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            0
        );

        // Act
        var actualRoundedCorners = tableSelector.RoundedCorners;

        // Assert
        Assert.AreEqual(true, actualRoundedCorners);
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

        var tableSelector = new TableSelector<string>(
            "Great tennis players",
            playersHeaders,
            new List<List<string>> { player1, player2, player3 }
        );

        // Act
        var actualCorners = tableSelector.GetCorners;

        // Assert
        Assert.AreEqual("╭╮╰╯", actualCorners);
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

        var tableSelector = new TableSelector<string>(
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

        var tableSelector = new TableSelector<string>(
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
        var tableSelector = new TableSelector<int>(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            0
        );

        // Act
        var actualFooterText = tableSelector.FooterText;

        // Assert
        Assert.AreEqual(string.Empty, actualFooterText);
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

        var tableSelector = new TableSelector<string>(
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
        var tableSelector = new TableSelector<int>(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            0
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

        var tableSelector = new TableSelector<string>(
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

        var tableSelector = new TableSelector<string>(
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
        var tableSelector = new TableSelector<int>(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            0
        );

        // Act
        var actualCount = tableSelector.Count;

        // Assert
        Assert.AreEqual(0, actualCount);
    }
    #endregion
}
