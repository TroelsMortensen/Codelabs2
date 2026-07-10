using MdToHtmlConversion.Models.Segments.Quiz;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace UI.Pages.QuizComponents.ParsonsProblem;

public partial class ParsonsProblem : ComponentBase
{
    [Parameter, EditorRequired] public ParsonsProblemSegment Data { get; set; } = null!;
    [Inject] public IJSRuntime JS { get; set; } = null!;

    private ParsonsProblemSegment? _initializedData;
    private List<ParsonsProblemLine> _orderedLines = [];
    private List<ParsonsProblemLine> _correctOrder = [];
    private bool _isValid;
    private bool _isChecked;
    private bool _allCorrect;
    private int _correctCount;

    protected override void OnParametersSet()
    {
        if (ReferenceEquals(_initializedData, Data))
            return;

        _initializedData = Data;
        _isValid = Data.Lines.Count > 0;
        _correctOrder = Data.Lines.OrderBy(line => line.Id).ToList();
        _orderedLines = Data.Lines.OrderBy(_ => Random.Shared.Next()).ToList();
        _isChecked = false;
        _allCorrect = false;
        _correctCount = 0;
    }

    private Task OnLineDrop(int lineIndex) => OnDrop(lineIndex, fromSlot: false);

    private Task OnSlotDrop(int insertIndex) => OnDrop(insertIndex, fromSlot: true);

    private async Task OnDrop(int insertIndex, bool fromSlot)
    {
        if (_isChecked)
            return;

        var sourceIndex = await JS.InvokeAsync<int?>("parsonsDrag.consumeSourceIndex");
        if (sourceIndex is null || sourceIndex == insertIndex)
            return;

        var item = _orderedLines[sourceIndex.Value];
        _orderedLines.RemoveAt(sourceIndex.Value);

        if (fromSlot && sourceIndex.Value < insertIndex)
            insertIndex--;

        _orderedLines.Insert(insertIndex, item);
    }

    private void CheckAnswer()
    {
        if (_isChecked)
            return;

        _isChecked = true;
        _correctCount = _orderedLines
            .Select((line, index) => line.Id == _correctOrder[index].Id)
            .Count(isCorrect => isCorrect);
        _allCorrect = _correctCount == _correctOrder.Count;
    }

    private string GetLineCssClass(int index)
    {
        if (!_isChecked)
            return string.Empty;

        return _orderedLines[index].Id == _correctOrder[index].Id
            ? "correct"
            : "incorrect";
    }
}
