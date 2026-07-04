using MdToHtmlConversion.Models.Segments;
using MdToHtmlConversion.Models.Segments.Quiz;
using MdToHtmlConversion.Transformers;

namespace Tests;

public class HtmlSegmentMergerTests
{
    private readonly MergeHtmlSegments _merger = new();

    [Fact]
    public void Handle_WhenListIsEmpty_ReturnsEmptyList()
    {
        List<PageSegment> result = _merger.Handle([], "ignored");

        Assert.Empty(result);
    }

    [Fact]
    public void Handle_WhenSingleHtmlSegment_ReturnsSingleSegmentWithSameContent()
    {
        List<PageSegment> input = [new HtmlSegment("<p>one</p>")];

        List<PageSegment> result = _merger.Handle(input, "ignored");

        Assert.Single(result);
        Assert.Equal("<p>one</p>", ((HtmlSegment)result[0]).HtmlContent);
        AssertHtmlContentPreserved(input, result);
    }

    [Fact]
    public void Handle_WhenConsecutiveHtmlSegments_MergesIntoOneSegment()
    {
        List<PageSegment> input =
        [
            new HtmlSegment("<p>a</p>"),
            new HtmlSegment("<p>b</p>"),
            new HtmlSegment("<p>c</p>")
        ];

        List<PageSegment> result = _merger.Handle(input, "ignored");

        Assert.Single(result);
        Assert.Equal("<p>a</p><p>b</p><p>c</p>", ((HtmlSegment)result[0]).HtmlContent);
        AssertHtmlContentPreserved(input, result);
    }

    [Fact]
    public void Handle_WhenHtmlSegmentsSeparatedByNonHtml_MergesEachRunSeparately()
    {
        SingleChoiceQuizSegment quiz = new("Question?", [new QuizOption("Answer", true)]);
        RawMarkdownSegment raw = new("# raw");
        List<PageSegment> input =
        [
            new HtmlSegment("<h1>"),
            new HtmlSegment("</h1>"),
            quiz,
            new HtmlSegment("<p>1</p>"),
            new HtmlSegment("<p>2</p>"),
            raw,
            new HtmlSegment("<footer/>")
        ];

        List<PageSegment> result = _merger.Handle(input, "ignored");

        Assert.Equal(5, result.Count);
        Assert.Equal("<h1></h1>", ((HtmlSegment)result[0]).HtmlContent);
        Assert.Same(quiz, result[1]);
        Assert.Equal("<p>1</p><p>2</p>", ((HtmlSegment)result[2]).HtmlContent);
        Assert.Same(raw, result[3]);
        Assert.Equal("<footer/>", ((HtmlSegment)result[4]).HtmlContent);
        AssertHtmlContentPreserved(input, result);
    }

    [Fact]
    public void Handle_WhenNoHtmlSegments_ReturnsSameSegmentsUnchanged()
    {
        SingleChoiceQuizSegment quiz = new("Question?", [new QuizOption("Answer", true)]);
        RawMarkdownSegment raw = new("# title");
        List<PageSegment> input = [quiz, raw];

        List<PageSegment> result = _merger.Handle(input, "ignored");

        Assert.Equal(2, result.Count);
        Assert.Same(quiz, result[0]);
        Assert.Same(raw, result[1]);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    public void Handle_WhenOnlyConsecutiveHtmlSegments_CollapsesToSingleSegment(int segmentCount)
    {
        List<PageSegment> input = Enumerable.Range(1, segmentCount)
            .Select(i => (PageSegment)new HtmlSegment($"<span>{i}</span>"))
            .ToList();

        List<PageSegment> result = _merger.Handle(input, "ignored");

        Assert.Single(result);
        AssertHtmlContentPreserved(input, result);
    }

    [Fact]
    public void Handle_WhenAlternatingHtmlAndNonHtml_DoesNotMergeAcrossBoundaries()
    {
        SingleChoiceQuizSegment quiz = new("Question?", [new QuizOption("Answer", true)]);
        List<PageSegment> input =
        [
            new HtmlSegment("<p>1</p>"),
            quiz,
            new HtmlSegment("<p>2</p>"),
            new RawMarkdownSegment("# raw"),
            new HtmlSegment("<p>3</p>")
        ];

        List<PageSegment> result = _merger.Handle(input, "ignored");

        Assert.Equal(5, result.Count);
        Assert.IsType<HtmlSegment>(result[0]);
        Assert.IsAssignableFrom<QuizSegment>(result[1]);
        Assert.IsType<HtmlSegment>(result[2]);
        Assert.IsType<RawMarkdownSegment>(result[3]);
        Assert.IsType<HtmlSegment>(result[4]);
        AssertHtmlContentPreserved(input, result);
    }

    [Fact]
    public void Handle_PreservesTotalHtmlContent_ForVariousSegmentPatterns()
    {
        List<List<PageSegment>> patterns =
        [
            [new HtmlSegment("a"), new HtmlSegment("b")],
            [new HtmlSegment("a"), new RawMarkdownSegment("x"), new HtmlSegment("b")],
            [new HtmlSegment("a"), new HtmlSegment("b"), new HtmlSegment("c"), new RawMarkdownSegment("x")],
            [new RawMarkdownSegment("x"), new HtmlSegment("a"), new HtmlSegment("b")],
            [new HtmlSegment("<div>"), new HtmlSegment("content"), new HtmlSegment("</div>")]
        ];

        foreach (List<PageSegment> input in patterns)
        {
            List<PageSegment> result = _merger.Handle(input, "ignored");
            AssertHtmlContentPreserved(input, result);
        }
    }

    private static void AssertHtmlContentPreserved(List<PageSegment> input, List<PageSegment> result)
    {
        Assert.Equal(ConcatenateHtmlContent(input), ConcatenateHtmlContent(result));
    }

    private static string ConcatenateHtmlContent(IEnumerable<PageSegment> segments) =>
        string.Concat(segments.OfType<HtmlSegment>().Select(segment => segment.HtmlContent));
}
