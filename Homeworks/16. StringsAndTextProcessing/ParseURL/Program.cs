using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ParseURL
{
    class Program
    {
        //Write a program that parses an URL address given in the format:

        //and extracts from it the [protocol], [server] and [resource] elements. 
        //For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
        //[protocol] = "http"
        //[server] = "www.devbg.org"
        //[resource] = "/forum/index.php"

        static void Main(string[] args)
        {
            string url = "http://www.devbg.org/forum/index.php";
            Regex reg = new Regex(@"\b(?<protocol>http:)//(?<domain>www\.[a-zA-Z0-9]{2,14}\.[a-z]{2,4})(?<resource>/.*)\b");

            Match m = reg.Match(url);

            Group protocol = m.Groups["protocol"];
            Group domain = m.Groups["domain"];
            Group resource = m.Groups["resource"];


            Console.WriteLine("the protocol is {0}\n the domain is {1} \nand the resource is {2}\n", protocol, domain, resource);       
        }
    }
}
