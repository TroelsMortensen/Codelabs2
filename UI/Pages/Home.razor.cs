using GitHubHttpRequester;
using Microsoft.AspNetCore.Components;

namespace UI.Pages;

public partial class Home : ComponentBase
{
    [Inject] public HttpClient Client { get; set; }
    [Inject] public NavigationManager NavMgr { get; set; }

    private List<GitHubFolderContent>? folders;

    protected override async Task OnInitializedAsync()
    {
        folders = await TutorialsRequester.GetFolders(Client);
    }

    private void NavigateToArticle(string tutorialName) =>
        NavMgr.NavigateTo($"/article/{tutorialName}");
}