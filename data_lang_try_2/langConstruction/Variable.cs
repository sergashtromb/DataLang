using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLang
{
    public class Variable
    {


        public TypeVariables.TypeVariable type;

        public int intValue = 0;
        public string stringValue = "";
        public bool boolValue = false;
        public bool isNull = false;
        public float floatValue = 0.0f;

        public Variable(TypeVariables.TypeVariable tp)
        {
            this.type = tp;
        }
        
        

        

    }
}
