


using System.Runtime.Serialization;

namespace BO;
public class Exceptions : Exception
{
    public class NotEnoughInStock : Exception
    {
        public NotEnoughInStock() : base() { }
        public NotEnoughInStock(string message) : base(message) { }

        override public string ToString() =>
        "No more of this product in stock";

    }
    public class DoesnotExistException : Exception
    {
        public DoesnotExistException() : base() { }
        public DoesnotExistException(string message) : base(message) { }
        public DoesnotExistException(string message, Exception innerException) : base(message, innerException) { }
        protected DoesnotExistException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        override public string ToString() =>
        "Doesn't Exist Exception: the object doesn't exist in the data layer";

    }
    public class ErrorDetailsException : Exception
    {
        public ErrorDetailsException() : base() { }
        public ErrorDetailsException(string message) : base(message) { }
        public ErrorDetailsException(string message, Exception innerException) : base(message, innerException) { }
        protected ErrorDetailsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        override public string ToString() =>
        "Error Details Exception: one or more of the details doesn't correct";

    }

    public class AddFailedExcaption : Exception
    {
        public AddFailedExcaption() : base() { }
        public AddFailedExcaption(string message) : base(message) { }
        public AddFailedExcaption(string message, Exception innerException) : base(message, innerException) { }
        protected AddFailedExcaption(SerializationInfo info, StreamingContext context) : base(info, context) { }
        override public string ToString() =>
        "Add Failed Excaption: adding the product failed due to duplicate product ID/abnormal catch/incorrect data";

    }

    public class AvailableException : Exception
    {
        public AvailableException() : base() { }
        public AvailableException(string message) : base(message) { }
        public AvailableException(string message, Exception innerException) : base(message, innerException) { }
        protected AvailableException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        override public string ToString() =>
        "The product is available on order";
    }
}

