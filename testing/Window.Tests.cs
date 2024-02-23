/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestWindow
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
    public void AddElement_WindowHasElement()
    {
        // Arrange
        var defaultValue = Window.GetElements.Count;

        // Act
        Window.AddElement(new Prompt("Hello World!"));

        // Assert
        Assert.AreNotEqual(Window.CountElements, defaultValue);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void NextId_IteratesBy1StartsFrom0()
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
    public void GetElement_ElementEqualsToInitial()
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
    public void GetElement_InvalidIdRaisesError()
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
    public void GetElement_ElementNotFound()
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
    public void GetVisibleElement_ElementEqualsToInitial()
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
    public void GetVisibleElement_ElementNotFound()
    {
        // Arrange
        var prompt = new Prompt("Hello World!", default, Placement.TopCenter, 0);
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
    public void InsertElement_OrderWellUpdated()
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
    public void InsertElement_InvalidIndexRaisesError()
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
    public void RemoveElement()
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
    public void RemoveElement_InvalidId()
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
    public void RemoveElement_ElementType()
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
    public void RemoveElement_ElementType_NotFound()
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
    public void RemoveElement_NotFound()
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
    public void RemoveElement_HappyPath()
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
    public void RemoveAllElements_WindowIsEmptyAfterRemoval()
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
    public void ActivateAllElements_AllElementsAreActivated()
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
    public void AddElement_AddsElementToList()
    {
        // Arrange
        var element = new Prompt("Hello World!");

        // Act
        Window.AddElement(element);

        // Assert
        Assert.IsTrue(Window.GetElements.Contains(element));
    }
    #endregion

    #region DeactivateElement
    [TestMethod]
    public void DeactivateElement_ValidId_ElementIsDeactivated()
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
    public void DeactivateElement_InvalidId_ThrowsException()
    {
        // Arrange
        int id = -1;

        // Act and Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => Window.DeactivateElement(id));
    }

    [TestMethod]
    public void DeactivateElement_NotFound_ThrowsException()
    {
        // Arrange
        var element = new Prompt("Hello World!");

        // Assert
        Assert.ThrowsException<ElementNotFoundException>(
            () => Window.DeactivateElement(element, false)
        );
    }

    [TestMethod]
    public void DeactivateElement_ElementIsDeactivated()
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
    public void DeactivateElement_Clear_ElementIsDeactivated()
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
    public void DeactivateElement_NotFound_ElementType_ThrowsException()
    {
        // Assert
        Assert.ThrowsException<ElementNotFoundException>(
            () => Window.DeactivateElement<Prompt>(false)
        );
    }

    [TestMethod]
    public void DeactivateElement_ElementType_ElementIsDeactivated()
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
    public void DeactivateElement_ElementTypeClear_ElementIsDeactivated()
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
    public void DeactivateAllElements_AllElementsAreDeactivated()
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
    public void GetLine_AvailableLine(Placement placement)
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
    public void GetLine_AvailableLine_TopCenterFullWidth()
    {
        // Arrange
        var table1 = new TableView<string>("Title", null, null, false, Placement.TopLeft);
        Window.AddElement(table1);
        var table2 = new TableView<string>("Title", null, null, false, Placement.TopRight);
        Window.AddElement(table2);
        var table3 = new TableView<string>("Title", null, null, false, Placement.TopCenter);
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
    public void CheckLine_Validations(int? line)
    {
        if (line == null)
            Assert.IsNull(Window.CheckLine(line));
        else if (line < 0)
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Window.CheckLine(line));
        else
            Assert.AreEqual(line, Window.CheckLine(line));
    }

    [TestMethod]
    public void Clear_WindowContentRemoved()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");
        Window.AddElement(prompt);

        // Act
        var result = Window.Clear(true);

        // Assert
        Assert.IsTrue(result);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void OnResize_ColorSet()
    {
        // Arrange
        Core.SetBackgroundColor(ConsoleColor.Blue);

        // Act
        var result = Window.OnResize();

        // Assert
        Assert.IsTrue(result);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void OnResize_ColorReset()
    {
        // Arrange
        Core.RestoreColorPanel();

        // Act
        var result = Window.OnResize();

        // Assert
        Assert.IsFalse(result);

        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion

    #region RenderElements
    [TestMethod]
    public void RenderOneElement_ElementRenderedById()
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
    public void RenderOneElement_InvalidId_ExceptionThrown()
    {
        // Arrange
        var title = new Title("Hello World!");
        Window.AddElement(title);

        // Act and Assert
        Assert.ThrowsException<ElementNotFoundException>(
            () => Window.RenderOneElement(title.Id + 1)
        );

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void RenderOneElement_ElementRenderedByElement()
    {
        // Arrange
        var title = new Title("Hello World!");
        Window.AddElement(title);

        // Act
        var result = Window.RenderOneElement(title);

        // Assert
        Assert.IsTrue(result);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void RenderOneElement_InvalidElement_ExceptionThrown()
    {
        // Arrange
        var title = new Title("Hello World!");
        Window.AddElement(title);
        var prompt = new Prompt("Hello World!");

        // Act and Assert
        Assert.ThrowsException<ElementNotFoundException>(() => Window.RenderOneElement(prompt));

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void RenderAllElements_AllElementsRendered()
    {
        // Arrange
        var title = new Title("Hello World!");
        Window.AddElement(title);

        // Act
        var result = Window.RenderAllElementsSpace();

        // Assert
        Assert.IsTrue(result);

        // Cleanup
        Window.RemoveAllElements();
    }
    #endregion
}
