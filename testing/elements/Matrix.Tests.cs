/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestMatrix
{
    #region Cleanup
    [TestCleanup]
    public void Cleanup()
    {
        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion

    #region NoLines_MatrixIsEmpty
    [TestMethod]
    public void MatrixIsEmpty()
    {
        // Arrange
        Matrix<string> matrix = new();

        // Act

        // Assert
        Assert.AreEqual(0, matrix.Count);
    }
    #endregion

    #region WrongLinesLengths_ThrowsArgumentException
    [TestMethod]
    public void WrongLinesLengths_ArgumentException()
    {
        // Arrange

        // Act
        Assert.ThrowsException<ArgumentException>(() =>
        {
            // Act
            _ = new Matrix<string>(
                new List<List<string?>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5" }
                }
            );
        });

        // Assert
    }
    #endregion

    #region GetElement_ReturnsCorrectElement
    [TestMethod]
    public void GetElement_CorrectElement()
    {
        // Arrange
        Matrix<string> matrix =
            new(
                new List<List<string?>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );

        // Act

        // Assert
        Assert.AreEqual("1", matrix.GetItem(new Position(0, 0)));
    }
    #endregion

    #region GetWrongElement_ThrowsArgumentOutOfRangeException
    [TestMethod]
    public void GetWrongElement_ArgumentOutOfRangeException()
    {
        // Arrange
        Matrix<string> matrix =
            new(
                new List<List<string?>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );

        // Act
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            // Act
            matrix.GetItem(new Position(2, 0));
        });

        // Assert
    }
    #endregion

    #region UpdateElement_UpdatesCorrectElement
    [TestMethod]
    public void UpdateElement_CorrectElement()
    {
        // Arrange
        Matrix<string> matrix =
            new(
                new List<List<string?>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );

        // Act
        matrix.UpdateItem(new Position(0, 0), "7");

        // Assert
        Assert.AreEqual("7", matrix.GetItem(new Position(0, 0)));
    }
    #endregion

    #region UpdateWrongElement_ThrowsArgumentOutOfRangeException
    [TestMethod]
    public void UpdateWrongElement_ArgumentOutOfRangeException()
    {
        // Arrange
        Matrix<string> matrix =
            new(
                new List<List<string?>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );

        // Act
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            // Act
            matrix.UpdateItem(new Position(2, 0), "7");
        });

        // Assert
    }
    #endregion

    #region UpdateElementWrongIndex_ThrowsArgumentOutOfRangeException
    [TestMethod]
    public void UpdateElementWrongIndex_ArgumentOutOfRangeException()
    {
        // Arrange
        Matrix<string> matrix =
            new(
                new List<List<string?>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );

        // Act
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            // Act
            matrix.UpdateItem(new Position(0, 3), "7");
        });

        // Assert
    }
    #endregion

    #region Placement_SetPlacement_ReturnsPlacement
    [TestMethod]
    public void Placement_SetPlacement_ReturnsPlacement()
    {
        // Arrange
        Matrix<string> matrix =
            new(
                new List<List<string?>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                },
                false,
                Placement.TopRight
            );

        // Act

        // Assert
        Assert.AreEqual(Placement.TopRight, matrix.Placement);
    }
    #endregion

    #region Dimensions_ReturnsCorrectDimensions
    [TestMethod]
    public void Dimensions_ReturnsCorrectDimensions()
    {
        // Arrange
        Matrix<string> matrix =
            new(
                new List<List<string?>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                },
                false,
                Placement.TopRight
            );

        // Act

        // Assert
        Assert.AreEqual(5, matrix.Height);
        Assert.AreEqual(13, matrix.Width);
    }
    #endregion

    #region Dimension_NullMatrix_ReturnsZeroDimensions
    [TestMethod]
    public void Dimension_NullMatrix_ReturnsZeroDimensions()
    {
        // Arrange
        Matrix<string> matrix = new(null);

        // Act

        // Assert
        Assert.AreEqual(0, matrix.Height);
        Assert.AreEqual(0, matrix.Width);
    }
    #endregion

    #region Line_ReturnsZero
    [TestMethod]
    public void Line_ReturnsZero()
    {
        // Arrange
        Matrix<string> matrix =
            new(
                new List<List<string?>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                },
                false,
                Placement.TopRight
            );

        // Act

        // Assert
        Assert.AreEqual(0, matrix.Line);
    }
    #endregion

    #region LinesEmpty_ThrowsArgumentException
    [TestMethod]
    public void LinesEmpty_ArgumentException()
    {
        // Arrange

        // Act
        Assert.ThrowsException<ArgumentException>(() =>
        {
            // Act
            _ = new Matrix<string>(new List<List<string?>>());
        });

        // Assert
    }
    #endregion


    #region AddLine_AddsLineCorrectly
    [TestMethod]
    public void AddLine_AddsLineCorrectly()
    {
        // Arrange
        Matrix<string> matrix =
            new(
                new List<List<string?>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                },
                false
            );

        // Act
        matrix.AddLine(new List<string?>() { "7", "8", "9" });

        // Assert
        Assert.AreEqual(3, matrix.Count);
    }
    #endregion

    #region RoundedCorners_SetRoundedCorners_ReturnsTrue
    [TestMethod]
    public void RoundedCorners_SetRoundedCorners_ReturnsTrue()
    {
        // Arrange
        Matrix<string> matrix =
            new(
                new List<List<string?>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                },
                false
            );

        // Act
        matrix.SetRoundedCorners(true);

        // Assert
        Assert.IsTrue(matrix.RoundedCorners);
    }
    #endregion

    #region AddLine_MatrixNull
    [TestMethod]
    public void AddLine_MatrixNull()
    {
        // Arrange
        Matrix<string> matrix = new();

        // Act
        matrix.AddLine(new List<string?>() { "1", "2", "3" });

        // Assert
        Assert.AreEqual(1, matrix.Count);
    }
    #endregion

    #region AddLine_WrongLength
    [TestMethod]
    public void AddLine_WrongLength()
    {
        // Arrange
        Matrix<string> matrix =
            new(
                new List<List<string?>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                },
                false
            );

        // Act
        Assert.ThrowsException<ArgumentException>(() =>
        {
            matrix.AddLine(new List<string?>() { "1", "2" });
        });
    }
    #endregion

    #region InsertLine
    [TestMethod]
    public void InsertLine()
    {
        // Arrange
        Matrix<string> matrix = new();

        // Act
        matrix.AddLine(new List<string?>() { "1", "2", "3" });
        matrix.AddLine(new List<string?>() { "4", "5", "6" });

        // Assert
        Assert.IsTrue(matrix.InsertLine(1, new List<string?>() { "7", "8", "9" }));
    }
    #endregion

    #region InsertLine_OutOfRange
    [TestMethod]
    public void InsertLine_OutOfRange()
    {
        // Arrange
        Matrix<string> matrix = new();

        // Act
        matrix.AddLine(new List<string?>() { "1", "2", "3" });
        matrix.AddLine(new List<string?>() { "4", "5", "6" });

        // Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            matrix.InsertLine(3, new List<string?>() { "7", "8", "9" });
        });
    }
    #endregion

    #region InsertLine_NotEnoughElements
    [TestMethod]
    public void InsertLine_NotEnoughElements()
    {
        // Arrange
        Matrix<string> matrix = new();

        // Act
        matrix.AddLine(new List<string?>() { "1", "2", "3" });

        // Assert
        Assert.ThrowsException<ArgumentException>(() =>
        {
            matrix.InsertLine(0, new List<string?>() { "7", "8" });
        });
    }
    #endregion

    #region UpdateLine
    [TestMethod]
    public void UpdateLine()
    {
        // Arrange
        Matrix<string> matrix = new();

        // Act
        matrix.AddLine(new List<string?>() { "1", "2", "3" });
        matrix.AddLine(new List<string?>() { "4", "5", "6" });
        matrix.UpdateLine(0, new List<string?>() { "7", "8", "9" });

        // Assert
        Assert.AreEqual("7", matrix.GetItem(new Position(0, 0)));
    }
    #endregion

    #region UpdateLine_OutOfRange
    [TestMethod]
    public void UpdateLine_OutOfRange()
    {
        // Arrange
        Matrix<string> matrix = new();

        // Act
        matrix.AddLine(new List<string?>() { "1", "2", "3" });
        matrix.AddLine(new List<string?>() { "4", "5", "6" });

        // Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            matrix.UpdateLine(2, new List<string?>() { "7", "8", "9" });
        });
    }
    #endregion

    #region UpdateLine_NotEnoughElements
    [TestMethod]
    public void UpdateLine_NotEnoughElements()
    {
        // Arrange
        Matrix<string> matrix = new();

        // Act
        matrix.AddLine(new List<string?>() { "1", "2", "3" });
        matrix.AddLine(new List<string?>() { "4", "5", "6" });

        // Assert
        Assert.ThrowsException<ArgumentException>(() =>
        {
            matrix.UpdateLine(0, new List<string?>() { "7", "8" });
        });
    }
    #endregion

    #region RemoveLine
    [TestMethod]
    public void RemoveLine()
    {
        // Arrange
        Matrix<string> matrix = new();

        // Act
        matrix.AddLine(new List<string?>() { "1", "2", "3" });
        matrix.AddLine(new List<string?>() { "4", "5", "6" });
        matrix.RemoveLine(0);

        // Assert
        Assert.AreEqual(1, matrix.Count);
    }
    #endregion

    #region RemoveLine_OutOfRange
    [TestMethod]
    public void RemoveLine_OutOfRange()
    {
        // Arrange
        Matrix<string> matrix = new();

        // Act
        matrix.AddLine(new List<string?>() { "1", "2", "3" });
        matrix.AddLine(new List<string?>() { "4", "5", "6" });

        // Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            matrix.RemoveLine(2);
        });
    }
    #endregion

    #region Remove
    [TestMethod]
    public void Remove()
    {
        // Arrange
        Matrix<string> matrix = new();

        // Act
        matrix.AddLine(new List<string?>() { "1", "2", "3" });
        matrix.AddLine(new List<string?>() { "4", "5", "6" });
        matrix.RemoveItem(new Position(0, 0));

        // Assert
        Assert.AreEqual(null, matrix.GetItem(new Position(0, 0)));
    }
    #endregion

    #region Remove_OutOfRange
    [TestMethod]
    public void Remove_OutOfRange()
    {
        // Arrange
        Matrix<string> matrix = new();

        // Act
        matrix.AddLine(new List<string?>() { "1", "2", "3" });
        matrix.AddLine(new List<string?>() { "4", "5", "6" });

        // Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            matrix.RemoveItem(new Position(2, 0));
        });
    }
    #endregion

    #region RenderElement
    [TestMethod]
    public void RenderElement()
    {
        // Arrange
        Matrix<string> matrix =
            new(
                new List<List<string?>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                },
                false
            );

        // Act
        Window.AddElement(matrix);
        Window.ActivateElement<Matrix<string>>();

        // Assert
        Assert.IsNotNull(matrix.Count);

        // Cleanup
        Window.RemoveElement<Matrix<string>>();
    }
    #endregion

    #region RenderElement_Null
    [TestMethod]
    public void RenderElement_Null()
    {
        // Arrange
        Matrix<string> matrix = new(null);

        // Act
        Window.AddElement(matrix);

        // Assert
        Assert.ThrowsException<InvalidOperationException>(() =>
        {
            Window.ActivateElement<Matrix<string>>();
        });

        // Cleanup
        Window.RemoveElement<Matrix<string>>();
    }
    #endregion
}
