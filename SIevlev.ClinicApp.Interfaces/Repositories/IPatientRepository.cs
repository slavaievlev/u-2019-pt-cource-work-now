using SIevlev.ClinicApp.Models;

namespace SIevlev.ClinicApp.Interfaces.Repositories
{
    public interface IPatientRepository
    {
        Patient ChangePatient(Patient patient);
    }
}