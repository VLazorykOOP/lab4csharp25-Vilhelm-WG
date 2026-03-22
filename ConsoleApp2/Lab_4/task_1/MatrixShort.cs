namespace ConsoleApp2;
using System;

public class MatrixShort
{
    protected uint[,] ShortArray;
    protected int n, m;
    protected int codeError;
    protected static int num_m;

    // Конструктор без параметрів
    public MatrixShort()
    {
        n = 1;
        m = 1;
        ShortArray = new uint[n, m];
        ShortArray[0, 0] = 0;
        codeError = 0;
        num_m++;
    }

    // Конструктор з двома параметрами - розміри матриці
    public MatrixShort(int rows, int cols)
    {
        n = rows;
        m = cols;
        ShortArray = new uint[n, m];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                ShortArray[i, j] = 0;
        codeError = 0;
        num_m++;
    }

    // Конструктор з трьома параметрами - розміри і значення ініціалізації
    public MatrixShort(int rows, int cols, uint initValue)
    {
        n = rows;
        m = cols;
        ShortArray = new uint[n, m];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                ShortArray[i, j] = initValue;
        codeError = 0;
        num_m++;
    }

    // Деструктор
    ~MatrixShort()
    {
        Console.WriteLine($"Деструктор викликано для матриці {n}x{m}");
    }

