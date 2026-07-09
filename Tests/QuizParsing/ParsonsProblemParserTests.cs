using MdToHtmlConversion.Models.Segments;
using MdToHtmlConversion.Models.Segments.Quiz;
using MdToHtmlConversion.Transformers;

namespace Tests.QuizParsing;

public class ParsonsProblemParserTests
{
    [Fact]
    public void QuizParser_Should_Capture_And_Deserialize_Json_Correctly()
    {
        var converter = new ConvertMarkdownToHtml();
        var markdown = $"<Quiz>\n{QuizBlockWithJson}\n</Quiz>";
        var input = new RawMarkdownSegment(markdown);

        var segments = converter.Handle([input], "");

        var quizSegment = segments.OfType<ParsonsProblemSegment>().FirstOrDefault();

        Assert.NotNull(quizSegment);
        Assert.Equal("ParsonsProblem", quizSegment.Type);
        Assert.Contains("valid Java method", quizSegment.Question);
        Assert.Equal(4, quizSegment.Lines.Count);
        Assert.Contains(quizSegment.Lines, l => l.Id == 1 && l.Content.Contains("public int sum"));
        Assert.Contains(quizSegment.Lines, l => l.Id == 4 && l.Content == "}");
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
                                               "Type": "ParsonsProblem",
                                               "Question": "Arrange the lines to create a valid Java method that returns the sum of two integers.",
                                               "Lines": [
                                                 { "Id": 1, "Content": "public int sum(int a, int b) {" },
                                                 { "Id": 2, "Content": "    int result = a + b;" },
                                                 { "Id": 3, "Content": "    return result;" },
                                                 { "Id": 4, "Content": "}" }
                                               ]
                                             }
                                             """;
}
