using SIevlev.ClinicApp.Models;

namespace SIevlev.ClinicApp.Interfaces.BindingModel
{
    public class PatientBindingModel
    {   
        public string Login { get; set; }
        
        public string Password { get; set; }
        
        public PatientStatus PatientStatus { get; set; }
        
        public string Phone { get; set; }
        
        public int Bonus { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
    }
}