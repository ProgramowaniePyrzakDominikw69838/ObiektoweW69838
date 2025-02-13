using System;
using System.Collections.Generic;

enum Operacja
{
    Dodawanie,
    Odejmowanie,
    Mnożenie,
    Dzielenie
}

class Kalkulator
{
    private List<double> historiaWynikow = new List<double>();

    public double Oblicz(double a, double b, Operacja operacja)
    {
        double wynik = 0;
        try
        {
            switch (operacja)
            {
                case Operacja.Dodawanie:
                    wynik = a + b;
                    break;
                case Operacja.Odejmowanie:
                    wynik = a - b;
                    break;
                case Operacja.Mnożenie:
                    wynik = a * b;
                    break;
                case Operacja.Dzielenie:
                    if (b == 0)
                        throw new DivideByZeroException();
                    wynik = a / b;
                    break;
                default:
                    throw new ArgumentException("Nieznana operacja");
            }

            historiaWynikow.Add(wynik);
            return wynik;
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Błąd: Próba dzielenia przez zero.");
            return double.NaN;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
            return double.NaN;
        }
    }

    public void PokazHistorie()
    {
        Console.WriteLine("Historia obliczeń:");
        foreach (var wynik in historiaWynikow)
        {
            Console.WriteLine(wynik);
        }
    }
}

class Program
{
    static void Main()
    {
        Kalkulator kalkulator = new Kalkulator();

        while (true)
        {
            try
            {
                Console.Write("Podaj pierwszą liczbę: ");
                double liczba1 = double.Parse(Console.ReadLine());

                Console.Write("Podaj drugą liczbę: ");
                double liczba2 = double.Parse(Console.ReadLine());

                Console.Write("Wybierz operację (0-Dodawanie, 1-Odejmowanie, 2-Mnożenie, 3-Dzielenie): ");
                Operacja operacja = (Operacja)int.Parse(Console.ReadLine());

                double wynik = kalkulator.Oblicz(liczba1, liczba2, operacja);
                Console.WriteLine($"Wynik: {wynik}");

                Console.Write("Czy chcesz zobaczyć historię obliczeń? (tak/nie): ");
                if (Console.ReadLine()?.ToLower() == "tak")
                {
                    kalkulator.PokazHistorie();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Błąd: Wprowadź poprawne liczby.");
            }
        }
    }
}
