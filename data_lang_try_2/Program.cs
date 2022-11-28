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

            string code1 = "a = 5 + 23 + 10\nresult = a + 45 + 3";

            
            Lexer lex = new Lexer(code1);

            Parser pars = new Parser(lex.LexAnaliser());

            pars.CreateStringsManager(pars.tok);

            pars.SetCommands(pars.strings);

            List<List<Command>> com = pars.commands;

            Console.ReadLine();



            


        }
    }
}
