/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace tests;

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
        var defaultValue = Window.Elements.Count;

        // Act
        Window.AddElement(new Prompt("Hello World!"));

        // Assert
        Assert.AreNotEqual(Window.CountElements, defaultValue);
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
    }

    [TestMethod]
    public void GetVisibleElement_ElementNotFound()
    {
        // Arrange
        var prompt = new Prompt("Hello World!", default, Placement.TopCenter);
        Window.AddElement(prompt);

        // Act
        Window.ActivateElement(prompt.Id, false);
        var element = Window.GetVisibleElement<LoadingBar>();

        // Assert
        Assert.IsNull(element);
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
    }

    [TestMethod]
    public void RemoveElement_NotFound()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");
        Window.AddElement(prompt);

        // Assert
        Assert.ThrowsException<ElementNotFoundException>(() => Window.RemoveElement<LoadingBar>());
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
        Assert.IsTrue(Window.Elements.Contains(element));
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
        Window.DeactivateElement(id, false);

        // Assert
        Assert.IsFalse(element.Visibility);
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
    }

    [TestMethod]
    public void DeactivateElement_ElementTypeClear_ElementIsDeactivated()
    {
        // Arrange
        var element = new Prompt("Hello World!");

        //Act
        Window.AddElement(element);
        Window.ActivateElement(element.Id, false);
        Window.DeactivateElement<Prompt>(false);

        // Assert
        Assert.IsFalse(element.Visibility);
    }

    [TestMethod]
    public void DeactivateAllElements_AllElementsAreDeactivated()
    {
        // Arrange
        var prompt = new Prompt("Hello World!");
        Window.AddElement(prompt);

        // Act
        Window.ActivateAllElements();
        Window.DeactivateAllElements(false);

        // Assert
        Assert.IsFalse(prompt.Visibility);
    }
    #endregion

    #region General

    [TestMethod]
    [DataRow(null)]
    [DataRow(0)]
    [DataRow(-1)]
    public void CheckLine_Validations(int? line)
    {
        if (line == null)
            Assert.IsNull(Window.CheckLine(line));
        else if (line < 0)
            Assert.ThrowsException<LineOutOfConsoleException>(() => Window.CheckLine(line));
        else
            Assert.AreEqual(line, Window.CheckLine(line));
    }

    #endregion

    #region GetLineAvailable
    [TestMethod]
    public void GetLineAvailable_MinimalApp()
    {
        // Arrange
        var title = new Title("Title");
        var header = new Header();
        var footer = new Footer();
        var loadingBarLeft = new FakeLoadingBar("LoadingBarLeft", Placement.TopLeft);
        var loadingBarRight = new FakeLoadingBar("LoadingBarRight", Placement.TopRight);
        var loadingBarCenter = new FakeLoadingBar("LoadingBarCenter", Placement.TopCenter);

        // Act
        Window.AddElement(title, header, footer, loadingBarLeft, loadingBarRight, loadingBarCenter);

        // Assert
        Assert.IsNotNull(Window.GetLineAvailable(Placement.TopLeft));
        Assert.IsNotNull(Window.GetLineAvailable(Placement.TopRight));
        Assert.IsNotNull(Window.GetLineAvailable(Placement.TopCenter));
        Assert.IsNotNull(Window.GetLineAvailable(Placement.TopCenterFullWidth));
        Assert.IsNotNull(Window.GetLineAvailable(Placement.BottomCenterFullWidth));
    }

    [TestMethod]
    public void UpdateIDs_IdChanged()
    {
        // Arrange
        var title = new Title("Title");
        var header = new Header();
        Window.AddElement(title, header);

        // Act
        var initialHeaderId = 1;
        Window.RemoveElement(title);

        // Assert
        Assert.AreEqual(1, Window.CountElements);
        Assert.AreNotEqual(initialHeaderId, header.Id);
    }
    #endregion

    #region AddElement Duplicate
    [TestMethod]
    [ExpectedException(typeof(DuplicateElementException))]
    public void AddElement_Duplicate()
    {
        // Arrange
        var title = new Title("Title");

        // Act
        Window.AddElement(title, title);
    }
    #endregion

    #region AddElement Empty

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddElement_Null()
    {
        // Act
        Window.AddElement();
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddElement_Empty()
    {
        // Arrange
        var elements = Array.Empty<Element>();

        // Act
        Window.AddElement(elements);
    }
    #endregion
}
