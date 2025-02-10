using System;

class Osoba
{
    private string imie;
    private string nazwisko;
    private int wiek;

    public string Imie
    {
        get { return imie; }
        set
        {
            if (value.Length >= 2)
                imie = value;
            else
                Console.WriteLine("Imię musi mieć co najmniej 2 znaki.");
        }
    }

    public string Nazwisko
    {
        get { return nazwisko; }
        set
        {
            if (value.Length >= 2)
                nazwisko = value;
            else
                Console.WriteLine("Nazwisko musi mieć co najmniej 2 znaki.");
        }
    }

    public int Wiek
    {
        get { return wiek; }
        set
        {
            if (value > 0)
                wiek = value;
            else
                Console.WriteLine("Wiek musi być liczbą dodatnią.");
        }
    }

    public Osoba(string imie, string nazwisko, int wiek)
    {
        Imie = imie;
        Nazwisko = nazwisko;
        Wiek = wiek;
    }

    public void WyswietlInformacje()
    {
        Console.WriteLine($"Imię: {Imie}, Nazwisko: {Nazwisko}, Wiek: {Wiek}");
    }
}

class Program
{
    static void Main()
    {
        Osoba osoba = new Osoba("Dominik", "Pyrzak", 24);
        osoba.WyswietlInformacje();
    }
}
