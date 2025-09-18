using System.Text.RegularExpressions;

namespace MdToHtmlConversion.Transformers;

public class MoveLineHighlightingAttributes : ITransformer
{
    public string Handle(string markdown, string articleName)
    {
        Regex pattern = new Regex("<pre><code class=\"line-numbers language-[a-z]{0,15}{(.*?)}\">");
        MatchCollection matchCollection = pattern.Matches(markdown);
        foreach (Match match in matchCollection)
        {
            string existingHtml = match.Value;
            // Regex regex = new Regex("{(.*?)}");
            // Match dataLineValueMatch = regex.Match(existingHtml);
            string dataLineValue = match.Groups[1].Value;

            string replacementHtml = Regex.Replace(existingHtml, @"{(.*?)}", "");
            replacementHtml = replacementHtml.Replace("pre", $"pre data-line=\"{dataLineValue}\"");
            markdown = markdown.Replace(existingHtml, replacementHtml);
        }

        return markdown;
    }
}