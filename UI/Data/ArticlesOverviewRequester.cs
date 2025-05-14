using GitHubHttpRequester;
using UI.Data.Models;

namespace UI.Data;

public static class ArticlesOverviewRequester
{
    public static async Task<List<ArticleData>> GetArticleHeaders(HttpClient client)
    {
        List<GitHubFolderContent> folders = await GitHubHttpRequester.ArticlesOverviewRequester.GetFolders(client);

        List<ArticleData> articleHeaders = folders
            .ToList()
            .Select(content => new ArticleData(
                    content.Name,
                    content.Owner,
                    AddMetaData(content),
                    []
                )
            )
            .ToList();

        return articleHeaders;
    }

    private static ArticleHeaderMetaData AddMetaData(GitHubFolderContent content)
    {
        // TODO fetch meta data file, later. For now, dummy data.
        return new ArticleHeaderMetaData("Description", "Category", []);
    }
}