using System.Collections.Generic;
using SIevlev.ClinicApp.Models;

namespace SIevlev.ClinicApp.Interfaces.Repositories
{
    public interface IDoctorRepository
    {
        Doctor CreateDoctor(Doctor doctor);

        Doctor UpdateDoctor(Doctor doctor);

        Doctor GetDoctor(int doctorId);

        List<Doctor> GetDoctors();

        void DeleteDoctor(int doctorId);
    }
}