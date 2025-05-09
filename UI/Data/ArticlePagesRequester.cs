using GitHubHttpRequester;
using UI.Data.Models;

namespace UI.Data;

public static class ArticlePagesRequester
{
    public static async Task<List<ArticlePage>> GetArticlePages(HttpClient client, string articleName)
    {
        List<GitHubFileContent> files = await FilesRequester.GetFilesFromFolder(client, articleName);
        
        List<ArticlePage> articleHeaders = files.Select(content => new ArticlePage(
            content.Name,
            content.Markdown
        )).ToList();
        
        return articleHeaders;
    }
}

