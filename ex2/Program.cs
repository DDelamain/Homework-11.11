using System;

class Program
{
    static void Main()
    {
        const int N = 5;
        int[,] arr = new int[N, N];
        Random rnd = new Random();

        Console.WriteLine("Исходный массив:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                arr[i, j] = rnd.Next(-100, 101);
                Console.Write($"{arr[i, j],5}");
            }
            Console.WriteLine();
        }

        int min = arr[0, 0];
        int max = arr[0, 0];
        int minI = 0, minJ = 0;
        int maxI = 0, maxJ = 0;

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (arr[i, j] < min)
                {
                    min = arr[i, j];
                    minI = i; minJ = j;
                }
                if (arr[i, j] > max)
                {
                    max = arr[i, j];
                    maxI = i; maxJ = j;
                }
            }
        }

        Console.WriteLine($"\nМинимум = {min} (позиция [{minI},{minJ}])");
        Console.WriteLine($"Максимум = {max} (позиция [{maxI},{maxJ}])");

        int startI, startJ, endI, endJ;
        bool minFirst = false;

        if (minI < maxI || (minI == maxI && minJ < maxJ))
        {
            minFirst = true;
            startI = minI; startJ = minJ;
            endI = maxI; endJ = maxJ;
        }
        else
        {
            minFirst = false;
            startI = maxI; startJ = maxJ;
            endI = minI; endJ = minJ;
        }

        long sum = 0;
        bool started = false;

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (started)
                {
                    if (i == endI && j == endJ)
                    {
                        goto endSum;
                    }
                    sum += arr[i, j];
                }

                if (i == startI && j == startJ)
                {
                    started = true;
                }
            }
        }

    endSum:
        Console.WriteLine($"\nСумма элементов между {(minFirst ? "минимумом" : "максимумом")} и {(minFirst ? "максимумом" : "минимумом")} = {sum}");
    }
}