using GitHubHttpRequester;

namespace Tests;

public class TutorialsRequesterTests
{
    HttpClient client = new();

    [Fact]
    public async Task CanFetchFolders()
    {
        List<GitHubFolderContent> folders = await TutorialsRequester.GetFolders(client);
        Assert.NotNull(folders);
        Assert.Contains(folders, content => content.Name == "Tutorial 1");
    }

    [Fact]
    public async Task DoesNotGetCsprojFile()
    {
        List<GitHubFolderContent> folders = await TutorialsRequester.GetFolders(client);
        Assert.NotNull(folders);
        Assert.DoesNotContain(folders, content => content.Name == "Tutorials.csproj");
    }

    [Fact]
    public async Task CanFetchMdFiles()
    {
        List<GitHubFileContent> files = await FilesRequester.GetFilesFromFolder(client,
            "Tutorial 1");
        Assert.NotNull(files);
    }
}