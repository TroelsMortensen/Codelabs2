namespace UI.Data.Models;

// wonder why I made this a class, rather than a record..
public class ArticleData(string name, string owner, List<ArticlePage> pages)
{
    public string Name { get; } = name;
    public string Owner { get; } = owner;
    public List<ArticlePage> Pages { get; set; } = pages;
}