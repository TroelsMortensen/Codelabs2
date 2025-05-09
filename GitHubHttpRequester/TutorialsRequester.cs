using System.Net.Http.Headers;
using System.Text.Json;

namespace GitHubHttpRequester;

public static class TutorialsRequester
{
    public static async Task<List<GitHubFolderContent>> GetFolders(HttpClient client)
    {
        client.DefaultRequestHeaders.UserAgent.Clear();
        client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("MyCSharpApp-FileFetcher", "1.0"));
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));

        HttpResponseMessage response = await client.GetAsync(BaseUrl.ARTICLES_URL);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

        string content = await response.Content.ReadAsStringAsync();

        List<GitHubFolderContent> contents = JsonSerializer.Deserialize<List<GitHubFolderContent>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        )!;

        return contents
            .Where(cnt => cnt.Type == "dir")
            .OrderBy(cnt => cnt.Name)
            .ToList();
    }
}

public class GitHubFolderContent
{
    public string Name { get; set; }

    public string Path { get; set; }

    public string Type { get; set; }

    public string Url { get; set; }
}