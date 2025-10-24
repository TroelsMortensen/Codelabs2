using UI.Data;
using UI.Data.Models;
using Xunit.Abstractions;

namespace Tests;

public class TestFetchFolderNestedArticles(ITestOutputHelper testOutputHelper)
{


    [Fact]
    public async Task GetFiles()
    {
        HttpClient client = new();

        List<ArticlePage> first = await ArticlePagesRequester.GetArticlePages(client, "Feature%20Tester");
        List<ArticlePage> articlePages = await ArticlePagesRequester.GetArticlePages(client, "SEP1/Actors");
        ;
    }
}