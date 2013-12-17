using System;
namespace CestnoSoftware
{
    public interface IFunctionResult<T>
    {
        void AddException(Exception ex);
        void AddException(string message);
        FunctionResultExtraData ExtraData { get; }
        FunctionResultMessageList Messages { get; set; }
        FunctionResultOperationStatus OperationStatus { get; set; }
        T ReturnValue { get; set; }
        bool WasSuccessful { get; }
    }
}
