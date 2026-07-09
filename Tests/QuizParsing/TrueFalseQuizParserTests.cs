using MdToHtmlConversion.Models.Segments;
using MdToHtmlConversion.Models.Segments.Quiz;
using MdToHtmlConversion.Transformers;

namespace Tests.QuizParsing;

public class TrueFalseQuizParserTests
{
    [Fact]
    public void QuizParser_Should_Capture_And_Deserialize_Json_Correctly()
    {
        var converter = new ConvertMarkdownToHtml();
        var markdown = $"<Quiz>\n{QuizBlockWithJson}\n</Quiz>";
        var input = new RawMarkdownSegment(markdown);

        var segments = converter.Handle([input], "");

        var quizSegment = segments.OfType<TrueFalseQuizSegment>().FirstOrDefault();

        Assert.NotNull(quizSegment);
        Assert.Equal("TrueFalseQuiz", quizSegment.Type);
        Assert.Equal(3, quizSegment.Statements.Count);
        Assert.Contains(quizSegment.Statements, s => s.Text.Contains("boolean") && s.IsCorrect);
        Assert.Contains(quizSegment.Statements, s => s.Text.Contains("char") && !s.IsCorrect);
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
                                               "Type": "TrueFalseQuiz",
                                               "Statements": [
                                                 {
                                                   "Text": "boolean represents true or false.",
                                                   "IsCorrect": true
                                                 },
                                                 {
                                                   "Text": "char is a single 16-bit Unicode character.",
                                                   "IsCorrect": false
                                                 },
                                                 {
                                                   "Text": "decimal is a floating-point type with binary precision only.",
                                                   "IsCorrect": false
                                                 }
                                               ]
                                             }
                                             """;
}
