using Microsoft.AspNetCore.Components;
using UI.Data;
using UI.Data.Models;

namespace UI.Pages.ArticleComponents;

public partial class Article : ComponentBase
{
    [Parameter] public string TutorialsName { get; set; } = string.Empty;

    [Inject] public HttpClient Client { get; set; }

    [Inject] public NavigationManager NavMgr { get; set; }

    private List<ArticlePage> pages = new();
    private int stepIndex = 0;
    private ArticlePage currentPage = null!;

    protected override async Task OnInitializedAsync()
    {
        pages = await ArticlePagesRequester.GetArticlePages(Client, TutorialsName);
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
}