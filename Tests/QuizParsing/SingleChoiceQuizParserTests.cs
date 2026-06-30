using MdToHtmlConversion.Models.Segments;
using MdToHtmlConversion.Models.Segments.Quiz;
using MdToHtmlConversion.Transformers;

namespace Tests.QuizParsing;

public class SingleChoiceQuizParserTests
{
    
    [Fact]
    public void QuizParser_Should_Capture_And_Deserialize_Json_Correctly()
    {
      // Arrange
      var converter = new ConvertMarkdownToHtml();
      var markdown = $"<Quiz>\n{QuizBlockWithJson}\n</Quiz>";
      var input = new RawMarkdownSegment(markdown);

      // Act
      var segments = converter.Handle([input], "");

      // Assert
      var quizSegment = segments.OfType<SingleChoiceQuizSegment>().FirstOrDefault();
    
      Assert.NotNull(quizSegment);
      Assert.Equal("SingleChoiceQuiz", quizSegment.Type);
      Assert.Equal(3, quizSegment.Options.Count);
      Assert.True(quizSegment.Shuffle);
      Assert.Contains("open for extension", quizSegment.Question);
    
      // Verify specific option content
      Assert.Contains(quizSegment.Options, o => o.Text == "OCP" && o.IsCorrect);
    }

    [Fact]
    public void QuizParser_Should_Handle_Mixed_Markdown_And_Quiz()
    {
      // Arrange
      var converter = new ConvertMarkdownToHtml();
      var markdown = $"# Title\n<Quiz>\n{QuizBlockWithJson}\n</Quiz>\nSome text after.";
      var input = new RawMarkdownSegment(markdown);

      // Act
      var segments = converter.Handle([input], "");

      // Assert
      Assert.Equal(4, segments.Count); // [Header, Quiz, Paragraph]
      Assert.IsType<HtmlSegment>(segments[0]); // Header
      Assert.IsAssignableFrom<QuizSegment>(segments[1]); // Quiz
      Assert.IsType<HtmlSegment>(segments[2]); // Paragraph
      Assert.IsType<HtmlSegment>(segments[3]); // Paragraph
    }

    [Fact]
    public void QuizParser_Should_Not_Capture_Quiz_Inside_Code_Blocks()
    {
      // Arrange
      var converter = new ConvertMarkdownToHtml();
      var markdown = "```\n<Quiz>\nNot a real quiz\n</Quiz>\n```";
      var input = new RawMarkdownSegment(markdown);

      // Act
      var segments = converter.Handle([input], "");

      // Assert
      // Should only contain the code block as HTML, no QuizSegment
      Assert.DoesNotContain(segments, s => s is QuizSegment);
    }


    private const string QuizBlockWithJson = """
                                             {
                                               "Type": "SingleChoiceQuiz",
                                               "Question": "<p>Which principle states that software entities should be open for extension but closed for modification?</p>",
                                               "Options": [
                                                 {
                                                   "Text": "SRP",
                                                   "IsCorrect": false
                                                 },
                                                 {
                                                   "Text": "OCP",
                                                   "IsCorrect": true
                                                 },
                                                 {
                                                   "Text": "LSP",
                                                   "IsCorrect": false
                                                 }
                                               ],
                                               "Shuffle": true,
                                               "Hint": "Think about adding new functionality without touching existing code.",
                                               "Explanation": "The Open/Closed Principle (OCP) is the second of the SOLID principles."
                                             }
                                             """;

}