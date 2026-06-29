using MdToHtmlConversion.Models.Segments;

namespace MdToHtmlConversion.Models.Quizz;

public interface QuizSegment : PageSegment;


public record SingleChoiceQuiz(string Question, List<Answer> Answers) : QuizSegment;

public record Answer(string text, bool IsCorrect);