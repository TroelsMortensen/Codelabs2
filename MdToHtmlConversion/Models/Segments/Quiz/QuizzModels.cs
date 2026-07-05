namespace MdToHtmlConversion.Models.Segments.Quiz;

public abstract record QuizSegment(string Type) : PageSegment;

public record SingleChoiceQuizSegment(
    string Question, 
    List<QuizOption> Options, 
    bool Shuffle = false,
    string? Hint = null, 
    string? Explanation = null
) : QuizSegment("SingleChoiceQuiz");

public record QuizOption(string Text, bool IsCorrect);

public record FlashCard(string Front, string Back);

public record FlashCardSetSegment(
    List<FlashCard> Cards,
    string? Title = null
) : QuizSegment("FlashCardSet");