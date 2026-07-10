using MdToHtmlConversion.Models.Segments.Quiz;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace UI.Pages.QuizComponents.ParsonsProblem;

public partial class ParsonsProblem : ComponentBase
{
    [Parameter, EditorRequired] public ParsonsProblemSegment Data { get; set; } = null!;
    [Inject] private IJSRuntime JS { get; set; } = null!;

    private ParsonsProblemSegment? _initializedData;
    private List<ParsonsProblemLine> _orderedLines = [];
    private List<ParsonsProblemLine> _correctOrder = [];
    private bool _isValid;
    private bool _isChecked;
    private bool _allCorrect;
    private int _correctCount;
    private int? _hintLineIndex;
    private int? _hintSlotIndex;

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
        ClearDragState();
    }

    private async Task OnDragEnd()
    {
        ClearDragState();
        await JS.InvokeVoidAsync("ppDrag.clearVisuals");
    }

    private void OnLineDragOver(int index)
    {
        if (_isChecked || _hintLineIndex == index)
            return;

        _hintLineIndex = index;
        _hintSlotIndex = null;
    }

    private void OnSlotDragOver(int slotIndex)
    {
        if (_isChecked || _hintSlotIndex == slotIndex)
            return;

        _hintSlotIndex = slotIndex;
        _hintLineIndex = null;
    }

    private void ClearDragState()
    {
        _hintLineIndex = null;
        _hintSlotIndex = null;
    }

    private Task OnLineDrop(int lineIndex) => OnDrop(lineIndex, fromSlot: false);

    private Task OnSlotDrop(int insertIndex) => OnDrop(insertIndex, fromSlot: true);

    private async Task OnDrop(int insertIndex, bool fromSlot)
    {
        if (_isChecked)
            return;

        var sourceIndex = await JS.InvokeAsync<int?>("ppDrag.consumeIndex");
        if (sourceIndex is not int source || source == insertIndex)
            return;

        var item = _orderedLines[source];
        _orderedLines.RemoveAt(source);

        if (fromSlot && source < insertIndex)
            insertIndex--;

        _orderedLines.Insert(insertIndex, item);
        ClearDragState();
        await JS.InvokeVoidAsync("ppDrag.clearVisuals");
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

    private void TryAgain()
    {
        _isChecked = false;
        _allCorrect = false;
        _correctCount = 0;
        ClearDragState();
    }

    private string GetSlotHintClass(int slotIndex) =>
        _hintSlotIndex == slotIndex ? "pp-drop-slot-active" : string.Empty;

    private string GetLineDragClass(int index)
    {
        var classes = new List<string>();

        var resultClass = GetLineCssClass(index);
        if (!string.IsNullOrEmpty(resultClass))
            classes.Add(resultClass);

        if (_hintLineIndex == index)
            classes.Add("pp-line-drop-active");

        if ((_hintLineIndex == index && index == 0) || _hintSlotIndex == index)
            classes.Add("pp-line-shift-down");
        else if ((_hintLineIndex == index && index > 0) || _hintSlotIndex == index + 1)
            classes.Add("pp-line-shift-up");

        return string.Join(' ', classes);
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
