using System.Text;
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
        MergeSegmentsOfHints(segments).Select(
            Convert
        ).ToList();

    private static List<PageSegment> MergeSegmentsOfHints(List<PageSegment> segments)
    {
        List<PageSegment> result = new List<PageSegment>();
        bool isInHint = false;
        StringBuilder hintBuilder = new StringBuilder();

        foreach (PageSegment segment in segments)
        {
            if (segment is HtmlSegment htmlSegment)
            {
                if (isInHint && htmlSegment.HtmlContent.Trim().StartsWith("</hint", StringComparison.OrdinalIgnoreCase))
                {
                    isInHint = false;
                    hintBuilder.Append(htmlSegment.HtmlContent);
                    result.Add(new HtmlSegment(hintBuilder.ToString()));
                    hintBuilder.Clear();
                }
                else if (htmlSegment.HtmlContent.Trim().StartsWith("<hint", StringComparison.OrdinalIgnoreCase))
                {
                    isInHint = true;
                    hintBuilder.Append(htmlSegment.HtmlContent);
                }
                else if (isInHint)
                {
                    hintBuilder.Append(htmlSegment.HtmlContent);
                }
                else
                {
                    result.Add(segment);
                }
            }
            else
            {
                result.Add(segment);
            }
        }

        return result;
    }

    private static PageSegment Convert(PageSegment segment)
    {
        if (segment is HtmlSegment html)
        {
            HtmlSegment newSegment = html with { HtmlContent = Regex.Replace(html.HtmlContent, Pattern, Replacement, RegexOptions.Singleline) };
            return newSegment;
        }

        return segment;
    }
}