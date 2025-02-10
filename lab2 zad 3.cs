using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Imie { get; }
    public string Nazwisko { get; }
    private List<int> oceny = new List<int>();

    public double SredniaOcen => oceny.Any() ? oceny.Average() : 0;

    public Student(string imie, string nazwisko)
    {
        Imie = imie;
        Nazwisko = nazwisko;
    }

    public void DodajOcene(int ocena)
    {
        if (ocena >= 1 && ocena <= 6) oceny.Add(ocena);
    }

    public void WyswietlInformacje()
    {
        Console.WriteLine($"Student: {Imie} {Nazwisko}, Średnia ocen: {SredniaOcen}");
    }
}

class Program
{
    static void Main()
    {
        Student student = new Student("Dominik", "Pyrzak");
        student.DodajOcene(5);
        student.DodajOcene(3);
        student.DodajOcene(4);
        student.WyswietlInformacje();
    }
}
