using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CestnoSoftware
{
    public class FunctionResult<T> : CestnoSoftware.IFunctionResult<T>
    {
        #region WasSuccessful
        public bool WasSuccessful
        {
            get
            {
                return this.OperationStatus == FunctionResultOperationStatus.Success;
            }

        }
        #endregion

        #region Return Value
        private T _ReturnValue;
        public T ReturnValue
        {
            get
            {
                return this._ReturnValue;
            }
            set
            {
                this._OperationStatus = FunctionResultOperationStatus.Success;
                this._ReturnValue = value;
            }
        }
        #endregion

        #region Operation Status
        private FunctionResultOperationStatus _OperationStatus = FunctionResultOperationStatus.Error;
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
