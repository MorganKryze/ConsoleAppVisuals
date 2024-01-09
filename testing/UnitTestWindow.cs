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
        Window.AddElement(new FakeLoadingBar());

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
        var loadingBar = new FakeLoadingBar();
        Window.AddElement(prompt);

        // Act
        Window.InsertElement(loadingBar, 0);

        // Assert
        Assert.AreEqual(loadingBar, Window.GetElement<FakeLoadingBar>(0));
        Assert.AreEqual(prompt, Window.GetElement<Prompt>(1));

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void Test_InsertElement_InvalidIndex()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");
        var loadingBar = new FakeLoadingBar();
        Window.AddElement(prompt);

        // Act
        Assert.ThrowsException<ArgumentOutOfRangeException>(
            () => Window.InsertElement(loadingBar, -1)
        );
        Assert.ThrowsException<ArgumentOutOfRangeException>(
            () => Window.InsertElement(loadingBar, 2)
        );

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
    public void AddElement_AddsElementToWindowElementsList()
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
    public void DeactivateElement_WithValidId_ShouldDeactivateElement()
    {
        // Arrange
        var element = new Prompt("Hello World!");
        Window.AddElement(element);
        int id = element.Id;

        // Act
        Window.DeactivateElement(id);

        // Assert
        Assert.IsFalse(element.Visibility);
    }

    [TestMethod]
    public void DeactivateElement_WithInvalidId_ShouldThrowArgumentOutOfRangeException()
    {
        // Arrange
        int id = -1;

        // Act and Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => Window.DeactivateElement(id));
    }

    [TestMethod]
    public void DeactivateElement_WithValidId_ShouldReturnTrue()
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
    }
    #endregion
}
