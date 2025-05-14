using UI.Data;
using UI.Data.Models;

namespace UI.State;

public class ArticlesState(HttpClient client)
{
    private List<ArticleData> articles = [];

    public async Task<List<ArticleHeader>> GetArticleHeaders()
    {
        await LoadArticlesIfNecessary();

        return articles
            .Select(data => new ArticleHeader(data.Name, data.Owner, data.MetaData))
            .ToList();
    }


    // TODO owner will eventually be used, if articles are hosted on other github repos. #YAGNI!!
    public async Task<List<ArticlePage>> GetArticlePages(string owner, string tutorialsName)
    {
        await LoadArticlesIfNecessary();
        ArticleData articleData = articles.Single(data => data.Name == tutorialsName);

        if (articleData.Pages.Count == 0)
        {
            List<ArticlePage> pages = await ArticlePagesRequester.GetArticlePages(client, tutorialsName);
            articleData.Pages = pages;
        }

        return articleData.Pages;
    }

    private async Task LoadArticlesIfNecessary()
    {
        if (articles.Count == 0)
        {
            articles = await ArticlesOverviewRequester.GetArticleHeaders(client);
        }
    }
}