using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLang
{
    public class Parser
    {

        public List<Token> tok = new List<Token> { };

        public List<List<Token>> strings = new List<List<Token>>();


        public Parser(List<Token> tokList)
        {
            this.tok = tokList;
        
        }

        public void CreateStringsManager(List<Token> tokens)
        {

            List<Token> newString = new List<Token> { };
            for(int i = 0; i < tokens.Count; i++)
            {
                if(i + 1 == tokens.Count)
                {
                    newString.Add(tokens[i]);
                    this.strings.Add(newString);
                    break;
                }
                else
                {
                    if (tokens[i].type.name != "SEMICOLUM")
                    {
                        newString.Add(tokens[i]);
                    }
                    else
                    {
                        newString.Add(tokens[i]);
                        this.strings.Add(newString);
                        newString = new List<Token> { };
                    }
                }
                
            }

        }




    }
}
