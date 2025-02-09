using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Podaj operację (+, -, *, /, ^, sqrt, sin, cos, tan) lub 'exit'");
            string op = Console.ReadLine();
            if (op == "exit") break;

            Console.Write("Podaj pierwszą liczbę: ");
            double a = Convert.ToDouble(Console.ReadLine());
            double b = 0;
            if (op != "sqrt" && op != "sin" && op != "cos" && op != "tan")
            {
                Console.Write("Podaj drugą liczbę: ");
                b = Convert.ToDouble(Console.ReadLine());
            }

            double wynik = op switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
                "/" => a / b,
                "^" => Math.Pow(a, b),
                "sqrt" => Math.Sqrt(a),
                "sin" => Math.Sin(a * Math.PI / 180),
                "cos" => Math.Cos(a * Math.PI / 180),
                "tan" => Math.Tan(a * Math.PI / 180),
                _ => 0
            };
            Console.WriteLine($"Wynik: {wynik}");
        }
    }
}
