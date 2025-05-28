using Microsoft.AspNetCore.Components;

namespace UI.Pages.ArticleComponents;

public partial class ArticleButtons : ComponentBase
{
    [Inject] public NavigationManager NavMgr { get; set; }

    [Parameter] public int StepIndex { get; set; }
    [Parameter] public int MaxSteps { get; set; }
    
    [Parameter] public EventCallback<int> OnChangePage { get; set; }
}