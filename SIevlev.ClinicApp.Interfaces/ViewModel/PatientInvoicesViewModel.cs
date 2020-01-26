using System;

namespace SIevlev.ClinicApp.Interfaces.ViewModel
{
    public class PatientInvoicesViewModel
    {
        public DateTime CreateDate { get; set; }
        
        public DateTime ImplementDate { get; set; }

        public int Price { get; set; }
        
        public int PatientId { get; set; }
        
        public string PatientFirstName { get; set; }
        
        public string PatientLastName { get; set; }

        public int DoctorId { get; set; }
        
        public string DoctorFirstName { get; set; }
        
        public string DoctorLastName { get; set; }
    }
}