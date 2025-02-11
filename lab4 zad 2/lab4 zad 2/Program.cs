using System;
using System.Collections.Generic;

//Klasa bazowa Osoba
abstract class Osoba
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Pesel { get; set; }

    public Osoba(string imie, string nazwisko, string pesel)
    {
        Imie = imie;
        Nazwisko = nazwisko;
        Pesel = pesel;
    }

    public int GetAge()
    {
        int rok = int.Parse(Pesel.Substring(0, 2));
        rok += (rok < 30) ? 2000 : 1900;
        return DateTime.Now.Year - rok;
    }

    public string GetGender()
    {
        return (int.Parse(Pesel[9].ToString()) % 2 == 0) ? "Kobieta" : "Mężczyzna";
    }

    public abstract string GetEducationInfo();
    public abstract bool CanGoAloneToHome();
}

//Klasa Uczen
class Uczen : Osoba
{
    public string Szkola { get; set; }
    public bool MozeSamWracacDoDomu { get; set; }

    public Uczen(string imie, string nazwisko, string pesel, string szkola, bool mozeSamWracacDoDomu)
        : base(imie, nazwisko, pesel)
    {
        Szkola = szkola;
        MozeSamWracacDoDomu = mozeSamWracacDoDomu;
    }

    public override string GetEducationInfo()
    {
        return $"Uczeń {Imie} {Nazwisko}, szkoła: {Szkola}";
    }

    public override bool CanGoAloneToHome()
    {
        return GetAge() >= 12 || MozeSamWracacDoDomu;
    }
}

//Klasa Nauczyciel
class Nauczyciel : Osoba
{
    public string TytulNaukowy { get; set; }
    public List<Uczen> PodwladniUczniowie { get; set; }

    public Nauczyciel(string imie, string nazwisko, string pesel, string tytul)
        : base(imie, nazwisko, pesel)
    {
        TytulNaukowy = tytul;
        PodwladniUczniowie = new List<Uczen>();
    }

    public override string GetEducationInfo()
    {
        return $"Nauczyciel {TytulNaukowy} {Imie} {Nazwisko}";
    }

    public override bool CanGoAloneToHome()
    {
        return true; // Nauczyciel zawsze może iść sam do domu
    }

    public void WhichStudentCanGoHomeAlone()
    {
        Console.WriteLine($"Uczniowie mogący wrócić sami do domu:");
        foreach (var uczen in PodwladniUczniowie)
        {
            if (uczen.CanGoAloneToHome())
            {
                Console.WriteLine($"- {uczen.Imie} {uczen.Nazwisko}");
            }
        }
    }
}

// TEST PROGRAMU
class Program
{
    static void Main()
    {
        Console.WriteLine("\nTestowanie klasy Osoba, Uczen, Nauczyciel:");

        Uczen uczen1 = new Uczen("Jan", "Kowalski", "02123112345", "Szkoła Podstawowa nr 1", false);
        Uczen uczen2 = new Uczen("Anna", "Nowak", "08123122345", "Szkoła Podstawowa nr 1", true);

        Nauczyciel nauczyciel = new Nauczyciel("Dominik", "Pyrzak", "002520572575", "Dr");
        nauczyciel.PodwladniUczniowie.Add(uczen1);
        nauczyciel.PodwladniUczniowie.Add(uczen2);

        Console.WriteLine(nauczyciel.GetEducationInfo());
        Console.WriteLine(uczen1.GetEducationInfo());
        Console.WriteLine(uczen2.GetEducationInfo());

        nauczyciel.WhichStudentCanGoHomeAlone();
    }
}
