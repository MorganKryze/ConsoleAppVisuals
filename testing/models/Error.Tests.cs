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
public void ElementNotFoundException_GetObjectData_MessageIsSerialized()
{
    // Arrange
    var exception = new ElementNotFoundException("Test message");
    var info = new SerializationInfo(
        typeof(ElementNotFoundException),
        new FormatterConverter()
    );
    var context = new StreamingContext();
    
    // Act
    exception.GetObjectData(info, context);
    
    // Assert
    Assert.AreEqual("Test message", info.GetString("Message"));
}

[TestMethod]
[ExpectedException(typeof(ArgumentNullException))]
public void ElementNotFoundException_GetObjectDataWithNullInfo_ThrowsArgumentNullException()
{
    // Arrange
    var exception = new ElementNotFoundException("Test message");
    var context = new StreamingContext();
    
    // Act
    exception.GetObjectData(null, context);
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

[TestMethod]
public void ElementNotFoundException_SerializationConstructor_MessageAndInnerExceptionMatch()
{
    // Arrange
    var info = new SerializationInfo(
        typeof(ElementNotFoundException),
        new FormatterConverter()
    );
    var context = new StreamingContext();
    var message = "Test message";
    info.AddValue("Message", message, typeof(string));
    info.AddValue("InnerException", new Exception("Inner exception"), typeof(Exception));
    info.AddValue("HelpURL", "", typeof(string));
    info.AddValue("Source", "", typeof(string));
    info.AddValue("StackTraceString", "", typeof(string));
    info.AddValue("RemoteStackTraceString", "", typeof(string));
    info.AddValue("RemoteStackIndex", 0, typeof(int));
    info.AddValue("ExceptionMethod", "", typeof(string));
    info.AddValue("HResult", 0, typeof(int));
    info.AddValue("WatsonBuckets", null, typeof(byte[]));

    // Act
    var exception = (ElementNotFoundException)
        FormatterServices.GetUninitializedObject(typeof(ElementNotFoundException));
    var constructor = typeof(ElementNotFoundException).GetConstructor(
        BindingFlags.NonPublic | BindingFlags.Instance,
        null,
        new[] { typeof(SerializationInfo), typeof(StreamingContext) },
        null
    );
    constructor?.Invoke(exception, new object[] { info, context });

    // Assert
    Assert.AreEqual(message, exception.Message);
    Assert.IsNotNull(exception.InnerException);
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
public void EmptyFileException_GetObjectData_MessageIsSerialized()
{
    // Arrange
    var exception = new EmptyFileException("Test message");
    var info = new SerializationInfo(
        typeof(EmptyFileException),
        new FormatterConverter()
    );
    var context = new StreamingContext();
    
    // Act
    exception.GetObjectData(info, context);
    
    // Assert
    Assert.AreEqual("Test message", info.GetString("Message"));
}

[TestMethod]
[ExpectedException(typeof(ArgumentNullException))]
public void EmptyFileException_GetObjectDataWithNullInfo_ThrowsArgumentNullException()
{
    // Arrange
    var exception = new EmptyFileException("Test message");
    var context = new StreamingContext();
    
    // Act
    exception.GetObjectData(null, context);
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

[TestMethod]
public void EmptyFileException_SerializationConstructor_MessageAndInnerExceptionMatch()
{
    // Arrange
    var info = new SerializationInfo(
        typeof(EmptyFileException),
        new FormatterConverter()
    );
    var context = new StreamingContext();
    var message = "Test message";
    info.AddValue("Message", message, typeof(string));
    info.AddValue("InnerException", new Exception("Inner exception"), typeof(Exception));
    info.AddValue("HelpURL", "", typeof(string));
    info.AddValue("Source", "", typeof(string));
    info.AddValue("StackTraceString", "", typeof(string));
    info.AddValue("RemoteStackTraceString", "", typeof(string));
    info.AddValue("RemoteStackIndex", 0, typeof(int));
    info.AddValue("ExceptionMethod", "", typeof(string));
    info.AddValue("HResult", 0, typeof(int));
    info.AddValue("WatsonBuckets", null, typeof(byte[]));

    // Act
    var exception = (EmptyFileException)
        FormatterServices.GetUninitializedObject(typeof(EmptyFileException));
    var constructor = typeof(EmptyFileException).GetConstructor(
        BindingFlags.NonPublic | BindingFlags.Instance,
        null,
        new[] { typeof(SerializationInfo), typeof(StreamingContext) },
        null
    );
    constructor?.Invoke(exception, new object[] { info, context });

    // Assert
    Assert.AreEqual(message, exception.Message);
    Assert.IsNotNull(exception.InnerException);
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
public void NotSupportedCharException_GetObjectData_MessageIsSerialized()
{
    // Arrange
    var exception = new NotSupportedCharException("Test message");
    var info = new SerializationInfo(
        typeof(NotSupportedCharException),
        new FormatterConverter()
    );
    var context = new StreamingContext();
    
    // Act
    exception.GetObjectData(info, context);
    
    // Assert
    Assert.AreEqual("Test message", info.GetString("Message"));
}

[TestMethod]
[ExpectedException(typeof(ArgumentNullException))]
public void NotSupportedCharException_GetObjectDataWithNullInfo_ThrowsArgumentNullException()
{
    // Arrange
    var exception = new NotSupportedCharException("Test message");
    var context = new StreamingContext();
    
    // Act
    exception.GetObjectData(null, context);
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

[TestMethod]
public void NotSupportedCharException_SerializationConstructor_MessageAndInnerExceptionMatch()
{
    // Arrange
    var info = new SerializationInfo(
        typeof(NotSupportedCharException),
        new FormatterConverter()
    );
    var context = new StreamingContext();
    var message = "Test message";
    info.AddValue("Message", message, typeof(string));
    info.AddValue("InnerException", new Exception("Inner exception"), typeof(Exception));
    info.AddValue("HelpURL", "", typeof(string));
    info.AddValue("Source", "", typeof(string));
    info.AddValue("StackTraceString", "", typeof(string));
    info.AddValue("RemoteStackTraceString", "", typeof(string));
    info.AddValue("RemoteStackIndex", 0, typeof(int));
    info.AddValue("ExceptionMethod", "", typeof(string));
    info.AddValue("HResult", 0, typeof(int));
    info.AddValue("WatsonBuckets", null, typeof(byte[]));

    // Act
    var exception = (NotSupportedCharException)
        FormatterServices.GetUninitializedObject(typeof(NotSupportedCharException));
    var constructor = typeof(NotSupportedCharException).GetConstructor(
        BindingFlags.NonPublic | BindingFlags.Instance,
        null,
        new[] { typeof(SerializationInfo), typeof(StreamingContext) },
        null
    );
    constructor?.Invoke(exception, new object[] { info, context });

    // Assert
    Assert.AreEqual(message, exception.Message);
    Assert.IsNotNull(exception.InnerException);
}

#endregion

}
