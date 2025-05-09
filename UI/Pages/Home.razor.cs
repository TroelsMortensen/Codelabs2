using GitHubHttpRequester;
using Microsoft.AspNetCore.Components;
using UI.Data;
using UI.Data.Models;

namespace UI.Pages;

public partial class Home : ComponentBase
{
    [Inject] public HttpClient Client { get; set; }
    [Inject] public NavigationManager NavMgr { get; set; }

    private List<ArticleHeader>? headers;

    protected override async Task OnInitializedAsync()
    {
        headers = await ArticlesOverviewRequester.GetArticleHeaders(Client);
    }

    private void NavigateToArticle(string tutorialName) =>
        NavMgr.NavigateTo($"/article/{tutorialName}");
}