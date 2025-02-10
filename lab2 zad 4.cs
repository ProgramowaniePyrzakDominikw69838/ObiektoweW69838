using System;

class Licz
{
    private int value;

    public Licz(int value) => this.value = value;

    public void Dodaj(int liczba) => value += liczba;
    public void Odejmij(int liczba) => value -= liczba;
    public void Wypisz() => Console.WriteLine($"Wartość: {value}");
}

class Program
{
    static void Main()
    {
        Licz liczba = new Licz(10);
        liczba.Dodaj(5);
        liczba.Odejmij(3);
        liczba.Wypisz();
    }
}
