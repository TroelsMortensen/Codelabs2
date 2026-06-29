namespace MdToHtmlConversion.Models.Segments.Quiz;

public record QuizSegment : PageSegment;

public record SingleChoiceQuiz(string Question, List<Answer> Answers) : QuizSegment;

public record Answer(string text, bool IsCorrect);