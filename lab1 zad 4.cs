using System;

class Program
{
    static void Main()
    {
        double[] liczby = new double[10];
        Console.WriteLine("Podaj 10 liczb:");

        for (int i = 0; i < 10; i++)
        {
            liczby[i] = Convert.ToDouble(Console.ReadLine());
        }

        double suma = 0;
        double iloczyn = 1;
        double min = liczby[0];
        double max = liczby[0];

        for (int i = 0; i < 10; i++)
        {
            suma += liczby[i];
            iloczyn *= liczby[i];
            if (liczby[i] < min) min = liczby[i];
            if (liczby[i] > max) max = liczby[i];
        }

        Console.WriteLine("Suma: " + suma);
        Console.WriteLine("Iloczyn: " + iloczyn);
        Console.WriteLine("Min: " + min);
        Console.WriteLine("Max: " + max);
    }
}
