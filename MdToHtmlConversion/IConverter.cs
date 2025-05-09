namespace MdToHtmlConversion;

public interface IConverter
{
    public string Handle(string markdown);
}