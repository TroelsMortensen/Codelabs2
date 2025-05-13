using System.Text.RegularExpressions;

namespace MdToHtmlConversion.Transformers;

public class CircleStepNumbersInRed : ITransformer
{
    public string Handle(string markdown, string articleName)
    {
        Regex pattern = new(@"\(\(\d*\)\)");
        MatchCollection matchCollection = pattern.Matches(markdown);
        foreach (Match match in matchCollection)
        {
            string theMatch = match.Value;
            string stepNumber = theMatch.Replace("((", "").Replace("))", "");
            string replacementHtml = $"<span class=\"numberCircle\"><span>{stepNumber}</span></span>";
            markdown = markdown.Replace(theMatch, replacementHtml);
        }

        return markdown;
    }
}