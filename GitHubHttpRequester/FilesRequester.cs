using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GitHubHttpRequester;

public static class FilesRequester
{
    public static async Task<List<GitHubFileContent>> GetFilesFromFolder(HttpClient client, string folderPath)
    {
        string content = await FetchArticlesOverview(client, folderPath);
        List<GitHubFileContent> fileDetails = ToFileContents(content);
        await PopulateFileDetailsWithMarkdownContents(client, fileDetails);

        return fileDetails;
    }

    private static List<GitHubFileContent> ToFileContents(string content)
    {
        List<GitHubFileContent> fileDetails = JsonSerializer.Deserialize<List<GitHubFileContent>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        fileDetails = fileDetails
            .Where(cnt => cnt.Type == "file")
            .ToList();

        return fileDetails;
    }

    private static async Task<string> FetchArticlesOverview(HttpClient client, string folderPath)
    {

        client.DefaultRequestHeaders.UserAgent.Clear();
        client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("MyCSharpApp-FileFetcher", "1.0"));
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));


        HttpResponseMessage response = await client.GetAsync(BaseUrl.ARTICLES_URL + "/" + folderPath);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

        string content = await response.Content.ReadAsStringAsync();
        return content;
    }

    private static async Task PopulateFileDetailsWithMarkdownContents(HttpClient client, List<GitHubFileContent> fileDetails)
    {
        // TODO Do this in parallel, instead of serial
        foreach (GitHubFileContent fileContent in fileDetails)
        {
            HttpResponseMessage contentResponse = await client.GetAsync(fileContent.DownloadUrl);
            if (!contentResponse.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {contentResponse.StatusCode}");
            }

            string mdContent = await contentResponse.Content.ReadAsStringAsync();
            fileContent.Markdown = mdContent;
        }
    }
}

public class GitHubFileContent
{
    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("path")] public string Path { get; set; }

    [JsonPropertyName("type")] public string Type { get; set; } // Should be "file"

    [JsonPropertyName("download_url")] public string DownloadUrl { get; set; }

    public string Markdown { get; set; } = "";
}