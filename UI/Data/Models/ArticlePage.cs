using MdToHtmlConversion.Models.Segments;

namespace UI.Data.Models;

public record ArticlePage(string Name, List<PageSegment> PageSegments);
