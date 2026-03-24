namespace MdToHtmlConversion.Transformers;

public interface ITransformer
{
    public string Handle(string html, string articleName);
}