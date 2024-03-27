/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace tests;

[TestClass]
public class UnitTestError
{
    #region ElementNotFoundExceptionTests

    [TestMethod]
    public void ElementNotFoundException_DefaultConstructor_MessageIsNull()
    {
        // Arrange & Act
        var exception = new ElementNotFoundException();

        // Assert
        Assert.IsNotNull(exception);
    }

    [TestMethod]
    public void ElementNotFoundException_ConstructorWithMessage_MessageMatches()
    {
        // Arrange
        var message = "Test message";

        // Act
        var exception = new ElementNotFoundException(message);

        // Assert
        Assert.AreEqual(message, exception.Message);
    }

    [TestMethod]
    public void ElementNotFoundException_ConstructorWithMessageAndInnerException_MessageAndInnerExceptionMatch()
    {
        // Arrange
        var message = "Test message";
        var innerException = new Exception("Inner exception");

        // Act
        var exception = new ElementNotFoundException(message, innerException);

        // Assert
        Assert.AreEqual(message, exception.Message);
        Assert.AreEqual(innerException, exception.InnerException);
    }


    [TestMethod]
    public void ElementNotFoundException_GetDebuggerDisplay_ReturnsToString()
    {
        // Arrange
        var message = "Test message";
        var exception = new ElementNotFoundException(message);
        var method = typeof(ElementNotFoundException).GetMethod(
            "GetDebuggerDisplay",
            BindingFlags.NonPublic | BindingFlags.Instance
        );

        // Act
        var result = method?.Invoke(exception, null);

        // Assert
        Assert.AreEqual(exception.ToString(), result);
    }


    #endregion

    #region EmptyFileExceptionTests

    [TestMethod]
    public void EmptyFileException_DefaultConstructor_MessageIsNull()
    {
        // Arrange & Act
        var exception = new EmptyFileException();

        // Assert
        Assert.IsNotNull(exception);
    }

    [TestMethod]
    public void EmptyFileException_ConstructorWithMessage_MessageMatches()
    {
        // Arrange
        var message = "Test message";

        // Act
        var exception = new EmptyFileException(message);

        // Assert
        Assert.AreEqual(message, exception.Message);
    }

    [TestMethod]
    public void EmptyFileException_ConstructorWithMessageAndInnerException_MessageAndInnerExceptionMatch()
    {
        // Arrange
        var message = "Test message";
        var innerException = new Exception("Inner exception");

        // Act
        var exception = new EmptyFileException(message, innerException);

        // Assert
        Assert.AreEqual(message, exception.Message);
        Assert.AreEqual(innerException, exception.InnerException);
    }


    [TestMethod]
    public void EmptyFileException_GetDebuggerDisplay_ReturnsToString()
    {
        // Arrange
        var message = "Test message";
        var exception = new EmptyFileException(message);
        var method = typeof(EmptyFileException).GetMethod(
            "GetDebuggerDisplay",
            BindingFlags.NonPublic | BindingFlags.Instance
        );

        // Act
        var result = method?.Invoke(exception, null);

        // Assert
        Assert.AreEqual(exception.ToString(), result);
    }


    #endregion

    #region NotSupportedCharExceptionTests

    [TestMethod]
    public void NotSupportedCharException_DefaultConstructor_MessageIsNull()
    {
        // Arrange & Act
        var exception = new NotSupportedCharException();

        // Assert
        Assert.IsNotNull(exception);
    }

    [TestMethod]
    public void NotSupportedCharException_ConstructorWithMessage_MessageMatches()
    {
        // Arrange
        var message = "Test message";

        // Act
        var exception = new NotSupportedCharException(message);

        // Assert
        Assert.AreEqual(message, exception.Message);
    }

