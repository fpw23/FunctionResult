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

        #region Is Public
        private bool _IsPublic = true;
        public bool IsPublic
        {
            get
            {
                return this._IsPublic;
            }
            set
            {
                this._IsPublic = value;
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
        public FunctionResultMessage(string fieldName, string message, bool isPublic = true)
        {
            this._FieldName = fieldName;
            this._Message = message;
            this._MessageType = FunctionResultMessageTypes.Validation;
            this._IsPublic = isPublic;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RulesEngineViolation"/> class.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="message">The message.</param>
        public FunctionResultMessage(string fieldName, string message, FunctionResultMessageTypes type, bool isPublic = true)
        {
            this._FieldName = fieldName;
            this._Message = message;
            this._MessageType = type;
            this._IsPublic = isPublic;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RulesEngineViolation"/> class.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="message">The message.</param>
        public FunctionResultMessage(string message, FunctionResultMessageTypes type, bool isPublic = true)
        {
            this._Message = message;
            this._MessageType = type;
            this._IsPublic = isPublic;
        }

        public FunctionResultMessage()
        {

        }

        #endregion

    }
}
