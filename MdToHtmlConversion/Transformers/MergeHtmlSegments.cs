using System.Text;
using MdToHtmlConversion.Models.Segments;

namespace MdToHtmlConversion.Transformers;

public class MergeHtmlSegments : ITransformer
{
    public List<PageSegment> Handle(List<PageSegment> segments, string articleName)
    {
        List<PageSegment> result = new();
        StringBuilder htmlBuilder = new();

        foreach (PageSegment segment in segments)
        {
            if (segment is HtmlSegment htmlSegment)
            {
                htmlBuilder.Append(htmlSegment.HtmlContent);
            }
            else
            {
                if (htmlBuilder.Length > 0)
                {
                    result.Add(new HtmlSegment(htmlBuilder.ToString()));
                    htmlBuilder.Clear();
                }

                result.Add(segment);
            }
        }

        if (htmlBuilder.Length > 0)
        {
            result.Add(new HtmlSegment(htmlBuilder.ToString()));
        }

        return result;
    }
}