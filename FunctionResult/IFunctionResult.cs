using System;
namespace CestnoSoftware
{
    public interface IFunctionResult<T>
    {
        FunctionResultExtraData ExtraData { get; }
        FunctionResultMessageList Messages { get; set; }
        FunctionResultOperationStatus OperationStatus { get; set; }
        T ReturnValue { get; set; }
        bool WasSuccessful { get; }
    }
}
