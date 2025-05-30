﻿using GitHubHttpRequester;
using MdToHtmlConversion;
using Microsoft.AspNetCore.Components;
using UI.Data.Models;

namespace UI.Data;

public static class ArticlePagesRequester
{
    public static async Task<List<ArticlePage>> GetArticlePages(HttpClient client, string articleName)
    {
        List<GitHubFileContent> files = await FilesRequester.GetFilesFromFolder(client, articleName);

        List<ArticlePage> articlePages = files
            // .Where(file => !file.Name.StartsWith("Meta.json", StringComparison.OrdinalIgnoreCase))
            .Where(file => file.Name.EndsWith(".md"))
            .Select((content, index) => new ArticlePage(
                RemoveLeadingNumberAndSuffixThenAddPageNumber(content.Name, index),
                new MarkupString(MasterConverter.ConvertMarkdownToHtml(content.Markdown, articleName))
            )).ToList();

        return articlePages;
    }

    // TODO split into smaller functions, ext funcs on string?
    private static string RemoveLeadingNumberAndSuffixThenAddPageNumber(string name, int index)
    {
        string updatedName = (++index + ". ") + name
            .Replace(".md", "")
            [name.IndexOf(' ')..];
        return updatedName;
    }
}