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
                ret.Messages.AddError(ex);
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
                    ret.Messages.AddValidation("Parameter X is not an even number", "X");
                    ret.OperationStatus = FunctionResultOperationStatus.Error;
                    return ret;
                }

                mod = y % 2;

                if (mod > 0)
                {
                    ret.Messages.AddValidation("Parameter Y is not an even number", "Y");
                    ret.OperationStatus = FunctionResultOperationStatus.Error;
                    return ret;
                }

                ret.ReturnValue = x + y;
                ret.OperationStatus = FunctionResultOperationStatus.Success;

            }
            catch (Exception ex)
            {
                ret.Messages.AddError(ex, false);
                ret.Messages.AddError("Unexpected error adding two number");
                ret.OperationStatus = FunctionResultOperationStatus.Error;
            }

            return ret;
        }

        public IFunctionResult<int> DivideTwoNumbers(int x, int y)
        {
            var ret = new FunctionResult<int>();

            try
            {
                if (x == 0)
                {
                    ret.Messages.AddValidation("X can not be 0", "X");
                    ret.OperationStatus = FunctionResultOperationStatus.Error;
                    return ret;
                }

                if (y == 0)
                {
                    ret.Messages.AddValidation("Y can not be 0", "Y");
                    ret.OperationStatus = FunctionResultOperationStatus.Error;
                    return ret;
                }

                ret.ReturnValue = x / y;
                ret.OperationStatus = FunctionResultOperationStatus.Success;
            }
            catch (Exception ex)
            {
                ret.Messages.AddError(ex, false);
                ret.Messages.AddError("Unexpected error dividing two numbers");
                ret.OperationStatus = FunctionResultOperationStatus.Error;
            }

            return ret;
        }

    }
}
