using GitHubHttpRequester;
using UI.Data.Models;

namespace UI.Data;

public static class ArticlesOverviewRequester
{
    public static async Task<List<ArticleHeader>> GetArticleHeaders(HttpClient client)
    {
        List<GitHubFolderContent> folders = await TutorialsRequester.GetFolders(client);

        List<ArticleHeader> articleHeaders = folders
            .ToList()
            .Select(content => new ArticleHeader(
                content.Name,
                AddMetaData(content))
            )
            .ToList();

        return articleHeaders;
    }

    private static ArticleHeaderMetaData AddMetaData(GitHubFolderContent content)
    {
        // TODO fetch meta data file
        return new("Category");
    }
}