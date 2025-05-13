namespace MdToHtmlConversion.Transformers;

public interface ITransformer
{
    public string Handle(string markdown, string articleName);
}