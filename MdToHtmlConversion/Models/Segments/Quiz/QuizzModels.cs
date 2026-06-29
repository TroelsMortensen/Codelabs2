namespace MdToHtmlConversion.Models.Segments.Quiz;

public record QuizSegment : PageSegment;

public record SingleChoiceQuizSegment(string Question, List<Answer> Answers) : QuizSegment;

public record Answer(string text, bool IsCorrect);