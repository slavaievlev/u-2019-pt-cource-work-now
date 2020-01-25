namespace SIevlev.ClinicApp.Models
{
    public class PayStore
    {
        public int Id { get; set; }
        
        public int Sum { get; set; }
        
        public int OrderId { get; set; }
        
        public virtual Order Order { get; set; }
    }
}