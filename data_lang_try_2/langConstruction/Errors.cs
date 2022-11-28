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
            UninitializedVariable,
            InvalidExpression,
            InvalidOperation
        }
        

        public static void ReturnError(LangErrors err, int numSring)
        {
            switch (err)
            {
                case LangErrors.UninitializedVariable:
                {
                    Console.WriteLine($"Error - UninitializedVariable: on string {numSring}");
                    throw new Exception($"Error - UninitializedVariable: on string {numSring}");
                    
                }
                case LangErrors.InvalidExpression:
                    {
                        Console.WriteLine($"Error - InvalidExpression: on string {numSring}");
                        throw new Exception($"Error - InvalidExpression: on string {numSring}");
                    }
                case LangErrors.InvalidOperation:
                    {
                        Console.WriteLine($"Error - InvalidOperation: on string {numSring}");
                        throw new Exception($"Error - InvalidOperation: on string {numSring}");
                    }
                
            
            }
        }


    }
}
