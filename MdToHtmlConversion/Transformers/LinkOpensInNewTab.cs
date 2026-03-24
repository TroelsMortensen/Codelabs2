namespace MdToHtmlConversion.Transformers;

public class LinkOpensInNewTab : ITransformer
{
    public string Handle(string html, string articleName)
    {
        // TODO regex for links til at opdatere med det der blank_ something

        return html;
    }
}