    [TestMethod]
    public void NotSupportedCharException_ConstructorWithMessageAndInnerException_MessageAndInnerExceptionMatch()
    {
        // Arrange
        var message = "Test message";
        var innerException = new Exception("Inner exception");

        // Act
        var exception = new NotSupportedCharException(message, innerException);

        // Assert
        Assert.AreEqual(message, exception.Message);
        Assert.AreEqual(innerException, exception.InnerException);
    }


    [TestMethod]
    public void NotSupportedCharException_GetDebuggerDisplay_ReturnsToString()
    {
        // Arrange
        var message = "Test message";
        var exception = new NotSupportedCharException(message);
        var method = typeof(NotSupportedCharException).GetMethod(
            "GetDebuggerDisplay",
            BindingFlags.NonPublic | BindingFlags.Instance
        );

        // Act
        var result = method?.Invoke(exception, null);

        // Assert
        Assert.AreEqual(exception.ToString(), result);
    }


    #endregion

    #region DuplicateElementFoundExceptionTests
    [TestMethod]
    public void DuplicateElementFoundException_DefaultConstructor_MessageIsNull()
    {
        // Arrange & Act
        var exception = new DuplicateElementException();

        // Assert
        Assert.IsNotNull(exception);
    }

    [TestMethod]
    public void DuplicateElementFoundException_ConstructorWithMessage_MessageMatches()
    {
        // Arrange
        var message = "Test message";

        // Act
        var exception = new DuplicateElementException(message);

        // Assert
        Assert.AreEqual(message, exception.Message);
    }

    [TestMethod]
    public void DuplicateElementFoundException_ConstructorWithMessageAndInnerException_MessageAndInnerExceptionMatch()
    {
        // Arrange
        var message = "Test message";
        var innerException = new Exception("Inner exception");

        // Act
        var exception = new DuplicateElementException(message, innerException);

        // Assert
        Assert.AreEqual(message, exception.Message);
        Assert.AreEqual(innerException, exception.InnerException);
    }

    [TestMethod]
    public void DuplicateElementFoundException_GetDebuggerDisplay_ReturnsToString()
    {
        // Arrange
        var message = "Test message";
        var exception = new DuplicateElementException(message);
        var method = typeof(DuplicateElementException).GetMethod(
            "GetDebuggerDisplay",
            BindingFlags.NonPublic | BindingFlags.Instance
        );

        // Act
        var result = method?.Invoke(exception, null);

        // Assert
        Assert.AreEqual(exception.ToString(), result);
    }

    #endregion

    #region LineOutOfConsoleExceptionTests
    [TestMethod]
    public void LineOutOfConsoleException_DefaultConstructor_MessageIsNull()
    {
        // Arrange & Act
        var exception = new LineOutOfConsoleException();

        // Assert
        Assert.IsNotNull(exception);
    }

    [TestMethod]
    public void LineOutOfConsoleException_ConstructorWithMessage_MessageMatches()
    {
        // Arrange
        var message = "Test message";

        // Act
        var exception = new LineOutOfConsoleException(message);

        // Assert
        Assert.AreEqual(message, exception.Message);
    }

    [TestMethod]
    public void LineOutOfConsoleException_ConstructorWithMessageAndInnerException_MessageAndInnerExceptionMatch()
    {
        // Arrange
        var message = "Test message";
        var innerException = new Exception("Inner exception");

        // Act
        var exception = new LineOutOfConsoleException(message, innerException);

        // Assert
        Assert.AreEqual(message, exception.Message);
        Assert.AreEqual(innerException, exception.InnerException);
    }


    [TestMethod]
    public void LineOutOfConsoleException_GetDebuggerDisplay_ReturnsToString()
    {
        // Arrange
        var message = "Test message";
        var exception = new LineOutOfConsoleException(message);
        var method = typeof(LineOutOfConsoleException).GetMethod(
            "GetDebuggerDisplay",
            BindingFlags.NonPublic | BindingFlags.Instance
        );

        // Act
        var result = method?.Invoke(exception, null);

        // Assert
        Assert.AreEqual(exception.ToString(), result);
    }
    #endregion
}
