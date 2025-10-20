using Markdig;

namespace MdToHtmlConversion.Transformers;

public class ConvertMarkdownToHtml : ITransformer
{
    public string Handle(string markdown, string articleName) =>
        Markdown
            .ToHtml(
                markdown,
                pipeline: new MarkdownPipelineBuilder()
                    .UseAdvancedExtensions()
                    .Build()
            );
}