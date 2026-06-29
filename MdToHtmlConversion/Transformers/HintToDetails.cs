using System.Text.RegularExpressions;
using MdToHtmlConversion.Models.Segments;

namespace MdToHtmlConversion.Transformers;

public class HintToDetails : ITransformer
{
    private const string Pattern = """<hint\s+title="(.*?)">\s*\r?\n(.*?)\r?\n?</hint>""";

    private const string Replacement = """
                                       <details>
                                           <summary>$1</summary>
                                       $2
                                       </details>
                                       """;

    public List<PageSegment> Handle(List<PageSegment> segments, string articleName) =>
        segments.Select(segment =>
            segment is HtmlSegment html
                ? html with { HtmlContent = Regex.Replace(html.HtmlContent, Pattern, Replacement, RegexOptions.Singleline) }
                : segment
        ).ToList();
}