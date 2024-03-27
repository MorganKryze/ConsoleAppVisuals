/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace tests;

[TestClass]
public class UnitTestDialog
{
    #region Cleanup
    [TestCleanup]
    public void Cleanup()
    {
        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion

    #region Constructor
    [TestMethod]
    public void Constructor_HappyPath()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message"],
            "Yes",
            "No",
            TextAlignment.Center,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Assert
        Assert.IsNotNull(dialog.TextToDisplay);
    }

    [TestMethod]
    public void Constructor_NullTitle()
    {
        // Arrange
        Dialog dialog = new Dialog(
            [],
            "Yes",
            "No",
            TextAlignment.Center,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Assert
        Assert.IsNull(dialog.TextToDisplay);
    }
    #endregion

    #region Properties
    [TestMethod]
    public void Placement_HappyPath()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message"],
            "Yes",
            "No",
            TextAlignment.Center,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Assert
        Assert.AreEqual(Placement.TopCenter, dialog.Placement);
    }

    [TestMethod]
    public void Placement_DefaultValue()
    {
        // Arrange
        Dialog dialog = new Dialog(["Title", "Message"], "Yes", "No", TextAlignment.Center);

        // Assert
        Assert.AreEqual(Placement.TopCenter, dialog.Placement);
    }

