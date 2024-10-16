﻿using XmlConverter;
using System;


class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        TextRead reader = new TextRead();
        XmlConvert xmlConvert = new XmlConvert();

        while (running)
        { 
            Console.WriteLine("Enter name of file to parse to XML: ");

            string baseDirectory = AppContext.BaseDirectory;
            string path = Path.Combine(baseDirectory, "..", "..", "..", "Data", Console.ReadLine()); // combine the base directory with relative path to find the data file

            if (File.Exists(path))
            {
                var xmlCode = xmlConvert.MakeXML(reader.TextParseFile(path));

                Console.WriteLine(xmlCode);
            }
            else
            {
                Console.WriteLine("ERROR! Could not find file!");
            }
            Console.WriteLine("Enter 'exit' to exit the application. Any other input will start the converting process of another file! ");
            if(Console.ReadLine() == "exit")
            {
                running = false;
            }
        }
    }
}