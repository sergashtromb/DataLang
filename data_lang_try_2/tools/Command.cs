using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLang
{
    public class Command
    {
        public Commands.TypeCommands typeCommand;
        public int number;
    }

    public class InitilationCom: Command
    {
        public Token varName = null;
        

        public InitilationCom(Token varName)
        {
            this.varName = varName;

        }
    }

    public class AssingCom: Command
    { 
        public Token varName = null; 
        public Token varVal = null;

        public AssingCom(Token varName, Token varVal)
        {
            this.varName = varName;
            this.varVal = varVal;
        }
    }

    public class TwoOperationCom: Command
    {
        public Token Val1 = null;
        public Token Val2 = null;
        public Commands.TypeTwoOperation typeOperation;

        public TwoOperationCom(Token Val1, Token Val2, Commands.TypeTwoOperation typeOperation)
        {
            this.Val1 = Val1;
            this.Val2 = Val2;
            this.typeOperation = typeOperation;
        }
    }

}
