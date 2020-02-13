namespace SIevlev.ClinicApp.Interfaces.ViewModel
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Description { get; set; }
        
        public int Price { get; set; }

        public DoctorViewModel()
        {
        }

        public DoctorViewModel(int id, string firstName, string lastName, string description, int price)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Description = description;
            Price = price;
        }
    }
}