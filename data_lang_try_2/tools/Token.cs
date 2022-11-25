using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLang
{
    public class Token
    {

        public TokenType type; // тип токена
        public string text; // его текст
        public int pos; // позиция в коде

        public Token(TokenType type, string text, int pos)
        {
            this.type = type;
            this.text = text;
            this.pos = pos;
        }


    }
}
