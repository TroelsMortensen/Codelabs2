using System.Text.RegularExpressions;
using Markdig;
using MdToHtmlConversion.Transformers;

namespace Tests.HtmlTransformers;

public class ConfigureVideoTagsTests
{
    [Fact]
    public void HtmlWithCorrectlyFormattedTag_ShouldProduceCorrectVideoTag()
    {
        string markdown = """
                          ## Summary

                          The `super` keyword is essential for inheritance in Java:

                          1. **`super()`** - Calls super class constructor (must be first in constructor)
                          2. **`super.method()`** - Calls parent class method
                          3. **`super.field`** - Accesses parent class field
                          4. **Always refers to immediate super class** in inheritance chain

                          Understanding `super` is crucial for building proper inheritance hierarchies and maintaining the relationship between super class and subclass.


                          ## Video

                          John explains the `super` keyword in 11 minutes, if you need to learn about it in a different way:

                          <video src="https://youtu.be/Qb_NUn0TSAU"></video>

                          You may optionally watch this video.
                          """;
        var pipeline = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .Build();
        
        string html = Markdown.ToHtml(markdown, pipeline);
        string result = new ConfigureVideoTags().Handle(html, "");
        Assert.Contains("https://youtube.com/embed/Qb_NUn0TSAU", result);
    }
    
    [Fact]
    public void HtmlWithCorrectlyFormattedQueryTag_ShouldProduceCorrectVideoTag()
    {
        string markdown = """
                          ## Summary

                          The `super` keyword is essential for inheritance in Java:

                          1. **`super()`** - Calls super class constructor (must be first in constructor)
                          2. **`super.method()`** - Calls parent class method
                          3. **`super.field`** - Accesses parent class field
                          4. **Always refers to immediate super class** in inheritance chain

                          Understanding `super` is crucial for building proper inheritance hierarchies and maintaining the relationship between super class and subclass.


                          ## Video

                          John explains the `super` keyword in 11 minutes, if you need to learn about it in a different way:

                          <video src="https://www.youtube.com/watch?v=Qb_NUn0TSAU"></video>

                          You may optionally watch this video.
                          """;
        var pipeline = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .Build();
        
        string html = Markdown.ToHtml(markdown, pipeline);
        string result = new ConfigureVideoTags().Handle(html, "");
        Assert.Contains("https://youtube.com/embed/Qb_NUn0TSAU", result);
    }

    [Fact]
    public void TestRegExMatch()
    {
        string pattern = @"<video\s+src=""https:\/\/www.youtube\.com\/watch\?v=([a-zA-Z0-9_-]+)\""\s*><\/video>";
        Match match = Regex.Match("<video src=\"https://www.youtube.com/watch?v=Qb_NUn0TSAU\"></video>", pattern);
        ;
    }
    
    
}