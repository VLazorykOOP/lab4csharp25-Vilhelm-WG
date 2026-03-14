namespace Lab3CSharp;
using System;

public class Rectangle
{
    protected int a, b;
    protected int c;

    public int A
    {
        get => a;
        set => a = value;
    }

    public int B
    {
        get => b;
        set => b = value;
    }

    public int C
    {
        get => c;
    }

    public Rectangle(int sideA, int sideB, int color)
    {
        a = sideA;
        b = sideB;
        c = color;
    }

    public void PrintSides() => Console.WriteLine($" Сторона А: {a}, сторона B: {b}");

    public int Perimetr() => 2 * a + 2 * b;

    public int Area() => a * b;

    public bool IsSquare() => a == b;
}