namespace CIevlev.ClinicApp.WebApi.Models
{
    public class ExceptionResponseModel
    {
        public readonly string Type;

        public readonly string Message;

        public ExceptionResponseModel(string type, string message)
        {
            Type = type;
            Message = message;
        }
    }
}