using Markdig;

namespace MdToHtmlConversion.Transformers;

public class MarkdownToHtmlTransformer : ITransformer
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