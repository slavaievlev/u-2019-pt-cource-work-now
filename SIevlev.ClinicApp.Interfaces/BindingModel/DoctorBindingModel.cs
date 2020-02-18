namespace SIevlev.ClinicApp.Interfaces.BindingModel
{
    public class DoctorBindingModel
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Description { get; set; }
        
        public int Price { get; set; }

        public DoctorBindingModel(int id, string firstName, string lastName, string description, int price)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Description = description;
            Price = price;
        }
    }
}