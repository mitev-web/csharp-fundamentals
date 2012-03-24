using System;
using System.Linq;
using System.Xml;

class ExtractFromXML
{
    //Write a program that extracts from given XML
    //file all the text without the tags.
    static void Main(string[] args)
    {
        string filePath = "../../Files/student.xml";
        XmlTextReader xmlReader = new XmlTextReader(filePath);
        while (xmlReader.Read())
        {
            switch (xmlReader.NodeType)
            {
                case XmlNodeType.Text:
                    Console.WriteLine("{0}", xmlReader.Value);
                    break;
            }
        }
    }
}