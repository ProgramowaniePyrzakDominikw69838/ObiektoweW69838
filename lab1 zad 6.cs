using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Podaj ilość liczb:");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] tab = new int[n];

        Console.WriteLine("Podaj liczby:");
        for (int i = 0; i < n; i++)
        {
            tab[i] = Convert.ToInt32(Console.ReadLine());
        }

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (tab[j] > tab[j + 1])
                {
                    int temp = tab[j];
                    tab[j] = tab[j + 1];
                    tab[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("Posortowane liczby:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(tab[i] + " ");
        }
    }
}
