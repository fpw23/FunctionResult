using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CestnoSoftware
{
    public class FunctionResultMessage
    {
        #region Properties

        #region FieldName

        private string _FieldName = null;

        public string FieldName
        {
            get
            {
                return this._FieldName;
            }
            set
            {
                this._FieldName = value;
            }
        }

        #endregion

        #region Message

        private string _Message = null;

        public string Message
        {
            get
            {
                return this._Message;
            }
            set
            {
                this._Message = value;
            }
        }

        #endregion

        #region MessageType

        private FunctionResultMessageTypes _MessageType = FunctionResultMessageTypes.Undefined;

        public FunctionResultMessageTypes MessageType
        {
            get
            {
                return this._MessageType;
            }
            set
            {
                this._MessageType = value;
            }
        }

        #endregion

        #region Exception
        private Exception _Exception = null;
        public Exception Exception
        {
            get
            {
                return this._Exception;
            }
            set
            {
                this._Exception = value;
            }
        }
        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RulesEngineViolation"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public FunctionResultMessage(string message)
        {
            this._Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RulesEngineViolation"/> class.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="message">The message.</param>
        public FunctionResultMessage(string fieldName, string message)
        {
            this._FieldName = fieldName;
            this._Message = message;
            this._MessageType = FunctionResultMessageTypes.RuleError;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RulesEngineViolation"/> class.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="message">The message.</param>
        public FunctionResultMessage(string fieldName, string message, FunctionResultMessageTypes type)
        {
            this._FieldName = fieldName;
            this._Message = message;
            this._MessageType = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RulesEngineViolation"/> class.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="message">The message.</param>
        public FunctionResultMessage(string message, FunctionResultMessageTypes type)
        {
            this._Message = message;
            this._MessageType = type;
        }

        public FunctionResultMessage()
        {

        }

        #endregion

    }
}
