using System.ComponentModel.DataAnnotations.Schema;

namespace SIevlev.ClinicApp.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Description { get; set; }
        
        public int Price { get; set; }
        
        [ForeignKey("DoctorId")]
        public virtual OrderDoctor OrderDoctor { get; set; }
    }
}