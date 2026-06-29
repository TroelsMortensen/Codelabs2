using Markdig;
using MdToHtmlConversion.Models.Segments;

namespace MdToHtmlConversion.Transformers;

public class ConvertMarkdownToHtml : ITransformer
{
    public List<PageSegment> Handle(List<PageSegment> segments, string articleName)
    {
        // Assuming 'segments' contains one big raw Markdown segment initially
        var rawMarkdown = ((RawMarkdownSegment)segments[0]).Markdown;

        var html = Markdown.ToHtml(rawMarkdown, new MarkdownPipelineBuilder().UseAdvancedExtensions().Build());

        return [new HtmlSegment(html)];
    }
}