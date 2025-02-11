using System;
using System.Collections.Generic;

//Klasa baazowa Shape
abstract class Shape
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }

    public Shape(int x, int y, int height, int width)
    {
        X = x;
        Y = y;
        Height = height;
        Width = width;
    }

    public abstract void Draw();
}

//Klasy pochodne
class Rectangle : Shape
{
    public Rectangle(int x, int y, int height, int width) : base(x, y, height, width) { }

    public override void Draw()
    {
        Console.WriteLine($"Rysowanie prostokąta na pozycji ({X}, {Y}) o wymiarach {Width}x{Height}");
    }
}

class Triangle : Shape
{
    public Triangle(int x, int y, int height, int width) : base(x, y, height, width) { }

    public override void Draw()
    {
        Console.WriteLine($"Rysowanie trójkąta na pozycji ({X}, {Y}) o wymiarach {Width}x{Height}");
    }
}

class Circle : Shape
{
    public Circle(int x, int y, int radius) : base(x, y, radius * 2, radius * 2) { }

    public override void Draw()
    {
        Console.WriteLine($"Rysowanie koła na pozycji ({X}, {Y}) o promieniu {Width / 2}");
    }
}

//TEST PROGRAMU
class Program
{
    static void Main()
    {
        List<Shape> figury = new List<Shape>
        {
            new Rectangle(0, 0, 10, 20),
            new Triangle(5, 5, 15, 10),
            new Circle(10, 10, 8)
        };

        Console.WriteLine("Rysowanie figur:");
        foreach (var figura in figury)
        {
            figura.Draw();
        }
    }
}
