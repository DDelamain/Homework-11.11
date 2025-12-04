string[] badWords = { "die", "damn", "shit", "nword", "fuck" };

Console.WriteLine("Введите текст:");
string text = Console.ReadLine();

string lowerText = text.ToLower();
int totalReplacements = 0;
foreach (string badWord in badWords)
{
    string lowerBadWord = badWord.ToLower();
    int count = 0;
    int index = lowerText.IndexOf(lowerBadWord);
    while (index != -1)
    {
        bool isWord = (index == 0 || !char.IsLetterOrDigit(lowerText[index - 1])) &&
                        (index + lowerBadWord.Length == lowerText.Length ||
                        !char.IsLetterOrDigit(lowerText[index + lowerBadWord.Length]));
        if (isWord)
        {
            count++;
            totalReplacements++;
            string stars = new string('*', badWord.Length);
            text = text.Remove(index, badWord.Length).Insert(index, stars);
            lowerText = lowerText.Remove(index, lowerBadWord.Length).Insert(index, stars);
        }
        index = lowerText.IndexOf(lowerBadWord, index + 1);
    }
}
Console.WriteLine("\nОтцензурированный текст:");
Console.WriteLine(text);
Console.WriteLine($"\nСтатистика: {totalReplacements} слов заменено");
