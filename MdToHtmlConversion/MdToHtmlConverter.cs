using MdToHtmlConversion.Transformers;

namespace MdToHtmlConversion;

public static class MasterConverter
{
    public static string ConvertMarkdownToHtml(string markdown, string articleName)
    {
        List<ITransformer> converters =
        [
            new ConvertMarkdownToHtml(),
            new CircleStepNumbersInRed(),
            new FixImageUrls(),
            new AddLinesToCodeBlocks(),
            new HintToDetails()
        ];

        return converters
            .Aggregate(
                markdown,
                (currentHtml, converter) => converter.Handle(currentHtml, articleName)
            );
    }
}