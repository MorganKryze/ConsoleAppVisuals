/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestInteractiveElement
{
    [TestMethod]
        public void TestIsInteractiveProperty()
        {
            var element = new TestInteractiveElement();
            Assert.IsTrue(element.IsInteractive);
        }

        [TestMethod]
        public void TestMaxNumberOfThisElementProperty()
        {
            var element = new TestInteractiveElement();
            Assert.AreEqual(1, element.MaxNumberOfThisElement);
        }

        [TestMethod]
        public void TestGetInteractionResponse_Info()
        {
            // Arrange
            var element = new TestInteractiveElement();
            Window.AddElement(element);

            // Act
            Window.ActivateElement<TestInteractiveElement>();
            var response = element.GetInteractionResponse;

            // Assert
            Assert.AreEqual("Test info", response?.Info);

            // Cleanup
            Window.RemoveAllElements();
        }

        [TestMethod]
        public void TestGetInteractionResponse_State()
        {
            // Arrange
            var element = new TestInteractiveElement();
            Window.AddElement(element);

            // Act
            Window.ActivateElement<TestInteractiveElement>();
            var response = element.GetInteractionResponse;

            // Assert
            Assert.AreEqual(Output.Select, response?.State);

            // Cleanup
            Window.RemoveAllElements();
        }
}

public class TestInteractiveElement : InteractiveElement<string>
{
    public TestInteractiveElement() : base()
    {
    }

    protected override void RenderElementActions()
    {
        SendResponse(this, new InteractionEventArgs<string>(Output.Select, "Test info"));
    }
}