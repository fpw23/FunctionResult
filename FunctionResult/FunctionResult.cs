using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CestnoSoftware
{
    public static class FunctionResult
    {
        public static FunctionResult<T> Call<T>(Func<T> work)
        {
            FunctionResult<T> ret = new FunctionResult<T>();

            try
            {
                ret.ReturnValue = work();
            }
            catch (Exception ex)
            {
                ret.AddException(ex);
            }

            return ret;
        }
    }

    public class FunctionResult<T> : CestnoSoftware.IFunctionResult<T>
    {
        #region WasSuccessful
        private bool _checkedWasSuccessful = false;
        public bool WasSuccessful
        {
            get
            {
                this._checkedWasSuccessful = true;
                if (this.OperationStatus == FunctionResultOperationStatus.Success || this.OperationStatus == FunctionResultOperationStatus.SuccessWarnings)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        #endregion

        #region Return Value
        private T _ReturnValue;
        public T ReturnValue
        {
            get
            {
                if (!this._checkedWasSuccessful)
                {
                    throw new FunctionResultUncheckedException("You tried to use a function result value without checking if the action was successful! You must check for success before accessing the return value property!");
                }
                return this._ReturnValue;
            }
            set
            {
                if (this._ReturnValue is FunctionResultVoid)
                {
                    throw new FunctionResultUncheckedException("You tried to set the return value for a funtion result with a void type! This is not allowed, please change the type and trying again!");
                }
                this._OperationStatus = FunctionResultOperationStatus.Success;
                this._ReturnValue = value;
            }
        }
        #endregion

        #region Operation Status
        private FunctionResultOperationStatus _OperationStatus = FunctionResultOperationStatus.FailureExceptions;
        public FunctionResultOperationStatus OperationStatus
        {
            get
            {
                return this._OperationStatus;
            }
            set
            {
                this._OperationStatus = value;
            }
        }
        #endregion

        #region Add Exception

        public void AddException(string message)
        {
            FunctionResultMessage exMessage = new FunctionResultMessage(message, FunctionResultMessageTypes.Error)
            {
                Exception = new Exception(message)
            };
            this.Messages.Add(exMessage);
            this.OperationStatus = FunctionResultOperationStatus.FailureExceptions;
        }

        public void AddException(Exception ex)
        {
            Exception currentEx = ex;
            while (currentEx != null)
            {
                FunctionResultMessage exMessage = new FunctionResultMessage(currentEx.Message, FunctionResultMessageTypes.Error)
                {
                    Exception = currentEx
                };
                this.Messages.Add(exMessage);
                currentEx = currentEx.InnerException;
            }
            this.OperationStatus = FunctionResultOperationStatus.FailureExceptions;
        }

        #endregion

        #region Messages
        private FunctionResultMessageList _Messages = new FunctionResultMessageList();
        public FunctionResultMessageList Messages
        {
            get
            {
                return this._Messages;
            }
            set
            {
                this._Messages = value;
            }
        }
        #endregion

        #region Extra Data
        private FunctionResultExtraData _ExtraData = new FunctionResultExtraData();
        public FunctionResultExtraData ExtraData
        {
            get
            {
                return this._ExtraData;
            }
        }
        #endregion


    }

}
