using System;
using System.Collections.Generic;

// Klasa reprezentujaca osobe (bazowa)
class Osoba
{
    private string? imie;
    private string? nazwisko;
    private int wiek;

    public string? Imie
    {
        get { return imie; }
        set { imie = !string.IsNullOrWhiteSpace(value) ? value : "Brak imienia"; }
    }

    public string? Nazwisko
    {
        get { return nazwisko; }
        set { nazwisko = !string.IsNullOrWhiteSpace(value) ? value : "Brak nazwiska"; }
    }

    public int Wiek
    {
        get { return wiek; }
        set { wiek = value > 0 ? value : 1; }
    }

    public Osoba(string imie, string nazwisko, int wiek)
    {
        this.Imie = imie;
        this.Nazwisko = nazwisko;
        this.Wiek = wiek;
    }

    public virtual void PokazDane()
    {
        Console.WriteLine($"Osoba: {Imie} {Nazwisko}, Wiek: {Wiek}");
    }
}

// Klasa Ksiazka
class Ksiazka
{
    private string? tytul;
    private Osoba? autor;
    private int rokWydania;

    public string? Tytul
    {
        get { return tytul; }
        set { tytul = !string.IsNullOrWhiteSpace(value) ? value : "Brak tytulu"; }
    }

    public Osoba? Autor
    {
        get { return autor; }
        set { autor = value ?? new Osoba("Nieznany", "Autor", 0); }
    }

    public int RokWydania
    {
        get { return rokWydania; }
        set { rokWydania = value > 0 ? value : 2000; }
    }

    public Ksiazka(string tytul, Osoba autor, int rokWydania)
    {
        this.Tytul = tytul;
        this.Autor = autor;
        this.RokWydania = rokWydania;
    }

    public void PokazDane()
    {
        Console.WriteLine($"Ksiazka: {Tytul}, Autor: {Autor?.Imie} {Autor?.Nazwisko}, Rok wydania: {RokWydania}");
    }
}

// Klasa Czytelnik
class Czytelnik : Osoba
{
    protected List<Ksiazka> przeczytaneKsiazki = new List<Ksiazka>();

    public Czytelnik(string imie, string nazwisko, int wiek) : base(imie, nazwisko, wiek) { }

    public void DodajKsiazke(Ksiazka ksiazka)
    {
        if (ksiazka != null)
            przeczytaneKsiazki.Add(ksiazka);
        else
            Console.WriteLine("Ksiazka nie moze byc null!");
    }

    public void PokazKsiazki()
    {
        Console.WriteLine($"Czytelnik {Imie} {Nazwisko} przeczytal:");
        foreach (var ksiazka in przeczytaneKsiazki)
        {
            Console.WriteLine($"- {ksiazka.Tytul}");
        }
    }

    public override void PokazDane()
    {
        base.PokazDane();
        PokazKsiazki();
    }

    public bool CzyCzytal(string tytul)
    {
        foreach (var ksiazka in przeczytaneKsiazki)
        {
            if (ksiazka.Tytul == tytul)
                return true;
        }
        return false;
    }
}

// Klasa Recenzent
class Recenzent : Czytelnik
{
    private Dictionary<string, string> opinie = new Dictionary<string, string>();

    public Recenzent(string imie, string nazwisko, int wiek) : base(imie, nazwisko, wiek) { }

    public void Recenzuj()
    {
        Random rnd = new Random();
        Console.WriteLine($"Recenzent {Imie} {Nazwisko} ocenil ksiazki:");
        foreach (var ksiazka in przeczytaneKsiazki)
        {
            int ocena = rnd.Next(1, 11);
            Console.WriteLine($"- {ksiazka.Tytul}: {ocena}/10");
        }
    }

    public void DodajOpinie(string tytul, string opinia)
    {
        if (CzyCzytal(tytul))
        {
            opinie[tytul] = opinia;
            Console.WriteLine($"Dodano opinie do ksiazki \"{tytul}\": {opinia}");
        }
        else
        {
            Console.WriteLine($"Nie mozna dodac opinii, bo {Imie} nie czytal tej ksiazki!");
        }
    }

    public void PokazOpinie()
    {
        Console.WriteLine($"Opinie recenzenta {Imie} {Nazwisko}:");
        foreach (var opinia in opinie)
        {
            Console.WriteLine($"- {opinia.Key}: \"{opinia.Value}\"");
        }
    }
}

// TEST PROGRAMU
class Program
{
    static void Main()
    {
        Osoba autor = new Osoba("Dominik", "Pyrzak", 24);
        Ksiazka ks1 = new Ksiazka("C# dla opornych", new Osoba("Jan", "Nowak", 40), 2020);
        Ksiazka ks2 = new Ksiazka("Zaawansowane OOP", new Osoba("Anna", "Kowalska", 35), 2022);

        Recenzent recenzent = new Recenzent("Dominik", "Pyrzak", 24);
        recenzent.DodajKsiazke(ks1);
        recenzent.DodajKsiazke(ks2);

        recenzent.Recenzuj();
        recenzent.DodajOpinie("C# dla opornych", "Mega przydatna ksiazka!");
        recenzent.PokazOpinie();
    }
}
