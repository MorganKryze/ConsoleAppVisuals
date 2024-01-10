/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestMatrix
{
    [TestMethod]
    public void TestNoLines()
    {
        Matrix<string> matrix = new();
        Assert.AreEqual(0, matrix.Count);
    }

    [TestMethod]
    public void TestWrongLinesLengths()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            _ = new Matrix<string>(
                new List<List<string?>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5" }
                }
            );
        });
    }

    [TestMethod]
    public void TestGetElement()
    {
        Matrix<string> matrix =
            new(
                new List<List<string?>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );
        Assert.AreEqual("1", matrix.GetItem(new Position(0, 0)));
    }

    [TestMethod]
    public void TestGetWrongElement()
    {
        Matrix<string> matrix =
            new(
                new List<List<string?>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            matrix.GetItem(new Position(2, 0));
        });
    }

    [TestMethod]
    public void TestUpdateElement()
    {
        Matrix<string> matrix =
            new(
                new List<List<string?>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );
        matrix.UpdateItem(new Position(0, 0), "7");
        Assert.AreEqual("7", matrix.GetItem(new Position(0, 0)));
    }

    [TestMethod]
    public void TestUpdateWrongElement()
    {
        Matrix<string> matrix =
            new(
                new List<List<string?>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            matrix.UpdateItem(new Position(2, 0), "7");
        });
    }

    [TestMethod]
    public void TestUpdateElementWrongIndex()
    {
        Matrix<string> matrix =
            new(
                new List<List<string?>>()
                {
                    new() { "1", "2", "3" },
                    new() { "4", "5", "6" }
                }
            );
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            matrix.UpdateItem(new Position(0, 3), "7");
        });
    }

    [TestMethod]
    public void Test_Placement()
    {
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

        Assert.AreEqual(Placement.TopRight, matrix.Placement);
    }

    [TestMethod]
    public void Test_Dimensions()
    {
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

        Assert.AreEqual(5, matrix.Height);
        Assert.AreEqual(13, matrix.Width);
    }

    [TestMethod]
    public void Test_Dimension_Null()
    {
        Matrix<string> matrix = new(null);

        Assert.AreEqual(0, matrix.Height);
        Assert.AreEqual(0, matrix.Width);
    }

    [TestMethod]
    public void Test_Line()
    {
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

        Assert.AreEqual(0, matrix.Line);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Test_LinesEmpty()
    {
        _ = new Matrix<string>(new List<List<string?>>());
    }

    [TestMethod]
    public void Test_AddLine()
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

    [TestMethod]
    public void Test_RoundedCorners_Set()
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

    [TestMethod]
    public void Test_AddLine_MatrixNull()
    {
        // Arrange
        Matrix<string> matrix = new();

        // Act
        matrix.AddLine(new List<string?>() { "1", "2", "3" });

        // Assert
        Assert.AreEqual(1, matrix.Count);
    }

    [TestMethod]
    public void Test_AddLine_WrongLength()
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

    [TestMethod]
    public void Test_InsertLine()
    {
        // Arrange
        Matrix<string> matrix = new();

        // Act
        matrix.AddLine(new List<string?>() { "1", "2", "3" });
        matrix.AddLine(new List<string?>() { "4", "5", "6" });

        // Assert
        Assert.IsTrue(matrix.InsertLine(1, new List<string?>() { "7", "8", "9" }));
    }

    [TestMethod]
    public void Test_InsertLine_OutOfRange()
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

    [TestMethod]
    public void Test_InsertLine_NotEnoughElements()
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

    [TestMethod]
    public void Test_UpdateLine()
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

    [TestMethod]
    public void Test_UpdateLine_OutOfRange()
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

    [TestMethod]
    public void Test_UpdateLine_NotEnoughElements()
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

    [TestMethod]
    public void Test_RemoveLine()
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

    [TestMethod]
    public void Test_RemoveLine_OutOfRange()
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

    [TestMethod]
    public void Test_Remove()
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

    [TestMethod]
    public void Test_Remove_OutOfRange()
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

    [TestMethod]
    public void Test_RenderElement()
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

    [TestMethod]
    public void Test_RenderElement_Null()
    {
        // Arrange
        Matrix<string> matrix = new(null);

        // Assert
        Window.AddElement(matrix);

        Assert.ThrowsException<InvalidOperationException>(() =>
        {
            Window.ActivateElement<Matrix<string>>();
        });

        // Cleanup
        Window.RemoveElement<Matrix<string>>();
    }
}
