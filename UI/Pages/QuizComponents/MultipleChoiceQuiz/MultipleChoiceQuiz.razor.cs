using MdToHtmlConversion.Models.Segments.Quiz;
using Microsoft.AspNetCore.Components;

namespace UI.Pages.QuizComponents.MultipleChoiceQuiz;

public partial class MultipleChoiceQuiz : ComponentBase
{
    [Parameter, EditorRequired] public MultipleChoiceQuizSegment Data { get; set; } = null!;

    private MultipleChoiceQuizSegment? _initializedData;
    private List<QuizOption> _displayOptions = [];
    private HashSet<int> _selectedIndices = [];
    private bool _isChecked;
    private bool? _wasCorrect;
    private bool _isValid;
    private int _correctCount;

    protected override void OnParametersSet()
    {
        if (ReferenceEquals(_initializedData, Data))
            return;

        _initializedData = Data;
        _correctCount = Data.Options.Count(o => o.IsCorrect);
        _isValid = _correctCount >= 1;
        _displayOptions = Data.Shuffle
            ? Data.Options.OrderBy(_ => Random.Shared.Next()).ToList()
            : Data.Options.ToList();
        _selectedIndices = [];
        _isChecked = false;
        _wasCorrect = null;
    }

    private void ToggleOption(int index)
    {
        if (_isChecked)
            return;

        if (!_selectedIndices.Remove(index))
            _selectedIndices.Add(index);
    }

    private void CheckAnswer()
    {
        if (_selectedIndices.Count == 0 || _isChecked)
            return;

        _isChecked = true;
        _wasCorrect = _displayOptions
            .Select((option, index) => option.IsCorrect == _selectedIndices.Contains(index))
            .All(match => match);
    }

    private string GetOptionCssClass(int index)
    {
        var classes = new List<string>();

        if (_selectedIndices.Contains(index))
            classes.Add("selected");

        if (!_isChecked)
            return string.Join(' ', classes);

        var option = _displayOptions[index];
        if (option.IsCorrect)
            classes.Add("correct");
        else if (_selectedIndices.Contains(index))
            classes.Add("incorrect");

        return string.Join(' ', classes);
    }
}
