using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class IntersectFiles
{
    //Write a program that removes from a text 
    //file all words listed in given another text file. 
    //Handle all possible exceptions in your methods.
    static void Main(string[] args)
    {
        char[] separators = { ' ', ',', '.', '!', ')', '?', '\n', '\t', '\r' };

        StringBuilder resultText = new StringBuilder();
        StringBuilder currentWord = new StringBuilder();

        try
        {
            using (StreamReader textFile = new StreamReader("..//..//Files//InputTextFile.txt"))
            {
                using (StreamReader wordsFile = new StreamReader("..//..//Files//InputWordsFile.txt"))
                {
                    string[] words = wordsFile.ReadToEnd().Split(separators);

                    char symbol;
                    while (textFile.Peek() != -1)
                    {
                        symbol = (char)textFile.Read();
                        if (IsIn(symbol, separators))
                        {
                            if (IsIn(currentWord.ToString(), words))
                            {
                                resultText.Append(symbol);
                                currentWord.Clear();
                            }
                            else
                            {
                                resultText.Append(currentWord.ToString());
                                currentWord.Clear();
                                resultText.Append(symbol);
                            }
                        }
                        else
                        {
                            currentWord.Append(symbol);
                        }
                    }
                }
            }
            using (StreamWriter outFile = new StreamWriter("..//..//Files//OutputTextFile.txt", false))
            {
                outFile.Write(resultText.ToString());
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FileLoadException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FieldAccessException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (OutOfMemoryException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static bool IsIn<T>(T word, T[] words)
    {
        foreach (T elem in words)
        {
            if (elem.Equals(word))
            {
                return true;
            }
        }
        return false;
    }
}