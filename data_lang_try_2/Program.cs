using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLang
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string code1 = "a = 23\nresult = 45";

            
            Lexer lex = new Lexer(code1);

            Parser pars = new Parser(lex.LexAnaliser());

            pars.CreateStringsManager(pars.tok);

            List<List<Token>> tokens = pars.strings;

            for(int i = 0; i < tokens.Count; i++)
            {
                foreach (Token token in tokens[i])
                {
                    Console.WriteLine(token.type.name);
                }
            }


            
            


        }
    }
}
