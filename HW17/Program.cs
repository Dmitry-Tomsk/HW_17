using HW17;

float CheckFloat<T>(T values)
{
    if (float.TryParse(values!.ToString(), out var num))
    { return num; }
    else
    { return 0; }
}

var floats = new List<string>() { "a", "30", "-26", "34,1", "32", "17" };
var maxNum = floats.GetMax<string>(CheckFloat);

Console.WriteLine($"Максимальное число {maxNum}");

string path = Directory.GetCurrentDirectory();
Console.WriteLine($"Каталог: {path}");

FileSearch fileSearch = new();
fileSearch.scanCatalog(path);
