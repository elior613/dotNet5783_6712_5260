

using System.Runtime.Serialization;

namespace DO
{
    [Serializable]
    public class DalConfigException : Exception
    {
        public DalConfigException(string msg) : base(msg) { }
        public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
    }

    public class ExistException : Exception
    {
        public ExistException():base(){}
        public ExistException(string message) : base(message) { }
        public ExistException(string message, Exception innerException) : base(message, innerException) { }
        protected ExistException (SerializationInfo info, StreamingContext context) : base(info, context) { }

        override public string ToString() =>
        "Exist Exception: the object already exist ";

    }
    public class DoesntExistException : Exception
    {
        public DoesntExistException():base(){}
        public DoesntExistException(string message) : base(message) { }
        public DoesntExistException(string message, Exception innerException) : base(message, innerException) { }
        protected DoesntExistException (SerializationInfo info, StreamingContext context) : base(info, context) { }
        override public string ToString()=> 
        "Doesn't Exist Exception: the object doesn't exist" ;

    }
}
