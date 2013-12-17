using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CestnoSoftware
{
    public class FunctionResultUncheckedException : Exception
    {
        public FunctionResultUncheckedException(string message) : base(message) 
        {
            
        }

    }
}
