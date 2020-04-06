using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LexicalAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader fileRead = new StreamReader(@"..\..\..\Text.txt", Encoding.GetEncoding(1251));
            string text = fileRead.ReadToEnd();
            Console.WriteLine("Text: " + text);
            LexicalAnalyzer lexicalAnalyzer = new LexicalAnalyzer();
            lexicalAnalyzer.CheckText(text);
        }
    }
}
