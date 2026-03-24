namespace MdToHtmlConversion.Transformers;

public class AddLinesToCodeBlocks : ITransformer
{
    public string Handle(string html, string articleName)
    {
        return html.Replace("class=\"language-", "class=\"line-numbers language-");
    }
}