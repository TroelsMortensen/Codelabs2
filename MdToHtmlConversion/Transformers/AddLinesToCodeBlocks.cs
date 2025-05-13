namespace MdToHtmlConversion.Transformers;

public class AddLinesToCodeBlocks : ITransformer
{
    public string Handle(string markdown, string articleName)
    {
        return markdown.Replace("class=\"language-", "class=\"line-numbers language-");
    }
}