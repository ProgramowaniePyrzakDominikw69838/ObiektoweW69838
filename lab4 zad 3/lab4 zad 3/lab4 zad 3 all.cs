using System;
using System.Collections.Generic;
using System.Linq;

// Zadanie 3a: Interfejs IOsoba i klasa Osoba
public interface IOsoba
{
    string Imie { get; set; }
    string Nazwisko { get; set; }
    string ZwrocPelnaNazwe();
}

public class Osoba : IOsoba
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }

    public Osoba(string imie, string nazwisko)
    {
        Imie = imie;
        Nazwisko = nazwisko;
    }

    public string ZwrocPelnaNazwe()
    {
        return $"{Imie} {Nazwisko}";
    }
}

//Zadanie 3b: Metoda rozszerzająca List<IOsoba>.WypiszOsoby()
public static class OsobaExtensions
{
    public static void WypiszOsoby(this List<IOsoba> osoby)
    {
        foreach (var osoba in osoby)
        {
            Console.WriteLine(osoba.ZwrocPelnaNazwe());
        }
    }

    // Zadanie 3c: Metoda rozszerzająca List<IOsoba>.PosortujOsobyPoNazwisku()
    public static void PosortujOsobyPoNazwisku(this List<IOsoba> osoby)
    {
        osoby.Sort((o1, o2) => o1.Nazwisko.CompareTo(o2.Nazwisko));
    }
}

//Zadanie 3d: Interfejs IStudent rozszerzający IOsoba
public interface IStudent : IOsoba
{
    string Uczelnia { get; set; }
    string Kierunek { get; set; }
    int Rok { get; set; }
    int Semestr { get; set; }

    string WypiszPelnaNazweIUczelnie();
}

public class Student : Osoba, IStudent
{
    public string Uczelnia { get; set; }
    public string Kierunek { get; set; }
    public int Rok { get; set; }
    public int Semestr { get; set; }

    public Student(string imie, string nazwisko, string uczelnia, string kierunek, int rok, int semestr)
        : base(imie, nazwisko)
    {
        Uczelnia = uczelnia;
        Kierunek = kierunek;
        Rok = rok;
        Semestr = semestr;
    }

    public string WypiszPelnaNazweIUczelnie()
    {
        return $"{ZwrocPelnaNazwe()} – {Kierunek} {Rok} rok, {Semestr} semestr, {Uczelnia}";
    }
}

//Zadanie 3e: Klasa StudentWSIiZ dziedzicząca po Student
public class StudentWSIiZ : Student
{
    public StudentWSIiZ(string imie, string nazwisko, string kierunek, int rok, int semestr)
        : base(imie, nazwisko, "WSIiZ", kierunek, rok, semestr) { }
}

//TEST PROGRAMU
class Program
{
    static void Main()
    {
        List<IOsoba> osoby = new List<IOsoba>
        {
            new Osoba("Jan", "Kowalski"),
            new Osoba("Anna", "Nowak"),
            new Student("Marek", "Zieliński", "UJ", "Informatyka", 3, 1),
            new StudentWSIiZ("Dominik", "Pyrzak", "Programowanie", 2, 4),
            new StudentWSIiZ("Agnieszka", "Kowal", "Sztuczna Inteligencja", 1, 2)
        };

        Console.WriteLine("Lista osób przed sortowaniem:");
        osoby.WypiszOsoby();

        osoby.PosortujOsobyPoNazwisku();

        Console.WriteLine("\nLista osób po sortowaniu:");
        osoby.WypiszOsoby();

        Console.WriteLine("\nPełne informacje o studentach:");
        foreach (var osoba in osoby)
        {
            if (osoba is IStudent student)
            {
                Console.WriteLine(student.WypiszPelnaNazweIUczelnie());
            }
        }
    }
}
