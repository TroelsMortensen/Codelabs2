using System.Text.RegularExpressions;
using MdToHtmlConversion.Models.Segments;

namespace MdToHtmlConversion.Transformers;

public class CircleStepNumbersInRed : ITransformer
{
    public List<PageSegment> Handle(List<PageSegment> segments, string articleName) =>
        segments.Select(segment =>
            segment is HtmlSegment htmlSegment
                ? htmlSegment with { HtmlContent = InsertCircle(htmlSegment.HtmlContent) }
                : segment
        ).ToList();

    private static string InsertCircle(string html)
    {
        Regex pattern = new(@"\(\(\d*\)\)");
        MatchCollection matchCollection = pattern.Matches(html);
        foreach (Match match in matchCollection)
        {
            string theMatch = match.Value;
            string stepNumber = theMatch.Replace("((", "").Replace("))", "");
            string replacementHtml = $"<span class=\"numberCircle\"><span>{stepNumber}</span></span>";
            html = html.Replace(theMatch, replacementHtml);
        }

        return html;
    }
}