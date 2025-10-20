using MdToHtmlConversion.Transformers;
using Xunit.Abstractions;

namespace Tests.HtmlTransformers;

public class VideoToIframeTests
{
    private readonly ITestOutputHelper testOutputHelper;

    public VideoToIframeTests(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void CanConvertVideoToIframe()
    {
        string inputHtml =@"
            <p>Some content before</p>
            <video src=""https://youtu.be/6BwybLqMa34""></video>
            <p>Some content after</p>
            <video src=""https://youtu.be/dQw4w9WgXcQ""></video>";
        
        // string expectedHtml = "<iframe src=\"https://youtube.com/embed/12345\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture\" allowfullscreen></iframe>";

        string result = ConfigureVideoTags.VideoToIframe(inputHtml);

        testOutputHelper.WriteLine(result);
    }
}