namespace MdToHtmlConversion.Models.Segments.Quiz;

public abstract record QuizSegment(string Type) : PageSegment;

public record SingleChoiceQuizSegment(
    string Question, 
    List<QuizOption> Options, 
    bool Shuffle = false,
    string? Hint = null, 
    string? Explanation = null
) : QuizSegment("SingleChoiceQuiz");

public record MultipleChoiceQuizSegment(
    string Question, 
    List<QuizOption> Options, 
    bool Shuffle = false,
    string? Hint = null, 
    string? Explanation = null
) : QuizSegment("MultipleChoiceQuiz");

public record QuizOption(string Text, bool IsCorrect);

public record FlashCard(string Front, string Back);

public record FlashCardSetSegment(
    List<FlashCard> Cards,
    string? Title = null
) : QuizSegment("FlashCardSet");

public record ExpandableDetailItem(string Header, string Content);

public record ExpandableDetailsSegment(
    List<ExpandableDetailItem> Details
) : QuizSegment("ExpandableDetails");

public record StepGuideSegment(
    string Title,
    List<StepGuideItem> Details
) : QuizSegment("StepGuide");

public record StepGuideItem(string Header, string Content);