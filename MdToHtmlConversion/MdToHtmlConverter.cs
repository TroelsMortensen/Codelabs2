namespace MdToHtmlConversion;

public static class MasterConverter
{
    public static string ConvertMarkdownToHtml(string markdown)
    {
        List<IConverter> converters = new List<IConverter>
        {
            new MarkdownToHtmlConverter()
        };

        string finalHtml = converters
            .Aggregate(
                markdown,
                (currentHtml, converter) => converter.Handle(currentHtml)
            );

        return finalHtml;
    }
}