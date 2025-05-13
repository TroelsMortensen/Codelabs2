using MdToHtmlConversion.Transformers;

namespace MdToHtmlConversion;

public static class MasterConverter
{
    public static string ConvertMarkdownToHtml(string markdown)
    {
        List<ITransformer> converters = new List<ITransformer>
        {
            new MarkdownToHtmlTransformer(),
            new StepNumberCircleTransformer()
        };

        string finalHtml = converters
            .Aggregate(
                markdown,
                (currentHtml, converter) => converter.Handle(currentHtml)
            );

        return finalHtml;
    }
}