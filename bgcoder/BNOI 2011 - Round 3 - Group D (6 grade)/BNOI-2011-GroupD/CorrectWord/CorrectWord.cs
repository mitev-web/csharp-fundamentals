using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class CorrectWord
{
    static void Main(string[] args)
    {
        //string word = Console.ReadLine();
        string word = "L*bbC*abda***CCDb*%-dA**bdMvV";

        word = word.Replace('*', ' ');
        word = ClearSpecialChars(word);

        string[] words = Regex.Split(word, " +");
        int correctWordNumber = 0;
        int correctWordLength = 0;
        int tempLength = 0;


        for (int i = 0; i < words.Length; i++)
        {
            if (WordIsCorrect(words[i]))
            {
                tempLength = words[i].Length;
                if (tempLength > correctWordLength)
                {
                    correctWordLength = tempLength;
                    correctWordNumber = i;
                }
            }
        }
        Console.WriteLine("{0} {1}", correctWordNumber+1, correctWordLength);
    }

    private static bool WordIsCorrect(string word)
    {
        string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        word = word.ToUpper();

        bool wordIsCorrect = true;

        if (word.Length % 2 == 0)
        {
            wordIsCorrect = false;
        }

        for (int i = 1; i < word.Length - 1; i++)
        {
            if (alpha.IndexOf(word[i]) > alpha.IndexOf(word[i + 1]))
            {
                wordIsCorrect = false;
            }
        }

        return wordIsCorrect;
    }



    private static string ClearSpecialChars(string word)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in word)
        {
            if (c == '%' || c == '=' || c == '.' || c == ',' || c == '+' || c == '-' || c == ':' || c == '(' || c == ')')
            {
                continue;
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }
}