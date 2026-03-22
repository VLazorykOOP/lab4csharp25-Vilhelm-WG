namespace ConsoleApp2;
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

    // Індексатор
    public object this[int index]
    {
        get
        {
            return index switch
            {
                0 => a,
                1 => b,
                2 => c,
                _ => throw new IndexOutOfRangeException("Помилка: індекс має бути 0, 1 або 2")
            };
        }
        set
        {
            switch (index)
            {
                case 0:
                    a = (int)value;
                    break;
                case 1:
                    b = (int)value;
                    break;
                case 2:
                    c = (int)value;
                    break;
                default:
                    throw new IndexOutOfRangeException("Помилка: індекс має бути 0, 1 або 2");
            }
        }
    }

    // Перевантаження оператора ++
    public static Rectangle operator ++(Rectangle r)
    {
        r.a++;
        r.b++;
        return r;
    }

    // Перевантаження оператора --
    public static Rectangle operator --(Rectangle r)
    {
        r.a--;
        r.b--;
        return r;
    }

    // Перевантаження true
    public static bool operator true(Rectangle r)
    {
        return r.IsSquare();
    }

    // Перевантаження false
    public static bool operator false(Rectangle r)
    {
        return !r.IsSquare();
    }

    // Перевантаження оператора *
    public static Rectangle operator *(Rectangle r, int scalar)
    {
        r.a *= scalar;
        r.b *= scalar;
        return r;
    }

    public static Rectangle operator *(int scalar, Rectangle r)
    {
        return r * scalar;
    }

    // Перетворення Rectangle в string
    public static explicit operator string(Rectangle r)
    {
        return $"{r.a},{r.b},{r.c}";
    }

    // Перетворення string в Rectangle
    public static explicit operator Rectangle(string s)
    {
        var parts = s.Split(',');
        if (parts.Length != 3)
            throw new ArgumentException("Рядок має містити три значення, розділені комами");

        return new Rectangle(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
    }
}