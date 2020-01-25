using SIevlev.ClinicApp.Models;

namespace SIevlev.ClinicApp.Interfaces.Repositories
{
    public interface IDoctorRepository
    {
        Doctor CreateDoctor(Doctor doctor);

        Doctor UpdateDoctor(Doctor doctor);

        Doctor GetDoctor(int doctorId);

        void DeleteDoctor(int doctorId);
    }
}