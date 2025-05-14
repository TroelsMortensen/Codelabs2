using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using UI.Data;
using UI.Data.Models;
using UI.State;

namespace UI.Pages.ArticleComponents;

public partial class Article : ComponentBase
{
    [Parameter] public string TutorialsName { get; set; } = string.Empty;
    [Parameter] public string Owner { get; set; } = string.Empty;

    // [Inject] public HttpClient Client { get; set; }
    [Inject] public NavigationManager NavMgr { get; set; }
    [Inject] public IJSRuntime JsRuntime { get; set; }
    [Inject] public ArticlesState ArticlesState { get; set; }

    private List<ArticlePage> pages = new();
    private int stepIndex = 0;
    private ArticlePage currentPage = null!;

    protected override async Task OnInitializedAsync()
    {
        pages = await ArticlesState.GetArticlePages(Owner, TutorialsName);
        currentPage = pages[stepIndex];
    }

    private void ChangePage(int step)
    {
        stepIndex += step;
        currentPage = pages[stepIndex];
    }

    private void GoToPage(int idx)
    {
        stepIndex = idx;
        currentPage = pages[stepIndex];
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await JsRuntime.InvokeVoidAsync("Prism.highlightAll");
    }
}