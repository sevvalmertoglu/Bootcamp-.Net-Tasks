namespace LibraryManagementAPI.Models
{
    public class ErrorModel
    {
        public required string Message { get; set; }
        public required string Detail { get; set; }
        public required string Code { get; set; }
    }

}
