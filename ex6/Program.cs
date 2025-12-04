Console.Write("Введите текст: ");
string text = Console.ReadLine();

if (text == null || text.Length == 0)
{
    Console.WriteLine("Текст пустой.");
    return;
}

char[] chars = text.ToCharArray();
if (chars.Length > 0 && char.IsLetter(chars[0]))
{
    chars[0] = char.ToUpper(chars[0]);
}

for (int i = 1; i < chars.Length; i++)
{
    if (chars[i] == '.' || chars[i] == '!' || chars[i] == '?')
    {
        int j = i + 1;
        while (j < chars.Length && !char.IsLetter(chars[j]))
        {
            j++;
        }
        if (j < chars.Length)
        {
            chars[j] = char.ToUpper(chars[j]);
        }
    }
}
string result = new string(chars);
Console.WriteLine("\nРезультат:");
Console.WriteLine(result);

