using System;

class BankAccount
{
    private decimal saldo;
    public string Wlasciciel { get; private set; }

    public decimal Saldo
    {
        get { return saldo; }
    }

    public BankAccount(string wlasciciel, decimal poczatkoweSaldo)
    {
        Wlasciciel = wlasciciel;
        saldo = poczatkoweSaldo;
    }

    public void Wplata(decimal kwota)
    {
        if (kwota > 0)
        {
            saldo += kwota;
            Console.WriteLine($"Wpłacono {kwota}. Nowe saldo: {Saldo}");
        }
        else
            Console.WriteLine("Kwota wpłaty musi być dodatnia.");
    }

    public void Wyplata(decimal kwota)
    {
        if (kwota > 0 && kwota <= saldo)
        {
            saldo -= kwota;
            Console.WriteLine($"Wypłacono {kwota}. Nowe saldo: {Saldo}");
        }
        else
            Console.WriteLine("Nie można wykonać wypłaty.");
    }
}

class Program
{
    static void Main()
    {
        BankAccount konto = new BankAccount("Dominik Pyrzak", 1500);
        konto.Wplata(500);
        konto.Wyplata(200);
        Console.WriteLine($"Saldo końcowe: {konto.Saldo}");
    }
}
