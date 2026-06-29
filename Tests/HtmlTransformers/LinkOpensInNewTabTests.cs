using System.Text.RegularExpressions;
using MdToHtmlConversion.Models.Segments;
using MdToHtmlConversion.Transformers;

namespace Tests.HtmlTransformers;

public class LinkOpensInNewTabTests
{
    [Fact]
    public void Handle_WhenHtmlContainsMultipleLinks_UpdatesAllLinks()
    {
        string html = "<p><a href=\"https://a.com\">First</a> and <a href=\"https://b.com\">Second</a></p>";

        List<PageSegment> result = new LinkOpensInNewTab().Handle([new HtmlSegment(html)], "ignored");

        Assert.Equal(2, Regex.Matches(((HtmlSegment)result[0]).HtmlContent, "target=\"_blank\"").Count);
        Assert.Equal(2, Regex.Matches(((HtmlSegment)result[0]).HtmlContent, "rel=\"noopener noreferrer\"").Count);
        Assert.Contains(">First ↗</a>", ((HtmlSegment)result[0]).HtmlContent);
        Assert.Contains(">Second ↗</a>", ((HtmlSegment)result[0]).HtmlContent);
    }

    [Fact]
    public void Handle_WhenLinkHasExistingRel_PreservesRelAndAddsSecurityValues()
    {
        string html = "<a class=\"btn\" rel=\"author\" href=\"https://example.com\">Read more</a>";

        List<PageSegment> result = new LinkOpensInNewTab().Handle([new HtmlSegment(html)], "ignored");

        Assert.Contains("class=\"btn\"", ((HtmlSegment)result[0]).HtmlContent);
        Assert.Contains("target=\"_blank\"", ((HtmlSegment)result[0]).HtmlContent);
        Assert.Contains("rel=\"author noopener noreferrer\"", ((HtmlSegment)result[0]).HtmlContent);
        Assert.Contains(">Read more ↗</a>", ((HtmlSegment)result[0]).HtmlContent);
    }
}
