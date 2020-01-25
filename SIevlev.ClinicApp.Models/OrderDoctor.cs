namespace SIevlev.ClinicApp.Models
{
    public class OrderDoctor
    {
        public int Id { get; set; }
        
        public int OrderId { get; set; }
        
        public int DoctorId { get; set; }
        
        public virtual Order Order { get; set; }
        
        public virtual Doctor Doctor { get; set; }
    }
}