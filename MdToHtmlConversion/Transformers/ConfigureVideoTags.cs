using System.Text.RegularExpressions;
using MdToHtmlConversion.Models.Segments;

namespace MdToHtmlConversion.Transformers;

public class ConfigureVideoTags : ITransformer
{
    public List<PageSegment> Handle(List<PageSegment> segments, string articleName) =>
        segments.Select(segment =>
            segment is HtmlSegment htmlSegment
                ? htmlSegment with { HtmlContent = VideoToIframe(htmlSegment.HtmlContent) }
                : segment).ToList();

    public static string VideoToIframe(string inputHtml) =>
        inputHtml
            .ReplaceDirectLinks()
            .ReplaceQueryLinks();
}

public static class StringExtensions
{
    private const string Replacement = """
                                       <div class="video-box">
                                       <p>
                                       <iframe src="https://youtube.com/embed/$1" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                                       </p>
                                       </div>
                                       """;

    public static string ReplaceDirectLinks(this string inputHtml) =>
        Regex.Replace(
            inputHtml,
            pattern: """<p><video\s+src="https:\/\/youtu\.be\/([a-zA-Z0-9_-]+)\"\s*><\/video><\/p>""",
            Replacement
        );

    public static string ReplaceQueryLinks(this string inputHtml) =>
        Regex.Replace(
            inputHtml,
            pattern: """<p><video\s+src="https:\/\/www.youtube\.com\/watch\?v=([a-zA-Z0-9_-]+)\"\s*><\/video><\/p>""",
            Replacement
        );
}