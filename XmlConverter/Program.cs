using XmlConverter;
using System;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter name of file to parse to XML: ");
        string path = "Data/" + Console.ReadLine();

        TextRead reader = new TextRead();
        XmlConvert xmlConvert = new XmlConvert();

        var xmlCode = xmlConvert.MakeXML(reader.TextParseFile(path));

        Console.WriteLine(xmlCode);
    }
}