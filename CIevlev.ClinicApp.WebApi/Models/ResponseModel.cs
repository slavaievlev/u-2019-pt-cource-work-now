namespace CIevlev.ClinicApp.WebApi.Models
{
    public class ResponseModel
    {
        public readonly object Value;

        public readonly string Description;

        public ResponseModel(object value, string description)
        {
            Value = value;
            Description = description;
        }

        public ResponseModel(object value)
        {
            Value = value;
            Description = null;
        }

        public ResponseModel(string description)
        {
            Description = description;
        }
    }
}