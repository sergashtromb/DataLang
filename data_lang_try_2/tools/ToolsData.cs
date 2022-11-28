using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLang
{
    static class ToolsData
    {

        public static TokenType[] _listTokens = {
            new TokenType("VARIABLE", "^[a-zA-Z_]*"),
            new TokenType("NUMBER", "^[0-9]*"),
            new TokenType("SEMICOLUM", "^\\n"),
            new TokenType("SPACE", "^[ \\t\\r]"),
            new TokenType("LPAR", "^\\("),
            new TokenType("RPAR", "^\\)"),
            new TokenType("ASSIGN", "^="),
            new TokenType("PLUS", "^\\+"),
            new TokenType("MINUS", "^\\-"),
            new TokenType("LCURPAR", "^\\{"),
            new TokenType("LCURPAR", "^\\}"),
            new TokenType("LOG", "^log")

        };


    }
}
