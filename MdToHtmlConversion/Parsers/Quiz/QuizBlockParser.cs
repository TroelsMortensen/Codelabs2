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
// 1. Get the current line
        var line = processor.Line;
        line.Trim();

        // 2. Fast check: If it doesn't start with '<', exit immediately
        if (line.CurrentChar != '<') return BlockState.None;

        // 3. String comparison for the FULL tag
        // Convert to string only after passing the initial character check
        if (line.ToString().Equals("<Quiz>", StringComparison.OrdinalIgnoreCase))
        {
            jsonBuilder.Clear();
            processor.NewBlocks.Push(new QuizBlock(this));
            return BlockState.Continue;
        }

        // 4. Return None for <hint>, <div>, <p>, etc.
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