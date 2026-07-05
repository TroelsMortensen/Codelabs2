using MdToHtmlConversion.Models.Segments;
using MdToHtmlConversion.Models.Segments.Quiz;
using MdToHtmlConversion.Transformers;

namespace Tests.QuizParsing;

public class FlashCardSetParserTests
{
    [Fact]
    public void QuizParser_Should_Capture_And_Deserialize_Json_Correctly()
    {
        var converter = new ConvertMarkdownToHtml();
        var markdown = $"<Quiz>\n{QuizBlockWithJson}\n</Quiz>";
        var input = new RawMarkdownSegment(markdown);

        var segments = converter.Handle([input], "");

        var quizSegment = segments.OfType<FlashCardSetSegment>().FirstOrDefault();

        Assert.NotNull(quizSegment);
        Assert.Equal("FlashCardSet", quizSegment.Type);
        Assert.Equal("General Knowledge", quizSegment.Title);
        Assert.Equal(3, quizSegment.Cards.Count);
        Assert.Contains(quizSegment.Cards, c => c.Front == "What is the capital of France?" && c.Back == "Paris");
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
                                               "Type": "FlashCardSet",
                                               "Title": "General Knowledge",
                                               "Cards": [
                                                 {
                                                   "Front": "What is the capital of France?",
                                                   "Back": "Paris"
                                                 },
                                                 {
                                                   "Front": "What is the result of 2 + 2?",
                                                   "Back": "4"
                                                 },
                                                 {
                                                   "Front": "What language runs in the browser?",
                                                   "Back": "JavaScript"
                                                 }
                                               ]
                                             }
                                             """;
}
