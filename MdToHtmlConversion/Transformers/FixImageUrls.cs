using System.Text.RegularExpressions;
using MdToHtmlConversion.Models.Segments;

namespace MdToHtmlConversion.Transformers;

public class FixImageUrls : ITransformer
{
    public List<PageSegment> Handle(List<PageSegment> segments, string articleName) =>
        segments.Select(segment =>
            segment is HtmlSegment htmlSegment
                ? htmlSegment with { HtmlContent = PrependBaseUrlToRelativeImgUrl(articleName, htmlSegment.HtmlContent) }
                : segment
        ).ToList();

    public static string PrependBaseUrlToRelativeImgUrl(string articleName, string input)
    {
        string prefix = "https://raw.githubusercontent.com/TroelsMortensen/Codelabs2/refs/heads/master/Articles/" + articleName + "/"; // TODO put this somewhere better

        string patternWhichTargetsSrcAndValue = @"(<img[^>]*\bsrc\s*=\s*"")([^""]+)(""[^>]*>)";

        string result = Regex.Replace(input, patternWhichTargetsSrcAndValue, m =>
        {
            string before = GetBeforeSrcUrl(m);
            string originalSrc = GetCurrentUrl(m);
            string after = GetAfterSrcUrl(m);

            if (originalSrc.StartsWith("http"))
            {
                return $"{before}{originalSrc}{after}";
            }

            return $"{before}{prefix}{originalSrc}{after}";
        }, RegexOptions.IgnoreCase);

        return result;
    }

    private static string GetBeforeSrcUrl(Match m) => m.Groups[1].Value;

    private static string GetCurrentUrl(Match m) => m.Groups[2].Value;

    private static string GetAfterSrcUrl(Match m) => m.Groups[3].Value;
}