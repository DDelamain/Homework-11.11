Console.Write("Введите арифметическое выражение: ");
string input = Console.ReadLine();

string[] parts = input.Split(' ');

if (parts.Length == 0)
{
    Console.WriteLine("Пустое выражение!");
    return;
}

int result = int.Parse(parts[0]);
for (int i = 1; i < parts.Length; i += 2)
{
    string operation = parts[i];
    int number = int.Parse(parts[i + 1]);

    if (operation == "+")
        result += number;
    else if (operation == "-")
        result -= number;
    else
    {
        Console.WriteLine($"Ошибка: неизвестный символ '{operation}'");
        return;
    }
}

Console.WriteLine($"Результат: {result}");

