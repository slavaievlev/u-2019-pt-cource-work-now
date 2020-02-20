using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using SIevlev.ClinicApp.Interfaces.WebModels;

namespace CIevlev.ClinicApp.DesktopClient.Helpers
{
    public static class ResponseModelHelper
    {
        public static List<T> GetResultAsList<T>(ResponseModel responseModel)
        {
            return ((JArray) responseModel.Value).ToObject<List<T>>();
        }
    }
}