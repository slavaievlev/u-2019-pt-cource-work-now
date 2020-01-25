using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIevlev.ClinicApp.Models
{
    public class Patient
    {
        public int Id { get; set; }
        
        public string Login { get; set; }
        
        public string Password { get; set; }
        
        public PatientStatus PatientStatus { get; set; }
        
        public string Phone { get; set; }
        
        public int Bonus { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        [ForeignKey("PatientId")]
        public virtual List<Order> Orders { get; set; }
    }
}