using Markdig;

namespace MdToHtmlConversion;

public class MarkdownToHtmlConverter : IConverter
{
    public string Handle(string markdown)
    {
        var pipeline = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .Build();
        
        string html = Markdown.ToHtml(markdown, pipeline);
        return html;
    }
}