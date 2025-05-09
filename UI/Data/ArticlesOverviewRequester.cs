using GitHubHttpRequester;
using UI.Data.Models;

namespace UI.Data;

public static class ArticlesOverviewRequester
{
    public static async Task<List<ArticleHeader>> GetArticleHeaders(HttpClient client)
    {
        var folders = await TutorialsRequester.GetFolders(client);
        
        List<ArticleHeader> articleHeaders = folders
            .Select(content => new ArticleHeader(content.Name))
            .ToList();
        
        return articleHeaders;
    }
}