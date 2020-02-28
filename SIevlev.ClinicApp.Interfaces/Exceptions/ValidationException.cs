using System;

namespace SIevlev.ClinicApp.Interfaces.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
        }
    }
}