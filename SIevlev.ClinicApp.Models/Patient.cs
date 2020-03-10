using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIevlev.ClinicApp.Models
{
    public class Patient
    {
        public int Id { get; set; }
        
        public string Login { get; set; }
        
        public string Password { get; set; }
        
        public string Email { get; set; }
        
        public string Token { get; set; }
        
        public PatientStatus PatientStatus { get; set; }
        
        public string Phone { get; set; }
        
        [Description("Бонусный счет")]
        public int Bonus { get; set; }
        
        [Description("Процент начисления бонусов")]
        public int BonusPercent { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        [ForeignKey("PatientId")]
        public virtual List<Order> Orders { get; set; }
    }
}