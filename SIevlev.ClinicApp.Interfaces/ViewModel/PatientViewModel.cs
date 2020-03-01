namespace SIevlev.ClinicApp.Interfaces.ViewModel
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        
        public string Login { get; set; }
        
        public string PatientStatus { get; set; }
        
        public string Phone { get; set; }
        
        public int Bonus { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public PatientViewModel()
        {
            
        }
        
        public PatientViewModel(int id, string login, string patientStatus, string phone, int bonus, string firstName, string lastName)
        {
            Id = id;
            Login = login;
            PatientStatus = patientStatus;
            Phone = phone;
            Bonus = bonus;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}