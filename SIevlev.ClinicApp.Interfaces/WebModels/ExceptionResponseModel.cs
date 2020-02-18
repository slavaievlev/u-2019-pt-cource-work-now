namespace SIevlev.ClinicApp.Interfaces.WebModels
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