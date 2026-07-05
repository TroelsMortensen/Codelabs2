using MdToHtmlConversion.Models.Segments.Quiz;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace UI.Pages.QuizComponents.FlashCardSet;

public partial class FlashCardSet : ComponentBase
{
    [Parameter, EditorRequired] public FlashCardSetSegment Data { get; set; } = null!;

    private FlashCardSetSegment? _initializedData;
    private HashSet<int> _flippedIndices = [];

    protected override void OnParametersSet()
    {
        if (ReferenceEquals(_initializedData, Data))
            return;

        _initializedData = Data;
        _flippedIndices = [];
    }

    private bool IsFlipped(int index) => _flippedIndices.Contains(index);

    private void ToggleCard(int index)
    {
        if (_flippedIndices.Contains(index))
            _flippedIndices.Remove(index);
        else
            _flippedIndices.Add(index);
    }

    // TODO probably remove this.
    private void HandleKeyDown(int index, KeyboardEventArgs e)
    {
        if (e.Key is "Enter" or " ")
        {
            ToggleCard(index);
        }
    }
}
