/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestInteractiveElement
{
    [TestMethod]
    public void IsInteractiveProperty_ReturnsTrue()
    {
        // Arrange
        var element = new TestInteractiveElement();

        // Act & Assert
        Assert.IsTrue(element.IsInteractive);
    }

    [TestMethod]
    public void MaxNumberOfThisElementProperty_ReturnsOne()
    {
        // Arrange
        var element = new TestInteractiveElement();

        // Act & Assert
        Assert.AreEqual(1, element.MaxNumberOfThisElement);
    }

    [TestMethod]
    public void GetInteractionResponse_ReturnsInfoResponse()
    {
        // Arrange
        var element = new TestInteractiveElement();
        Window.AddElement(element);

        // Act
        Window.ActivateElement<TestInteractiveElement>();
        var response = element.GetInteractionResponse;

        // Assert
        Assert.AreEqual("Test info", response?.Value);

        // Cleanup
        Window.RemoveAllElements();
    }

    [TestMethod]
    public void GetInteractionResponse_ReturnsSelectState()
    {
        // Arrange
        var element = new TestInteractiveElement();
        Window.AddElement(element);

        // Act
        Window.ActivateElement<TestInteractiveElement>();
        var response = element.GetInteractionResponse;

        // Assert
        Assert.AreEqual(Output.Selected, response?.Status);

        // Cleanup
        Window.RemoveAllElements();
    }
}

public class TestInteractiveElement : InteractiveElement<string>
{
    public TestInteractiveElement()
        : base() { }

    protected override void RenderElementActions()
    {
        SendResponse(this, new InteractionEventArgs<string>(Output.Selected, "Test info"));
    }
}
