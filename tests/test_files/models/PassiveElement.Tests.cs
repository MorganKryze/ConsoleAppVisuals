/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace tests;

[TestClass]
public class UnitTestPassiveElement
{
    #region IsInteractive is False
    [TestMethod]
    public void IsInteractive_IsFalse()
    {
        // Arrange
        var element = new TestElement();

        // Act
        var result = element.IsInteractive;

        // Assert
        Assert.IsFalse(result);
    }
    #endregion
}

public class TestElement2 : PassiveElement { }
