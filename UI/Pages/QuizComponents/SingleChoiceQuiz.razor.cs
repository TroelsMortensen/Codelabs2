using MdToHtmlConversion.Models.Segments.Quiz;
using Microsoft.AspNetCore.Components;

namespace UI.Pages.QuizComponents;

public partial class SingleChoiceQuiz : ComponentBase
{
    [Parameter] public SingleChoiceQuizSegment Data { get; set; }
}