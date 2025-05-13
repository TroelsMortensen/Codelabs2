using GitHubHttpRequester;
using MdToHtmlConversion;
using UI.Data.Models;

namespace UI.Data;

public static class ArticlePagesRequester
{
    public static async Task<List<ArticlePage>> GetArticlePages(HttpClient client, string articleName)
    {
        List<GitHubFileContent> files = await FilesRequester.GetFilesFromFolder(client, articleName);

        List<ArticlePage> articlePages = files
            .Where(file => !file.Name.StartsWith("Meta.json", StringComparison.OrdinalIgnoreCase))
            .Select(content => new ArticlePage(
                content.Name,
                MasterConverter.ConvertMarkdownToHtml(content.Markdown)
            )).ToList();

        return articlePages;
    }
}