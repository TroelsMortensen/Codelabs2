using GitHubHttpRequester;
using Microsoft.AspNetCore.Components;

namespace UI.Pages;

public partial class Article : ComponentBase
{
    [Parameter] public string TutorialsName { get; set; } = string.Empty;

    [Inject] public HttpClient Client { get; set; }
    
    private List<GitHubFileContent> files = new();
    private int stepIndex = 0;
    private GitHubFileContent currentPage = null!;
    
    protected override async Task OnInitializedAsync()
    {
        Console.WriteLine(TutorialsName);
        files = await FilesRequester.GetFilesFromFolder(Client, TutorialsName);
        currentPage = files[stepIndex];
    }
}