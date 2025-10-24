using GitHubHttpRequester;
using UI.Data;
using UI.Data.Models;

namespace Tests;

public class ArticlesOverviewRequesterTests
{
    HttpClient client = new();

  

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