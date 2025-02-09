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

        Console.WriteLine("Od pierwszego do ostatniego:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write(liczby[i] + " ");
        }
        Console.WriteLine();

        Console.WriteLine("Od ostatniego do pierwszego:");
        for (int i = 9; i >= 0; i--)
        {
            Console.Write(liczby[i] + " ");
        }
        Console.WriteLine();
    }
}
