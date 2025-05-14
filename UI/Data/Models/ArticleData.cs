namespace UI.Data.Models;

public class ArticleData(string name, string owner, ArticleHeaderMetaData metadata, List<ArticlePage> pages)
{
    public string Name { get; } = name;
    public string Owner { get; } = owner;
    public ArticleHeaderMetaData MetaData { get; } = metadata;
    public List<ArticlePage> Pages { get; set; } = pages;
}