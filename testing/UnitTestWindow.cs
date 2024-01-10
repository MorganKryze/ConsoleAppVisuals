/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestWindow
{
    #region Properties

    [TestMethod]
    public void Test_Elements()
    {
        // Arrange
        var defaultValue = Window.Elements.Count;

        // Act
        Window.AddElement(new Prompt("Hello World!"));

        // Assert
        Assert.AreNotEqual(Window.CountElements, defaultValue);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_NextId()
    {
        // Assert default value
        var defaultValue = Window.NextId;

        // Arrange
        Window.AddElement(new Prompt("Hello World!"));

        // Assert
        Assert.AreEqual(0, defaultValue);
        Assert.AreEqual(1, Window.NextId);

        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion

    #region GetElement
    [TestMethod]
    public void Test_GetElement()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");
        Window.AddElement(prompt);

        // Act
        var element = Window.GetElement<Prompt>(prompt.Id);

        // Assert
        Assert.AreEqual(prompt, element);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_GetElement_InvalidId()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");
        Window.AddElement(prompt);

        // Act
        Assert.ThrowsException<ArgumentOutOfRangeException>(
            () => Window.GetElement<Prompt>(prompt.Id + 1)
        );
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => Window.GetElement<Prompt>(-1));

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_GetElement_NotFound()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");
        Window.AddElement(prompt);

        // Act
        var element = Window.GetElement<LoadingBar>();

        // Assert
        Assert.IsNull(element);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_GetVisibleElement()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");
        Window.AddElement(prompt);

        // Act
        Window.ActivateElement(prompt.Id, false);
        var element = Window.GetVisibleElement<Prompt>();

        // Assert
        Assert.AreEqual(prompt, element);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_GetVisibleElement_NotFound()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");
        Window.AddElement(prompt);

        // Act
        Window.ActivateElement(prompt.Id, false);
        var element = Window.GetVisibleElement<LoadingBar>();

        // Assert
        Assert.IsNull(element);

        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion

    #region InsertElement

    [TestMethod]
    public void Test_InsertElement()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");
        var title = new Title("Title");
        Window.AddElement(prompt);

        // Act
        Window.InsertElement(title, 0);

        // Assert
        Assert.AreEqual(title, Window.GetElement<Title>(0));
        Assert.AreEqual(prompt, Window.GetElement<Prompt>(1));

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_InsertElement_InvalidIndex()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");
        var title = new Title("Title");
        Window.AddElement(prompt);

        // Act
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => Window.InsertElement(title, -1));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => Window.InsertElement(title, 2));

        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion

    #region RemoveElement
    [TestMethod]
    public void Test_RemoveElement()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");
        Window.AddElement(prompt);

        // Act
        Window.RemoveElement(prompt.Id);

        // Assert
        Assert.AreEqual(0, Window.CountElements);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_RemoveElement_InvalidId()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");
        Window.AddElement(prompt);

        // Act
        Assert.ThrowsException<ArgumentOutOfRangeException>(
            () => Window.RemoveElement(prompt.Id + 1)
        );
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => Window.RemoveElement(-1));

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_RemoveElement_ElementType()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");
        Window.AddElement(prompt);

        // Act
        var result = Window.RemoveElement(prompt);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(0, Window.CountElements);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_RemoveElement_ElementType_NotFound()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");

        // Act
        Assert.ThrowsException<ElementNotFoundException>(() => Window.RemoveElement(prompt));

        // Assert
        Assert.AreEqual(0, Window.CountElements);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_RemoveElement_NotFound()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");
        Window.AddElement(prompt);

        // Assert
        Assert.ThrowsException<ElementNotFoundException>(() => Window.RemoveElement<LoadingBar>());

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_RemoveElement_HappyPath()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");
        Window.AddElement(prompt);

        // Act
        var result = Window.RemoveElement<Prompt>();

        // Assert
        Assert.IsTrue(result);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_RemoveLibraryElement()
    {
        // Arrange
        Window.AddListWindowElements();

        // Act
        var result = Window.RemoveLibraryElement<TableView<string>>();

        // Assert
        Assert.IsTrue(result);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_RemoveLibraryElement_NotFound()
    {
        // Arrange
        Window.AddListWindowElements();

        // Act
        Assert.ThrowsException<ElementNotFoundException>(
            () => Window.RemoveLibraryElement<LoadingBar>()
        );

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_RemoveLibraryElement_NotFromLibrary()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");
        Window.AddElement(prompt);

        // Act
        Assert.ThrowsException<InvalidOperationException>(
            () => Window.RemoveLibraryElement<Prompt>()
        );

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_RemoveAllElements()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");
        Window.AddElement(prompt);

        // Act
        Window.RemoveAllElements();

        // Assert
        Assert.AreEqual(0, Window.CountElements);
    }
    #endregion

    #region ActivateAllElements
    [TestMethod]
    public void Test_ActivateAllElements()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");
        Window.AddElement(prompt);

        // Act
        Window.ActivateAllElements();

        // Assert
        Assert.IsTrue(prompt.Visibility);

        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion

    #region AddElement
    [TestMethod]
    public void Test_AddElement_AddsElementToWindowElementsList()
    {
        // Arrange
        var element = new Prompt("Hello World!");

        // Act
        Window.AddElement(element);

        // Assert
        Assert.IsTrue(Window.Elements.Contains(element));
    }
    #endregion

    #region DeactivateElement
    [TestMethod]
    public void Test_DeactivateElement_WithValidId()
    {
        // Arrange
        var element = new Prompt("Hello World!");
        Window.AddElement(element);
        int id = element.Id;

        // Act
        Window.ActivateElement(id, false);
        Window.DeactivateElement(id);

        // Assert
        Assert.IsFalse(element.Visibility);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_DeactivateElement_WithInvalidId()
    {
        // Arrange
        int id = -1;

        // Act and Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => Window.DeactivateElement(id));
    }

    [TestMethod]
    public void DeactivateElement_NotFound()
    {
        // Arrange
        var element = new Prompt("Hello World!");

        // Assert
        Assert.ThrowsException<ElementNotFoundException>(
            () => Window.DeactivateElement(element, false)
        );
    }

    [TestMethod]
    public void Test_DeactivateElement()
    {
        // Arrange
        var element = new Prompt("Hello World!");

        //Act
        Window.AddElement(element);
        Window.ActivateElement(element.Id, false);
        Window.DeactivateElement(element, false);

        // Assert
        Assert.IsFalse(element.Visibility);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_DeactivateElement_Clear()
    {
        // Arrange
        var element = new Prompt("Hello World!");

        //Act
        Window.AddElement(element);
        Window.ActivateElement(element.Id, false);
        Window.DeactivateElement(element, true);

        // Assert
        Assert.IsFalse(element.Visibility);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_DeactivateElement_NotFound_ElementType()
    {
        // Assert
        Assert.ThrowsException<ElementNotFoundException>(
            () => Window.DeactivateElement<Prompt>(false)
        );
    }

    [TestMethod]
    public void Test_DeactivateElement_ElementType()
    {
        // Arrange
        var element = new Prompt("Hello World!");

        //Act
        Window.AddElement(element);
        Window.ActivateElement(element.Id, false);
        Window.DeactivateElement<Prompt>(false);

        // Assert
        Assert.IsFalse(element.Visibility);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_DeactivateElement_ElementTypeClear()
    {
        // Arrange
        var element = new Prompt("Hello World!");

        //Act
        Window.AddElement(element);
        Window.ActivateElement(element.Id, false);
        Window.DeactivateElement<Prompt>(true);

        // Assert
        Assert.IsFalse(element.Visibility);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_DeactivateAllElements()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");
        Window.AddElement(prompt);

        // Act
        Window.ActivateAllElements();
        Window.DeactivateAllElements();

        // Assert
        Assert.IsFalse(prompt.Visibility);

        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion

    #region General
    [TestMethod]
    [DataRow(Placement.TopCenter)]
    [DataRow(Placement.TopLeft)]
    [DataRow(Placement.TopRight)]
    [DataRow(Placement.TopCenterFullWidth)]
    [DataRow(Placement.BottomCenterFullWidth)]
    public void Test_GetLineAvailable(Placement placement)
    {
        // Arrange
        var title = new Title("Title");
        Window.AddElement(title);
        var prompt = new Prompt("Hello World!");
        Window.AddElement(prompt);

        // Act
        var line = Window.GetLineAvailable(placement);

        // Assert
        if (placement == Placement.BottomCenterFullWidth)
            Assert.AreEqual(Console.WindowHeight, line);
        else
            Assert.AreEqual(8, line);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_GetLineAvailable_ibbfeizlfbizhe()
    {
        // Arrange
        var table1 = new TableView<string>("Title", null, null, Placement.TopLeft);
        Window.AddElement(table1);
        var table2 = new TableView<string>("Title", null, null, Placement.TopRight);
        Window.AddElement(table2);
        var table3 = new TableView<string>("Title", null, null, Placement.TopCenter);
        Window.AddElement(table3);

        // Act
        Window.ActivateAllElements();
        var line = Window.GetLineAvailable(Placement.TopCenterFullWidth);

        // Assert
        Assert.AreEqual(0, line);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    [DataRow(null)]
    [DataRow(0)]
    [DataRow(-1)]
    public void Test_CheckLine(int? line)
    {
        if (line == null)
            Assert.IsNull(Window.CheckLine(line));
        else if (line < 0)
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Window.CheckLine(line));
        else
            Assert.AreEqual(line, Window.CheckLine(line));
    }

    [TestMethod]
    public void Test_Clear_True()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");
        Window.AddElement(prompt);

        // Act
        Window.Clear(true);

        // Assert
        Assert.AreEqual(
            Console.WindowHeight == 0 ? 0 : Console.WindowHeight - 1,
            Console.CursorTop
        );

        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion

    #region RenderElements
    [TestMethod]
    public void Test_RenderOneElement()
    {
        // Arrange
        var title = new Title("Hello World!");
        Window.AddElement(title);

        // Act
        var result = Window.RenderOneElement(title.Id);

        // Assert
        Assert.IsTrue(result);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_RenderElement_InvalidId()
    {
        // Arrange
        var title = new Title("Hello World!");
        Window.AddElement(title);

        // Act
        Assert.ThrowsException<ElementNotFoundException>(
            () => Window.RenderOneElement(title.Id + 1)
        );

        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion
}