    [TestMethod]
    public void TextAlignment_HappyPath()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message"],
            "Yes",
            "No",
            TextAlignment.Center,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Assert
        Assert.AreEqual(TextAlignment.Center, dialog.TextAlignment);
    }

    [TestMethod]
    public void TextAlignment_DefaultValue()
    {
        // Arrange
        Dialog dialog = new Dialog(["Title", "Message"], "Yes", null);

        // Assert
        Assert.AreEqual(TextAlignment.Left, dialog.TextAlignment);
    }

    [TestMethod]
    public void Height_HappyPath()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message"],
            null,
            "No",
            TextAlignment.Center,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Assert
        Assert.AreEqual(6, dialog.Height);
    }

    [TestMethod]
    public void Width_HappyPath()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message"],
            "Yes",
            "No",
            TextAlignment.Center,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Assert
        Assert.AreEqual(11, dialog.Width);
    }

    [TestMethod]
    public void Lines_HappyPath()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message"],
            "Yes",
            "No",
            TextAlignment.Center,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Assert
        Assert.AreEqual(2, dialog.Lines.Count);
    }

    [TestMethod]
    public void Lines_NullTitle()
    {
        // Arrange
        Dialog dialog = new Dialog(
            [],
            "Yes",
            "No",
            TextAlignment.Center,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Assert
        Assert.AreEqual(0, dialog.Lines.Count);
    }

    [TestMethod]
    public void LeftOption_HappyPath()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message"],
            "Yes",
            "No",
            TextAlignment.Center,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Assert
        Assert.AreEqual("Yes", dialog.LeftOption);
    }

    [TestMethod]
    public void LeftOption_NullValue()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message"],
            null,
            "No",
            TextAlignment.Center,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Assert
        Assert.IsNull(dialog.LeftOption);
    }

    [TestMethod]
    public void RightOption_HappyPath()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message"],
            "Yes",
            "No",
            TextAlignment.Center,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Assert
        Assert.AreEqual("No", dialog.RightOption);
    }

    [TestMethod]
    public void RightOption_NullValue()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message"],
            "Yes",
            null,
            TextAlignment.Center,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Assert
        Assert.IsNull(dialog.RightOption);
    }

    [TestMethod]
    public void BordersType_HappyPath()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message"],
            "Yes",
            "No",
            TextAlignment.Center,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Assert
        Assert.AreEqual(BordersType.SingleStraight, dialog.BordersType);
    }
    #endregion

    #region UpdateRightOption
    [TestMethod]
    public void UpdateRightOption_HappyPath()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message"],
            "Yes",
            "No",
            TextAlignment.Center,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Act
        dialog.UpdateRightOption("Cancel");

        // Assert
        Assert.AreEqual("Cancel", dialog.RightOption);
    }

    [TestMethod]
    public void UpdateRightOption_NullValue()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message"],
            "Yes",
            "No",
            TextAlignment.Center,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Act
        dialog.UpdateRightOption(null);

        // Assert
        Assert.IsNull(dialog.RightOption);
    }
    #endregion

    #region UpdateLeftOption
    [TestMethod]
    public void UpdateLeftOption_HappyPath()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message"],
            "Yes",
            "No",
            TextAlignment.Center,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Act
        dialog.UpdateLeftOption("Accept");

        // Assert
        Assert.AreEqual("Accept", dialog.LeftOption);
    }

    [TestMethod]
    public void UpdateLeftOption_NullValue()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message"],
            "Yes",
            "No",
            TextAlignment.Center,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Act
        dialog.UpdateLeftOption(null);

        // Assert
        Assert.IsNull(dialog.LeftOption);
    }
    #endregion

    #region UpdateLines
    [TestMethod]
    public void UpdateLines_HappyPath()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message"],
            "Yes",
            "No",
            TextAlignment.Center,
            Placement.TopCenter,
            BordersType.SingleStraight
        );
        var newLines = new List<string> { "New Title", "New Message" };

        // Act
        dialog.UpdateLines(newLines);

        // Assert
        Assert.AreEqual(newLines, dialog.Lines);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void UpdateLines_NullValue()
    {
        // Arrange
        var initialLines = new List<string> { "Title", "Message" };
        Dialog dialog = new Dialog(
            initialLines,
            "Yes",
            "No",
            TextAlignment.Center,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Act
        dialog.UpdateLines([]);
    }
    #endregion

    #region UpdateTextAlignment
    [TestMethod]
    public void UpdateTextAlignment_HappyPath()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message"],
            "Yes",
            "No",
            TextAlignment.Left,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Act
        dialog.UpdateTextAlignment(TextAlignment.Center);

        // Assert
        Assert.AreEqual(TextAlignment.Center, dialog.TextAlignment);
    }

    [TestMethod]
    public void UpdateTextAlignment_DefaultValue()
    {
        // Arrange
        Dialog dialog = new Dialog(["Title", "Message"], "Yes", "No", TextAlignment.Left);

        // Act
        dialog.UpdateTextAlignment(TextAlignment.Center);

        // Assert
        Assert.AreEqual(TextAlignment.Center, dialog.TextAlignment);
    }
    #endregion

    #region UpdatePlacement
    [TestMethod]
    public void UpdatePlacement_HappyPath()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message"],
            "Yes",
            "No",
            TextAlignment.Left,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Act
        dialog.UpdatePlacement(Placement.TopRight);

        // Assert
        Assert.AreEqual(Placement.TopRight, dialog.Placement);
    }

    [TestMethod]
    public void UpdatePlacement_DefaultValue()
    {
        // Arrange
        Dialog dialog = new Dialog(["Title", "Message"], "Yes", "No", TextAlignment.Left);

        // Act
        dialog.UpdatePlacement(Placement.TopRight);

        // Assert
        Assert.AreEqual(Placement.TopRight, dialog.Placement);
    }
    #endregion

    #region UpdateBordersType
    [TestMethod]
    public void UpdateBordersType_HappyPath()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message"],
            "Yes",
            "No",
            TextAlignment.Left,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Act
        dialog.UpdateBordersType(BordersType.DoubleStraight);

        // Assert
        Assert.AreEqual(BordersType.DoubleStraight, dialog.BordersType);
    }

    [TestMethod]
    public void UpdateBordersType_DefaultValue()
    {
        // Arrange
        Dialog dialog = new Dialog(["Title", "Message"], "Yes", "No", TextAlignment.Left);

        // Act
        dialog.UpdateBordersType(BordersType.DoubleStraight);

        // Assert
        Assert.AreEqual(BordersType.DoubleStraight, dialog.BordersType);
    }
    #endregion

    #region AddLine
    [TestMethod]
    public void AddLine_HappyPath()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message"],
            "Yes",
            "No",
            TextAlignment.Left,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Act
        dialog.AddLine("New Line");

        // Assert
        Assert.AreEqual(3, dialog.Lines.Count);
    }
    #endregion

    #region InsertLine
    [TestMethod]
    public void InsertLine_HappyPath()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message", "New Line"],
            "Yes",
            "No",
            TextAlignment.Left,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Act
        dialog.InsertLine(2, "Inserted Line");

        // Assert
        Assert.AreEqual(4, dialog.Lines.Count);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void InsertLine_NullValue()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message", "New Line"],
            "Yes",
            "No",
            TextAlignment.Left,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Act
        dialog.InsertLine(3, "Inserted Line");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void InsertLine_NegativeValue()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message", "New Line"],
            "Yes",
            "No",
            TextAlignment.Left,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Act
        dialog.InsertLine(-1, "Inserted Line");
    }
    #endregion

    #region RemoveLine
    [TestMethod]
    public void RemoveLine_HappyPath()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message", "New Line"],
            "Yes",
            "No",
            TextAlignment.Left,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Act
        dialog.RemoveLine(2);

        // Assert
        Assert.AreEqual(2, dialog.Lines.Count);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void RemoveLine_NullValue()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message", "New Line"],
            "Yes",
            "No",
            TextAlignment.Left,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Act
        dialog.RemoveLine(3);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void RemoveLine_NegativeValue()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message", "New Line"],
            "Yes",
            "No",
            TextAlignment.Left,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Act
        dialog.RemoveLine(-1);
    }

    [TestMethod]
    public void RemoveLine_String_HappyPath()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message", "New Line"],
            "Yes",
            "No",
            TextAlignment.Left,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Act
        dialog.RemoveLine("New Line");

        // Assert
        Assert.AreEqual(2, dialog.Lines.Count);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RemoveLine_String_NullValue()
    {
        // Arrange
        Dialog dialog = new Dialog(
            ["Title", "Message", "New Line"],
            "Yes",
            "No",
            TextAlignment.Left,
            Placement.TopCenter,
            BordersType.SingleStraight
        );

        // Act
        dialog.RemoveLine("Line");
    }
    #endregion
}
