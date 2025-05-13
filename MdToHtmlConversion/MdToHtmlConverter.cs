using MdToHtmlConversion.Transformers;

namespace MdToHtmlConversion;

public static class MasterConverter
{
    public static string ConvertMarkdownToHtml(string markdown, string articleName)
    {
        List<ITransformer> converters = new List<ITransformer>
        {
            new MarkdownToHtmlTransformer(),
            new StepNumberCircleTransformer(),
            new ImageUrlFixer()
        };

        string finalHtml = converters
            .Aggregate(
                markdown,
                (currentHtml, converter) => converter.Handle(currentHtml, articleName)
            );

        return finalHtml;
    }
}