using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CestnoSoftware
{
    public class FunctionResultExtraData : Dictionary<string, object>
    {
        public void AddBool(string key, bool value)
        {
            this.Add(key, value);
        }

        public void AddDate(string key, DateTime value)
        {
            this.Add(key, value);
        }

        public void AddInt(string key, int value)
        {
            this.Add(key, value);
        }

        public void AddString(string key, string value)
        {
            this.Add(key, value);
        }

        public bool? GetBool(string key)
        {
            bool? ret = null;
            if (this.ContainsKey(key))
            {
                object data = this[key];
                bool temp = false;
                if (bool.TryParse(data.ToString(), out temp))
                {
                    ret = temp;
                }

            }
            return ret;
        }

        public DateTime? GetDate(string key)
        {
            DateTime? ret = null;
            if (this.ContainsKey(key))
            {
                object data = this[key];
                DateTime temp = DateTime.Now;
                if (DateTime.TryParse(data.ToString(), out temp))
                {
                    ret = temp;
                }
            }
            return ret;
        }

        public int? GetInt(string key)
        {
            int? ret = null;
            if (this.ContainsKey(key))
            {
                object data = this[key];
                int temp = 0;
                if (int.TryParse(data.ToString(), out temp))
                {
                    ret = temp;
                }
            }
            return ret;
        }

        public string GetString(string key)
        {
            if (this.ContainsKey(key))
            {
                object data = this[key];
                try
                {
                    return (string)data;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
