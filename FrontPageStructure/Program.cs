// See https://aka.ms/new-console-template for more information

string pathToArticles = @"C:\MyStuff\DotNet Projects\Codelabs2\Articles";
string pathToStructureJson = @"C:\MyStuff\DotNet Projects\Codelabs2\Articles/front-page-structure.json";

IEnumerable<string> enumerateDirectories = Directory.EnumerateDirectories(pathToArticles);

List<Folder> folders = enumerateDirectories
    .Select(dir => new Folder(dir.Substring(dir.LastIndexOf('\\')+1), []))
    .ToList();

folders.ForEach(Console.WriteLine);

PopulateWithSubFolders(folders);

void PopulateWithSubFolders(List<Folder> folders)
{
    
}

record Folder(string Name, List<Folder> SubFolders);