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

        public List<List<Command>> commands = new List<List<Command>>() { new List<Command> { } };

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
                    newString.Add(new Token(new TokenType("SEMICOLUM", ""), "", -1));
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


        public void SetCommands(List<List<Token>> strs)
        {
            int index = 0;
            for(int i = 0; i < strs.Count;i++) 
            {
                switch (strs[i][0].type.name)
                {
                    case "VARIABLE":


                        if (!IsInitilationVariable(strs[i][0], index))
                        {
                            commands[0].Add(CreateInitVar(strs[i][0], index++));
                        }


                        switch(strs[i][1].type.name)
                        {
                            case "ASSIGN":
                                List<Token> exp = new List<Token>();
                                for(int k = 2; strs[i][k].type.name != "SEMICOLUM"; k++)
                                {
                                    exp.Add(strs[i][k]);
                                }
                                commands[0].Add(CreateAssignCom(strs[i][0], index, exp));

                                break;
                        }

                        break;
                }
            }
        
        }

        
        public bool IsInitilationVariable(Token var, int j)
        {
            for(int i = 0; i < j; i++)
            {
                if (commands[0][i].typeCommand == Commands.TypeCommands.Initialized)
                {
                    
                    if (commands[0][i].tok.text == var.text)
                    {
                        return true;
                    }
                    
                }
            }

            return false;
        }
        
        public InitialitionCom CreateInitVar(Token var, int j)
        {
            InitialitionCom item1 = new InitialitionCom(var);
            item1.number = j;
            item1.typeCommand = Commands.TypeCommands.Initialized;
            return item1;
        }

        public AssignCom CreateAssignCom(Token var, int j, List<Token> expression)
        {
            VariableCom varS = new VariableCom(var.text);
            varS.typeCommand = Commands.TypeCommands.NameMemory;

            AssignCom item1 = new AssignCom();
            item1.var = varS;
            item1.number = j;
            if(expression.Count == 1)
            {
                if (expression[0].type.name == "NUMBER")
                {
                    item1.varOrOperation = new Command() { tok = expression[0], typeCommand = Commands.TypeCommands.NoneNameMemory };
                }
                else if (expression[0].type.name == "VARIABLE")
                {
                    if(IsInitilationVariable(expression[0], j--))
                    {
                        item1.varOrOperation = new VariableCom(expression[0].text) { typeCommand = Commands.TypeCommands.NameMemory};
                        
                    }
                    else
                    {
                        Errors.ReturnError(Errors.LangErrors.UninitializedVariable, expression[0].pos);
                    }
                    
                }

                else
                {
                    Errors.ReturnError(Errors.LangErrors.InvalidExpression, expression[0].pos);
                }
            }
            else
            {
                item1.varOrOperation = ParseExpression(expression, j);
            }

            return item1;
        }

        public Commands.TypeTwoOperation CheckOperation(Token op)
        {
            if (op.type.name == "PLUS")
            {
                return Commands.TypeTwoOperation.Concat;
            }
            else if (op.type.name == "MINUS")
            {
                return Commands.TypeTwoOperation.UnConcat;
            }
            else if (op.type.name == "MULTIPLY")
            {
                return Commands.TypeTwoOperation.Multiply;
            }
            else if (op.type.name == "DIVIDED")
            {
                return Commands.TypeTwoOperation.Divided;
            }
            else
            {
                return Commands.TypeTwoOperation.None;
            }
        }

        public TwoOperationCom ParseExpression(List<Token> exp, int j)
        {
            TwoOperationCom item = new TwoOperationCom();
            item.typeCommand = Commands.TypeCommands.TwoOperation;
            List<TwoOperationCom> opers = new List<TwoOperationCom>();
            if(exp.Count == 3)
            {
                if (exp[0].type.name == "VARIABLE")
                {
                    item.var1 = new VariableCom(exp[0].text);
                }
                else if (exp[0].type.name == "NUMBER")
                {
                    item.var1 = new VariableCom("") { tok = exp[0] };
                }
                else
                {
                    Errors.ReturnError(Errors.LangErrors.InvalidExpression, exp[0].pos);
                }


                item.typeOperation = CheckOperation(exp[1]);

                if(item.typeOperation == Commands.TypeTwoOperation.None)
                {
                    Errors.ReturnError(Errors.LangErrors.InvalidOperation, exp[1].pos);
                }

                if (exp[2].type.name == "VARIABLE")
                {
                    item.var2 = new VariableCom(exp[2].text);
                }
                else if (exp[2].type.name == "NUMBER")
                {
                    item.var2 = new VariableCom(exp[2].text);
                }
                else
                {
                    Errors.ReturnError(Errors.LangErrors.InvalidExpression, exp[2].pos);
                }
                
            }
            for(int q = 0; q < exp.Count; q++)
            {
                if(q + 2 < exp.Count)
                {
                    if (exp[q].type.name == "VARIABLE" || exp[q].type.name == "NUMBER")
                    {
                        TwoOperationCom oper = new TwoOperationCom();
                        
                        if(exp[q].type.name == "VARIABLE")
                        {
                            oper.var1 = new VariableCom(exp[q].text);
                        }
                        else if(exp[q].type.name == "NUMBER")
                        {
                            oper.var1 = new VariableCom("") { tok = exp[q] };
                        }



                        if (exp[q + 2].type.name == "VARIABLE")
                        {
                            oper.var2 = new VariableCom(exp[q + 2].text);

                            oper.typeOperation = CheckOperation(exp[q + 1]);
                            if(oper.typeOperation == Commands.TypeTwoOperation.None)
                            {
                                Errors.ReturnError(Errors.LangErrors.InvalidOperation, exp[q + 1].pos);
                            }

                            opers.Add(oper);
                            q+=3;
                        }
                        else if(exp[q + 2].type.name == "NUMBER")
                        {
                            oper.var2 = new VariableCom("") { tok = exp[q + 2] };

                            oper.typeOperation = CheckOperation(exp[q+1]);
                            if (oper.typeOperation == Commands.TypeTwoOperation.None)
                            {
                                Errors.ReturnError(Errors.LangErrors.InvalidOperation, exp[q+1].pos);
                            }

                            opers.Add(oper);
                            q += 3;
                        }
                        else
                        {
                            Errors.ReturnError(Errors.LangErrors.InvalidExpression, exp[q + 2].pos);
                        }
                    }
                    else
                    {
                        if(exp[q].type.name == "PLUS" || exp[q].type.name == "MINUS" || exp[q].type.name == "DIVIDED" || exp[q].type.name == "MULTIPLY")
                        {
                            if (exp[q++].type.name == "VARIABLE")
                            {
                                TwoOperationCom oper = new TwoOperationCom(opers[opers.Count-1], new VariableCom(exp[q+1].text), Commands.TypeTwoOperation.Concat);
                                
                                oper.typeOperation = CheckOperation(exp[q]);
                                if(oper.typeOperation == Commands.TypeTwoOperation.None)
                                {
                                    Errors.ReturnError(Errors.LangErrors.InvalidOperation, exp[q].pos);
                                }

                                opers.Add(oper);
                                q+=2;
                            }
                            else if(exp[q++].type.name == "NUMBER")
                            {
                                TwoOperationCom oper = new TwoOperationCom(opers[opers.Count - 1], new VariableCom("") { tok = exp[q+1] }, Commands.TypeTwoOperation.Concat);

                                oper.typeOperation = CheckOperation(exp[q]);
                                if (oper.typeOperation == Commands.TypeTwoOperation.None)
                                {
                                    Errors.ReturnError(Errors.LangErrors.InvalidOperation, exp[q].pos);
                                }

                                opers.Add(oper);
                                q += 2;
                            }
                            else
                            {
                                Errors.ReturnError(Errors.LangErrors.InvalidExpression, exp[q+1].pos);
                            }
                        }
                    }
                }
                else
                {
                    item.Operation1 = opers[opers.Count-1];
                    item.var2 = new VariableCom(exp[exp.Count-1].text);
                    item.typeOperation = CheckOperation(exp[exp.Count - 2]);
                    if(item.typeOperation == Commands.TypeTwoOperation.None)
                    {
                        Errors.ReturnError(Errors.LangErrors.InvalidOperation, exp[exp.Count - 2].pos);
                    }
                    break;
                }
                
            }


            return item;
        }
    }
}
