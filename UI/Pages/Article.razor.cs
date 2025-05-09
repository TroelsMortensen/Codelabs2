using Microsoft.AspNetCore.Components;
using UI.Data;
using UI.Data.Models;

namespace UI.Pages;

public partial class Article : ComponentBase
{
    [Parameter] public string TutorialsName { get; set; } = string.Empty;

    [Inject] public HttpClient Client { get; set; }

    private List<ArticlePage> pages = new();
    private int stepIndex = 0;
    private ArticlePage currentPage = null!;

    protected override async Task OnInitializedAsync()
    {
        pages = await ArticlePagesRequester.GetArticlePages(Client, TutorialsName);
        currentPage = pages[stepIndex];
    }
}