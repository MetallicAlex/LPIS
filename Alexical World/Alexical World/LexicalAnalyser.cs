using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Alexical_World
{
    class LexicalAnalyser
    {
        private List<KeyValuePair<string, string>> lexems;
        public void AnalysisText(string text)
        {
            if (IsTextCorrect(text))
                Split(text);
            else Console.WriteLine("This text has error(-s)");
        }
        public void ShowLexems()
        {
            if (lexems != null)
            {
                for (int i = 0; i < 121; i++)
                    Console.Write("=");
                Console.WriteLine("\n|{0,-100}|{1,-18}|", "Lexem", "Type");
                for (int i = 0; i < 121; i++)
                    Console.Write("=");
                Console.WriteLine();
                foreach (var lexem in lexems)
                    Console.WriteLine("|{0,-100}|{1,-18}|", lexem.Key, lexem.Value);
                for (int i = 0; i < 121; i++)
                    Console.Write("=");
                Console.WriteLine();
            }
        }
        private void Split(string text)
        {
            lexems = new List<KeyValuePair<string, string>>();
            Regex regex = new Regex("(\\w+)|([+=;])|([\"\'].*[\"\'])");
            MatchCollection matchedLexems = regex.Matches(text);
            for (int i = 0; i < matchedLexems.Count; i++)
                IdentificationTypeLexem(matchedLexems[i].Value);
        }
        private void IdentificationTypeLexem(string lexem)
        {
            if (lexem[0] == '\"')
                lexems.Add(new KeyValuePair<string, string>(lexem, "Const string"));
            else if (lexem[0] == '\'')
                lexems.Add(new KeyValuePair<string, string>(lexem, "Character"));
            else if (lexem[0] == '+')
                lexems.Add(new KeyValuePair<string, string>(lexem, "Concatenation"));
            else if (lexem[0] == '=')
                lexems.Add(new KeyValuePair<string, string>(lexem, "Assignment"));
            else if (lexem[0] == ';')
                lexems.Add(new KeyValuePair<string, string>(lexem, "Semicolon"));
            else
                lexems.Add(new KeyValuePair<string, string>(lexem, "Identifier"));
        }
        private bool IsTextCorrect(string text)
        {
            int numberErrors = 0;
            numberErrors += GetNumberTypeError(text, "([^;]$)", "Last character isn't ';'");
            //numberErrors += TypeError(text, "([\"\'].*[\"\'][^;])", "Last character after \" or \' isn't ';'");
            //numberErrors += TypeError(text, "(\\w+\\s*[^=+])", "Last character after identifier isn't '=','+'");
            Console.WriteLine("This text has {0} number(-s) of errors", numberErrors);
            if (numberErrors > 0)
                return false;
            return true;
        }
        private int GetNumberTypeError(string text,string pattern,string messageError)
        {
            int numberErrors = 0;
            Regex regex = new Regex(pattern);
            MatchCollection matchedLexems = regex.Matches(text);
            if (matchedLexems.Count > 0)
            {
                for (int i = 0; i < matchedLexems.Count; i++)
                {
                    Console.WriteLine(messageError + ": {0}", matchedLexems[i].Index);
                    numberErrors++;
                }
            }
            return numberErrors;
        }
    }
}
