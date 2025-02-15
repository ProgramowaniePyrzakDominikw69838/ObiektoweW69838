using System;
using System.IO;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nCo chcesz zrobić?");
            Console.WriteLine("1 - Zapisz numer albumu do nowego pliku");
            Console.WriteLine("2 - Odczytaj istniejący plik");
            Console.WriteLine("3 - Wyjście");
            Console.Write("Wybierz opcję: ");
            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    ZapiszPlik();
                    break;
                case "2":
                    OdczytajPlik();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Niepoprawna opcja, spróbuj ponownie.");
                    break;
            }
        }
    }

    static void ZapiszPlik()
    {
        Console.Write("Podaj nazwę pliku: ");
        string fileName = Console.ReadLine();
        string path = fileName + ".txt";
        string numerAlbumu = "69838"; // Numer albumu Dominika

        File.WriteAllText(path, numerAlbumu);
        Console.WriteLine($"Nr albumu {numerAlbumu} zapisany do pliku {path}");
    }

    static void OdczytajPlik()
    {
        Console.Write("Podaj nazwę pliku do odczytu: ");
        string fileName = Console.ReadLine();
        string path = fileName + ".txt";

        if (File.Exists(path))
        {
            string content = File.ReadAllText(path);
            Console.WriteLine($"Zawartość pliku:\n{content}");
        }
        else
        {
            Console.WriteLine("Plik nie istnieje.");
        }
    }
}
