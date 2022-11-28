using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLang
{
    public class Command // общий класс команда
    {
        public Commands.TypeCommands typeCommand;
        public int number;
        public Token tok;
        
    }

    public class InitialitionCom: Command // команда для инициализации переменной в памяти
    {
        public string name = "";
        

        public InitialitionCom(Token tok)
        {
            this.tok = tok;
            this.name = this.tok.text;
        }
    }

    public class TwoOperationCom: Command // команда для бинарных операций принимает первое как значение второе либо значение либо операция
    {
        public VariableCom var1 = null;
        public VariableCom var2 = null;
        public Commands.TypeTwoOperation typeOperation;
        public TwoOperationCom Operation1 = null;
        public TwoOperationCom Operation2 = null;

        public TwoOperationCom() { }

        public TwoOperationCom(VariableCom var1, VariableCom var2, Commands.TypeTwoOperation typeOper)
        {
            this.var1 = var1;
            this.var2 = var2;
            this.typeOperation = typeOper;
        }

        public TwoOperationCom(TwoOperationCom oper1, TwoOperationCom oper2, Commands.TypeTwoOperation typeOper)
        {
            this.Operation1 = oper1;
            this.Operation2 = oper2;
            this.typeOperation = typeOper;
        }

        public TwoOperationCom(TwoOperationCom oper1, VariableCom var2, Commands.TypeTwoOperation typeOper)
        {
            this.Operation1 = oper1;
            this.var2 = var2;
            this.typeOperation = typeOper;
        }

        public TwoOperationCom(VariableCom var1, TwoOperationCom oper2, Commands.TypeTwoOperation typeOper)
        {
            this.Operation2 = oper2;
            this.var1 = var1;
            this.typeOperation = typeOper;
        }
    }

    //public class NoneNameMemoryCom: Command // не именованная область памяти для промежуточных вычислений
    //{
        
    //    public NoneNameMemoryCom(Token tok)
    //    {
    //        this.tok = tok;
    //    }
        
    //}

    public class VariableCom: Command // команда для обращения к переменной
    {
        public string linkPlaceInMemory = "";
        public VariableCom (string linkPlaceInMemory)
        {
            this.linkPlaceInMemory = linkPlaceInMemory;
        }
    
    }

    public class AssignCom: Command // команда для присваивания 
    {
        public Command var = null;
        public Command varOrOperation = null;

        public AssignCom() { }
        public AssignCom(Command var, Command varOrOperation)
        {
            this.var = var;
            this.varOrOperation = varOrOperation;
        }
    }

}
