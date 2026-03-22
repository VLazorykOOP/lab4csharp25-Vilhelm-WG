namespace ConsoleApp2;
using System;

public class VectorShort
{
    protected short[] ShortArray;
    protected uint n;
    protected uint codeError;
    protected static uint num_v;

    // Конструктор без параметрів
    public VectorShort()
    {
        n = 1;
        ShortArray = new short[n];
        ShortArray[0] = 0;
        codeError = 0;
        num_v++;
    }

    // Конструктор з одним параметром - розмір вектора
    public VectorShort(uint size)
    {
        n = size;
        ShortArray = new short[n];
        for (int i = 0; i < n; i++)
            ShortArray[i] = 0;
        codeError = 0;
        num_v++;
    }

    // Конструктор з двома параметрами - розмір і значення ініціалізації
    public VectorShort(uint size, short initValue)
    {
        n = size;
        ShortArray = new short[n];
        for (int i = 0; i < n; i++)
            ShortArray[i] = initValue;
        codeError = 0;
        num_v++;
    }

    // Деструктор
    ~VectorShort()
    {
        Console.WriteLine($"Деструктор викликано для вектора розміром {n}");
    }

    // Метод вводу елементів з клавіатури
    public void Input()
    {
        Console.WriteLine($"Введіть {n} елементів вектора:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Елемент [{i}]: ");
            ShortArray[i] = short.Parse(Console.ReadLine() ?? "0");
        }
    }

    // Метод виведення елементів на екран
    public void Print()
    {
        Console.Write("[ ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(ShortArray[i]);
            if (i < n - 1) Console.Write(", ");
        }
        Console.WriteLine(" ]");
    }

    // Присвоєння всім елементам значення
    public void AssignValue(short value)
    {
        for (int i = 0; i < n; i++)
            ShortArray[i] = value;
    }

    // Статичний метод підрахунку кількості векторів
    public static uint GetVectorCount()
    {
        return num_v;
    }

    // Властивість для отримання розмірності (тільки читання)
    public uint Size
    {
        get => n;
    }

    // Властивість для codeError (читання і запис)
    public uint CodeError
    {
        get => codeError;
        set => codeError = value;
    }

    // Індексатор
    public short this[int index]
    {
        get
        {
            if (index < 0 || index >= n)
            {
                codeError = 10;
                return 0;
            }
            return ShortArray[index];
        }
        set
        {
            if (index < 0 || index >= n)
            {
                codeError = 10;
            }
            else
            {
                ShortArray[index] = value;
            }
        }
    }

    // Унарна операція ++
    public static VectorShort operator ++(VectorShort v)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
            result.ShortArray[i] = (short)(v.ShortArray[i] + 1);
        return result;
    }

    // Унарна операція --
    public static VectorShort operator --(VectorShort v)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
            result.ShortArray[i] = (short)(v.ShortArray[i] - 1);
        return result;
    }

    // Оператори true і false
    public static bool operator true(VectorShort v)
    {
        if (v.n == 0) return false;
        foreach (var elem in v.ShortArray)
            if (elem == 0) return false;
        return true;
    }

    public static bool operator false(VectorShort v)
    {
        if (v.n == 0) return true;
        foreach (var elem in v.ShortArray)
            if (elem == 0) return true;
        return false;
    }

    // Унарна логічна операція !
    public static bool operator !(VectorShort v)
    {
        return v.n == 0;
    }

    // Унарна побітова операція ~
    public static VectorShort operator ~(VectorShort v)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
            result.ShortArray[i] = (short)(~v.ShortArray[i]);
        return result;
    }

    // Бінарна операція + (додавання двох векторів)
    public static VectorShort operator +(VectorShort v1, VectorShort v2)
    {
        uint maxSize = Math.Max(v1.n, v2.n);
        uint minSize = Math.Min(v1.n, v2.n);
        VectorShort result = new VectorShort(maxSize);

        for (int i = 0; i < minSize; i++)
            result.ShortArray[i] = (short)(v1.ShortArray[i] + v2.ShortArray[i]);

        if (v1.n > v2.n)
            for (int i = (int)minSize; i < maxSize; i++)
                result.ShortArray[i] = v1.ShortArray[i];
        else if (v2.n > v1.n)
            for (int i = (int)minSize; i < maxSize; i++)
                result.ShortArray[i] = v2.ShortArray[i];

        return result;
    }

    // Бінарна операція + (додавання вектора і скаляра)
    public static VectorShort operator +(VectorShort v, short scalar)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
            result.ShortArray[i] = (short)(v.ShortArray[i] + scalar);
        return result;
    }

    public static VectorShort operator +(short scalar, VectorShort v)
    {
        return v + scalar;
    }

    // Бінарна операція - (віднімання двох векторів)
    public static VectorShort operator -(VectorShort v1, VectorShort v2)
    {
        uint maxSize = Math.Max(v1.n, v2.n);
        uint minSize = Math.Min(v1.n, v2.n);
        VectorShort result = new VectorShort(maxSize);

        for (int i = 0; i < minSize; i++)
            result.ShortArray[i] = (short)(v1.ShortArray[i] - v2.ShortArray[i]);

        if (v1.n > v2.n)
            for (int i = (int)minSize; i < maxSize; i++)
                result.ShortArray[i] = v1.ShortArray[i];
        else if (v2.n > v1.n)
            for (int i = (int)minSize; i < maxSize; i++)
                result.ShortArray[i] = (short)(-v2.ShortArray[i]);

        return result;
    }

    // Бінарна операція - (віднімання скаляра з вектора)
    public static VectorShort operator -(VectorShort v, short scalar)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
            result.ShortArray[i] = (short)(v.ShortArray[i] - scalar);
        return result;
    }

    public static VectorShort operator -(short scalar, VectorShort v)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
            result.ShortArray[i] = (short)(scalar - v.ShortArray[i]);
        return result;
    }

    // Бінарна операція * (множення двох векторів)
    public static VectorShort operator *(VectorShort v1, VectorShort v2)
    {
        uint maxSize = Math.Max(v1.n, v2.n);
        uint minSize = Math.Min(v1.n, v2.n);
        VectorShort result = new VectorShort(maxSize);

        for (int i = 0; i < minSize; i++)
            result.ShortArray[i] = (short)(v1.ShortArray[i] * v2.ShortArray[i]);

        if (v1.n > v2.n)
            for (int i = (int)minSize; i < maxSize; i++)
                result.ShortArray[i] = v1.ShortArray[i];
        else if (v2.n > v1.n)
            for (int i = (int)minSize; i < maxSize; i++)
                result.ShortArray[i] = v2.ShortArray[i];

        return result;
    }

    // Бінарна операція * (множення вектора на скаляр)
    public static VectorShort operator *(VectorShort v, short scalar)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
            result.ShortArray[i] = (short)(v.ShortArray[i] * scalar);
        return result;
    }

    public static VectorShort operator *(short scalar, VectorShort v)
    {
        return v * scalar;
    }

    // Бінарна операція / (ділення двох векторів)
    public static VectorShort operator /(VectorShort v1, VectorShort v2)
    {
        uint maxSize = Math.Max(v1.n, v2.n);
        uint minSize = Math.Min(v1.n, v2.n);
        VectorShort result = new VectorShort(maxSize);

        for (int i = 0; i < minSize; i++)
            result.ShortArray[i] = v2.ShortArray[i] != 0 ? (short)(v1.ShortArray[i] / v2.ShortArray[i]) : (short)0;

        if (v1.n > v2.n)
            for (int i = (int)minSize; i < maxSize; i++)
                result.ShortArray[i] = v1.ShortArray[i];
        else if (v2.n > v1.n)
            for (int i = (int)minSize; i < maxSize; i++)
                result.ShortArray[i] = v2.ShortArray[i];

        return result;
    }

    // Бінарна операція / (ділення вектора на скаляр)
    public static VectorShort operator /(VectorShort v, ushort scalar)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
            result.ShortArray[i] = scalar != 0 ? (short)(v.ShortArray[i] / scalar) : (short)0;
        return result;
    }

    // Бінарна операція % (остача від ділення двох векторів)
    public static VectorShort operator %(VectorShort v1, VectorShort v2)
    {
        uint maxSize = Math.Max(v1.n, v2.n);
        uint minSize = Math.Min(v1.n, v2.n);
        VectorShort result = new VectorShort(maxSize);

        for (int i = 0; i < minSize; i++)
            result.ShortArray[i] = v2.ShortArray[i] != 0 ? (short)(v1.ShortArray[i] % v2.ShortArray[i]) : (short)0;

        if (v1.n > v2.n)
            for (int i = (int)minSize; i < maxSize; i++)
                result.ShortArray[i] = v1.ShortArray[i];
        else if (v2.n > v1.n)
            for (int i = (int)minSize; i < maxSize; i++)
                result.ShortArray[i] = v2.ShortArray[i];

        return result;
    }

    // Бінарна операція % (остача від ділення вектора на скаляр)
    public static VectorShort operator %(VectorShort v, short scalar)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
            result.ShortArray[i] = scalar != 0 ? (short)(v.ShortArray[i] % scalar) : (short)0;
        return result;
    }

    // Побітова операція | (побітове АБО двох векторів)
    public static VectorShort operator |(VectorShort v1, VectorShort v2)
    {
        uint maxSize = Math.Max(v1.n, v2.n);
        uint minSize = Math.Min(v1.n, v2.n);
        VectorShort result = new VectorShort(maxSize);

        for (int i = 0; i < minSize; i++)
            result.ShortArray[i] = (short)(v1.ShortArray[i] | v2.ShortArray[i]);

        if (v1.n > v2.n)
            for (int i = (int)minSize; i < maxSize; i++)
                result.ShortArray[i] = v1.ShortArray[i];
        else if (v2.n > v1.n)
            for (int i = (int)minSize; i < maxSize; i++)
                result.ShortArray[i] = v2.ShortArray[i];

        return result;
    }

    // Побітова операція | (побітове АБО вектора і скаляра)
    public static VectorShort operator |(VectorShort v, short scalar)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
            result.ShortArray[i] = (short)(v.ShortArray[i] | scalar);
        return result;
    }

    public static VectorShort operator |(short scalar, VectorShort v)
    {
        return v | scalar;
    }

    // Побітова операція ^ (XOR двох векторів)
    public static VectorShort operator ^(VectorShort v1, VectorShort v2)
    {
        uint maxSize = Math.Max(v1.n, v2.n);
        uint minSize = Math.Min(v1.n, v2.n);
        VectorShort result = new VectorShort(maxSize);

        for (int i = 0; i < minSize; i++)
            result.ShortArray[i] = (short)(v1.ShortArray[i] ^ v2.ShortArray[i]);

        if (v1.n > v2.n)
            for (int i = (int)minSize; i < maxSize; i++)
                result.ShortArray[i] = v1.ShortArray[i];
        else if (v2.n > v1.n)
            for (int i = (int)minSize; i < maxSize; i++)
                result.ShortArray[i] = v2.ShortArray[i];

        return result;
    }

    // Побітова операція ^ (XOR вектора і скаляра)
    public static VectorShort operator ^(VectorShort v, short scalar)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
            result.ShortArray[i] = (short)(v.ShortArray[i] ^ scalar);
        return result;
    }

    public static VectorShort operator ^(short scalar, VectorShort v)
    {
        return v ^ scalar;
    }

    // Побітова операція & (побітове І двох векторів)
    public static VectorShort operator &(VectorShort v1, VectorShort v2)
    {
        uint maxSize = Math.Max(v1.n, v2.n);
        uint minSize = Math.Min(v1.n, v2.n);
        VectorShort result = new VectorShort(maxSize);

        for (int i = 0; i < minSize; i++)
            result.ShortArray[i] = (short)(v1.ShortArray[i] & v2.ShortArray[i]);

        if (v1.n > v2.n)
            for (int i = (int)minSize; i < maxSize; i++)
                result.ShortArray[i] = v1.ShortArray[i];
        else if (v2.n > v1.n)
            for (int i = (int)minSize; i < maxSize; i++)
                result.ShortArray[i] = v2.ShortArray[i];

        return result;
    }

    // Побітова операція & (побітове І вектора і скаляра)
    public static VectorShort operator &(VectorShort v, short scalar)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
            result.ShortArray[i] = (short)(v.ShortArray[i] & scalar);
        return result;
    }

    public static VectorShort operator &(short scalar, VectorShort v)
    {
        return v & scalar;
    }

    // Побітова операція >> (зсув право двох векторів)
    public static VectorShort operator >>(VectorShort v1, VectorShort v2)
    {
        uint maxSize = Math.Max(v1.n, v2.n);
        uint minSize = Math.Min(v1.n, v2.n);
        VectorShort result = new VectorShort(maxSize);

        for (int i = 0; i < minSize; i++)
            result.ShortArray[i] = (short)(v1.ShortArray[i] >> v2.ShortArray[i]);

        if (v1.n > v2.n)
            for (int i = (int)minSize; i < maxSize; i++)
                result.ShortArray[i] = v1.ShortArray[i];
        else if (v2.n > v1.n)
            for (int i = (int)minSize; i < maxSize; i++)
                result.ShortArray[i] = v2.ShortArray[i];

        return result;
    }

    // Побітова операція >> (зсув право вектора на скаляр)
    public static VectorShort operator >>(VectorShort v, int scalar)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
            result.ShortArray[i] = (short)(v.ShortArray[i] >> scalar);
        return result;
    }

    // Побітова операція << (зсув ліво двох векторів)
    public static VectorShort operator <<(VectorShort v1, VectorShort v2)
    {
        uint maxSize = Math.Max(v1.n, v2.n);
        uint minSize = Math.Min(v1.n, v2.n);
        VectorShort result = new VectorShort(maxSize);

        for (int i = 0; i < minSize; i++)
            result.ShortArray[i] = (short)(v1.ShortArray[i] << v2.ShortArray[i]);

        if (v1.n > v2.n)
            for (int i = (int)minSize; i < maxSize; i++)
                result.ShortArray[i] = v1.ShortArray[i];
        else if (v2.n > v1.n)
            for (int i = (int)minSize; i < maxSize; i++)
                result.ShortArray[i] = v2.ShortArray[i];

        return result;
    }

    // Побітова операція << (зсув ліво вектора на скаляр)
    public static VectorShort operator <<(VectorShort v, int scalar)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
            result.ShortArray[i] = (short)(v.ShortArray[i] << scalar);
        return result;
    }

    // Операція == (рівність)
    public static bool operator ==(VectorShort v1, VectorShort v2)
    {
        if (v1.n != v2.n) return false;
        for (int i = 0; i < v1.n; i++)
            if (v1.ShortArray[i] != v2.ShortArray[i])
                return false;
        return true;
    }

    // Операція != (нерівність)
    public static bool operator !=(VectorShort v1, VectorShort v2)
    {
        return !(v1 == v2);
    }

    // Операція > (більше)
    public static bool operator >(VectorShort v1, VectorShort v2)
    {
        uint minSize = Math.Min(v1.n, v2.n);
        for (int i = 0; i < minSize; i++)
            if (v1.ShortArray[i] <= v2.ShortArray[i])
                return false;
        return true;
    }

    // Операція < (менше)
    public static bool operator <(VectorShort v1, VectorShort v2)
    {
        uint minSize = Math.Min(v1.n, v2.n);
        for (int i = 0; i < minSize; i++)
            if (v1.ShortArray[i] >= v2.ShortArray[i])
                return false;
        return true;
    }

    // Операція >= (більше або рівне)
    public static bool operator >=(VectorShort v1, VectorShort v2)
    {
        uint minSize = Math.Min(v1.n, v2.n);
        for (int i = 0; i < minSize; i++)
            if (v1.ShortArray[i] < v2.ShortArray[i])
                return false;
        return true;
    }

    // Операція <= (менше або рівне)
    public static bool operator <=(VectorShort v1, VectorShort v2)
    {
        uint minSize = Math.Min(v1.n, v2.n);
        for (int i = 0; i < minSize; i++)
            if (v1.ShortArray[i] > v2.ShortArray[i])
                return false;
        return true;
    }

    // Перевизначення Equals і GetHashCode для коректної роботи операторів == і !=
    public override bool Equals(object? obj)
    {
        if (obj is VectorShort other)
            return this == other;
        return false;
    }

    public override int GetHashCode()
    {
        int hash = (int)n;
        foreach (var elem in ShortArray)
            hash = hash * 31 + elem.GetHashCode();
        return hash;
    }
}
