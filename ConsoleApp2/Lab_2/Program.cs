namespace Lab3CSharp;
using System;

internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Lab 1 - меню");
            Console.WriteLine("2 - Task 2");
            Console.WriteLine("1 - Task 1");
            Console.WriteLine("0 - Вихід");
            Console.Write("Ваш вибір: ");

            string? choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "2":
                        // Створюємо масив базового класу
                        // Дані для створення об'єктів
                        Random random = new Random();
                        string[] names = { "Іван", "Петро", "Андрій", "Олег", "Сергій", "Микола", "Василь", "Юрій" };
                        string[] specializations = { "Програміст", "Електрик", "Механік", "Будівельник" };
                        string[] positions = { "Директор", "Менеджер", "Бухгалтер", "Начальник" };
                        int n = 0; 
                        Console.Write("Введіть кількість обʼєктів: ");
                        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                        {
                            Console.WriteLine("Помилка: розмірність має бути додатним числом.");
                            Console.Write("Введіть кількість обʼєктів: ");
                        }
                    
                        Employee[] staff = new Employee[n];
                        for (int i = 0; i < n; i++)
                        {
                            string name = names[random.Next(names.Length)];
                            int age = random.Next(20, 60);
    
                            int type = random.Next(3);
                            switch (type)
                            {
                                case 0: // Engineer
                                    string spec = specializations[random.Next(specializations.Length)];
                                    staff[i] = new Engineer(name, age, spec);
                                    break;
                                case 1: // Worker
                                    int rank = random.Next(1, 6);
                                    staff[i] = new Worker(name, age, rank);
                                    break;
                                case 2: // Admin
                                    string pos = positions[random.Next(positions.Length)];
                                    staff[i] = new Admin(name, age, pos);
                                    break;
                            }
                        }

                        Console.WriteLine("--- Співробітники, впорядковані за типом ---");
    
                        // Сортування за іменем класу
                        var sortedStaff = staff.OrderBy(e => e.GetType().Name);

                        foreach (var emp in sortedStaff)
                        {
                            emp.Show(); // Викличе потрібний метод залежно від реального типу об'єкта
                        }
                        break;

                case "1":
                {
                        task_1_Rectangle[] rects = new task_1_Rectangle[]
                        {
                            new task_1_Rectangle(5, 5, 2),
                            new task_1_Rectangle(10, 2, 1),
                            new task_1_Rectangle(4, 4, 1),
                            new task_1_Rectangle(3, 8, 3)
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
    static void PrintCollection(IEnumerable<task_1_Rectangle> collection)
    {
        foreach (var r in collection)
        {
            Console.WriteLine($"Колір: {r.C, -3} | Площа: {r.Area(), -5} | Периметр: {r.Perimetr(), -5} | Квадрат: {r.IsSquare()}");
        }
    }
}