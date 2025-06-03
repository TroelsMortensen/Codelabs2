// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

const string path = "C:\\TRMO\\RiderProjects\\Codelabs3\\Articles\\Session 1 Learning Path";

Directory.EnumerateFiles(path)
    .Where(filePath => filePath.EndsWith(".md"))
    .Where(StartsWithPageIndex)
    .Select((filePath, index) => (fileName: filePath, index: index))
    .ToList()
    .ForEach(tuple => UpdateName(tuple.fileName, tuple.index));


static bool StartsWithPageIndex(string filePath) =>
    Regex.IsMatch(Path.GetFileName(filePath), @"^\d{2,4} ");

static void UpdateName(string filePath, int index)
{
    const int totalIndexLength = 3;
    string prefix = (index + 1).ToString().PadLeft(totalIndexLength, '0') + " ";
    string newFilePath = Path.Combine(Path.GetDirectoryName(filePath)!, prefix + Path.GetFileName(filePath)[4..]);
    if (filePath == newFilePath)
    {
        return;
    }

    File.Move(filePath, newFilePath);

    Console.WriteLine($"Renamed:\n\t{Path.GetFileName(filePath)}\n\t->\n\t{Path.GetFileName(newFilePath)}");
}