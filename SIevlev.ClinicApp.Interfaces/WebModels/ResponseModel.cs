using Newtonsoft.Json;

namespace SIevlev.ClinicApp.Interfaces.WebModels
{
    public class ResponseModel
    {
        public readonly object Value;

        public readonly string Description;

        [JsonConstructor]
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