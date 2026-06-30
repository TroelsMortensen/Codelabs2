using System.Text;
using Markdig.Helpers;
using Markdig.Parsers;
using Markdig.Syntax;

namespace MdToHtmlConversion.Parsers.Quiz;

public class QuizBlockParser : BlockParser
{
    
    private StringBuilder jsonBuilder = new();
    
    public QuizBlockParser()
    {
        // Tell Markdig this block starts with '<'
        OpeningCharacters = new[] { '<' };
    }

    public override BlockState TryOpen(BlockProcessor processor)
    {
        StringSlice line = processor.Line;
        line.Trim();
        if (line.ToString().StartsWith("<Quiz>"))
        {
            jsonBuilder.Clear();
            processor.NewBlocks.Push(new QuizBlock(this));
            return BlockState.Continue;
        }
        return BlockState.None;
    }

    public override BlockState TryContinue(BlockProcessor processor, Block block)
    {
        var line = processor.Line;
        line.Trim();
        if (line.ToString().StartsWith("</Quiz>"))
        {
            var quizBlock = (QuizBlock)block;
            quizBlock.JsonContent = jsonBuilder.ToString();
            return BlockState.Break;
        }
        
        jsonBuilder.AppendLine(processor.Line.ToString());
        return BlockState.Continue;
    }
}