using System;
using SIevlev.ClinicApp.Interfaces.Enums;

namespace SIevlev.ClinicApp.Interfaces.BindingModel
{
    public class PatientInvoicesBindingModel
    {
        public int PatientId { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public DocumentType DocumentType { get; set; }
    }
}