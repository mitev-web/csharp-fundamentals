using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace phpvars
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string>();
            List<string> variables = new List<string>();

            
            //get the string into a strings array
            string line_read;
            do
            {
                line_read = Console.ReadLine();
                strings.Add(line_read);
            } while (line_read!="?>");
            
            //remove all commented lines
            
            /*
            strings.Add("$code");
            strings.Add("$validvar");
            strings.Add("$just");
            strings.Add("$Just");
            strings.Add("");
            
             */ 
            List<string> newList = new List<string>();
            bool in_multiline_comment = false;
            foreach (string line in strings)
	        {
                string line2 = line;
                bool include = true;
		        //remove one line comments
                if(line2.Length>0 && line2[0]=='#') include = false;
                if(line2.Length>1 && line2[0]=='/' && line2[1]=='/' ) include = false;
                
                //remove multiline
                    int indexEndMultiline = line2.IndexOf("*/");
                    int indexStartMultiline = line2.IndexOf("/*");
                    if(indexStartMultiline<0 && indexEndMultiline<0 && in_multiline_comment)
                    {
                        include=false;
                    }
                    else
                    {
                        if(indexStartMultiline>=0)
                        {
                            line2 = line2.Substring(0,indexStartMultiline);
                            in_multiline_comment = true;
                        }
                        if (indexEndMultiline >= 0) 
                        {
                            indexEndMultiline = line2.IndexOf("*/");
                            line2 = line2.Substring(indexEndMultiline + 1, line2.Length - indexEndMultiline - 1);
                            in_multiline_comment = false;
                        }
                    }
                //include if valid
                if (include)
                {
                    newList.Add(line2);
                }
                //check if it works
            }

            //check for variables
            foreach (string line in newList)
            {
                string[] words = line.Split(';','[',']','(',')', '"',',', '=','>','<','{', '}', '\'', ' ', '.', '+', '-', '*', '&', '@', '?', '%' ,'/','^', '`','|','~');
                foreach (string word in words)
                {
                    if (word.Length>0 && word[0] == '$')
                    {
                        string varname = word.Substring(1, word.Length - 1);
                        if (!variables.Contains(varname))
                        {
                            variables.Add(varname);
                        }
                    }
                }
            }

            string[] outputvars = variables.ToArray();
            Array.Sort(outputvars, StringComparer.Ordinal);
            Console.WriteLine(variables.Count);
            foreach (string item in outputvars)
            {
                Console.WriteLine(item);
            }
        }


    }
}
