using System;
using System.Collections.Generic;
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
        
        public DateTime? DeleteAt { get; set; }
        
        public bool? IsActive { get; set; }
        
        [ForeignKey("DoctorId")]
        public virtual List<OrderDoctor> OrderDoctor { get; set; }
    }
}