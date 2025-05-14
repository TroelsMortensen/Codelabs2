using System.Text.RegularExpressions;

namespace MdToHtmlConversion.Transformers;

public class HintToDetails : ITransformer
{
    public string Handle(string html, string articleName)
    {
        string pattern = @"<hint\s+title=""(.*?)"">\s*\r?\n(.*?)\r?\n?</hint>";
        string replacement = 
@"
<details>
    <summary>$1</summary>
<p>
$2
</p>
</details>";

        return Regex.Replace(html, pattern, replacement, RegexOptions.Singleline);
    }
}