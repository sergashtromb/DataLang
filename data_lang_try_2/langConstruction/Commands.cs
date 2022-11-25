using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLang
{
    public static class Commands
    {

        public enum TypeCommands
        {
            Initialized,
            Assing,
            TwoOperation
        }

        public enum TypeTwoOperation
        {
            Concat,
            UnConcat,
            Divided,
            Multiply
        }

    }
}
