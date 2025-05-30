﻿using System.Text.RegularExpressions;

namespace MdToHtmlConversion.Transformers;

public class ConfigureVideoTags : ITransformer
{
    public string Handle(string html, string articleName)
    {
        return VideoToIframe(html);
    }

    public static string VideoToIframe(string inputHtml)
    {
        string pattern = @"<p><video\s+src=""https:\/\/youtu\.be\/([a-zA-Z0-9_-]+)\""\s*><\/video><\/p>";

        string replacement = @"
<div class=""video-box"">
<p>
<iframe src=""https://youtube.com/embed/$1"" frameborder=""0"" allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"" allowfullscreen></iframe>
</p>
</div>";

        string result = Regex.Replace(inputHtml, pattern, replacement);

        return result;
    }
}