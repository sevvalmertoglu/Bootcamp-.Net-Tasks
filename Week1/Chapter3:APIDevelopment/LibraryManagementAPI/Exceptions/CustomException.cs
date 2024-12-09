namespace LibraryManagementAPI.Exceptions
{
    public class CustomException : Exception
    {
        public string ErrorCode { get; set; }

        public CustomException(string message, string errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }

    public class NotFoundException : CustomException
    {
        public NotFoundException(string message) : base(message, "NOT_FOUND") { }
    }

    public class ValidationException : CustomException
    {
        public ValidationException(string message) : base(message, "VALIDATION_ERROR") { }
    }
}
