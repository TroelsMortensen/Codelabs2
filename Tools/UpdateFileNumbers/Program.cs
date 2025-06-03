// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

static bool StartsWithPageIndex(string filePath) => Regex.IsMatch(Path.GetFileName(filePath), @"^\d{2,4} ");

string path = "C:\\TRMO\\RiderProjects\\Codelabs3\\Articles\\MD Documentation";

List<string> mdFiles = Directory.EnumerateFiles(path)
    .Where(filePath => filePath.EndsWith(".md"))
    .Where(StartsWithPageIndex)
    .ToList();

int count = mdFiles.Count;
int numOfDigits = count.ToString().Length; // should probably always 3

mdFiles
    .Select((filePath, index) => (fileName: filePath, index: index))
    .ToList()
    .ForEach(tuple => UpdateName(tuple.fileName, tuple.index));


void UpdateName(string filePath, int index)
{
    int totalIndexLength = 3;
    string prefix = (index+1).ToString().PadLeft(totalIndexLength, '0') + " ";
    string newFilePath = Path.Combine(Path.GetDirectoryName(filePath)!, prefix + Path.GetFileName(filePath)[(4)..]);
    File.Move(filePath, newFilePath);
    Console.WriteLine($"Renamed:\n\t{Path.GetFileName(filePath)}\n\t->\n\t{Path.GetFileName(newFilePath)}");
}