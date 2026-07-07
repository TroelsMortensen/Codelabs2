using MdToHtmlConversion.Models.Segments.Quiz;
using Microsoft.AspNetCore.Components;

namespace UI.Pages.QuizComponents.MatchPair;

public partial class MatchPair : ComponentBase
{
    [Parameter, EditorRequired] public MatchPairSegment Data { get; set; } = null!;

    private sealed record PoolItem(int Id, int OriginalIndex, string Text);

    private sealed record UserPair(PoolItem Prompt, PoolItem Answer);

    private MatchPairSegment? _initializedData;
    private List<PoolItem> _unpairedPrompts = [];
    private List<PoolItem> _unpairedAnswers = [];
    private List<UserPair> _pairedItems = [];
    private int? _selectedPromptId;
    private int? _selectedAnswerId;
    private bool _isChecked;
    private bool? _wasCorrect;
    private int _correctCount;
    private int _nextItemId;

    protected override void OnParametersSet()
    {
        if (ReferenceEquals(_initializedData, Data))
            return;

        _initializedData = Data;
        _nextItemId = 0;
        _unpairedPrompts = Data.Pairs
            .Select((pair, index) => new PoolItem(_nextItemId++, index, pair.Prompt))
            .OrderBy(_ => Random.Shared.Next())
            .ToList();
        _unpairedAnswers = Data.Pairs
            .Select((pair, index) => new PoolItem(_nextItemId++, index, pair.Answer))
            .OrderBy(_ => Random.Shared.Next())
            .ToList();
        _pairedItems = [];
        _selectedPromptId = null;
        _selectedAnswerId = null;
        _isChecked = false;
        _wasCorrect = null;
        _correctCount = 0;
    }

    private bool IsValid => Data.Pairs.Count > 0;

    private bool AllPaired => _unpairedPrompts.Count == 0 && _unpairedAnswers.Count == 0;

    private void ClickPrompt(int id)
    {
        if (_isChecked)
            return;

        if (_selectedPromptId == id)
        {
            _selectedPromptId = null;
            return;
        }

        _selectedPromptId = id;

        if (_selectedAnswerId is not null)
            TryCreatePair();
    }

    private void ClickAnswer(int id)
    {
        if (_isChecked)
            return;

        if (_selectedAnswerId == id)
        {
            _selectedAnswerId = null;
            return;
        }

        _selectedAnswerId = id;

        if (_selectedPromptId is not null)
            TryCreatePair();
    }

    private void TryCreatePair()
    {
        if (_selectedPromptId is null || _selectedAnswerId is null)
            return;

        var prompt = _unpairedPrompts.FirstOrDefault(p => p.Id == _selectedPromptId);
        var answer = _unpairedAnswers.FirstOrDefault(a => a.Id == _selectedAnswerId);

        if (prompt is null || answer is null)
            return;

        _unpairedPrompts.Remove(prompt);
        _unpairedAnswers.Remove(answer);
        _pairedItems.Add(new UserPair(prompt, answer));
        _selectedPromptId = null;
        _selectedAnswerId = null;
    }

    private void UndoPair(UserPair pair)
    {
        if (_isChecked)
            return;

        _pairedItems.Remove(pair);
        _unpairedPrompts.Add(pair.Prompt);
        _unpairedAnswers.Add(pair.Answer);
        _selectedPromptId = null;
        _selectedAnswerId = null;
    }

    private void CheckAnswer()
    {
        if (!AllPaired || _isChecked)
            return;

        _isChecked = true;
        _correctCount = _pairedItems.Count(p => p.Prompt.OriginalIndex == p.Answer.OriginalIndex);
        _wasCorrect = _correctCount == Data.Pairs.Count;
    }

    private string GetPromptCssClass(PoolItem item)
    {
        var classes = new List<string> { "match-piece-prompt" };
        if (_selectedPromptId == item.Id)
            classes.Add("selected");
        return string.Join(' ', classes);
    }

    private string GetAnswerCssClass(PoolItem item)
    {
        var classes = new List<string> { "match-piece-answer" };
        if (_selectedAnswerId == item.Id)
            classes.Add("selected");
        return string.Join(' ', classes);
    }

    private string GetPairedRowCssClass(UserPair pair)
    {
        if (!_isChecked)
            return "match-pair-row";

        var isCorrect = pair.Prompt.OriginalIndex == pair.Answer.OriginalIndex;
        return isCorrect ? "match-pair-row correct" : "match-pair-row incorrect";
    }
}
