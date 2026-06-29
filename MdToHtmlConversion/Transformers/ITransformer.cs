using MdToHtmlConversion.Models.Segments;

namespace MdToHtmlConversion.Transformers;

public interface ITransformer
{
    List<PageSegment> Handle(List<PageSegment> segments, string articleName);
}