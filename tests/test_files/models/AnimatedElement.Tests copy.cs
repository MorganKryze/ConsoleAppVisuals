/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace tests;

[TestClass]
public class UnitTestAnimatedElement
{
    #region Type is Animated
    [TestMethod]
    public void IsInteractive_IsFalse()
    {
        // Arrange
        var element = new TestElement3();

        // Assert
        Assert.AreEqual(ElementType.Animated, element.Type);
    }
    #endregion
}

public class TestElement3 : AnimatedElement { }
