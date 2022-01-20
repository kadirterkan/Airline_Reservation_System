using System;
using System.Web.Caching;

namespace Control.Common
{
    public class MessageTemplate
    {
        private string _message;
        private string _value;

        public string Message
        {
            get => _message;
            set => _message = value;
        }

        public string Value
        {
            get => _value;
            set => _value = value;
        }
    }
}