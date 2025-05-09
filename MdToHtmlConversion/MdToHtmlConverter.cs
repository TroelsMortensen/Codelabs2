using Markdig;

namespace MdToHtmlConversion;

public static class MdToHtmlConverter
{
    public static string ConvertMarkdownToHtml(string markdown)
    {
        // Use a Markdown library to convert the markdown to HTML
        var pipeline = new Markdig.MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .Build();

        List<IConverter> converters = new List<IConverter>
        {
        };
        
        return string.Empty;
    }
}