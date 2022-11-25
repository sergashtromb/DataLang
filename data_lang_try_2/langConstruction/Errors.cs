using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLang
{
    static class Errors
    {

        public enum LangErrors
        {
            UninitializedVariable
        }
        

        public static void ReturnError(LangErrors err, int numSring)
        {
            switch (err)
            {
                case LangErrors.UninitializedVariable:
                {
                    throw new Exception($"Error - UninitializedVariable: on string {numSring}");
                }

                
            
            }
        }


    }
}
