using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PHPVariables
{
    class PHPVariables
    {
        private const int MAX_NAMES = 10000;
        private static string[] varNames = new string[MAX_NAMES];
        private static int currentId = 0;

        static void readInputFile()
        {
            char symbol;
            string lineReader;
            StringBuilder currentName = new StringBuilder();
            lineReader = Console.ReadLine(); //Read start tag

            while (lineReader != "?>")
            {
                lineReader = Console.ReadLine();
                for (int i = 0; i < lineReader.Length-1; i++)
                {
                    switch (lineReader[i])
                    {
                        case '$':
                            if (i == 0)
                            {
                                makeVar(lineReader, currentName, i);
                            }
                            else
                            {
                                if (noSalshesBefore(lineReader, i))
                                {                                    
                                    makeVar(lineReader, currentName, i);
                                }
                            }
                            break;
                        case '/':
                            if (lineReader[i+1] == '*')
                            {
                                bool endCommentFound = false;
                                while (!endCommentFound)
                                {
                                    for (int k = i; k < lineReader.Length-1; k++)
                                    {                                       
                                        if ((lineReader[k] == '*') && (lineReader[k+1] == '/'))
                                        {
                                            endCommentFound = true;
                                            i = k;
                                            break;
                                        }
                                    }
                                    if (!endCommentFound)
                                    {
                                        lineReader = Console.ReadLine();
                                    }
                                }
                            }
                            else if (lineReader[i + 1] == '/')
                            {
                                i = lineReader.Length;
                            }
                            
                            break;
                        case '"':
                            while((lineReader[i] != '"') && (lineReader[i-1] != '\\'))
                            {
                                if (i == lineReader.Length)
                                {
                                    lineReader = Console.ReadLine();
                                    i = 0;
                                }
                                if ((lineReader[i] == '$') && noSalshesBefore(lineReader,i))
                                {
                                    makeVar(lineReader, currentName, i);
                                }
                                i++;
                            }
                            break;
                        case '\'':
                            while ((lineReader[i] != '\'') && (lineReader[i - 1] != '\\'))
                            {
                                if (i == lineReader.Length)
                                {
                                    lineReader = Console.ReadLine();
                                    i = 0;
                                }
                                if ((lineReader[i] == '$') && noSalshesBefore(lineReader,i))
                                {
                                    makeVar(lineReader, currentName, i);
                                }
                                i++;
                            }
                            break;
                        case '#':
                            i = lineReader.Length;
                            break;
                        case '\\':
                            break;
                        default:
                            break;
                    }
                }
            }

        }

        private static bool noSalshesBefore(string lineReader, int startIndex)
        {
            //Console.WriteLine("FUU {0}",startIndex);
            if (startIndex < 2)
            {
              //  Console.WriteLine("Start index {0} linereader {1}",startIndex,lineReader[startIndex-1]);
                if (lineReader[startIndex-1] == '\\')
                {
                    return false;
                }
            }
            for (int i = startIndex-1; i > 1; i--)
            {
                if ((lineReader[i] == '\\'))
                {
                    if (lineReader[i - 1] != '\\')
                    {
                        return false;
                    }
                    else
                    {
                        i--;
                    }
                    //Console.WriteLine("FU ! {0}", lineReader[i]);
                }
                else
                {
                    break;
                }
            }
            return true;
        }

        private static void makeVar(string lineReader, StringBuilder currentName, int i)
        {
            ++i;
            if((lineReader[i+1] < '0') || (lineReader[i+1] > '9')){
                while (System.Char.IsLetter(lineReader[i]) || (System.Char.IsDigit(lineReader[i])) || (lineReader[i] == '_'))
                {
                    currentName.Append(lineReader[i]);
                    ++i;
                }
                if (!varRepeat(currentName))
                {
                    varNames[currentId] = currentName.ToString();
                    currentId++;
                }
            }
            currentName.Clear();
        }

        private static bool varRepeat(StringBuilder currentName)
        {
            for (int i = 0; i < currentId; i++)
            {
                if (varNames[i] == currentName.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        static void printOutputString()
        {
            Array.Sort(varNames);
            //sortArrayItems();
            Console.WriteLine(currentId);
            for (int i = MAX_NAMES-currentId; i < MAX_NAMES; i++)
            {
                Console.WriteLine(varNames[i]);
            }
            
        }

        private static void sortArrayItems()
        {
            if (currentId > 1)
            {
                bool sorted = false;
                while (!sorted)
                {
                    sorted = true;
                    for (int i = MAX_NAMES-currentId; i < MAX_NAMES - 1; i++)
                    {
                        if (varNames[i][0] > varNames[i + 1][0])
                        {
                            string flip = varNames[i];
                            varNames[i] = varNames[i + 1];
                            varNames[i + 1] = flip;
                            sorted = false;
                        }
                        else if (varNames[i][0] == varNames[i + 1][0])
                        {
                            int k = 0;
                            while (varNames[i][k] == varNames[i + 1][k])
                            {
                                k++;
                            }

                            if (varNames[i][k] > varNames[i + 1][k])
                            {
                                string flip = varNames[i];
                                varNames[i] = varNames[i + 1];
                                varNames[i + 1] = flip;
                                sorted = false;
                            }
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            readInputFile();
            printOutputString();
        }
    }
}
