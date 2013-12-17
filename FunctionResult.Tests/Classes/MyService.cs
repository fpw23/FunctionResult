using CestnoSoftware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionResult.Tests.Classes
{
    public class MyService
    {
        public IFunctionResult<int> AddTwoNumbers(int x, int y)
        {
            var ret = new FunctionResult<int>();

            try
            {
                ret.ReturnValue = x + y;
            }
            catch (Exception ex)
            {
                ret.AddException(ex);
            }

            return ret;
        }

        public IFunctionResult<int> AddTwoEvenNumbers(int x, int y)
        {
            var ret = new FunctionResult<int>();

            try
            {
                //test for even numbers
                var mod = x % 2;

                if (mod > 0)
                {
                    ret.Messages.AddMessageRuleWarning("Parameter X is not an even number", "X");
                    ret.OperationStatus = FunctionResultOperationStatus.FailureValidtion;
                }
                else
                {
                    mod = y % 2;

                    if (mod > 0)
                    {
                        ret.Messages.AddMessageRuleWarning("Parameter Y is not an even number", "Y");
                        ret.OperationStatus = FunctionResultOperationStatus.FailureValidtion;
                    }
                    else
                    {
                        ret.ReturnValue = x + y;
                    }
                }
            }
            catch (Exception ex)
            {
                ret.AddException(ex);
            }

            return ret;
        }

        public IFunctionResult<int> DivideTwoNumbers(int x, int y)
        {
            var ret = new FunctionResult<int>();

            try
            {
                ret.ReturnValue = x / y;
            }
            catch (Exception ex)
            {
                ret.AddException(ex);
            }

            return ret;
        }

    }
}
