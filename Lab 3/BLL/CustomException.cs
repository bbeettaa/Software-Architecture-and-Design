using System;
using System.Runtime.Serialization;

namespace BLL
{
    [Serializable]
    internal class CustomException: System.Exception
    {
        public CustomException() { }

        public CustomException(string message) : base(message) { }

        public CustomException(string message, CustomException inner) : base(message, inner) { }

        protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}