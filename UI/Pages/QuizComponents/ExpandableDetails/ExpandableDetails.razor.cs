using MdToHtmlConversion.Models.Segments.Quiz;
using Microsoft.AspNetCore.Components;

namespace UI.Pages.QuizComponents.ExpandableDetails;

public partial class ExpandableDetails : ComponentBase
{
    [Parameter, EditorRequired] public ExpandableDetailsSegment Data { get; set; } = null!;

    private readonly HashSet<int> _expandedIndices = [];

    private bool IsExpanded(int index) => _expandedIndices.Contains(index);

    private void ToggleDetail(int index)
    {
        if (!_expandedIndices.Remove(index))
            _expandedIndices.Add(index);
    }
}
