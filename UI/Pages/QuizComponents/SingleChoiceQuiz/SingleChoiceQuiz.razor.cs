using MdToHtmlConversion.Models.Segments.Quiz;
using Microsoft.AspNetCore.Components;

namespace UI.Pages.QuizComponents.SingleChoiceQuiz;

public partial class SingleChoiceQuiz : ComponentBase
{
    [Parameter, EditorRequired] public SingleChoiceQuizSegment Data { get; set; } = null!;

    private readonly string _radioGroupName = Guid.NewGuid().ToString("N");
    private SingleChoiceQuizSegment? _initializedData;
    private List<QuizOption> _displayOptions = [];
    private int? _selectedIndex;
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
        _isValid = _correctCount == 1;
        _displayOptions = Data.Shuffle
            ? Data.Options.OrderBy(_ => Random.Shared.Next()).ToList()
            : Data.Options.ToList();
        _selectedIndex = null;
        _isChecked = false;
        _wasCorrect = null;
    }

    private void SelectOption(int index)
    {
        if (_isChecked)
            return;

        _selectedIndex = index;
    }

    private void CheckAnswer()
    {
        if (_selectedIndex is null || _isChecked)
            return;

        _isChecked = true;
        _wasCorrect = _displayOptions[_selectedIndex.Value].IsCorrect;
    }

    private string GetOptionCssClass(int index)
    {
        var classes = new List<string>();

        if (_selectedIndex == index)
            classes.Add("selected");

        if (!_isChecked)
            return string.Join(' ', classes);

        var option = _displayOptions[index];
        if (option.IsCorrect)
            classes.Add("correct");
        else if (_selectedIndex == index)
            classes.Add("incorrect");

        return string.Join(' ', classes);
    }
}
