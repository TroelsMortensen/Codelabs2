using MdToHtmlConversion.Models.Segments;
using MdToHtmlConversion.Models.Segments.Quiz;
using MdToHtmlConversion.Transformers;

namespace Tests.QuizParsing;

public class StepGuideParserTests
{
    [Fact]
    public void QuizParser_Should_Capture_And_Deserialize_Json_Correctly()
    {
        var converter = new ConvertMarkdownToHtml();
        var markdown = $"<Quiz>\n{QuizBlockWithJson}\n</Quiz>";
        var input = new RawMarkdownSegment(markdown);

        var segments = converter.Handle([input], "");

        var quizSegment = segments.OfType<StepGuideSegment>().FirstOrDefault();

        Assert.NotNull(quizSegment);
        Assert.Equal("StepGuide", quizSegment.Type);
        Assert.Equal("World Capitals", quizSegment.Title);
        Assert.Equal(5, quizSegment.Details.Count);
        Assert.Contains(quizSegment.Details, d => d.Header == "Berlin" && d.Content == "<p>Berlin is the capital of Germany.</p>");
    }

    [Fact]
    public void QuizParser_Should_Handle_Mixed_Markdown_And_Quiz()
    {
        var converter = new ConvertMarkdownToHtml();
        var markdown = $"# Title\n<Quiz>\n{QuizBlockWithJson}\n</Quiz>\nSome text after.";
        var input = new RawMarkdownSegment(markdown);

        var segments = converter.Handle([input], "");

        Assert.Equal(4, segments.Count);
        Assert.IsType<HtmlSegment>(segments[0]);
        Assert.IsAssignableFrom<QuizSegment>(segments[1]);
        Assert.IsType<HtmlSegment>(segments[2]);
        Assert.IsType<HtmlSegment>(segments[3]);
    }

    [Fact]
    public void QuizParser_Should_Not_Capture_Quiz_Inside_Code_Blocks()
    {
        var converter = new ConvertMarkdownToHtml();
        var markdown = "```\n<Quiz>\nNot a real quiz\n</Quiz>\n```";
        var input = new RawMarkdownSegment(markdown);

        var segments = converter.Handle([input], "");

        Assert.DoesNotContain(segments, s => s is QuizSegment);
    }

    private const string QuizBlockWithJson = """
                                             {
                                               "Type": "StepGuide",
                                               "Title": "World Capitals",
                                               "Details": [
                                                 {
                                                   "Header": "This is the introduction to the quiz block.",
                                                   "Content": "<p>This guide introduces the reader to different capital cities of the world.</p>"
                                                 },
                                                 {
                                                   "Header": "Berlin",
                                                   "Content": "<p>Berlin is the capital of Germany.</p>"
                                                 },
                                                 {
                                                   "Header": "Paris",
                                                   "Content": "<p>Paris is the capital of France.</p>"
                                                 },
                                                 {
                                                   "Header": "London",
                                                   "Content": "<p>London is the capital of England.</p>"
                                                 },
                                                 {
                                                   "Header": "Conclusion",
                                                   "Content": "<p>This guide has introduced the reader to different capital cities of the world.</p>"
                                                 }
                                               ]
                                             }
                                             """;
}
