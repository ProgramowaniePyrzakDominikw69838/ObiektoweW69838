using System;
using System.Collections.Generic;

enum StatusZamowienia
{
    Oczekujące,
    Przyjęte,
    Zrealizowane,
    Anulowane
}

class Sklep
{
    private Dictionary<int, (StatusZamowienia status, List<string> produkty)> zamowienia = new Dictionary<int, (StatusZamowienia, List<string>)>();

    public void DodajZamowienie(int numer, List<string> produkty)
    {
        zamowienia[numer] = (StatusZamowienia.Oczekujące, produkty);
        Console.WriteLine($"Dodano zamówienie nr {numer}.");
    }

    public void ZmienStatusZamowienia(int numer, StatusZamowienia nowyStatus)
    {
        try
        {
            if (!zamowienia.ContainsKey(numer))
                throw new KeyNotFoundException("Nie znaleziono zamówienia o podanym numerze.");

            if (zamowienia[numer].status == nowyStatus)
                throw new ArgumentException("Zamówienie już ma ten status.");

            zamowienia[numer] = (nowyStatus, zamowienia[numer].produkty);
            Console.WriteLine($"Zmieniono status zamówienia nr {numer} na {nowyStatus}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
        }
    }

    public void WyswietlZamowienia()
    {
        foreach (var zamowienie in zamowienia)
        {
            Console.WriteLine($"Nr: {zamowienie.Key}, Status: {zamowienie.Value.status}, Produkty: {string.Join(", ", zamowienie.Value.produkty)}");
        }
    }
}

class Program
{
    static void Main()
    {
        Sklep sklep = new Sklep();

        sklep.DodajZamowienie(1, new List<string> { "Jabłka", "Chleb" });
        sklep.DodajZamowienie(2, new List<string> { "Mleko", "Ser" });

        sklep.WyswietlZamowienia();
        sklep.ZmienStatusZamowienia(1, StatusZamowienia.Przyjęte);
        sklep.WyswietlZamowienia();
    }
}
