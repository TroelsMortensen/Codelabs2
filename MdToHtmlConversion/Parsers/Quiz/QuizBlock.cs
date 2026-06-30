using Markdig.Parsers;
using Markdig.Syntax;

namespace MdToHtmlConversion.Parsers.Quiz;

public class QuizBlock(BlockParser parser) : LeafBlock(parser)
{
    public string JsonContent { get; set; }
}