using MdToHtmlConversion.Models.Segments;

namespace MdToHtmlConversion.Transformers;

public class AddLinesToCodeBlocks : ITransformer
{
    public List<PageSegment> Handle(List<PageSegment> segments, string articleName) =>
        segments.Select(segment =>
                segment is HtmlSegment htmlSegment
                    ? htmlSegment with { HtmlContent = htmlSegment.HtmlContent.Replace("class=\"language-", "class=\"line-numbers language-") }
                    : segment)
            .ToList();
}