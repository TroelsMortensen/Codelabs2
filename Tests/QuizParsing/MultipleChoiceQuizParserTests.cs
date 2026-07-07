using MdToHtmlConversion.Models.Segments;
using MdToHtmlConversion.Models.Segments.Quiz;
using MdToHtmlConversion.Transformers;

namespace Tests.QuizParsing;

public class MultipleChoiceQuizParserTests
{
    [Fact]
    public void QuizParser_Should_Capture_And_Deserialize_Json_Correctly()
    {
        var converter = new ConvertMarkdownToHtml();
        var markdown = $"<Quiz>\n{QuizBlockWithJson}\n</Quiz>";
        var input = new RawMarkdownSegment(markdown);

        var segments = converter.Handle([input], "");

        var quizSegment = segments.OfType<MultipleChoiceQuizSegment>().FirstOrDefault();

        Assert.NotNull(quizSegment);
        Assert.Equal("MultipleChoiceQuiz", quizSegment.Type);
        Assert.Equal(4, quizSegment.Options.Count);
        Assert.True(quizSegment.Shuffle);
        Assert.Contains("SOLID principles", quizSegment.Question);
        Assert.Equal(2, quizSegment.Options.Count(o => o.IsCorrect));
        Assert.Contains(quizSegment.Options, o => o.Text == "Single Responsibility Principle" && o.IsCorrect);
        Assert.Contains(quizSegment.Options, o => o.Text == "Don't Repeat Yourself" && !o.IsCorrect);
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
                                               "Type": "MultipleChoiceQuiz",
                                               "Question": "<p>Which of the following are SOLID principles?</p>",
                                               "Options": [
                                                 {
                                                   "Text": "Single Responsibility Principle",
                                                   "IsCorrect": true
                                                 },
                                                 {
                                                   "Text": "Open/Closed Principle",
                                                   "IsCorrect": true
                                                 },
                                                 {
                                                   "Text": "Dependency Inversion Pattern",
                                                   "IsCorrect": false
                                                 },
                                                 {
                                                   "Text": "Don't Repeat Yourself",
                                                   "IsCorrect": false
                                                 }
                                               ],
                                               "Shuffle": true,
                                               "Hint": "Two of these are named principles from the SOLID acronym.",
                                               "Explanation": "SRP and OCP are SOLID principles. DIP is close in name but the SOLID principle is Dependency Inversion Principle. DRY is a general guideline, not part of SOLID."
                                             }
                                             """;
}
