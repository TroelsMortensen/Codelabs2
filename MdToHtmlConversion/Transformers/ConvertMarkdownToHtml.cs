using System.Text.Json;
using Markdig;
using Markdig.Renderers;
using Markdig.Syntax;
using MdToHtmlConversion.Models.Segments;
using MdToHtmlConversion.Models.Segments.Quiz;
using MdToHtmlConversion.Parsers.Quiz;

namespace MdToHtmlConversion.Transformers;

public class ConvertMarkdownToHtml : ITransformer
{
    public List<PageSegment> Handle(List<PageSegment> initialMarkdown, string articleName)
    {
        // Assuming 'segments' contains one big raw Markdown segment initially, probably a dangerous assumption, should improve
        var rawMarkdown = ((RawMarkdownSegment)initialMarkdown[0]).Markdown;

        var pipeline = BuildPipeline();

        var document = Markdown.Parse(rawMarkdown, pipeline);

        using var writer = new StringWriter();
        var renderer = new HtmlRenderer(writer);
        pipeline.Setup(renderer);

        var result = new List<PageSegment>();

        foreach (var block in document)
        {
            if (block is QuizBlock quizBlock)
            {
                HandleQuizBlock(quizBlock, result);
            }
            else
            {
                HandleHtmlBlock(writer, renderer, block, result);
            }
        }

        return result;
    }

    private static void HandleHtmlBlock(StringWriter writer, HtmlRenderer renderer, Block block, List<PageSegment> result)
    {
        writer.GetStringBuilder().Clear();
        renderer.Write(block);
        writer.Flush();

        result.Add(new HtmlSegment(writer.ToString()));
    }

    private static void HandleQuizBlock(QuizBlock quizBlock, List<PageSegment> result)
    {
        using JsonDocument doc = JsonDocument.Parse(quizBlock.JsonContent);
        var type = doc.RootElement.GetProperty("Type").GetString();

        QuizSegment quizSegment = type switch
        {
            "SingleChoiceQuiz" => JsonSerializer.Deserialize<SingleChoiceQuizSegment>(quizBlock.JsonContent)!,
            "MultipleChoiceQuiz" => JsonSerializer.Deserialize<MultipleChoiceQuizSegment>(quizBlock.JsonContent)!,
            "FlashCardSet" => JsonSerializer.Deserialize<FlashCardSetSegment>(quizBlock.JsonContent)!,
            "ExpandableDetails" => JsonSerializer.Deserialize<ExpandableDetailsSegment>(quizBlock.JsonContent)!,
            "StepGuide" => JsonSerializer.Deserialize<StepGuideSegment>(quizBlock.JsonContent)!,
            "MatchPair" => JsonSerializer.Deserialize<MatchPairSegment>(quizBlock.JsonContent)!,
            _ => throw new NotSupportedException($"Quiz type {type} is not supported.")
        };
        result.Add(quizSegment);
    }

    private static MarkdownPipeline BuildPipeline()
    {
        MarkdownPipelineBuilder pipelineBuilder = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions();
        pipelineBuilder.BlockParsers.Insert(0, new QuizBlockParser());
        var pipeline = pipelineBuilder.Build();
        return pipeline;
    }
}