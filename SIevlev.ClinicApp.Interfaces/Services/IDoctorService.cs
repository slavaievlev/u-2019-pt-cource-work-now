using SIevlev.ClinicApp.Interfaces.BindingModel;

namespace SIevlev.ClinicApp.Interfaces.Services
{
    public interface IDoctorService
    {
        void CreateDoctor(DoctorBindingModel doctorBindingModel);

        void UpdateDoctor(DoctorBindingModel doctorBindingModel);

        void GetDoctor(int doctorId);

        void DeleteDoctor(int doctorId);
    }
}