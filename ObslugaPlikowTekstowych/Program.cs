using System;
using System.IO;

namespace ObslugaPlikowTekstowych
{
    internal class Program
    {
        static void AppendFile()
        {
            var files = Directory.GetFiles(@"C:/Users/playg/Desktop/New folder/ObslugaPlikowTekstowych/AppendFile", "*.txt", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                File.AppendAllText(file, "All rights reserved");
            }
        }

        static void ReadFiles()
        {
            var document1 = File.ReadAllText(@"C:/Users/playg/Desktop/New folder/ObslugaPlikowTekstowych/ReadFile/Plik1.txt");
            var document2 = File.ReadAllLines(@"C:/Users/playg/Desktop/New folder/ObslugaPlikowTekstowych/ReadFile/Plik2.txt");
            Console.WriteLine(document1);
            Console.WriteLine(document2);

            var document25string = string.Join(Environment.NewLine, document2);
            Console.WriteLine(document25string);

        }

        static void GenerateDocument()
        {
            var name = Console.ReadLine();

            var order = Console.ReadLine();

            var template = File.ReadAllText(@"C:/Users/playg/Desktop/New folder/ObslugaPlikowTekstowych/WriteFile/template.txt");
            var document = template.Replace("{name}", name)
                .Replace("{order}", order)
                .Replace("{dateTime}", DateTime.Now.ToString());

            File.WriteAllText($"C:/Users/playg/Desktop/New folder/ObslugaPlikowTekstowych/WriteFile/{name}.txt", document);
        }

        static void Main(string[] args)
        {
            //ReadFiles();
            //GenerateDocument();
            AppendFile();

        }
    }
}
