﻿namespace SIevlev.ClinicApp.Interfaces.ViewModel
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        
        public string Login { get; set; }
        
        public string Email { get; set; }
        
        public string Token { get; set; }

        public string PatientStatus { get; set; }
        
        public string Phone { get; set; }
        
        public int Bonus { get; set; }
        
        public int BonusPercent { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}