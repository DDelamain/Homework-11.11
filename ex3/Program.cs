using System;
using System.Text;

class CaesarCipher
{
    static void Main()
    {
        Console.Write("Введите текст для шифрования: ");
        string input = Console.ReadLine();

        Console.Write("Введите сдвиг (целое число, например 3): ");
        int shift = int.Parse(Console.ReadLine());

        shift = shift % 26;
        if (shift < 0) shift += 26;

        string encrypted = Encrypt(input, shift);
        string decrypted = Decrypt(encrypted, shift);

        Console.WriteLine("\nРезультаты:");
        Console.WriteLine($"Оригинал:     {input}");
        Console.WriteLine($"Зашифровано:  {encrypted}");
        Console.WriteLine($"Расшифровано: {decrypted}");
    }

    static string Encrypt(string text, int shift)
    {
        StringBuilder result = new StringBuilder();

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                char cryptedChar = char.IsUpper(c) ? 'A' : 'a';
                char encryptedChar = (char)(cryptedChar + (c + shift - cryptedChar) % 26);
                result.Append(encryptedChar);
            }
            else
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }
    static string Decrypt(string text, int shift)
    {
        return Encrypt(text, 26 - shift);
    }
}