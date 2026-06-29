namespace MdToHtmlConversion.Models.Segments.Quiz;

public interface IQuizSegment : IPageSegment;

public record SingleChoiceQuiz(string Question, List<Answer> Answers) : IQuizSegment;

public record Answer(string text, bool IsCorrect);