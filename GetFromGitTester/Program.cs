using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

HttpClient client = new();

client.DefaultRequestHeaders.UserAgent.Clear();
client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("MyCSharpApp-FileFetcher", "1.0"));
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));

var url = "https://api.github.com/repos/TroelsMortensen/CodeLabs/contents/Tutorials/BlazorLogin/002%20The%20project.md?ref=master";
// var url = "https://api.github.com/repos/TroelsMortensen/CodeLabs/contents/Tutorials/BlazorLogin?ref=master";
HttpResponseMessage response = await client.GetAsync(url);
if (response.IsSuccessStatusCode)
{
    string content = await response.Content.ReadAsStringAsync();
    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true // Handles slight case differences if any
    };

    GitHubFileContent fileDetails = JsonSerializer.Deserialize<GitHubFileContent>(content, options)!;
    byte[] data = Convert.FromBase64String(fileDetails.Content);
    string mdText = Encoding.UTF8.GetString(data);
    // List<GitHubFolderContent> contents = JsonSerializer.Deserialize<List<GitHubFolderContent>>(content, options) ?? [];
    ;
    // TODO image references skal opdateres, og have ?raw=true appended.
}
else
{
    Console.WriteLine($"Error: {response.StatusCode}");
}

public class GitHubFolderContent
{
    public string Name { get; set; }

    public string Path { get; set; }

    public string Type { get; set; } // "file" or "dir"

    public string Url { get; set; }

    // You can add other properties if needed, e.g., "sha", "size", "url", "html_url", etc.
}

public class GitHubFileContent
{
    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("path")] public string Path { get; set; }
    //
    // [JsonPropertyName("sha")]
    // public string Sha { get; set; }
    //
    // [JsonPropertyName("size")]
    // public int Size { get; set; }

    [JsonPropertyName("type")] public string Type { get; set; } // Should be "file"

    [JsonPropertyName("content")] public string Content { get; set; } // Base64 encoded content

    [JsonPropertyName("encoding")] public string Encoding { get; set; } // Should be "base64"

    [JsonPropertyName("download_url")] public string DownloadUrl { get; set; }

    // Other fields like "url", "html_url", "git_url", "_links" also exist
}