using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Alexical_World
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader fileRead = new StreamReader(@"..\..\..\Text.txt", Encoding.GetEncoding(1251));
            string text = fileRead.ReadToEnd();
            Console.WriteLine("Text: " + text);
            LexicalAnalyser lexicalAnalyser = new LexicalAnalyser();
            lexicalAnalyser.AnalysisText(text);
            lexicalAnalyser.ShowLexems();
        }
    }
}
