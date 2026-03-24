using System.Text.RegularExpressions;
using MdToHtmlConversion.Transformers;

namespace Tests.HtmlTransformers;

public class LinkOpensInNewTabTests
{
    [Fact]
    public void Handle_WhenHtmlContainsMultipleLinks_UpdatesAllLinks()
    {
        string html = "<p><a href=\"https://a.com\">First</a> and <a href=\"https://b.com\">Second</a></p>";

        string result = new LinkOpensInNewTab().Handle(html, "ignored");

        Assert.Equal(2, Regex.Matches(result, "target=\"_blank\"").Count);
        Assert.Equal(2, Regex.Matches(result, "rel=\"noopener noreferrer\"").Count);
        Assert.Contains(">First ↗</a>", result);
        Assert.Contains(">Second ↗</a>", result);
    }

    [Fact]
    public void Handle_WhenLinkHasExistingRel_PreservesRelAndAddsSecurityValues()
    {
        string html = "<a class=\"btn\" rel=\"author\" href=\"https://example.com\">Read more</a>";

        string result = new LinkOpensInNewTab().Handle(html, "ignored");

        Assert.Contains("class=\"btn\"", result);
        Assert.Contains("target=\"_blank\"", result);
        Assert.Contains("rel=\"author noopener noreferrer\"", result);
        Assert.Contains(">Read more ↗</a>", result);
    }

    [Fact]
    public void Handle_WhenRunTwice_DoesNotDuplicateIndicatorOrAttributes()
    {
        string html = "<a href=\"https://example.com\">Docs</a>";
        LinkOpensInNewTab transformer = new();

        string once = transformer.Handle(html, "ignored");
        string twice = transformer.Handle(once, "ignored");

        Assert.Equal(once, twice);
        Assert.Single(Regex.Matches(twice, "target=\"_blank\""));
        Assert.Single(Regex.Matches(twice, "noopener"));
        Assert.Single(Regex.Matches(twice, "noreferrer"));
        Assert.Single(Regex.Matches(twice, "↗"));
    }
}
