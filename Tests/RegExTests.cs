using System.Text.RegularExpressions;
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
        var result = FixImageUrls.PrependBaseUrlToRelativeImgUrl(articleName, input);
        testOutputHelper.WriteLine(result);
        // TODO Assert something eventually..
    }

    [Fact]
    public void CanConvertHintToDetails()
    {
        string input = @"
<hint title=""Hint 1"">
    This is a hint box, and it should be collapsible.
</hint>";

        string pattern = @"<hint\s+title=""(.*?)"">\s*\r?\n(.*?)\r?\n?</hint>";
        string replacement = @"
<details>
    <summary>$1</summary>
    $2
</details>";

        string output = Regex.Replace(input, pattern, replacement, RegexOptions.Singleline);
        testOutputHelper.WriteLine(output);
    }
}