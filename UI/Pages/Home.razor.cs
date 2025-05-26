using Microsoft.AspNetCore.Components;
using UI.Data.Models;
using UI.State;

namespace UI.Pages;

public partial class Home : ComponentBase
{
    // [Inject] public HttpClient Client { get; set; }
    [Inject] public NavigationManager NavMgr { get; set; }
    [Inject] public ArticlesState ArticlesState { get; set; }

    private List<ArticleHeader>? articles;

    protected override async Task OnInitializedAsync() =>
        articles = await ArticlesState.GetArticleHeaders();

    private void NavigateToArticle(string owner, string tutorialName) =>
        NavMgr.NavigateTo($"article/{owner}/{tutorialName}");
}