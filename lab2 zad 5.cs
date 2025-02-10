using System;

class Sumator
{
    private int[] Liczby;

    public Sumator(int[] liczby) => Liczby = liczby;

    public int Suma() => Liczby.Sum();
    public int SumaPodziel2() => Liczby.Where(x => x % 2 == 0).Sum();
    public int IleElementów() => Liczby.Length;
    public void WypiszElementy() => Console.WriteLine(string.Join(", ", Liczby));
    public void WypiszZakres(int low, int high)
    {
        for (int i = 0; i < Liczby.Length; i++)
            if (i >= low && i <= high) Console.Write(Liczby[i] + " ");
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        int[] liczby = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Sumator sumator = new Sumator(liczby);

        Console.WriteLine("Suma: " + sumator.Suma());
        Console.WriteLine("Suma podzielnych przez 2: " + sumator.SumaPodziel2());
        Console.WriteLine("Liczba elementów: " + sumator.IleElementów());

        Console.Write("Elementy tablicy: ");
        sumator.WypiszElementy();

        Console.Write("Elementy od indeksu 2 do 6: ");
        sumator.WypiszZakres(2, 6);
    }
}
