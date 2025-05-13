using MdToHtmlConversion.Transformers;
using Xunit.Abstractions;

namespace Tests;

public class RegExTests(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public void MatchesImgTag()
    {
        string input = @"
<p>Some text before.</p>
<img src=""Resources/img.png"" alt=""img.png"">
<img src=""https://github.com/TroelsMortensen/Codelabs2/blob/master/Articles/Feature%20Tester/Resources/img.png?raw=true"" alt=""img.png"">
<p>Some text after.</p>
<img src='another/image.jpg'>
<img alt='no src here'>
<img src=""/images/logo.gif"" />
";
        string articleName = "Feature Tester";
        var result = ImageUrlFixer.PrependBaseUrlToRelativeImgUrl(articleName, input);
        testOutputHelper.WriteLine(result);
        // TODO Assert something eventually..
    }
}