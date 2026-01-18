namespace NatLaRestTest.Bindings.Interfaces.Assertions;

public interface IHttpResponseAssertionBindings
{
    /// <summary>
    ///     Then step: Asserts that the current HTTP response exists and indicates success (2xx status).
    /// </summary>
    void ResponseIsSuccess();

    /// <summary>
    ///     Then step: Asserts that the current HTTP response exists and does not indicate success.
    /// </summary>
    void ResponseIsNotSuccess();

    /// <summary>
    ///     Then step: Asserts that the current HTTP response status code equals the expected value.
    /// </summary>
    /// <param name="code">The expected HTTP status code (e.g., 200).</param>
    void AssertResponseCode(int code);

    /// <summary>
    ///     Then step: Asserts that the current HTTP response status code does not equal the specified value.
    /// </summary>
    /// <param name="code">The HTTP status code that must not match.</param>
    void AssertResponseCodeIsNot(int code);
}