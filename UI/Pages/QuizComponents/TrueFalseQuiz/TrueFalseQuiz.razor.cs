using MdToHtmlConversion.Models.Segments.Quiz;
using Microsoft.AspNetCore.Components;

namespace UI.Pages.QuizComponents.TrueFalseQuiz;

public partial class TrueFalseQuiz : ComponentBase
{
    [Parameter, EditorRequired] public TrueFalseQuizSegment Data { get; set; } = null!;

    private TrueFalseQuizSegment? _initializedData;
    private List<bool?> _selectedAnswers = [];
    private bool _isValid;
    private bool _isChecked;
    private bool _allCorrect;
    private int _correctCount;

    private bool CanSubmit => _selectedAnswers.Count > 0 && _selectedAnswers.All(answer => answer.HasValue);

    protected override void OnParametersSet()
    {
        if (ReferenceEquals(_initializedData, Data))
            return;

        _initializedData = Data;
        _isValid = Data.Statements.Count > 0;
        _selectedAnswers = Data.Statements.Select(_ => (bool?)null).ToList();
        _isChecked = false;
        _allCorrect = false;
        _correctCount = 0;
    }

    private void SelectAnswer(int statementIndex, bool value)
    {
        if (_isChecked)
            return;

        _selectedAnswers[statementIndex] = value;
    }

    private void CheckAnswers()
    {
        if (_isChecked || !CanSubmit)
            return;

        _isChecked = true;
        _correctCount = Data.Statements
            .Select((statement, index) => statement.IsCorrect == _selectedAnswers[index])
            .Count(isCorrect => isCorrect);
        _allCorrect = _correctCount == Data.Statements.Count;
    }

    private string GetRowCssClass(int index)
    {
        if (!_isChecked)
            return string.Empty;

        return Data.Statements[index].IsCorrect == _selectedAnswers[index]
            ? "correct"
            : "incorrect";
    }
}
