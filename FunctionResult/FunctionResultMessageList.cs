using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CestnoSoftware
{
    public class FunctionResultMessageList : List<FunctionResultMessage>
    {
        public FunctionResultMessageList AddMessageError(string message)
        {
            this.Add(new FunctionResultMessage(message, FunctionResultMessageTypes.Error));
            return this;
        }

        public FunctionResultMessageList AddMessageSuccess(string message)
        {
            this.Add(new FunctionResultMessage(message, FunctionResultMessageTypes.Success));
            return this;
        }

        public FunctionResultMessageList AddMessageRuleError(string message)
        {
            this.Add(new FunctionResultMessage(message, FunctionResultMessageTypes.RuleError));
            return this;
        }

        public FunctionResultMessageList AddMessageRuleError(string message, string fieldName)
        {
            this.Add(new FunctionResultMessage(fieldName, message, FunctionResultMessageTypes.RuleError));
            return this;
        }

        public FunctionResultMessageList AddMessageRuleWarning(string message)
        {
            this.Add(new FunctionResultMessage(message, FunctionResultMessageTypes.RuleWarning));
            return this;
        }

        public FunctionResultMessageList AddMessageRuleWarning(string message, string fieldName)
        {
            this.Add(new FunctionResultMessage(fieldName, message, FunctionResultMessageTypes.RuleWarning));
            return this;
        }

        public FunctionResultMessageList AddMessage(string message)
        {
            this.Add(new FunctionResultMessage(message, FunctionResultMessageTypes.Undefined));
            return this;
        }

        public FunctionResultMessageList AddMessageWarning(string message)
        {
            this.Add(new FunctionResultMessage(message, FunctionResultMessageTypes.Warning));
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

        #region Get Messages

        public string GetMessages(List<FunctionResultMessageTypes> queryTypes, FunctionResultMessageDisplayTypes dispayType)
        {

            if (this.Where(c => queryTypes.Contains(c.MessageType)).Count() > 0)
            {
                StringBuilder sb = new StringBuilder();

                switch (dispayType)
                {
                    case FunctionResultMessageDisplayTypes.Text:

                        foreach (var message in this.Where(c => queryTypes.Contains(c.MessageType)))
                        {
                            sb.Append(message.Message);
                            sb.Append(Environment.NewLine);
                        }
                        break;

                    case FunctionResultMessageDisplayTypes.Html:
                        sb.Append("<ul>");

                        foreach (var message in this.Where(c => queryTypes.Contains(c.MessageType)))
                        {
                            sb.Append("<li>");
                            sb.Append(message.Message);
                            sb.Append("</li>");
                        }

                        sb.Append("</ul>");

                        break;
                }

                return sb.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion

        #region Get Messages As Text

        public string GetMessagesAsText()
        {
            return this.GetMessages(new List<FunctionResultMessageTypes>()
            {
                FunctionResultMessageTypes.Error,
                FunctionResultMessageTypes.RuleError,
                FunctionResultMessageTypes.RuleWarning,
                FunctionResultMessageTypes.Warning
            }, FunctionResultMessageDisplayTypes.Text);
        }
        #endregion

        #region Get Messages As Html
        public string GetMessagesAsHtml()
        {
            return this.GetMessages(new List<FunctionResultMessageTypes>()
            {
                FunctionResultMessageTypes.Error,
                FunctionResultMessageTypes.RuleError,
                FunctionResultMessageTypes.RuleWarning,
                FunctionResultMessageTypes.Warning
            }, FunctionResultMessageDisplayTypes.Html);
        }
        #endregion
    }
}
