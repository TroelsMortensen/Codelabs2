using MdToHtmlConversion.Models.Segments;
using MdToHtmlConversion.Transformers;

namespace MdToHtmlConversion;

public static class MasterConverter
{
    public static List<PageSegment> ConvertMarkdownToHtml(string markdown, string articleName)
    {
        List<PageSegment> segments = new() { new RawMarkdownSegment(markdown) };

        List<ITransformer> pipeline =
        [
            new ConvertMarkdownToHtml(),
            new MergeHtmlSegments(),
            new CircleStepNumbersInRed(),
            new FixImageUrls(),
            new AddLinesToCodeBlocks(),
            new MoveLineHighlightingAttributes(),
            new HintToDetails(),
            new ConfigureVideoTags(),
            new LinkOpensInNewTab()
        ];

        return pipeline
            .Aggregate(
                segments,
                (currentHtml, converter) => converter.Handle(currentHtml, articleName)
            );
    }
}