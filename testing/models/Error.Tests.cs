/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

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
}
