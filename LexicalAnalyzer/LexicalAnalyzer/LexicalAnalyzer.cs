using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer
{
    class LexicalAnalyzer
    {
        private List<string> lexems;
        public void CheckText(string text)
        {
            Split(text);
            TestingLexems();
            foreach(string lexem in lexems)
            {
                if (lexem == "=") Print(lexem, "Assignment");
                else if (lexem == "+") Print(lexem, "Concatenation");
                else if (lexem == ";") Print(lexem, "Semicolon");
                else if (lexem[0] == '\'') Print(lexem, "Character");
                else if (lexem[0] == '\"') Print(lexem, "Const string");
                else Print(lexem, "Identifier");
            }
        }
        private void Print(string lexem,string typeLexem)
        {
            Console.WriteLine("{0,-100}{1}", lexem, typeLexem);
        }
        private void Split(string text)
        {
            lexems = new List<string>();
            string lexem = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\"')
                {
                    lexem += text[i];
                    i++;
                    while (true)
                    {
                        if (text[i] == '\"')
                        {
                            lexem += text[i];
                            lexems.Add(lexem);
                            lexem = "";
                            break;
                        }
                        lexem += text[i];
                        i++;
                    }
                }
                else if (text[i] == '\'')
                {
                    lexem += text[i];
                    i++;
                    lexem += text[i];
                    i++;
                    lexem += text[i];
                    lexems.Add(lexem);
                    lexem = "";
                }
                else if (text[i] == ';' || text[i] == '=' || text[i] == '+')
                {
                    lexems.Add(text[i].ToString());
                    lexem = "";
                }
                else if (text[i] == ' ' || text[i] == '\r' || text[i] == '\n')
                {
                    lexem = "";
                }
                else
                {
                    lexem += text[i];
                    if (text[i + 1] == ';' || text[i + 1] == '=' || text[i + 1] == '+' || text[i + 1] == ' ' || text[i + 1] == '\'' || text[i + 1] == '\"')
                    {
                        lexems.Add(lexem);
                        lexem = "";
                    }
                }
            }
        }
        private void TestingLexems()
        {
            try
            {
                for (int i = 0; i < lexems.Count - 1; i++)
                {
                    switch (lexems[i][0])
                    {
                        case ';':
                        case '+':
                        case '=':
                            if (lexems[i + 1] == ";" || lexems[i + 1] == "+")
                                throw new Exception("Error: 1");
                            break;
                        case '\"':
                        case '\'':
                            if(lexems[i + 1] != "+" && lexems[i + 1] != ";")
                                throw new Exception("Error: 2");
                            break;
                        default:
                            if (lexems[i + 1] != "=" && lexems[i + 1] != ";")
                                throw new Exception("Error: 3");
                            break;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }
    }
}
