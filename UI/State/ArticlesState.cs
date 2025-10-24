using UI.Data;
using UI.Data.Models;

namespace UI.State;

public class ArticlesState(HttpClient client)
{
    private List<ArticleData> articles = [];

    // TODO owner will eventually be used, maybe, if articles are hosted on other github repos. #YAGNI!!
    public async Task<List<ArticlePage>> GetArticlePages(string owner, string tutorialsName)
    {
        ArticleData articleData = await GetArticleData(tutorialsName);

        if (articleData.Pages.Count == 0)
        {
            // should never get in here..
            List<ArticlePage> pages = await ArticlePagesRequester.GetArticlePages(client, tutorialsName);
            articleData.Pages = pages;
            throw new Exception("Wup wup, this should never happen");
        }

        return articleData.Pages;
    }

    private async Task<ArticleData> GetArticleData(string tutorialsName)
    {
        ArticleData? articleData = articles.SingleOrDefault(data => data.Name == tutorialsName);
        if (articleData is null)
        {
            var pages = await ArticlePagesRequester.GetArticlePages(client, tutorialsName);
            articleData = new ArticleData(tutorialsName, "TroelsMortensen", pages);
            articles.Add(articleData);
        }

        return articleData;
    }

}