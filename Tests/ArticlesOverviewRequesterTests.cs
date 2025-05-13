using GitHubHttpRequester;
using UI.Data;
using UI.Data.Models;
using ArticlesOverviewRequester = GitHubHttpRequester.ArticlesOverviewRequester;

namespace Tests;

public class ArticlesOverviewRequesterTests
{
    HttpClient client = new();

    [Fact]
    public async Task CanFetchFolders()
    {
        List<GitHubFolderContent> folders = await ArticlesOverviewRequester.GetFolders(client);
        Assert.NotNull(folders);
        Assert.Contains(folders, content => content.Name == "Tutorial 1");
    }

    [Fact]
    public async Task DoesNotGetCsprojFile()
    {
        List<GitHubFolderContent> folders = await ArticlesOverviewRequester.GetFolders(client);
        Assert.NotNull(folders);
        Assert.DoesNotContain(folders, content => content.Name == "Tutorials.csproj");
    }

    [Fact]
    public async Task CanFetchMdFiles()
    {
        List<GitHubFileContent> files = await FilesRequester.GetFilesFromFolder(client,
            "Tutorial 1");
        Assert.NotNull(files);
    }

    [Fact]
    public async Task FetchingFeatureTesterArticleDoesNotArgumentOutOfRangeException()
    {
        List<ArticlePage> folders = await ArticlePagesRequester.GetArticlePages(client, "Feature Tester");
        Assert.NotNull(folders);
    }
}