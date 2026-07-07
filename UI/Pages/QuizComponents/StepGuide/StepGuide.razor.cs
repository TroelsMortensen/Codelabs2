using MdToHtmlConversion.Models.Segments.Quiz;
using Microsoft.AspNetCore.Components;

namespace UI.Pages.QuizComponents.StepGuide;

public partial class StepGuide : ComponentBase
{
    [Parameter, EditorRequired] public StepGuideSegment Data { get; set; } = null!;

    private StepGuideSegment? _initializedData;
    private int _currentIndex;

    private bool HasValidData => Data.Details.Count > 0;
    private bool IsFirstStep => _currentIndex == 0;
    private bool IsLastStep => _currentIndex == Data.Details.Count - 1;
    private StepGuideItem? CurrentStep => HasValidData ? Data.Details[_currentIndex] : null;

    protected override void OnParametersSet()
    {
        if (ReferenceEquals(_initializedData, Data))
            return;

        _initializedData = Data;
        _currentIndex = 0;
    }

    private void GoToPreviousStep()
    {
        if (_currentIndex <= 0)
            return;

        _currentIndex--;
    }

    private void GoToNextStep()
    {
        if (_currentIndex >= Data.Details.Count - 1)
            return;

        _currentIndex++;
    }

    private void GoToStep(int index)
    {
        if (index < 0 || index >= Data.Details.Count)
            return;

        _currentIndex = index;
    }

    private string GetStepBadge()
    {
        if (IsFirstStep)
            return "Introduction";
        if (IsLastStep)
            return "Conclusion";

        return $"Step {_currentIndex}";
    }
}
