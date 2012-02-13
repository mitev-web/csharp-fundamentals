using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class VarPHP
{
    static void Main()
    {
        //StringBuilder code = new StringBuilder();
        StringBuilder variable = new StringBuilder();
        bool inMultiLineComment = false;
        bool inString = false;
        //bool inMultilineString = false;
        bool inSingleQuotedString = false;
        //bool inVariable = false;
        List<string> resultVars = new List<string>();

        string line = Console.ReadLine();
        while (line!="?>")
        {
            for (int j = 0; j < line.Length; j++)
                {
                    //if (inMultilineString)
                    //{
                    //    if (line[j] == '\"' && j + 1 < line.Length && line[j + 1] == '\"')
                    //    {
                    //        code.Append("\"\"");
                    //        j++;
                    //        continue;
                    //    }
                    //}
                    if (inString)
                    {
                        if (line[j] == '\\' && j + 1 < line.Length && line[j + 1] == '\"')
                        {
                            //code.Append("\\\"");
                            j++;
                            continue;
                        }
                        if (line[j] == '\\' && j + 1 < line.Length && line[j + 1] == '\'')
                        {
                            //code.Append("\\\'");
                            j++;
                            continue;
                        }
                        if (line[j] == '\"' && !inSingleQuotedString)
                        {
                            inString = false;
                            //inMultilineString = false;
                            //code.Append('\"');
                            continue;
                        }
                        if (line[j] == '\'' && inSingleQuotedString)
                        {
                            inString = false;
                            inSingleQuotedString = false;
                            //code.Append('\'');
                            continue;
                        }
                        if (line[j] == '\\' && j + 1 < line.Length && line[j + 1] == '$')
                        {
                            j++;
                            continue;
                        }
                        if (line[j] == '$' && j + 1 < line.Length && (char.IsLetter(line[j + 1]) || line[j + 1]=='_'))
                        {
                            j++;
                            //inVariable = true;
                            while (j < line.Length && (char.IsLetterOrDigit(line[j]) || line[j] == '_'))
                            {
                                variable.Append(line[j]);
                                j++;
                            }
                            resultVars.Add(variable.ToString());
                            variable.Clear();
                        }
                        
                        //code.Append(line[j]);
                        continue;
                    }

                    // Multiline comments
                    if (!inMultiLineComment && j + 1 < line.Length && line[j] == '/' && line[j + 1] == '*')
                    {
                        inMultiLineComment = true;
                        j++;
                        continue;
                    }
                    if (inMultiLineComment && j + 1 < line.Length && line[j] == '*' && line[j + 1] == '/')
                    {
                        inMultiLineComment = false;
                        j++;
                        continue;
                    }
                    if (inMultiLineComment)
                    {
                        continue;
                    }

                    // One line comment
                    if (line[j] == '#' || (line[j] == '/' && j + 1 < line.Length && line[j + 1] == '/'))
                    {                        
                        break;                        
                    }

                    //if (line[j] == '@' && j + 1 < line.Length && line[j + 1] == '\"')
                    //{
                    //    inString = true;
                    //    inMultilineString = true;
                    //    j++;
                    //    code.Append("@\"");
                    //    continue;
                    //}

                    if (line[j] == '\"')
                    {
                        inString = true;
                    }

                    if (line[j] == '\'')
                    {
                        inString = true;
                        inSingleQuotedString = true;
                    }
                    if (line[j] == '$' && j + 1 < line.Length && (char.IsLetter(line[j + 1]) || line[j + 1] == '_'))
                    {
                        j++;
                        //inVariable = true;
                        while (j < line.Length && (char.IsLetterOrDigit(line[j]) || line[j] == '_'))
                        {
                            variable.Append(line[j]);
                            j++;
                        }
                        resultVars.Add(variable.ToString());
                        variable.Clear();
                        continue;
                    }
                    


                    //code.Append(line[j]);
                }   

                //if (!inMultiLineComment) code.AppendLine();
                line = Console.ReadLine();
        }
        resultVars.Sort();
        int number = resultVars.Distinct().Count();
        Console.WriteLine(number);
        if (number>0)
        {
            Console.WriteLine(resultVars[0]);
            for (int i = 1; i < resultVars.Count; i++)
            {
                if (resultVars[i] != resultVars[i - 1])
                {
                    Console.WriteLine(resultVars[i]);
                }
            }
        }
        
        //foreach (var var in resultVars)
        //{
        //    Console.WriteLine(var);
        //}
    }
}
