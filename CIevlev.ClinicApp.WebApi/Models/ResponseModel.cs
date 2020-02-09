namespace CIevlev.ClinicApp.WebApi.Models
{
    public class ResponseModel
    {
        private readonly object _value;

        private readonly string _description;

        public ResponseModel(object value, string description)
        {
            _value = value;
            _description = description;
        }

        public ResponseModel(object value)
        {
            _value = value;
            _description = null;
        }

        public ResponseModel(string description)
        {
            _description = description;
        }
    }
}