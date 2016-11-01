using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CestnoSoftware
{
    public class FunctionResultMessageList : List<FunctionResultMessage>
    {
        public FunctionResultMessageList AddError(string message, bool isPublic = true)
        {
            this.Add(new FunctionResultMessage(message, FunctionResultMessageTypes.Error, isPublic));
            return this;
        }

        public FunctionResultMessageList AddError(Exception ex, bool isPublic = true)
        {
            var curEx = ex;
            while(curEx != null)
            {
                this.Add(new FunctionResultMessage(curEx.Message, FunctionResultMessageTypes.Error, isPublic));
                curEx = curEx.InnerException;
            }
            return this;
        }

        public FunctionResultMessageList AddSuccess(string message, bool isPublic = true)
        {
            this.Add(new FunctionResultMessage(message, FunctionResultMessageTypes.Success, isPublic));
            return this;
        }

        public FunctionResultMessageList AddWarning(string message, bool isPublic = true)
        {
            this.Add(new FunctionResultMessage(message, FunctionResultMessageTypes.Warning, isPublic));
            return this;
        }

        public FunctionResultMessageList AddValidation(string message, string fieldName, bool isPublic = true)
        {
            this.Add(new FunctionResultMessage(fieldName, message, FunctionResultMessageTypes.Validation, isPublic));
            return this;
        }

        public FunctionResultMessageList AddInfo(string message, bool isPublic = true)
        {
            this.Add(new FunctionResultMessage(message, FunctionResultMessageTypes.Info, isPublic));
            return this;
        }

        
        #region Has Messages

        public bool HasMessages
        {
            get
            {
                return this.Count > 0;
            }
        }
        #endregion

    }
}
