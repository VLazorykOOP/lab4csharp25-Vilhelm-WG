namespace ConsoleApp2;
using System;

internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Lab 4 - меню");
            Console.WriteLine("3 - Task 3 (MatrixShort)");
            Console.WriteLine("2 - Task 2 (VectorShort)");
            Console.WriteLine("1 - Task 1 (Rectangle - базові операції + нові операції)");
            Console.WriteLine("0 - Вихід");
            Console.Write("Ваш вибір: ");

            string? choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "3":
                {
                    Console.WriteLine("=== Тестування класу MatrixShort ===\n");

                    // Тест конструкторів
                    Console.WriteLine("--- Тест конструкторів ---");
                    MatrixShort m1 = new MatrixShort();
                    Console.WriteLine("m1 (без параметрів):");
                    m1.Print();

                    MatrixShort m2 = new MatrixShort(2, 3);
                    Console.WriteLine("\nm2 (2x3):");
                    m2.Print();

                    MatrixShort m3 = new MatrixShort(2, 2, 5);
                    Console.WriteLine("\nm3 (2x2, значення 5):");
                    m3.Print();

                    Console.WriteLine($"\nКількість створених матриць: {MatrixShort.GetMatrixCount()}");

                    // Тест індексаторів
                    Console.WriteLine("\n--- Тест індексаторів ---");
                    MatrixShort m4 = new MatrixShort(2, 3);
                    m4[0, 0] = 1;
                    m4[0, 1] = 2;
                    m4[0, 2] = 3;
                    m4[1, 0] = 4;
                    m4[1, 1] = 5;
                    m4[1, 2] = 6;
                    Console.WriteLine("m4 (індексатор [i,j]):");
                    m4.Print();

                    Console.WriteLine($"\nm4[0,0] = {m4[0, 0]}, m4[1,2] = {m4[1, 2]}");

                    MatrixShort m5 = new MatrixShort(2, 3);
                    m5[0] = 10;
                    m5[1] = 20;
                    m5[5] = 60;
                    Console.WriteLine("\nm5 (індексатор [k], де k=i*m+j):");
                    m5.Print();
                    Console.WriteLine($"m5[0] = {m5[0]}, m5[5] = {m5[5]}");

                    // Тест невірних індексів
                    uint invalid = m4[10, 10];
                    Console.WriteLine($"\nСпроба читання m4[10,10]: значення = {invalid}, CodeError = {m4.CodeError}");

                    // Тест унарних операторів ++ і --
                    Console.WriteLine("\n--- Тест операторів ++ і -- ---");
                    MatrixShort m6 = new MatrixShort(2, 2, 5);
                    Console.WriteLine("m6 до ++:");
                    m6.Print();
                    m6++;
                    Console.WriteLine("\nm6 після ++:");
                    m6.Print();
                    m6--;
                    Console.WriteLine("\nm6 після --:");
                    m6.Print();

                    // Тест операторів true/false
                    Console.WriteLine("\n--- Тест операторів true/false ---");
                    MatrixShort m7 = new MatrixShort(2, 2, 5);
                    MatrixShort m8 = new MatrixShort(2, 2, 0);
                    Console.WriteLine($"m7 (всі елементи 5): {(m7 ? "true" : "false")}");
                    Console.WriteLine($"m8 (всі елементи 0): {(m8 ? "true" : "false")}");

                    // Тест оператора !
                    Console.WriteLine("\n--- Тест оператора ! ---");
                    MatrixShort m9 = new MatrixShort(2, 2);
                    MatrixShort m10 = new MatrixShort(0, 0);
                    Console.WriteLine($"!m9 (розмір 2x2): {!m9}");
                    Console.WriteLine($"!m10 (розмір 0x0): {!m10}");

                    // Тест побітового ~
                    Console.WriteLine("\n--- Тест оператора ~ ---");
                    MatrixShort m11 = new MatrixShort(2, 2, 5);
                    Console.WriteLine("m11:");
                    m11.Print();
                    MatrixShort m11Not = ~m11;
                    Console.WriteLine("\n~m11:");
                    m11Not.Print();

                    // Тест арифметичних операцій
                    Console.WriteLine("\n--- Тест арифметичних операцій ---");
                    MatrixShort ma1 = new MatrixShort(2, 2, 10);
                    MatrixShort ma2 = new MatrixShort(2, 2, 3);

                    Console.WriteLine("ma1:");
                    ma1.Print();
                    Console.WriteLine("\nma2:");
                    ma2.Print();

                    MatrixShort maAdd = ma1 + ma2;
                    Console.WriteLine("\nma1 + ma2:");
                    maAdd.Print();

                    MatrixShort maSub = ma1 - ma2;
                    Console.WriteLine("\nma1 - ma2:");
                    maSub.Print();

                    MatrixShort maDiv = ma1 / ma2;
                    Console.WriteLine("\nma1 / ma2:");
                    maDiv.Print();

                    MatrixShort maMod = ma1 % ma2;
                    Console.WriteLine("\nma1 % ma2:");
                    maMod.Print();

                    // Тест операцій з скаляром
                    Console.WriteLine("\n--- Тест операцій з скаляром ---");
                    MatrixShort ms1 = new MatrixShort(2, 2, 10);
                    Console.WriteLine("ms1:");
                    ms1.Print();

                    MatrixShort msAddScalar = ms1 + 5;
                    Console.WriteLine("\nms1 + 5:");
                    msAddScalar.Print();

                    MatrixShort msMulScalar = ms1 * 2;
                    Console.WriteLine("\nms1 * 2:");
                    msMulScalar.Print();

                    // Тест математичного множення матриць
                    Console.WriteLine("\n--- Тест математичного множення матриць ---");
                    MatrixShort mm1 = new MatrixShort(2, 3);
                    mm1[0, 0] = 1; mm1[0, 1] = 2; mm1[0, 2] = 3;
                    mm1[1, 0] = 4; mm1[1, 1] = 5; mm1[1, 2] = 6;

                    MatrixShort mm2 = new MatrixShort(3, 2);
                    mm2[0, 0] = 1; mm2[0, 1] = 2;
                    mm2[1, 0] = 3; mm2[1, 1] = 4;
                    mm2[2, 0] = 5; mm2[2, 1] = 6;

                    Console.WriteLine("mm1 (2x3):");
                    mm1.Print();
                    Console.WriteLine("\nmm2 (3x2):");
                    mm2.Print();

                    MatrixShort mmMul = mm1 * mm2;
                    Console.WriteLine("\nmm1 * mm2 (має бути 2x2):");
                    mmMul.Print();

                    // Тест множення матриці на вектор
                    Console.WriteLine("\n--- Тест множення матриці на вектор ---");
                    MatrixShort mv1 = new MatrixShort(2, 3);
                    mv1[0, 0] = 1; mv1[0, 1] = 2; mv1[0, 2] = 3;
                    mv1[1, 0] = 4; mv1[1, 1] = 5; mv1[1, 2] = 6;

                    VectorShort vec1 = new VectorShort(3, 2);

                    Console.WriteLine("mv1 (2x3):");
                    mv1.Print();
                    Console.Write("\nvec1 (розмір 3): ");
                    vec1.Print();

                    VectorShort mvResult = mv1 * vec1;
                    Console.Write("\nmv1 * vec1 (має бути вектор розміру 2): ");
                    mvResult.Print();

                    // Тест побітових операцій
                    Console.WriteLine("\n--- Тест побітових операцій ---");
                    MatrixShort mb1 = new MatrixShort(2, 2, 12);  // 1100
                    MatrixShort mb2 = new MatrixShort(2, 2, 10);  // 1010

                    Console.WriteLine("mb1 (12):");
                    mb1.Print();
                    Console.WriteLine("\nmb2 (10):");
                    mb2.Print();

                    MatrixShort mbOr = mb1 | mb2;
                    Console.WriteLine("\nmb1 | mb2:");
                    mbOr.Print();

                    MatrixShort mbXor = mb1 ^ mb2;
                    Console.WriteLine("\nmb1 ^ mb2:");
                    mbXor.Print();

                    MatrixShort mbAnd = mb1 & mb2;
                    Console.WriteLine("\nmb1 & mb2:");
                    mbAnd.Print();

                    MatrixShort mbShr = mb1 >> 2;
                    Console.WriteLine("\nmb1 >> 2:");
                    mbShr.Print();

                    MatrixShort mbShl = mb1 << 1;
                    Console.WriteLine("\nmb1 << 1:");
                    mbShl.Print();

                    // Тест операцій порівняння
                    Console.WriteLine("\n--- Тест операцій порівняння ---");
                    MatrixShort mc1 = new MatrixShort(2, 2, 10);
                    MatrixShort mc2 = new MatrixShort(2, 2, 10);
                    MatrixShort mc3 = new MatrixShort(2, 2, 5);

                    Console.WriteLine($"mc1 == mc2: {mc1 == mc2}");
                    Console.WriteLine($"mc1 != mc3: {mc1 != mc3}");
                    Console.WriteLine($"mc1 > mc3: {mc1 > mc3}");
                    Console.WriteLine($"mc3 < mc1: {mc3 < mc1}");
                    Console.WriteLine($"mc1 >= mc2: {mc1 >= mc2}");
                    Console.WriteLine($"mc3 <= mc1: {mc3 <= mc1}");

                    break;
                }

                case "2":
                {
                    Console.WriteLine("=== Тестування класу VectorShort ===\n");

                    // Тест конструкторів
                    Console.WriteLine("--- Тест конструкторів ---");
                    VectorShort v1 = new VectorShort();
                    Console.Write("v1 (без параметрів): ");
                    v1.Print();

                    VectorShort v2 = new VectorShort(5);
                    Console.Write("v2 (розмір 5): ");
                    v2.Print();

                    VectorShort v3 = new VectorShort(4, 10);
                    Console.Write("v3 (розмір 4, значення 10): ");
                    v3.Print();

                    Console.WriteLine($"Кількість створених векторів: {VectorShort.GetVectorCount()}");

                    // Тест індексатора
                    Console.WriteLine("\n--- Тест індексатора ---");
                    VectorShort v4 = new VectorShort(3, 5);
                    Console.WriteLine($"v4[0] = {v4[0]}, v4[1] = {v4[1]}, v4[2] = {v4[2]}");
                    v4[1] = 20;
                    Console.Write("Після v4[1] = 20: ");
                    v4.Print();

                    short invalidRead = v4[10];
                    Console.WriteLine($"Спроба читання v4[10]: значення = {invalidRead}, CodeError = {v4.CodeError}");

                    // Тест унарних операторів ++ і --
                    Console.WriteLine("\n--- Тест операторів ++ і -- ---");
                    VectorShort v5 = new VectorShort(3, 5);
                    Console.Write("v5 до ++: ");
                    v5.Print();
                    v5++;
                    Console.Write("v5 після ++: ");
                    v5.Print();
                    v5--;
                    Console.Write("v5 після --: ");
                    v5.Print();

                    // Тест операторів true/false
                    Console.WriteLine("\n--- Тест операторів true/false ---");
                    VectorShort v6 = new VectorShort(3, 5);
                    VectorShort v7 = new VectorShort(3, 0);
                    Console.WriteLine($"v6 (всі елементи 5): {(v6 ? "true" : "false")}");
                    Console.WriteLine($"v7 (всі елементи 0): {(v7 ? "true" : "false")}");

                    // Тест оператора !
                    Console.WriteLine("\n--- Тест оператора ! ---");
                    VectorShort v8 = new VectorShort(3);
                    VectorShort v9 = new VectorShort(0);
                    Console.WriteLine($"!v8 (розмір 3): {!v8}");
                    Console.WriteLine($"!v9 (розмір 0): {!v9}");

                    // Тест побітового ~
                    Console.WriteLine("\n--- Тест оператора ~ ---");
                    VectorShort v10 = new VectorShort(3, 5);
                    Console.Write("v10: ");
                    v10.Print();
                    VectorShort v10Not = ~v10;
                    Console.Write("~v10: ");
                    v10Not.Print();

                    // Тест арифметичних операцій
                    Console.WriteLine("\n--- Тест арифметичних операцій ---");
                    VectorShort va1 = new VectorShort(3, 10);
                    VectorShort va2 = new VectorShort(3, 3);

                    Console.Write("va1: ");
                    va1.Print();
                    Console.Write("va2: ");
                    va2.Print();

                    VectorShort vaAdd = va1 + va2;
                    Console.Write("va1 + va2: ");
                    vaAdd.Print();

                    VectorShort vaSub = va1 - va2;
                    Console.Write("va1 - va2: ");
                    vaSub.Print();

                    VectorShort vaMul = va1 * va2;
                    Console.Write("va1 * va2: ");
                    vaMul.Print();

                    VectorShort vaDiv = va1 / va2;
                    Console.Write("va1 / va2: ");
                    vaDiv.Print();

                    VectorShort vaMod = va1 % va2;
                    Console.Write("va1 % va2: ");
                    vaMod.Print();

                    // Тест операцій з скаляром
                    Console.WriteLine("\n--- Тест операцій з скаляром ---");
                    VectorShort vs1 = new VectorShort(3, 10);
                    Console.Write("vs1: ");
                    vs1.Print();

                    VectorShort vsAddScalar = vs1 + 5;
                    Console.Write("vs1 + 5: ");
                    vsAddScalar.Print();

                    VectorShort vsMulScalar = vs1 * 2;
                    Console.Write("vs1 * 2: ");
                    vsMulScalar.Print();

                    // Тест побітових операцій
                    Console.WriteLine("\n--- Тест побітових операцій ---");
                    VectorShort vb1 = new VectorShort(3, 12);  // 1100
                    VectorShort vb2 = new VectorShort(3, 10);  // 1010

                    Console.Write("vb1 (12): ");
                    vb1.Print();
                    Console.Write("vb2 (10): ");
                    vb2.Print();

                    VectorShort vbOr = vb1 | vb2;
                    Console.Write("vb1 | vb2: ");
                    vbOr.Print();

                    VectorShort vbXor = vb1 ^ vb2;
                    Console.Write("vb1 ^ vb2: ");
                    vbXor.Print();

                    VectorShort vbAnd = vb1 & vb2;
                    Console.Write("vb1 & vb2: ");
                    vbAnd.Print();

                    VectorShort vbShr = vb1 >> 2;
                    Console.Write("vb1 >> 2: ");
                    vbShr.Print();

                    VectorShort vbShl = vb1 << 1;
                    Console.Write("vb1 << 1: ");
                    vbShl.Print();

                    // Тест операцій порівняння
                    Console.WriteLine("\n--- Тест операцій порівняння ---");
                    VectorShort vc1 = new VectorShort(3, 10);
                    VectorShort vc2 = new VectorShort(3, 10);
                    VectorShort vc3 = new VectorShort(3, 5);

                    Console.WriteLine($"vc1 == vc2: {vc1 == vc2}");
                    Console.WriteLine($"vc1 != vc3: {vc1 != vc3}");
                    Console.WriteLine($"vc1 > vc3: {vc1 > vc3}");
                    Console.WriteLine($"vc3 < vc1: {vc3 < vc1}");
                    Console.WriteLine($"vc1 >= vc2: {vc1 >= vc2}");
                    Console.WriteLine($"vc3 <= vc1: {vc3 <= vc1}");

                    // Тест роботи з векторами різного розміру
                    Console.WriteLine("\n--- Тест векторів різного розміру ---");
                    VectorShort vd1 = new VectorShort(5, 2);
                    VectorShort vd2 = new VectorShort(3, 1);

                    Console.Write("vd1 (розмір 5): ");
                    vd1.Print();
                    Console.Write("vd2 (розмір 3): ");
                    vd2.Print();

                    VectorShort vdAdd = vd1 + vd2;
                    Console.Write("vd1 + vd2: ");
                    vdAdd.Print();
                    Console.WriteLine($"Розмір результату: {vdAdd.Size}");

                    break;
                }


                case "1":
                {
                    Rectangle[] rects = new Rectangle[]
                    {
                        new Rectangle(5, 5, 2),
                        new Rectangle(10, 2, 1),
                        new Rectangle(4, 4, 1),
                        new Rectangle(3, 8, 3)
                    };

                    // 1. Визначення кількості квадратів
                    int squareCount = rects.Count(r => r.IsSquare());
                    Console.WriteLine($"--- Кількість квадратів: {squareCount} ---\n");

                    // 2. Впорядкування за кольорами
                    Console.WriteLine("Впорядковано за КОЛЬОРОМ:");
                    var byColor = rects.OrderBy(r => r.C);
                    PrintCollection(byColor);

                    // 3. Впорядкування за площею
                    Console.WriteLine("\nВпорядковано за ПЛОЩЕЮ:");
                    var byArea = rects.OrderBy(r => r.Area());
                    PrintCollection(byArea);

                    // 4. Впорядкування за периметром
                    Console.WriteLine("\nВпорядковано за ПЕРИМЕТРОМ:");
                    var byPerimeter = rects.OrderBy(r => r.Perimetr());
                    PrintCollection(byPerimeter);

                    Console.WriteLine("=== Тестування нових можливостей Rectangle ===\n");

                    Rectangle rect = new Rectangle(5, 10, 2);

                    // Тест індексатора
                    Console.WriteLine("--- Тест індексатора ---");
                    Console.WriteLine($"rect[0] (a): {rect[0]}");
                    Console.WriteLine($"rect[1] (b): {rect[1]}");
                    Console.WriteLine($"rect[2] (колір): {rect[2]}");
                    rect[0] = 7;
                    Console.WriteLine($"Після rect[0] = 7: a = {rect.A}");

                    // Тест операторів ++ та --
                    Console.WriteLine("\n--- Тест операторів ++ та -- ---");
                    Rectangle rect2 = new Rectangle(3, 4, 1);
                    Console.WriteLine($"До ++: a={rect2.A}, b={rect2.B}");
                    rect2++;
                    Console.WriteLine($"Після ++: a={rect2.A}, b={rect2.B}");
                    rect2--;
                    Console.WriteLine($"Після --: a={rect2.A}, b={rect2.B}");

                    // Тест операторів true/false
                    Console.WriteLine("\n--- Тест операторів true/false ---");
                    Rectangle square = new Rectangle(5, 5, 1);
                    Rectangle nonSquare = new Rectangle(5, 10, 1);
                    Console.WriteLine($"Квадрат 5x5: {(square ? "це квадрат" : "не квадрат")}");
                    Console.WriteLine($"Прямокутник 5x10: {(nonSquare ? "це квадрат" : "не квадрат")}");

                    // Тест оператора *
                    Console.WriteLine("\n--- Тест оператора множення ---");
                    Rectangle rect3 = new Rectangle(2, 3, 1);
                    Console.WriteLine($"До множення: a={rect3.A}, b={rect3.B}");
                    rect3 = rect3 * 3;
                    Console.WriteLine($"Після * 3: a={rect3.A}, b={rect3.B}");
                    rect3 = 2 * rect3;
                    Console.WriteLine($"Після 2 * rect: a={rect3.A}, b={rect3.B}");

                    // Тест перетворення типів
                    Console.WriteLine("\n--- Тест перетворення типів ---");
                    Rectangle rect4 = new Rectangle(8, 12, 3);
                    string rectStr = (string)rect4;
                    Console.WriteLine($"Rectangle -> string: \"{rectStr}\"");
                    Rectangle rect5 = (Rectangle)"4,6,2";
                    Console.WriteLine($"string -> Rectangle: a={rect5.A}, b={rect5.B}, колір={rect5.C}");

                    break;
                }

                case "0":
                    return;

                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
    static void PrintCollection(IEnumerable<Rectangle> collection)
    {
        foreach (var r in collection)
        {
            Console.WriteLine($"Колір: {r.C, -3} | Площа: {r.Area(), -5} | Периметр: {r.Perimetr(), -5} | Квадрат: {r.IsSquare()}");
        }
    }
}