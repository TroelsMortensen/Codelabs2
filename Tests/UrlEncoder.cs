using Xunit.Abstractions;

namespace Tests;

public class UrlEncoder
{
    private readonly ITestOutputHelper _testOutputHelper;

    public UrlEncoder(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void ShouldEncode()
    {
        string url = "UML/Analysis artefacts/Domain Model";
        var escapeDataString = Uri.EscapeDataString(url);
        _testOutputHelper.WriteLine(escapeDataString);
    }
}