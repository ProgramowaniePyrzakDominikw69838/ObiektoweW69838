using System;
using System.Collections.Generic;

enum Kolor
{
    Czerwony,
    Niebieski,
    Zielony,
    Żółty,
    Fioletowy
}

class GraKolory
{
    private List<Kolor> dostepneKolory = new List<Kolor> { Kolor.Czerwony, Kolor.Niebieski, Kolor.Zielony, Kolor.Żółty, Kolor.Fioletowy };
    private Kolor wylosowanyKolor;

    public GraKolory()
    {
        Random rnd = new Random();
        wylosowanyKolor = dostepneKolory[rnd.Next(dostepneKolory.Count)];
    }

    public void ZgadujKolor()
    {
        while (true)
        {
            try
            {
                Console.Write("Zgadnij kolor (Czerwony, Niebieski, Zielony, Żółty, Fioletowy): ");
                string input = Console.ReadLine();

                if (!Enum.TryParse(input, true, out Kolor kolorZgadniety))
                    throw new ArgumentException("Podano niepoprawny kolor!");

                if (kolorZgadniety == wylosowanyKolor)
                {
                    Console.WriteLine("Brawo! Zgadłeś!");
                    break;
                }
                else
                {
                    Console.WriteLine("Zła odpowiedź, spróbuj ponownie.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        GraKolory gra = new GraKolory();
        gra.ZgadujKolor();
    }
}
