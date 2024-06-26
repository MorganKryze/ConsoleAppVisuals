/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace tests;

[TestClass]
public class UnitTestAttribute
{
    #region ConstructorTests

    [TestMethod]
    public void Constructor_DefaultValues_ReturnsNullMessageAndFalseIsError()
    {
        // Arrange & Act
        var attribute = new VisualAttribute();

        // Assert
        Assert.IsNull(attribute.Message);
        Assert.IsFalse(attribute.IsError);
    }

    [TestMethod]
    public void Constructor_WithMessage_ReturnsMessageAndFalseIsError()
    {
        // Arrange & Act
        var attribute = new VisualAttribute("Test message");

        // Assert
        Assert.AreEqual("Test message", attribute.Message);
        Assert.IsFalse(attribute.IsError);
    }

    [TestMethod]
    public void Constructor_WithMessageAndError_ReturnsMessageAndTrueIsError()
    {
        // Arrange & Act
        var attribute = new VisualAttribute("Test message", true);

        // Assert
        Assert.AreEqual("Test message", attribute.Message);
        Assert.IsTrue(attribute.IsError);
    }

    #endregion

    #region DiagnosticIdPropertyTests

    [TestMethod]
    public void DiagnosticIdProperty_SetValue_ReturnsSetValue()
    {
        // Arrange
        var attribute = new VisualAttribute();

        // Act
        attribute.DiagnosticId = "Test diagnostic ID";

        // Assert
        Assert.AreEqual("Test diagnostic ID", attribute.DiagnosticId);
    }

    #endregion

    #region UrlFormatPropertyTests

    [TestMethod]
    public void UrlFormatProperty_SetValue_ReturnsSetValue()
    {
        // Arrange
        var attribute = new VisualAttribute();

        // Act
        attribute.UrlFormat = "Test URL format";

        // Assert
        Assert.AreEqual("Test URL format", attribute.UrlFormat);
    }

    #endregion
}
