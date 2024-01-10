/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace testing;

[TestClass]
public class UnitTestErrors
{
    #region ElementNotFoundException
    [TestMethod]
    public void Test_ElementNotFoundException_DefaultConstructor()
    {
        var exception = new ElementNotFoundException();
        Assert.IsNotNull(exception);
    }

    [TestMethod]
    public void Test_ElementNotFoundException_ConstructorWithMessage()
    {
        var message = "Test message";
        var exception = new ElementNotFoundException(message);
        Assert.AreEqual(message, exception.Message);
    }

    [TestMethod]
    public void Test_ElementNotFoundException_ConstructorWithMessageAndInnerException()
    {
        var message = "Test message";
        var innerException = new Exception("Inner exception");
        var exception = new ElementNotFoundException(message, innerException);
        Assert.AreEqual(message, exception.Message);
        Assert.AreEqual(innerException, exception.InnerException);
    }

    [TestMethod]
    public void Test_ElementNotFoundException_GetObjectData()
    {
        var exception = new ElementNotFoundException("Test message");
        var info = new SerializationInfo(
            typeof(ElementNotFoundException),
            new FormatterConverter()
        );
        var context = new StreamingContext();
        exception.GetObjectData(info, context);
        Assert.AreEqual("Test message", info.GetString("Message"));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Test_ElementNotFoundException_GetObjectDataWithNullInfo()
    {
        var exception = new ElementNotFoundException("Test message");
        var context = new StreamingContext();
        exception.GetObjectData(null, context);
    }

    [TestMethod]
    public void Test_ElementNotFoundException_GetDebuggerDisplay()
    {
        var message = "Test message";
        var exception = new ElementNotFoundException(message);
        var method = typeof(ElementNotFoundException).GetMethod(
            "GetDebuggerDisplay",
            BindingFlags.NonPublic | BindingFlags.Instance
        );
        var result = method?.Invoke(exception, null);
        Assert.AreEqual(exception.ToString(), result);
    }

    [TestMethod]
    public void Test_ElementNotFoundException_SerializationConstructor()
    {
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

        var exception = (ElementNotFoundException)
            FormatterServices.GetUninitializedObject(typeof(ElementNotFoundException));
        var constructor = typeof(ElementNotFoundException).GetConstructor(
            BindingFlags.NonPublic | BindingFlags.Instance,
            null,
            new[] { typeof(SerializationInfo), typeof(StreamingContext) },
            null
        );
        constructor?.Invoke(exception, new object[] { info, context });

        Assert.AreEqual(message, exception.Message);
        Assert.IsNotNull(exception.InnerException);
    }
    #endregion

    #region EmptyFileException
    [TestMethod]
    public void Test_EmptyFileException_DefaultConstructor()
    {
        var exception = new EmptyFileException();
        Assert.IsNotNull(exception);
    }

    [TestMethod]
    public void Test_EmptyFileException_ConstructorWithMessage()
    {
        var message = "Test message";
        var exception = new EmptyFileException(message);
        Assert.AreEqual(message, exception.Message);
    }

    [TestMethod]
    public void Test_EmptyFileException_ConstructorWithMessageAndInnerException()
    {
        var message = "Test message";
        var innerException = new Exception("Inner exception");
        var exception = new EmptyFileException(message, innerException);
        Assert.AreEqual(message, exception.Message);
        Assert.AreEqual(innerException, exception.InnerException);
    }

    [TestMethod]
    public void Test_EmptyFileException_GetObjectData()
    {
        var exception = new EmptyFileException("Test message");
        var info = new SerializationInfo(
            typeof(EmptyFileException),
            new FormatterConverter()
        );
        var context = new StreamingContext();
        exception.GetObjectData(info, context);
        Assert.AreEqual("Test message", info.GetString("Message"));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Test_EmptyFileException_GetObjectDataWithNullInfo()
    {
        var exception = new EmptyFileException("Test message");
        var context = new StreamingContext();
        exception.GetObjectData(null, context);
    }

    [TestMethod]
    public void Test_EmptyFileException_GetDebuggerDisplay()
    {
        var message = "Test message";
        var exception = new EmptyFileException(message);
        var method = typeof(EmptyFileException).GetMethod(
            "GetDebuggerDisplay",
            BindingFlags.NonPublic | BindingFlags.Instance
        );
        var result = method?.Invoke(exception, null);
        Assert.AreEqual(exception.ToString(), result);
    }

    [TestMethod]
    public void Test_EmptyFileException_SerializationConstructor()
    {
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

        var exception = (EmptyFileException)
            FormatterServices.GetUninitializedObject(typeof(EmptyFileException));
        var constructor = typeof(EmptyFileException).GetConstructor(
            BindingFlags.NonPublic | BindingFlags.Instance,
            null,
            new[] { typeof(SerializationInfo), typeof(StreamingContext) },
            null
        );
        constructor?.Invoke(exception, new object[] { info, context });

        Assert.AreEqual(message, exception.Message);
        Assert.IsNotNull(exception.InnerException);
    }
    #endregion

    #region NotSupportedCharException
    [TestMethod]
    public void Test_NotSupportedCharException_DefaultConstructor()
    {
        var exception = new NotSupportedCharException();
        Assert.IsNotNull(exception);
    }

    [TestMethod]
    public void Test_NotSupportedCharException_ConstructorWithMessage()
    {
        var message = "Test message";
        var exception = new NotSupportedCharException(message);
        Assert.AreEqual(message, exception.Message);
    }

    [TestMethod]
    public void Test_NotSupportedCharException_ConstructorWithMessageAndInnerException()
    {
        var message = "Test message";
        var innerException = new Exception("Inner exception");
        var exception = new NotSupportedCharException(message, innerException);
        Assert.AreEqual(message, exception.Message);
        Assert.AreEqual(innerException, exception.InnerException);
    }

    [TestMethod]
    public void Test_NotSupportedCharException_GetObjectData()
    {
        var exception = new NotSupportedCharException("Test message");
        var info = new SerializationInfo(
            typeof(NotSupportedCharException),
            new FormatterConverter()
        );
        var context = new StreamingContext();
        exception.GetObjectData(info, context);
        Assert.AreEqual("Test message", info.GetString("Message"));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Test_NotSupportedCharException_GetObjectDataWithNullInfo()
    {
        var exception = new NotSupportedCharException("Test message");
        var context = new StreamingContext();
        exception.GetObjectData(null, context);
    }

    [TestMethod]
    public void Test_NotSupportedCharException_GetDebuggerDisplay()
    {
        var message = "Test message";
        var exception = new NotSupportedCharException(message);
        var method = typeof(NotSupportedCharException).GetMethod(
            "GetDebuggerDisplay",
            BindingFlags.NonPublic | BindingFlags.Instance
        );
        var result = method?.Invoke(exception, null);
        Assert.AreEqual(exception.ToString(), result);
    }

    [TestMethod]
    public void Test_NotSupportedCharException_SerializationConstructor()
    {
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

        var exception = (NotSupportedCharException)
            FormatterServices.GetUninitializedObject(typeof(NotSupportedCharException));
        var constructor = typeof(NotSupportedCharException).GetConstructor(
            BindingFlags.NonPublic | BindingFlags.Instance,
            null,
            new[] { typeof(SerializationInfo), typeof(StreamingContext) },
            null
        );
        constructor?.Invoke(exception, new object[] { info, context });

        Assert.AreEqual(message, exception.Message);
        Assert.IsNotNull(exception.InnerException);
    }
    #endregion
}