    // Метод вводу елементів з клавіатури
    public void Input()
    {
        Console.WriteLine($"Введіть елементи матриці {n}x{m}:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"Елемент [{i},{j}]: ");
                ShortArray[i, j] = uint.Parse(Console.ReadLine() ?? "0");
            }
        }
    }

    // Метод виведення елементів на екран
    public void Print()
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write("[ ");
            for (int j = 0; j < m; j++)
            {
                Console.Write($"{ShortArray[i, j],4}");
                if (j < m - 1) Console.Write(" ");
            }
            Console.WriteLine(" ]");
        }
    }

    // Присвоєння всім елементам значення
    public void AssignValue(uint value)
    {
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                ShortArray[i, j] = value;
    }

    // Статичний метод підрахунку кількості матриць
    public static int GetMatrixCount()
    {
        return num_m;
    }

    // Властивості для отримання розмірів (тільки читання)
    public int N
    {
        get => n;
    }

    public int M
    {
        get => m;
    }

    // Властивість для codeError (читання і запис)
    public int CodeError
    {
        get => codeError;
        set => codeError = value;
    }

    // Індексатор з двома індексами
    public uint this[int i, int j]
    {
        get
        {
            if (i < 0 || i >= n || j < 0 || j >= m)
            {
                codeError = -1;
                return 0;
            }
            return ShortArray[i, j];
        }
        set
        {
            if (i < 0 || i >= n || j < 0 || j >= m)
            {
                codeError = -1;
            }
            else
            {
                ShortArray[i, j] = value;
            }
        }
    }

    // Індексатор з одним індексом (k = i*m + j)
    public uint this[int k]
    {
        get
        {
            int i = k / m;
            int j = k % m;
            if (i < 0 || i >= n || j < 0 || j >= m)
            {
                codeError = -1;
                return 0;
            }
            return ShortArray[i, j];
        }
        set
        {
            int i = k / m;
            int j = k % m;
            if (i < 0 || i >= n || j < 0 || j >= m)
            {
                codeError = -1;
            }
            else
            {
                ShortArray[i, j] = value;
            }
        }
    }

    // Унарна операція ++
    public static MatrixShort operator ++(MatrixShort matrix)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
            for (int j = 0; j < matrix.m; j++)
                result.ShortArray[i, j] = matrix.ShortArray[i, j] + 1;
        return result;
    }

    // Унарна операція --
    public static MatrixShort operator --(MatrixShort matrix)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
            for (int j = 0; j < matrix.m; j++)
                result.ShortArray[i, j] = matrix.ShortArray[i, j] > 0 ? matrix.ShortArray[i, j] - 1 : 0;
        return result;
    }

    // Оператори true і false
    public static bool operator true(MatrixShort matrix)
    {
        if (matrix.n == 0 || matrix.m == 0) return false;
        for (int i = 0; i < matrix.n; i++)
            for (int j = 0; j < matrix.m; j++)
                if (matrix.ShortArray[i, j] == 0) return false;
        return true;
    }

    public static bool operator false(MatrixShort matrix)
    {
        if (matrix.n == 0 || matrix.m == 0) return true;
        for (int i = 0; i < matrix.n; i++)
            for (int j = 0; j < matrix.m; j++)
                if (matrix.ShortArray[i, j] == 0) return true;
        return false;
    }

    // Унарна логічна операція !
    public static bool operator !(MatrixShort matrix)
    {
        return matrix.n == 0 || matrix.m == 0;
    }

    // Унарна побітова операція ~
    public static MatrixShort operator ~(MatrixShort matrix)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
            for (int j = 0; j < matrix.m; j++)
                result.ShortArray[i, j] = ~matrix.ShortArray[i, j];
        return result;
    }

    // Бінарна операція + (додавання двох матриць)
    public static MatrixShort operator +(MatrixShort m1, MatrixShort m2)
    {
        if (m1.n != m2.n || m1.m != m2.m)
            return m1;

        MatrixShort result = new MatrixShort(m1.n, m1.m);
        for (int i = 0; i < m1.n; i++)
            for (int j = 0; j < m1.m; j++)
                result.ShortArray[i, j] = m1.ShortArray[i, j] + m2.ShortArray[i, j];
        return result;
    }

    // Бінарна операція + (додавання матриці і скаляра)
    public static MatrixShort operator +(MatrixShort matrix, short scalar)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
            for (int j = 0; j < matrix.m; j++)
                result.ShortArray[i, j] = (uint)(matrix.ShortArray[i, j] + scalar);
        return result;
    }

    public static MatrixShort operator +(short scalar, MatrixShort matrix)
    {
        return matrix + scalar;
    }

    // Бінарна операція - (віднімання двох матриць)
    public static MatrixShort operator -(MatrixShort m1, MatrixShort m2)
    {
        if (m1.n != m2.n || m1.m != m2.m)
            return m1;

        MatrixShort result = new MatrixShort(m1.n, m1.m);
        for (int i = 0; i < m1.n; i++)
            for (int j = 0; j < m1.m; j++)
                result.ShortArray[i, j] = m1.ShortArray[i, j] > m2.ShortArray[i, j]
                    ? m1.ShortArray[i, j] - m2.ShortArray[i, j]
                    : 0;
        return result;
    }

    // Бінарна операція - (віднімання скаляра з матриці)
    public static MatrixShort operator -(MatrixShort matrix, short scalar)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
            for (int j = 0; j < matrix.m; j++)
                result.ShortArray[i, j] = matrix.ShortArray[i, j] > (uint)scalar
                    ? (uint)(matrix.ShortArray[i, j] - scalar)
                    : 0;
        return result;
    }

    // Бінарна операція * (множення двох матриць - математичне)
    public static MatrixShort operator *(MatrixShort m1, MatrixShort m2)
    {
        if (m1.m != m2.n)
            return m1;

        MatrixShort result = new MatrixShort(m1.n, m2.m);
        for (int i = 0; i < m1.n; i++)
        {
            for (int j = 0; j < m2.m; j++)
            {
                uint sum = 0;
                for (int k = 0; k < m1.m; k++)
                    sum += m1.ShortArray[i, k] * m2.ShortArray[k, j];
                result.ShortArray[i, j] = sum;
            }
        }
        return result;
    }

    // Бінарна операція * (множення матриці на вектор)
    public static VectorShort operator *(MatrixShort matrix, VectorShort vector)
    {
        if (matrix.m != (int)vector.Size)
            return vector;

        VectorShort result = new VectorShort((uint)matrix.n);
        for (int i = 0; i < matrix.n; i++)
        {
            short sum = 0;
            for (int j = 0; j < matrix.m; j++)
                sum += (short)(matrix.ShortArray[i, j] * vector[j]);
            result[i] = sum;
        }
        return result;
    }

    // Бінарна операція * (множення матриці на скаляр)
    public static MatrixShort operator *(MatrixShort matrix, short scalar)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
            for (int j = 0; j < matrix.m; j++)
                result.ShortArray[i, j] = (uint)(matrix.ShortArray[i, j] * scalar);
        return result;
    }

    public static MatrixShort operator *(short scalar, MatrixShort matrix)
    {
        return matrix * scalar;
    }

    // Бінарна операція / (ділення двох матриць)
    public static MatrixShort operator /(MatrixShort m1, MatrixShort m2)
    {
        if (m1.n != m2.n || m1.m != m2.m)
            return m1;

        MatrixShort result = new MatrixShort(m1.n, m1.m);
        for (int i = 0; i < m1.n; i++)
            for (int j = 0; j < m1.m; j++)
                result.ShortArray[i, j] = m2.ShortArray[i, j] != 0
                    ? m1.ShortArray[i, j] / m2.ShortArray[i, j]
                    : 0;
        return result;
    }

    // Бінарна операція / (ділення матриці на скаляр)
    public static MatrixShort operator /(MatrixShort matrix, short scalar)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
            for (int j = 0; j < matrix.m; j++)
                result.ShortArray[i, j] = scalar != 0
                    ? (uint)(matrix.ShortArray[i, j] / scalar)
                    : 0;
        return result;
    }

    // Бінарна операція % (остача від ділення двох матриць)
    public static MatrixShort operator %(MatrixShort m1, MatrixShort m2)
    {
        if (m1.n != m2.n || m1.m != m2.m)
            return m1;

        MatrixShort result = new MatrixShort(m1.n, m1.m);
        for (int i = 0; i < m1.n; i++)
            for (int j = 0; j < m1.m; j++)
                result.ShortArray[i, j] = m2.ShortArray[i, j] != 0
                    ? m1.ShortArray[i, j] % m2.ShortArray[i, j]
                    : 0;
        return result;
    }

    // Бінарна операція % (остача від ділення матриці на скаляр)
    public static MatrixShort operator %(MatrixShort matrix, short scalar)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
            for (int j = 0; j < matrix.m; j++)
                result.ShortArray[i, j] = scalar != 0
                    ? (uint)(matrix.ShortArray[i, j] % scalar)
                    : 0;
        return result;
    }

    // Побітова операція | (побітове АБО двох матриць)
    public static MatrixShort operator |(MatrixShort m1, MatrixShort m2)
    {
        if (m1.n != m2.n || m1.m != m2.m)
            return m1;

        MatrixShort result = new MatrixShort(m1.n, m1.m);
        for (int i = 0; i < m1.n; i++)
            for (int j = 0; j < m1.m; j++)
                result.ShortArray[i, j] = m1.ShortArray[i, j] | m2.ShortArray[i, j];
        return result;
    }

    // Побітова операція | (побітове АБО матриці і скаляра)
    public static MatrixShort operator |(MatrixShort matrix, ushort scalar)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
            for (int j = 0; j < matrix.m; j++)
                result.ShortArray[i, j] = matrix.ShortArray[i, j] | scalar;
        return result;
    }

    public static MatrixShort operator |(ushort scalar, MatrixShort matrix)
    {
        return matrix | scalar;
    }

    // Побітова операція ^ (XOR двох матриць)
    public static MatrixShort operator ^(MatrixShort m1, MatrixShort m2)
    {
        if (m1.n != m2.n || m1.m != m2.m)
            return m1;

        MatrixShort result = new MatrixShort(m1.n, m1.m);
        for (int i = 0; i < m1.n; i++)
            for (int j = 0; j < m1.m; j++)
                result.ShortArray[i, j] = m1.ShortArray[i, j] ^ m2.ShortArray[i, j];
        return result;
    }

    // Побітова операція ^ (XOR матриці і скаляра)
    public static MatrixShort operator ^(MatrixShort matrix, ushort scalar)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
            for (int j = 0; j < matrix.m; j++)
                result.ShortArray[i, j] = matrix.ShortArray[i, j] ^ scalar;
        return result;
    }

    public static MatrixShort operator ^(ushort scalar, MatrixShort matrix)
    {
        return matrix ^ scalar;
    }

    // Побітова операція & (побітове І двох матриць)
    public static MatrixShort operator &(MatrixShort m1, MatrixShort m2)
    {
        if (m1.n != m2.n || m1.m != m2.m)
            return m1;

        MatrixShort result = new MatrixShort(m1.n, m1.m);
        for (int i = 0; i < m1.n; i++)
            for (int j = 0; j < m1.m; j++)
                result.ShortArray[i, j] = m1.ShortArray[i, j] & m2.ShortArray[i, j];
        return result;
    }

    // Побітова операція & (побітове І матриці і скаляра)
    public static MatrixShort operator &(MatrixShort matrix, ushort scalar)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
            for (int j = 0; j < matrix.m; j++)
                result.ShortArray[i, j] = matrix.ShortArray[i, j] & scalar;
        return result;
    }

    public static MatrixShort operator &(ushort scalar, MatrixShort matrix)
    {
        return matrix & scalar;
    }

    // Побітова операція >> (зсув право двох матриць)
    public static MatrixShort operator >>(MatrixShort m1, MatrixShort m2)
    {
        if (m1.n != m2.n || m1.m != m2.m)
            return m1;

        MatrixShort result = new MatrixShort(m1.n, m1.m);
        for (int i = 0; i < m1.n; i++)
            for (int j = 0; j < m1.m; j++)
                result.ShortArray[i, j] = m1.ShortArray[i, j] >> (int)m2.ShortArray[i, j];
        return result;
    }

    // Побітова операція >> (зсув право матриці на скаляр)
    public static MatrixShort operator >>(MatrixShort matrix, int scalar)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
            for (int j = 0; j < matrix.m; j++)
                result.ShortArray[i, j] = matrix.ShortArray[i, j] >> scalar;
        return result;
    }

    // Побітова операція << (зсув ліво двох матриць)
    public static MatrixShort operator <<(MatrixShort m1, MatrixShort m2)
    {
        if (m1.n != m2.n || m1.m != m2.m)
            return m1;

        MatrixShort result = new MatrixShort(m1.n, m1.m);
        for (int i = 0; i < m1.n; i++)
            for (int j = 0; j < m1.m; j++)
                result.ShortArray[i, j] = m1.ShortArray[i, j] << (int)m2.ShortArray[i, j];
        return result;
    }

    // Побітова операція << (зсув ліво матриці на скаляр)
    public static MatrixShort operator <<(MatrixShort matrix, int scalar)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
            for (int j = 0; j < matrix.m; j++)
                result.ShortArray[i, j] = matrix.ShortArray[i, j] << scalar;
        return result;
    }

    // Операція == (рівність)
    public static bool operator ==(MatrixShort m1, MatrixShort m2)
    {
        if (m1.n != m2.n || m1.m != m2.m) return false;
        for (int i = 0; i < m1.n; i++)
            for (int j = 0; j < m1.m; j++)
                if (m1.ShortArray[i, j] != m2.ShortArray[i, j])
                    return false;
        return true;
    }

    // Операція != (нерівність)
    public static bool operator !=(MatrixShort m1, MatrixShort m2)
    {
        return !(m1 == m2);
    }

    // Операція > (більше)
    public static bool operator >(MatrixShort m1, MatrixShort m2)
    {
        if (m1.n != m2.n || m1.m != m2.m) return false;
        for (int i = 0; i < m1.n; i++)
            for (int j = 0; j < m1.m; j++)
                if (m1.ShortArray[i, j] <= m2.ShortArray[i, j])
                    return false;
        return true;
    }

    // Операція < (менше)
    public static bool operator <(MatrixShort m1, MatrixShort m2)
    {
        if (m1.n != m2.n || m1.m != m2.m) return false;
        for (int i = 0; i < m1.n; i++)
            for (int j = 0; j < m1.m; j++)
                if (m1.ShortArray[i, j] >= m2.ShortArray[i, j])
                    return false;
        return true;
    }

    // Операція >= (більше або рівне)
    public static bool operator >=(MatrixShort m1, MatrixShort m2)
    {
        if (m1.n != m2.n || m1.m != m2.m) return false;
        for (int i = 0; i < m1.n; i++)
            for (int j = 0; j < m1.m; j++)
                if (m1.ShortArray[i, j] < m2.ShortArray[i, j])
                    return false;
        return true;
    }

    // Операція <= (менше або рівне)
    public static bool operator <=(MatrixShort m1, MatrixShort m2)
    {
        if (m1.n != m2.n || m1.m != m2.m) return false;
        for (int i = 0; i < m1.n; i++)
            for (int j = 0; j < m1.m; j++)
                if (m1.ShortArray[i, j] > m2.ShortArray[i, j])
                    return false;
        return true;
    }

    // Перевизначення Equals і GetHashCode для коректної роботи операторів == і !=
    public override bool Equals(object? obj)
    {
        if (obj is MatrixShort other)
            return this == other;
        return false;
    }

    public override int GetHashCode()
    {
        int hash = n * 31 + m;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                hash = hash * 31 + ShortArray[i, j].GetHashCode();
        return hash;
    }
}
