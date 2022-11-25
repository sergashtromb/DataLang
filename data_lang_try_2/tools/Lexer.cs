using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace DataLang
{
    public class Lexer
    {

        string code;

        public int pos = 0;

        public List<Token> tokens = new List<Token>();

        public Lexer(string code)
        {
            this.code = code;
        }


        public List<Token> LexAnaliser()
        {
            while(IsNextToken())
            {
            
            }
            return this.tokens;
        }


        public bool IsNextToken()
        {
            if (this.pos >= this.code.Length)
            {
                return false;
            }

            for(int i = 0; i < ToolsData._listTokens.Length; i++)
            {

                Regex reg = new Regex(ToolsData._listTokens[i].regex);
                Match result = reg.Match(this.code.Substring(this.pos));

                if (result.Success && result.Value.Length != 0)
                {
                    Token token = new Token(ToolsData._listTokens[i], result.Value, this.pos);
                    this.pos += result.Value.Length;
                    if(ToolsData._listTokens[i].name != "SPACE")
                    {
                        this.tokens.Add(token);
                    }
                    return true;
                }
        
            }
            throw new Exception($"Error on position {this.pos}");

        }

    }
}
