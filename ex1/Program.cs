double[] A = new double[5];
double[,] B = new double[3, 4];

for (int i = 0; i < 5; i++)
{
    Console.Write("Введите элемент A[" + i + "]: ");
    A[i] = double.Parse(Console.ReadLine());
}

Random rnd = new Random();
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 4; j++)
    {
        B[i, j] = rnd.NextDouble() * 100;
    }
}

Console.WriteLine("\nМассив A:");
for (int i = 0; i < 5; i++)
{
    Console.Write(A[i] + " ");
}
Console.WriteLine();

Console.WriteLine("\nМассив B:");
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 4; j++)
    {
        Console.Write(B[i, j].ToString("0.00") + "\t");
    }
    Console.WriteLine();
}

double max = A[0];
double min = A[0];
double sum = 0;
double product = 1;

for (int i = 0; i < 5; i++)
{
    double x = A[i];

    if (x > max) max = x;
    if (x < min) min = x;

    sum += x;
    product *= x;
}

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 4; j++)
    {
        double x = B[i, j];

        if (x > max) max = x;
        if (x < min) min = x;

        sum += x;
        product *= x;
    }
}

double sumA = 0;
for (int i = 0; i < 5; i++)
{
    if ((int)A[i] % 2 == 0)
        sumA += A[i];
}

double sumB = 0;
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 4; j++)
    {
        if ((j + 1) % 2 == 1)
            sumB += B[i, j];
    }
}

Console.WriteLine("\nРезультаты:");
Console.WriteLine("Максимум: " + max);
Console.WriteLine("Минимум: " + min);
Console.WriteLine("Общая сумма: " + sum);
Console.WriteLine("Общее произведение: " + product);
Console.WriteLine("Сумма чётных элементов массива A: " + sumA);
Console.WriteLine("Сумма элементов нечетных столбцов массива B: " + sumB);
