using System.Collections.Generic;
using SIevlev.ClinicApp.Models;

namespace SIevlev.ClinicApp.Interfaces.Repositories
{
    public interface IPatientRepository
    {
        Patient CreatePatient(Patient patient);
        
        Patient UpdatePatient(Patient patient);

        Patient GetPatient(int patientId);

        List<Patient> GetPatients();
    }
}