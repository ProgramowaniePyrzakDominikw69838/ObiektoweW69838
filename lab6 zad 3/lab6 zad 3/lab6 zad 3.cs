using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "pesel.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Plik pesel.txt nie istnieje.");
            return;
        }

        string[] pesels = File.ReadAllLines(filePath);
        int liczbaKobiet = pesels.Count(p => p.Length == 11 && (p[9] - '0') % 2 == 0);

        Console.WriteLine($"Liczba żeńskich PESEL-i: {liczbaKobiet}");
    }
}
