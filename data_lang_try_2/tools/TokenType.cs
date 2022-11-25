using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLang
{
    public class TokenType // класс токена
    {

        public string name;
        public string regex;

        public TokenType(string name, string regex)
        {
            this.name = name;
            this.regex = regex;
        }

    }
}
