/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace tests;

[TestClass]
public class UnitTestPassiveElement
{
    #region Type is Passive
    [TestMethod]
    public void IsInteractive_IsFalse()
    {
        // Arrange
        var element = new TestElement2();

        // Assert
        Assert.AreEqual(ElementType.Passive, element.Type);
    }
    #endregion
}

public class TestElement2 : PassiveElement { }
