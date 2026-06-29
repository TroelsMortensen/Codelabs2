using HtmlAgilityPack;
using MdToHtmlConversion.Models.Segments;

namespace MdToHtmlConversion.Transformers;

public class LinkOpensInNewTab : ITransformer
{
    // I guess my AI did not like my suggestion of just continuing with reg-ex replacement.

    private const string LinkIcon = "↗";
    private const string WrapperNode = "link-transform-root";

    public List<PageSegment> Handle(List<PageSegment> segments, string articleName) =>
        segments.Select(segment =>
            segment is HtmlSegment htmlSegment
                ? htmlSegment with { HtmlContent = UpdateLinks(htmlSegment.HtmlContent) }
                : segment
        ).ToList();

    private static string UpdateLinks(string html)
    {
        HtmlDocument document = new();
        document.LoadHtml($"<{WrapperNode}>{html}</{WrapperNode}>"); // to ensure single root element of the passed in html

        HtmlNode root = document.DocumentNode.Element(WrapperNode);
        root.Descendants("a")
            .ToList()
            .ForEach(link =>
            {
                link.SetAttributeValue("target", "_blank");
                EnsureSecureRelAttribute(link);
                AppendIconIfMissing(link, document);
            });

        return root.InnerHtml;
    }

    private static void EnsureSecureRelAttribute(HtmlNode link)
    {
        HashSet<string> relValues = link
            .GetAttributeValue("rel", string.Empty)
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(value => value.ToLowerInvariant())
            .ToHashSet();

        relValues.Add("noopener");
        relValues.Add("noreferrer");

        link.SetAttributeValue("rel", string.Join(" ", relValues));
    }

    private static void AppendIconIfMissing(HtmlNode link, HtmlDocument document)
    {
        string text = link.InnerText?.TrimEnd() ?? string.Empty;

        if (string.IsNullOrEmpty(text) || text.EndsWith(LinkIcon, StringComparison.Ordinal))
        {
            return;
        }

        link.AppendChild(document.CreateTextNode($" {LinkIcon}"));
    }
}