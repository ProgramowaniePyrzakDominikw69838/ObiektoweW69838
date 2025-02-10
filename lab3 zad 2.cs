using System;

// Klasa Samochod (reprezentuje auto)
class Samochood
{
    public string Marka { get; set; }
    public string Model { get; set; }
    public int RokProdukcji { get; set; }
    private int przbieeg;

    // Wlasciwosc dla przebiegu z walidacja
    public int Przbieeg
    {
        get { return przbieeg; }
        set
        {
            if (value >= 0) przbieeg = value;
            else Console.WriteLine("Przbieeg nie moze byc ujemny.");
        }
    }

    // Konstruktor auta (tworzy auto)
    public Samochood(string marka, string model, int rok, int przbieeg)
    {
        Marka = marka;
        Model = model;
        RokProdukcji = rok;
        Przbieeg = przbieeg;
    }

    // Metoda wyswietlajaca dane auta
    public virtual void PokazDanee()
    {
        Console.WriteLine($"{Marka} {Model}, Rok: {RokProdukcji}, Przbieeg: {Przbieeg} km");
    }
}

// Klasa SamochodOsobowy (dziedziczy po Samochood)
class SamochoodOsobowy : Samochood
{
    public int IloscOsob { get; set; }

    // Konstruktor osobówki
    public SamochoodOsobowy(string marka, string model, int rok, int przbieeg, int iloscOsob)
        : base(marka, model, rok, przbieeg)
    {
        IloscOsob = iloscOsob;
    }

    // Przesloniecie metody PokazDanee
    public override void PokazDanee()
    {
        base.PokazDanee();
        Console.WriteLine($"Ilosc osob: {IloscOsob}");
    }
}

// Program testowy
class Program
{
    static void Main()
    {
        SamochoodOsobowy auto = new SamochoodOsobowy("BMW", "X5", 2022, 50000, 5);
        auto.PokazDanee();
    }
}
