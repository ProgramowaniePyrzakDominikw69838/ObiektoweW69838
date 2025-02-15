using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

class Program
{
    public class PopulationData
    {
        public Dictionary<int, Dictionary<string, long>> Data { get; set; }
    }

    static void Main()
    {
        string filePath = "db.json";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Plik db.json nie istnieje.");
            return;
        }

        string jsonString = File.ReadAllText(filePath);
        var populationData = JsonSerializer.Deserialize<PopulationData>(jsonString);

        Console.WriteLine("Podaj rok początkowy: ");
        int startYear = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj rok końcowy: ");
        int endYear = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj kraj (USA, Indie, Chiny): ");
        string country = Console.ReadLine();

        if (populationData.Data.ContainsKey(startYear) && populationData.Data.ContainsKey(endYear))
        {
            long startPop = populationData.Data[startYear][country];
            long endPop = populationData.Data[endYear][country];
            Console.WriteLine($"Różnica populacji {country} między {startYear} a {endYear}: {endPop - startPop}");
        }
        else
        {
            Console.WriteLine("Nie znaleziono danych dla podanych lat.");
        }
    }
}
