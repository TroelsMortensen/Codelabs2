using System.Text;
using Markdig;
using Markdig.Renderers;
using MdToHtmlConversion;
using MdToHtmlConversion.Models.Segments;
using Xunit.Abstractions;

namespace Tests.HtmlTransformers;

public class TablesAreCorrectTests(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public void MarkdownTableIsCorrectlyConvertedToHtmlWithBasicMarkdig()
    {
        MarkdownPipelineBuilder pipelineBuilder = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions();
        var pipeline = pipelineBuilder.Build();
        var document = Markdown.Parse(MarkdownWithTable, pipeline);
        // StringBuilder result = new();
        using var writer = new StringWriter();
        var renderer = new HtmlRenderer(writer);
        pipeline.Setup(renderer);

        foreach (var block in document)
        {
            renderer.Write(block);
        }
        writer.Flush();
        var renderBlockToHtml = writer.ToString();

        testOutputHelper.WriteLine(renderBlockToHtml);
        Assert.Contains("<table>", renderBlockToHtml);
    }

    [Fact]
    public void MasterConvertCorrectlyHandlesTable()
    {
        var segments = MasterConverter.ConvertMarkdownToHtml(MarkdownWithTable, "");
        ;

        var resultHtml = segments
            .Aggregate(new StringBuilder(), (builder, segment) => builder.AppendLine(((HtmlSegment)segment).HtmlContent))
            .ToString();
        
        Assert.Equal("""
                     <h2 id="tables">11. Tables</h2>
                     <table>
                     <thead>
                     <tr>
                     <th style="text-align: left;">Left aligned</th>
                     <th style="text-align: center;">Center aligned</th>
                     <th style="text-align: right;">Right aligned</th>
                     </tr>
                     </thead>
                     <tbody>
                     <tr>
                     <td style="text-align: left;">cell A1</td>
                     <td style="text-align: center;">cell B1</td>
                     <td style="text-align: right;">cell C1</td>
                     </tr>
                     <tr>
                     <td style="text-align: left;">cell A2</td>
                     <td style="text-align: center;">cell B2</td>
                     <td style="text-align: right;">cell C2</td>
                     </tr>
                     </tbody>
                     </table>

                     
                     """.Replace("\r", ""), resultHtml.Replace("\r", ""));
    }
    
    private const string MarkdownWithTable = """
                                             ## 11. Tables

                                             | Left aligned | Center aligned | Right aligned |
                                             |:-------------|:--------------:|--------------:|
                                             | cell A1      | cell B1        | cell C1       |
                                             | cell A2      | cell B2        | cell C2       |
                                             """;
}