using System;

namespace SIevlev.ClinicApp.Interfaces.Exceptions
{
    public class PatientNotFoundException : Exception
    {
        public PatientNotFoundException(string message) : base(message)
        {
        }
    }
}