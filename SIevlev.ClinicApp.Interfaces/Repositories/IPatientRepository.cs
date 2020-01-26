using SIevlev.ClinicApp.Models;

namespace SIevlev.ClinicApp.Interfaces.Repositories
{
    public interface IPatientRepository
    {
        Patient UpdatePatient(Patient patient);

        Patient GetPatient(int patientId);
    }
}