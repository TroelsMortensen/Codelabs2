using MdToHtmlConversion.Models.Segments;
using MdToHtmlConversion.Models.Segments.Quiz;
using MdToHtmlConversion.Transformers;

namespace Tests.QuizParsing;

public class ExpandableDetailsParserTests
{
    [Fact]
    public void QuizParser_Should_Capture_And_Deserialize_Json_Correctly()
    {
        var converter = new ConvertMarkdownToHtml();
        var markdown = $"<Quiz>\n{QuizBlockWithJson}\n</Quiz>";
        var input = new RawMarkdownSegment(markdown);

        var segments = converter.Handle([input], "");

        var quizSegment = segments.OfType<ExpandableDetailsSegment>().FirstOrDefault();

        Assert.NotNull(quizSegment);
        Assert.Equal("ExpandableDetails", quizSegment.Type);
        Assert.Equal(3, quizSegment.Details.Count);
        Assert.Contains(quizSegment.Details, d => d.Header == "What is the capital of France?" && d.Content == "<p>Paris</p>");
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
                                               "Type": "ExpandableDetails",
                                               "Details": [
                                                 {
                                                   "Header": "What is the capital of France?",
                                                   "Content": "<p>Paris</p>"
                                                 },
                                                 {
                                                   "Header": "What does SOLID stand for?",
                                                   "Content": "<p>Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, and Dependency Inversion.</p>"
                                                 },
                                                 {
                                                   "Header": "Why use expandable sections?",
                                                   "Content": "<p>They help keep pages scannable while still making detailed explanations available on demand.</p>"
                                                 }
                                               ]
                                             }
                                             """;
}
