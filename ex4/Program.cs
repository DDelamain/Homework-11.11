using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("\t Операции с матрицами \n");
        while (true)
        {
            Console.WriteLine("Выберите операцию:");
            Console.WriteLine("1. Умножение матрицы на число");
            Console.WriteLine("2. Сложение двух матриц");
            Console.WriteLine("3. Произведение двух матриц");
            Console.WriteLine("4. Выход");
            Console.Write("\nВаш выбор (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    MultiplyMatrixByNumber();
                    break;
                case "2":
                    AddMatrix();
                    break;
                case "3":
                    MultiplyMatrix();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.\n");
                    break;
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void MultiplyMatrixByNumber()
    {
        Console.WriteLine("\n\tУмножение матрицы на число ");
        int[,] matrix = InputMatrix("Введите первую матрицу:");
        Console.Write("Введите число для умножения: ");
        double number = double.Parse(Console.ReadLine());
        Console.WriteLine("\nРезультат:");
        PrintMatrix(matrix);
        Console.WriteLine($" * {number} =");

        int[,] result = new int[matrix.GetLength(0), matrix.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                result[i, j] = (int)(matrix[i, j] * number);
            }
        }
        PrintMatrix(result);
    }

    static void AddMatrix()
    {
        Console.WriteLine("\n\t Сложение матриц ");
        int[,] a = InputMatrix("Введите первую матрицу:");
        int[,] b = InputMatrix("Введите вторую матрицу:");

        if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
        {
            Console.WriteLine("Ошибка: матрицы должны быть одинакового размера!");
            return;
        }

        Console.WriteLine("\nРезультат:");
        PrintMatrix(a);
        Console.WriteLine(" + ");
        PrintMatrix(b);
        Console.WriteLine(" = ");

        int[,] result = new int[a.GetLength(0), a.GetLength(1)];
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                result[i, j] = a[i, j] + b[i, j];
            }
        }
        PrintMatrix(result);
    }

    static void MultiplyMatrix()
    {
        Console.WriteLine("\n\t Произведение матриц ");
        int[,] a = InputMatrix("Введите первую матрицу (A):");
        int[,] b = InputMatrix("Введите вторую матрицу (B):");

        if (a.GetLength(1) != b.GetLength(0))
        {
            Console.WriteLine($"Ошибка: невозможно умножить матрицы {a.GetLength(0)}*{a.GetLength(1)} и {b.GetLength(0)}*{b.GetLength(1)}");
            Console.WriteLine("Количество столбцов первой матрицы должно равняться количеству строк второй!");
            return;
        }

        Console.WriteLine("\nРезультат:");
        PrintMatrix(a);
        Console.WriteLine(" * ");
        PrintMatrix(b);
        Console.WriteLine(" = ");

        int[,] result = new int[a.GetLength(0), b.GetLength(1)];
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < b.GetLength(1); j++)
            {
                int sum = 0;
                for (int k = 0; k < a.GetLength(1); k++)
                {
                    sum += a[i, k] * b[k, j];
                }
                result[i, j] = sum;
            }
        }
        PrintMatrix(result);
    }

    static int[,] InputMatrix(string title)
    {
        Console.WriteLine(title);
        Console.Write("Введите количество строк: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Введите количество столбцов: ");
        int cols = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rows, cols];
        Console.WriteLine("Введите элементы матрицы построчно:");

        for (int i = 0; i < rows; i++)
        {
            Console.Write($"Строка {i + 1}: ");
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (input.Length != cols)
            {
                Console.WriteLine($"Ошибка: нужно ввести ровно {cols} чисел!");
                i--;
                continue;
            }
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = int.Parse(input[j]);
            }
        }
        return matrix;
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.Write(" ");
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j],6}");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}